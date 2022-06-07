using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    public record Horse()
    {
        [XmlAttribute("numero")]
        public int Id { get; set; }

        [XmlElement("Posicion")]
        public double Position { get; set; }

        [XmlElement("Velocidad"), Range(double.Epsilon, double.MaxValue)]
        public double Speed { get; set; }
    }
}
