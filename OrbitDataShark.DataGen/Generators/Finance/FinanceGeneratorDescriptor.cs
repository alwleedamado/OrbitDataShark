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

        public FinanceType FinanceType
        {
            get => (FinanceType)_arguments["FinanceType"];
            set => _arguments["FinanceType"] = value;
        }

        public override string GeneratorName => "Finance";
    }
}
