﻿using OrbitDataShark.DataGen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitDataShark.DataGen.Generators.Address
{
    public class AddressGeneratorDescriptor : GeneratorDescriptor
    {
        public ClrType ClrType => ClrType.String;
        public AddressType AddressType
        {
            get => (AddressType)_arguments["AddressType"];
            set => _arguments["AddressType"] = value;
        }
    }
}
