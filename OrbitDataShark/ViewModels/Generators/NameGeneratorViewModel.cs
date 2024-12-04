using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrbitDataShark.DataGen.Generators.Name;

namespace OrbitDataShark.ViewModels.Generators
{
    internal class NameGeneratorViewModel : ViewModelBase
    {
        public readonly NameType[] NameTypeOptions = [NameType.FirstName, NameType.LastName];
    }
}
