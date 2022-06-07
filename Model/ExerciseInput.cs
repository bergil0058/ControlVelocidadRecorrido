using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    [XmlRoot("root")]
    public record ExerciseInput()
    {
        [XmlElement("NumeroTests")]
        public int TestCount { get; set; }

        [XmlElement("Test")]
        public List<Test> Tests { get; set; }
    }
}
