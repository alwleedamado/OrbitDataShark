namespace OrbitDataShark.Core.ComponentModel
{
    public class Dataset
    {
        public string Name { get; set; }
        public List<Table> Tables { get; } = new List<Table>();

        public Dataset(string name)
        {
            Name = name;
        }
    }
}
