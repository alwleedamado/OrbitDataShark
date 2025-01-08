namespace OrbitDataShark.DataGen.Models
{
    public class Dataset
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Table> Tables { get; } = new List<Table>();

        public Dataset(string name)
        {
            Name = name;
        }
    }
}
