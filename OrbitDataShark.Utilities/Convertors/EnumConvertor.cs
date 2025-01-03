using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrbitDataShark.Utilities.Convertors
{
    public static class EnumConvertor
    {
        public static string[] EnumToArray<T>() where T : Enum
        {
            return Enum.GetNames(typeof(T));
        }
    }
}
