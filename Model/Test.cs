using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    public record Test()
    {
        [XmlAttribute("numero")]
        public int Number { get; set; }

        [XmlElement("Destino")]
        public double LenghtKms { get; set; }

        [XmlElement("Caballo")]
        public List<Horse> Horses { get; set; }
    }
}
