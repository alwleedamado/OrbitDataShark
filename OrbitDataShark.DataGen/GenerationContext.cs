using System.Reflection;
using System.Reflection.Emit;
using Bogus;
using OrbitDataShark.DataGen.Models;

namespace OrbitDataShark.DataGen
{
    public class GenerationContext
    {
        private static readonly Dictionary<string, DatasetBuilder> _datasetBuilders = new();
        public object? GenerateWholeDataset(Dataset dataset)
        {
            var builder = GetDatasetBuilder(dataset.Name);
            var datasetProxy = builder.BuildDataset(dataset);
            var datasetGenerator = DatasetGeneratorFactory.Create(dataset);
            var tables = datasetProxy.GetProperties().ToList();
            var result = new DatasetGenerationResult(dataset.Name);

            foreach (var table in tables)
            {
                var tableGenerator = datasetGenerator.TableGenerators[table.Name];
                var creatorMethod = typeof(GenerationContext).GetMethod(nameof(RuleForTable), BindingFlags.Instance | BindingFlags.NonPublic);
                var methodInfo = creatorMethod?.MakeGenericMethod(new Type[] { table.PropertyType });
                var faker = methodInfo?.Invoke(this, new object?[] { tableGenerator, table.PropertyType });
                var genMethod = faker?.GetType().GetMethod("Generate", new Type[] { typeof(string) });
                var r = genMethod?.Invoke(faker, new object?[] { null })
                    ?? throw new Exception($"Failed to generate data for {table.Name}");
                result.Tables.Add(new TableGenerationResult(table.Name, new ObjectProxy(r)));
            }
            return result;
        }
        public IEnumerable<object?> GenerateTable(Table table, int sampleCount = 1)
        {
            var builder = new TableBuilder(table.Name);
            var typeBuilder = builder.Create(table);
            var generator = TableGeneratorFactory.Create(table);
            var ruleForTable = typeof(GenerationContext).GetMethod(nameof(RuleForTable), BindingFlags.Instance | BindingFlags.NonPublic);
            var genericMd = ruleForTable?.MakeGenericMethod(new Type[] { typeBuilder.CreateType() });
            var faker = genericMd?.Invoke(this, new object?[] { generator, typeBuilder.CreateType() });
            var fakerGenerateMd = faker?.GetType().GetMethod("Generate", new Type[] { typeof(string) });
            for (var i = 0; i < sampleCount; i++)
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
            var ruleForInfo = typeof(GenerationContext).GetMethod(nameof(RuleFor), BindingFlags.Instance | BindingFlags.NonPublic);
            for (var i = 0; i < columns.Length; i++)
            {
                var columnName = columns[i].Name;
                var generator = tableGenerator.ColumnGenerators[columnName];
                var generic = ruleForInfo?.MakeGenericMethod(new Type[] { typeof(T), columns[i].PropertyType });
                faker = (Faker<T>?)generic?.Invoke(this, new object[] { faker!, columnName, generator });
            }
            return faker;
        }
        private static DatasetBuilder GetDatasetBuilder(string name)
        {
            if (_datasetBuilders.TryGetValue(name, out var dataset))
                return dataset;

            var builder = new DatasetBuilder();
            _datasetBuilders.Add(name, builder);
            return builder;
        }
    }
}
