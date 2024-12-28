using OrbitDataShark.DataGen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitDataShark.DataGen.Generators.Company
{
    public class CompanyDescriptor : GeneratorDescriptor
    {
        public CompanyOptions CompanyOptions
        {
            get => (CompanyOptions)_arguments["CompanyOptions"];
            set => _arguments["CompanyOptions"] = value;
        }

        public override string GeneratorName => "Company";
    }
}
