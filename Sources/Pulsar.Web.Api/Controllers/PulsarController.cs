using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using Pulsar.Common.Cqrs;
using Pulsar.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Web.Api.Controllers
{
    public class PulsarController : ControllerBase
    {
        public PulsarController(IConfiguration configuration, ICommandBus commandBus, IRequestBus requestBus) : base()
        {
            this.CommandBus = commandBus;
            this.RequestBus = requestBus;
            this.Configuration = configuration;
        }
        protected ICommandBus CommandBus { get; }
        protected IRequestBus RequestBus { get; }
        protected IConfiguration Configuration { get; }
        [NonAction]
        public string CreateToken(UserClaims claims)
        {
            var jwtSettings = Configuration.GetSection("JWT")?.Get<JWTConfigurationSection>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.SecurityKey);
            var tokenHandler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, claims.Id.ToString()),
                    new Claim(ClaimTypes.Role, claims.Role)
                }),
                Audience = jwtSettings.Audience,
                Issuer = jwtSettings.Issuer,
                Expires = DateTime.UtcNow.Add(jwtSettings.ExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }

        private CurrentUser _currentUser = null;
        public CurrentUser CurrentUser
        {
            get
            {
                if (_currentUser != null)
                    return _currentUser;

                try
                {
                    if (User == null || User.Identity == null || User.Identity.Name == null)
                        return null;
                    _currentUser = new CurrentUser()
                    {
                        Id = ObjectId.Parse(User.Identity.Name),
                        EstabelecimentoId = GetEstabelecimentoId(User.Claims.First(c => c.Type == ClaimTypes.Role)),
                        RedeEstabelecimentoId = GetRedeEstabelecimentoId(User.Claims.First(c => c.Type == ClaimTypes.Role))
                    };
                    return _currentUser;
                }
                catch
                {
                    return null;
                }
            }
        }

        private ObjectId? GetEstabelecimentoId(Claim claim)
        {
            var parts = claim.Value.Split('/', StringSplitOptions.RemoveEmptyEntries);
            if (parts[1] == "_")
                return null;
            else
                return ObjectId.Parse(parts[1]);
        }

        private ObjectId? GetRedeEstabelecimentoId(Claim claim)
        {
            var parts = claim.Value.Split('/', StringSplitOptions.RemoveEmptyEntries);
            if (parts[0] == "_")
                return null;
            else
                return ObjectId.Parse(parts[0]);
        }
    }
}
