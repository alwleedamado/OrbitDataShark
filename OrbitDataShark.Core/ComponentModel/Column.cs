namespace OrbitDataShark.Core.ComponentModel
{
    public class Column
    {
        public required string Name { get; set; }
        public required ClrType ClrType { get; set; }
        public required GeneratorDescriptor GeneratorDescriptor { get; set; }
    }
}