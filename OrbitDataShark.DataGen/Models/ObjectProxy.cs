namespace OrbitDataShark.DataGen.Models
{
    public class ObjectProxy
    {
        public object ContainedObject { get; }
        public ObjectProxy(object obj)
        {
            ContainedObject = obj;
        }
    }
}
