using Bogus;
using OrbitDataShark.DataGen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitDataShark.DataGen.Generators.Company
{
    public class CompanyGenerator : Generator
    {
        public CompanyGenerator(GeneratorDescriptor descriptor) : base(descriptor)
        {
        }

        public override Func<Faker, T, R> Generate<T, R>()
        {
            var descriptor = (CompanyDescriptor)base.Descriptor;

            return descriptor.CompanyOptions switch
            {
                CompanyOptions.CompanyName => (Faker f, T owner) => Convert<R>(f.Company.CompanyName()),
                CompanyOptions.CompanySuffix => (Faker f, T owner) => Convert<R>(f.Company.CompanySuffix()),

                _ => throw new InvalidOperationException($"This paramater is not supported")
            };
        }
    }
}
