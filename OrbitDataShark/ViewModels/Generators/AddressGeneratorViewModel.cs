using OrbitDataShark.DataGen.Generators.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitDataShark.ViewModels.Generators
{
    internal class AddressGeneratorViewModel : ViewModelBase
    {
        public string[] AddressTypeOptions = Enum.GetNames(typeof(AddressType));
    }
}
