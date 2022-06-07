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
    public record ExerciseOutput
    {

        [XmlElement("NumeroTests")]
        public int TestCount { get; set; }

        [XmlElement("ResultadoTest")]
        public List<TestResult> Results { get; set; }
    }
}
