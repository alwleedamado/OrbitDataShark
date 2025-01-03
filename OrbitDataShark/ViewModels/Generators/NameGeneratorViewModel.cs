using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrbitDataShark.DataGen.Generators.Name;

namespace OrbitDataShark.ViewModels.Generators
{
    public partial class NameGeneratorViewModel : ViewModelBase
    {
        public readonly string[] NameTypeOptions = Enum.GetNames(typeof(NameType));
        public bool ShowGender = true;
    }
}
