using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bogus;

using OrbitDataShark.Core.ComponentModel;

namespace OrbitDataShark.Core.DataGen.Generators.Name
{
    public class NameGenerator : Generator
    {
        
        public NameGenerator(GeneratorDescriptor descriptor) : base(descriptor)
        {
        }
        public override Func<Faker, T, R> Generate<T, R>()
        {
            NameGeneratorDescriptor descriptor = (NameGeneratorDescriptor)base.Descriptor;

            return descriptor.NameType switch
            {
                NameType.FullName => (Faker f, T owner) => Convert<R>(f.Name.FullName()),
                NameType.FirstName => (Faker f, T owner) => Convert<R>(f.Name.FirstName()),
                NameType.LastName => (Faker f, T owner) => Convert<R>(f.Name.LastName()),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
