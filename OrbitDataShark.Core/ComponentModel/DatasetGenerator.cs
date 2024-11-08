namespace OrbitDataShark.Core.ComponentModel
{
    internal class DatasetGenerator
    {
        public string Name { get; }
        public Dictionary<string, TableGenerator> TableGenerators { get; } = new();

        public DatasetGenerator(string name)
        {
            Name = name;
        }
    }
}