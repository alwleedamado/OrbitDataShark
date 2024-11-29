using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrbitDataShark.Core.DataGen.Generators.Name;

namespace OrbitDataShark.ViewModels.Generators
{
    internal class NameGeneratorViewModel : ViewModelBase
    {
        public readonly NameType[] NameTypeOptions = new NameType[] { NameType.FirstName, NameType.LastName };
    }
}
