using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using OrbitDataShark.Core.ComponentModel;

namespace OrbitDataShark.Core.DataGen
{
    public static class DataGetExtensions
    {
        public static IEnumerable<object?> EnumeratePropeties(this GeneratedType @this)
        {
            Type type = @this.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo property in properties) {
                var value = property?.GetMethod?.Invoke(@this, null);
                yield return value;
            }
        }

        public static object? ReadProperty(this GeneratedType @this, string propname)
        {
            Type type = @this.GetType();
            PropertyInfo? info = type.GetProperty(propname,BindingFlags.Instance | BindingFlags.Public);
            return info?.GetValue(@this, null);
        }

        
    }
}
