using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bogus;

using OrbitDataShark.Core.ComponentModel;

namespace OrbitDataShark.Core.DataGen.Generators.Name
{
    public class NameGeneratorDescriptor : GeneratorDescriptor
    {
        public ClrType ClrType => ClrType.String;
        public Gender Gender
        {
            get { return (Gender)Arguments["Gender"]; }
            set
            {
                _arguments["Gender"] = value;
            }
        }
        public NameType NameType
        {
            get { return (NameType)Arguments["NameType"]; }
            set
            {
                _arguments["NameType"] = value;
            }
        }

    }
}
