namespace OrbitDataShark.DataGen.Models
{
    public abstract class GeneratorDescriptor
    {
        protected Dictionary<string, object> _arguments = new();
        public IReadOnlyDictionary<string, object> Arguments => _arguments.AsReadOnly();
        public required string Name { get; set; }
        public void AddArgument(string name, object value)
        {
            _arguments.Add(name, value);
        }
        public object GetArgument(string name)
        {
            return _arguments[name];
        }
        public void RemoveArgument(string name)
        {
            _arguments.Remove(name);
        }
    }
}
