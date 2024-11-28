using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _20241128_BinarySerizationDemo
{
    [Serializable]
    public class Person : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Age { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} ({2})", Id, Name, Age);
        }

        public object Clone()
        {
            MemoryStream strm = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(strm, this);

            strm.Position = 0;

            return binaryFormatter.Deserialize(strm);
        }
    }
}
