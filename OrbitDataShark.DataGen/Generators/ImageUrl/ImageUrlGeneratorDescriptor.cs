using OrbitDataShark.DataGen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitDataShark.DataGen.Generators.ImageUrl
{
    public class ImageUrlGeneratorDescriptor : GeneratorDescriptor
    {
        public ImageUrlSource Source
        {
            get => (ImageUrlSource)_arguments["Source"];
            set => _arguments["Source"] = value;
        }
        public required int Width { get; set; }
        public required int Height { get; set; }
        public override string GeneratorName => "ImageUrl";
    }
}
