using OrbitDataShark.DataGen.Models;
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global

namespace OrbitDataShark.DataGen.Generators.Name
{
    public class NameGeneratorDescriptor : GeneratorDescriptor
    {
        public Gender Gender
        {
            get => (Gender)Arguments["Gender"];
            set => _arguments["Gender"] = value;
        }
        public NameType NameType
        {
            get => (NameType)Arguments["NameType"];
            set => _arguments["NameType"] = value;
        }

        public override string GeneratorName => "Name";
    }
}
