using OrbitDataShark.Core.ComponentModel;
using OrbitDataShark.Core.DataGen;
using OrbitDataShark.Core.DataGen.Generators.Name;

using ReflectionUtilities;
namespace TestApp
{
    internal class Employee
    {
        public string Name { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Dataset dataset = new Dataset("Hr");
            Employee employee = new Employee();

            Table table = new Table("Employee");
            var d = new NameGeneratorDescriptor() {Name="Name", Gender = Gender.Female, NameType = NameType.FullName };
            table.AddColumn(new Column {ClrType=ClrType.String, Name = "Name", GeneratorDescriptor = d });

            var d3 = new NameGeneratorDescriptor() {Name = "Name", Gender = Gender.Male, NameType = NameType.LastName };
            table.AddColumn(new Column {ClrType=ClrType.String, Name = "LastName", GeneratorDescriptor = d3 });
            dataset.Tables.Add(table);
            GenerationContext ctx = new GenerationContext();
          //  var resutl = ctx.GenerateTable(table, 1000);
 
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(baseDirectory);
        }
    }
}
