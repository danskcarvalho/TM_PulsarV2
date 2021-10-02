using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using Pulsar.Contracts.Atendimentos.Commands;
using Pulsar.Infrastructure;
using Pulsar.Web.Api.Common;
using Pulsar.Web.Api.Filters;
using Pulsar.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pulsar.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            PulsarContainer.Install(services);
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(RefreshJwtTokenFilter));
                options.Filters.Add(typeof(HandleAuthorizationFilter));
                options.ModelBinderProviders.Insert(0, new ObjectIdModelBinderProvider());
                options.ModelMetadataDetailsProviders.Add(
                    new BindingSourceMetadataProvider(typeof(ObjectId), BindingSource.Special));
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new ObjectIdJsonConverter());
                var enumConverter = new JsonStringEnumConverter();
                options.JsonSerializerOptions.Converters.Add(enumConverter);
            }).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CriarAtendimentoCommand>());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "Pulsar.Web.Api", Version = "v2" });
                c.CustomSchemaIds(x => x.FullName);
                c.MapType<ObjectId>(() => new OpenApiSchema()
                {
                    Type = "string",
                    Example = new OpenApiString("000000000000000000000000")
                });

                var swaggerFiles = new string[] { $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml",
                    "Pulsar.Contracts.xml" }
                  .Select(fileName => System.IO.Path.Combine(System.AppContext.BaseDirectory, fileName))
                  .Where(filePath => System.IO.File.Exists(filePath));

                foreach (var filePath in swaggerFiles)
                    c.IncludeXmlComments(filePath);

                c.OperationFilter<ObjectIdOperationFilter>(swaggerFiles);
                c.SchemaFilter<ObjectIdSchemaFilter>(swaggerFiles);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Por favor, entre com o token JWT no seguinte formato Bearer \"token\" onde \"token\" deve ser substituído pelo token de acesso.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });

            var jwtSettings = Configuration.GetSection("JWT")?.Get<JWTConfigurationSection>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.SecurityKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    RequireExpirationTime = true
                };

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "Pulsar.Web.Api v2"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
