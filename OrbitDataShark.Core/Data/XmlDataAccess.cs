using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace OrbitDataShark.Core.Data
{
    internal static class XmlDataAccess
    {
        public static void SaveToDisk<T>(string path, T data)
        {
            XmlSerializerFactory factory = new XmlSerializerFactory();
            XmlSerializer xmlSerializer = factory.CreateSerializer(typeof(T));
            FileStream fs = new(path, FileMode.OpenOrCreate, FileAccess.Write);
            xmlSerializer.Serialize(fs, data);
        }

        public static T ReadData<T>(string path)
        {
            XmlSerializerFactory factory = new XmlSerializerFactory();
            XmlSerializer xmlSerializer = factory.CreateSerializer(typeof(T));
            FileStream fs = new(path, FileMode.Open, FileAccess.Read);
            return (T)xmlSerializer.Deserialize(fs)!;
        }
    }
}
