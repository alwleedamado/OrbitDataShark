using Bogus;
using OrbitDataShark.DataGen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitDataShark.DataGen.Generators.Address
{
    public class AddressGenerator : Generator
    {
        public AddressGenerator(GeneratorDescriptor descriptor) : base(descriptor)
        {
        }

        public override Func<Faker, T, R> Generate<T, R>()
        {
            var descriptor = (AddressGeneratorDescriptor)base.Descriptor;

            return descriptor.AddressType switch
            {
                AddressType.Country => (Faker f, T owner) => Convert<R>(f.Address.Country()),
                AddressType.State => (Faker f, T owner) => Convert<R>(f.Address.State()),
                AddressType.StateAbbrviation => (Faker f, T owner) => Convert<R>(f.Address.StateAbbr()),
                AddressType.City => (Faker f, T owner) => Convert<R>(f.Address.City()),
                AddressType.BuildingNumber => (Faker f, T owner) => Convert<R>(f.Address.BuildingNumber()),
                AddressType.FullAddress => (Faker f, T owner) => Convert<R>(f.Address.FullAddress()),
                AddressType.SecondaryAddress => (Faker f, T owner) => Convert<R>(f.Address.SecondaryAddress()),
                AddressType.Latitude => (Faker f, T owner) => Convert<R>(f.Address.Latitude()),
                AddressType.Longitude => (Faker f, T owner) => Convert<R>(f.Address.Longitude()),
                AddressType.Direction => (Faker f, T owner) => Convert<R>(f.Address.Direction()),
                AddressType.CardinalDirection => (Faker f, T owner) => Convert<R>(f.Address.CardinalDirection()),
                AddressType.OrdinalDirection => (Faker f, T owner) => Convert<R>(f.Address.OrdinalDirection()),
                AddressType.ZipCode => (Faker f, T owner) => Convert<R>(f.Address.ZipCode()),

                _ => throw new InvalidOperationException($"This paramater is not supported")
            };
        }
    }
}
