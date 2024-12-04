namespace OrbitDataShark.DataGen.Models
{
    public class Table
    {
        public string Name { get; }
        private List<Column> _columns { get; set; } = new();
        public IReadOnlyCollection<Column> Columns => _columns.AsReadOnly();
        public Table(string name)
        {
            Name = name;
        }

        public void AddColumn(Column column) { _columns.Add(column); }
        public void RemoveColumn(Column column) { _columns.Remove(column); }
    }
}
