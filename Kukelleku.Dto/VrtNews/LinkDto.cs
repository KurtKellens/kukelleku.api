using System.Xml.Serialization;

namespace Kukelleku.Dto.VrtNews
{

    public class LinkDto
    {
        [XmlAttribute("href")]
        public required string Href { get; set; }

        [XmlAttribute("rel")]
        public string? Rel { get; set; }

        [XmlAttribute("type")]
        public string? Type { get; set; }

        [XmlAttribute("title")]
        public required string Title { get; set; }
    }

}
