using Bogus;
using OrbitDataShark.DataGen.Models;

namespace OrbitDataShark.DataGen.Generators.Name
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
                NameType.FullName => (Faker f, T owner) => Convert<R>(f.Name.FullName(ConvrtGender(descriptor.Gender))),
                NameType.FirstName => (Faker f, T owner) => Convert<R>(f.Name.FirstName(ConvrtGender(descriptor.Gender))),
                NameType.LastName => (Faker f, T owner) => Convert<R>(f.Name.LastName(ConvrtGender(descriptor.Gender))),
                NameType.Prefix => (Faker f, T owner) => Convert<R>(f.Name.Prefix(ConvrtGender(descriptor.Gender))),
                NameType.JobArea => (Faker f, T owner) => Convert<R>(f.Name.JobArea()),
                NameType.JobDescription => (Faker f, T owner) => Convert<R>(f.Name.JobDescriptor()),
                NameType.JobTitle => (Faker f, T owner) => Convert<R>(f.Name.JobTitle()),
                NameType.JobType => (Faker f, T owner) => Convert<R>(f.Name.JobType()),
                 _ => throw new NotImplementedException(),
            };
        }
        private Bogus.DataSets.Name.Gender ConvrtGender(Gender gender)
        {
            return gender == Gender.Male ? Bogus.DataSets.Name.Gender.Male : Bogus.DataSets.Name.Gender.Female;
        }
    }
}
