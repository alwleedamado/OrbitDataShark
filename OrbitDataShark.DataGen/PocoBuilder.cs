using System.Reflection;
using System.Reflection.Emit;
using OrbitDataShark.DataGen.Models;

namespace OrbitDataShark.DataGen
{
    internal static class PocoBuilder
    {
        public static void DefineProperty(TypeBuilder type, string name, Type propType)
        {
            var field = type.DefineField($"_{name}", propType, FieldAttributes.Private);
            var prop = type.DefineProperty(name, PropertyAttributes.HasDefault, propType, null);
            var getAccessor = type.DefineMethod($"get_{name}",
                MethodAttributes.SpecialName | MethodAttributes.Public | MethodAttributes.HideBySig,
                propType, Type.EmptyTypes);
            var getMthodIL = getAccessor.GetILGenerator();
            getMthodIL.Emit(OpCodes.Ldarg_0);
            getMthodIL.Emit(OpCodes.Ldfld, field);
            getMthodIL.Emit(OpCodes.Ret);

            var setAccessor = type.DefineMethod($"set_{name}",
               MethodAttributes.SpecialName | MethodAttributes.Public | MethodAttributes.HideBySig,
               null, new Type[] { propType });
            var setMthodIL = setAccessor.GetILGenerator();
            setMthodIL.Emit(OpCodes.Ldarg_0);
            setMthodIL.Emit(OpCodes.Ldarg_1);
            setMthodIL.Emit(OpCodes.Stfld, field);
            setMthodIL.Emit(OpCodes.Ret);
            prop.SetGetMethod(getAccessor);
            prop.SetSetMethod(setAccessor);
        }
        public static void DefineProperty(TypeBuilder type, string name, ClrType clrType)
        {
            DefineProperty(type, name, GetClTypeType(clrType));
        }
        public static Type GetClTypeType(ClrType clrType)
        {
            switch (clrType)
            {
                case ClrType.Int:
                    return typeof(int);
                case ClrType.Double:
                    return typeof(double);
                case ClrType.Decimal:
                    return typeof(decimal);
                case ClrType.String:
                    return typeof(string);
                case ClrType.DateTime:
                    return typeof(DateTime);
                case ClrType.DateOnly:
                    return typeof(DateOnly);
                case ClrType.TimeOnly:
                    return typeof(TimeOnly);
                default:
                    throw new ArgumentException("Unsportted type");
            }
        }

    }
}
