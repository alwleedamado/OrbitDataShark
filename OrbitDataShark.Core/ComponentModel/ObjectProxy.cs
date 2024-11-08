using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitDataShark.Core.ComponentModel
{
    public class ObjectProxy
    {
        public object ContainedObject { get; }
        public ObjectProxy(object obj)
        {
            ContainedObject = obj;
        }
    }
}
