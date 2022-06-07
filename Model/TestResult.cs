using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    public record TestResult
    {

        [XmlAttribute("numero")]
        public int Number { get; set; }

        [XmlText()]
        public double Result { get; set; }
    }
}
