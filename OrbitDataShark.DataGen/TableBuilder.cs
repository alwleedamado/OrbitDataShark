using System.Reflection;
using System.Reflection.Emit;
using OrbitDataShark.DataGen.Models;

namespace OrbitDataShark.DataGen
{
    internal class TableBuilder
    {
        public string TypeName { get; }
        public TableBuilder(string typeName)
        {
            TypeName = typeName;
        }
        public TypeBuilder Create(Table table)
        {
            return CreateColumns(table);
        }

        private TypeBuilder CreateColumns(Table table)
        {
            TypeBuilder type = CustomAssembly.Instance.DefineType(TypeName, TypeAttributes.Public);
            foreach (var column in table.Columns)
            {
                PocoBuilder.DefineProperty(type, column.Name, column.ClrType);
            }
            return type;
        }
    }
}
