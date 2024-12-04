namespace OrbitDataShark.DataGen.Models
{
    public class ConcreteType
    {
        public string Name { get; }
        public Type Type { get; }
        public ConcreteType(string name, Type type)
        {
            Name = name;
            Type = type;
        }
    }
}
