using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

using Bogus;

using OrbitDataShark.Core.ComponentModel;

namespace OrbitDataShark.Core.DataGen
{
    public class GenerationContext
    {
        private static readonly Dictionary<string, DatasetBuilder> _datasetBuilders = new();
        public Object? GenerateWholeDataset(Dataset dataset)
        {
            var builder = GetDatasetBuilder(dataset.Name);
            var datasetProxy = builder.BuildDataset(dataset);
            var datasetGenerator = DatasetGeneratorFactory.Create(dataset);
            var tables = datasetProxy.GetProperties().ToList();
            object result = datasetProxy.CreateInstance();

            foreach (var table in tables)
            {
                var tableGenerator = datasetGenerator.TableGenerators[table.Name];
                var creatorMethod = typeof(GenerationContext).GetMethod(nameof(RuleForTable), BindingFlags.Instance | BindingFlags.NonPublic);
                MethodInfo? methodInfo = creatorMethod?.MakeGenericMethod(new Type[] { table.PropertyType });
                var faker = methodInfo?.Invoke(this, new object?[] { tableGenerator, table.PropertyType });
                MethodInfo? genMethod = faker?.GetType().GetMethod("Generate", new Type[] { typeof(string) });
                var r = genMethod?.Invoke(faker, new object?[] { null })
                    ?? throw new Exception($"Failed to generate data for {table.Name}");
                datasetProxy.SetValue(result, table.Name, r);
            }
            return result;
        }
        public IEnumerable<object?> GenerateTable(Table table, int sampleCount = 1)
        {
            TableBuilder builder = new TableBuilder(table.Name);
            TypeBuilder typeBuilder = builder.Create(table);
            TableGenerator generator = TableGeneratorFactory.Create(table);
            MethodInfo? ruleForTable = typeof(GenerationContext).GetMethod(nameof(RuleForTable), BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo? genericMd = ruleForTable?.MakeGenericMethod(new Type[] { typeBuilder.CreateType() });
            object? faker = genericMd?.Invoke(this, new object?[] { generator, typeBuilder.CreateType() });
            MethodInfo? fakerGenerateMd = faker?.GetType().GetMethod("Generate", new Type[] { typeof(string) });
            for (int i = 0; i < sampleCount; i++)
            {
                yield return fakerGenerateMd?.Invoke(faker, new object?[] { null });
            }
        }

        private Faker<T> RuleFor<T, R>(Faker<T> faker, string propName, Generator generator) where T : class where R : class
        {
            return faker.RuleFor(propName, generator.Generate<T, R>());
        }
        private Faker<T>? RuleForTable<T>(TableGenerator tableGenerator, Type tableType) where T : class
        {
            var columns = tableType.GetProperties();
            Faker<T>? faker = new();
            MethodInfo? ruleForInfo = typeof(GenerationContext).GetMethod(nameof(RuleFor), BindingFlags.Instance | BindingFlags.NonPublic);
            for (var i = 0; i < columns.Length; i++)
            {
                string columnName = columns[i].Name;
                Generator generator = tableGenerator.ColumnGenerators[columnName];
                var generic = ruleForInfo?.MakeGenericMethod(new Type[] { typeof(T), columns[i].PropertyType });
                faker = (Faker<T>?)generic?.Invoke(this, new object[] { faker!, columnName, generator });
            }
            return faker;
        }
        private static DatasetBuilder GetDatasetBuilder(string name)
        {
            if (_datasetBuilders.TryGetValue(name, out DatasetBuilder? dataset))
                return dataset;

            DatasetBuilder builder = new DatasetBuilder();
            _datasetBuilders.Add(name, builder);
            return builder;
        }
    }
}
