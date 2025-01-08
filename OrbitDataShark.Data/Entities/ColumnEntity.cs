namespace OrbitDataShark.Data.Entities;

public class ColumnEntity : EntityBase
{
    public string Name { get; set; }
    public List<GeneratorEntity> Generators { get; set; } = new();
}
