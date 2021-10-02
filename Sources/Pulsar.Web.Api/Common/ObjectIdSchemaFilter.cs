using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Pulsar.Web.Api.Common
{
    public class ObjectIdSchemaFilter : ISchemaFilter
    {
        private readonly IEnumerable<string> objectIdIgnoreParameters = new[]
        {
            "Timestamp",
            "Machine",
            "Pid",
            "Increment",
            "CreationTime"
        };

        private readonly IEnumerable<XPathNavigator> xmlNavigators;

        public ObjectIdSchemaFilter(IEnumerable<string> filePaths)
        {
            xmlNavigators = filePaths != null
                ? filePaths.Select(x => new XPathDocument(x).CreateNavigator())
                : Array.Empty<XPathNavigator>();
        }

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(ObjectId))
            {
                schema.Type = "string";
                schema.Format = "24-digit hex string";
                schema.Example = new OpenApiString(ObjectId.Empty.ToString());
            }

            foreach (var item in schema.Properties)
            {
                if(item.Value.Reference != null && item.Value.Reference.Id == "MongoDB.Bson.ObjectId")
                {
                    item.Value.Type = "string";
                    item.Value.Format = "24-digit hex string";
                    item.Value.Example = new OpenApiString(ObjectId.Empty.ToString());
                    item.Value.Reference = null;
                    item.Value.Description = GetFieldDescription(item.Key, context);
                }
            }

        }

        private string GetFieldDescription(string idName, SchemaFilterContext context)
        {
            var classProp = context.Type.GetProperties().FirstOrDefault(x => x.Name.ToLowerInvariant() == idName.ToLowerInvariant());
            var typeAttr = classProp != null
                ? (DescriptionAttribute)classProp.GetCustomAttribute<DescriptionAttribute>()
                : null;
            if (typeAttr != null)
                return typeAttr?.Description;

            if (classProp != null)
                foreach (var xmlNavigator in xmlNavigators)
                {
                    var propertyMemberName = XmlCommentsNodeNameHelper.GetMemberNameForFieldOrProperty(classProp);
                    var propertySummaryNode = xmlNavigator.SelectSingleNode($"/doc/members/member[@name='{propertyMemberName}']/summary");
                    if (propertySummaryNode != null)
                        return XmlCommentsTextHelper.Humanize(propertySummaryNode.InnerXml);
                }

            return null;
        }
    }
}
