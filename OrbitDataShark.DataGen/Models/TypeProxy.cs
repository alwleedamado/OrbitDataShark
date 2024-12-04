using System.Reflection;

namespace OrbitDataShark.DataGen.Models
{
    public class TypeProxy
    {
        public string TypeName { get; }
        public Type Type { get; }
        public TypeProxy(string typeName, Type type)
        {
            TypeName = typeName;
            Type = type;
        }

        public object CreateInstance()
        {
            return Activator.CreateInstance(Type)!;
        }
        public object? GetValue(object target, string propertyName)
        {
            PropertyInfo info = Type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public)
                ?? throw new InvalidOperationException($"Property {propertyName} does not exist.");
            MethodInfo getMethod = info.GetMethod
                ?? throw new AccessViolationException($"Can not access property {propertyName} GetMethod");
            return getMethod.Invoke(target, Array.Empty<object>());
        }
        public void SetValue(object target, string propertyName, object value)
        {
            PropertyInfo info = Type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public)
                ?? throw new InvalidOperationException($"Property {propertyName} does not exist.");
            MethodInfo setMethod = info.SetMethod
                ?? throw new AccessViolationException($"Can not access property {propertyName} SetMethod");
            setMethod.Invoke(target,new object?[] { value });
        }
        public IEnumerable<object?> IterateProperties(object target)
        {
            PropertyInfo[] info = Type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo property in info)
            {
                yield return GetValue(target, property.Name);
            }
        }
        public IEnumerable<PropertyInfo> GetProperties()
        {
            PropertyInfo[] info = Type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo property in info)
            {
                yield return property;
            }
        }
        public object? CallMethod(object target, string methodName, BindingFlags flags, params object[] args)
        {
            MethodInfo method = Type.GetMethod(methodName, flags) ??
                throw new MethodAccessException(methodName);
            return method.Invoke(target, args);
        }
    }
}
