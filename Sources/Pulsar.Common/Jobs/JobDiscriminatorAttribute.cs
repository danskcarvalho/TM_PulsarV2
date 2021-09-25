using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Jobs
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class JobDiscriminatorAttribute : Attribute
    {
        public string Discriminator { get; }

        public JobDiscriminatorAttribute(string discriminator)
        {
            this.Discriminator = discriminator;
        }
    }
}
