using OrbitDataShark.DataGen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitDataShark.DataGen.Generators.Finance
{
    public class FinanceGeneratorDescriptor : GeneratorDescriptor
    {
        public FinanceGeneratorDescriptor(ClrType clrType = ClrType.String)
        {
            ClrType = clrType;
        }
        public ClrType ClrType { get; private set; }
        public FinanceType FinanceType
        {
            get => (FinanceType)_arguments["FinanceType"];
            set => _arguments["FinanceType"] = value;
        }
    }
}
