namespace OrbitDataShark.Data.Entities;

public class TableEntity : EntityBase
{
    public string Name { get; set; }
    public List<ColumnEntity> Columns { get; set; } = new();
}
