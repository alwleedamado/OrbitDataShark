using OrbitDataShark.Core.ComponentModel;

namespace OrbitDataShark.Core.DataGen
{
    public class DatasetBuilder
    {
        private static readonly Dictionary<string, TypeProxy> _datasetsCache = new();
        private readonly Dictionary<string, TypeProxy> _tablesCache = new();

        public TypeProxy BuildDataset(Dataset dataset)
        {
            if (_datasetsCache.TryGetValue(dataset.Name, out TypeProxy? value))
            {
                return value;
            }
            var builder = CustomAssembly.GetInstance().DefineType(dataset.Name, System.Reflection.TypeAttributes.Public);
            foreach (var table in dataset.Tables)
            {
                var tableBuilder = new TableBuilder(table.Name);
                var tableType = tableBuilder.Create(table);
                Type tablePropType = tableType.CreateType();
                _tablesCache.Add(table.Name, new TypeProxy(table.Name, tablePropType));
                PocoBuilder.DefineProperty(builder, tableBuilder.TypeName, tablePropType);
            }
            var createdType = new TypeProxy(dataset.Name, builder.CreateType());
            _datasetsCache[dataset.Name] = createdType;
            return createdType;
        }

        public TypeProxy BuildSingleTable(string datasetName, Table table)
        {
            if (_tablesCache.TryGetValue(table.Name, out TypeProxy? value)) { return value; }

            var tableBuilder = new TableBuilder(table.Name);
            var type = tableBuilder.Create(table);
            var concretType = new TypeProxy(table.Name, type.CreateType());
            _tablesCache.Add(table.Name, concretType);
            return concretType;
        }
    }
}
