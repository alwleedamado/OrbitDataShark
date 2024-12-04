using Bogus;
// ReSharper disable PublicConstructorInAbstractClass

namespace OrbitDataShark.DataGen.Models
{
    public abstract class Generator
    {
        public GeneratorDescriptor Descriptor { get; }

        public Generator(GeneratorDescriptor descriptor) => Descriptor = descriptor;
        public static T Convert<T>(object value) => (T)value;

        public abstract Func<Faker, T, R> Generate<T, R>() where T : class;
    }
}
