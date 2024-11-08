using Bogus;
namespace OrbitDataShark.Core.ComponentModel
{
    public abstract class Generator
    {
        public GeneratorDescriptor Descriptor { get; }

        public Generator(GeneratorDescriptor descriptor) => Descriptor = descriptor;
        public static T Convert<T>(object value) => (T)value;

        public abstract Func<Faker, T, R> Generate<T, R>() where T : class;
    }
}
