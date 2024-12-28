using Bogus;
using OrbitDataShark.DataGen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitDataShark.DataGen.Generators.ImageUrl
{
    public class ImageUrlGenerator : Generator
    {
        public ImageUrlGenerator(GeneratorDescriptor descriptor) : base(descriptor)
        {
        }

        public override Func<Faker, T, R> Generate<T, R>()
        {
            var descriptor = (ImageUrlGeneratorDescriptor)base.Descriptor;

            return descriptor.Source switch
            {
                ImageUrlSource.Placeholder => (Faker f, T owner) => Convert<R>(f.Image.PlaceholderUrl(descriptor.Width, descriptor.Height)),
                ImageUrlSource.PlaceImg => (Faker f, T owner) => Convert<R>(f.Image.PlaceImgUrl(descriptor.Width, descriptor.Height)),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
