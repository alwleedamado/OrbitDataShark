namespace OrbitDataShark.Core.ComponentModel
{
    internal class TableGenerator
    {
        public string Name { get; }
        public Dictionary<string, Generator> ColumnGenerators { get; } = new();
        public TableGenerator(string tableName)
        {
            Name = tableName;
        }
    }
}
