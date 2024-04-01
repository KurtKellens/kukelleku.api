namespace Kukelleku.Dto.VrtNews
{
    using System.Xml.Serialization;

    public class EntryDto
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("published")]
        public DateTime Published { get; set; }

        [XmlElement("updated")]
        public DateTime Updated { get; set; }

        [XmlElement("summary")]
        public string Summary { get; set; }

        [XmlElement("nstag")]
        public string Nstag { get; set; }

        [XmlElement("nslabeltag")]
        public string Nslabeltag { get; set; }

        [XmlElement("link")]
        public List<LinkDto> Links { get; set; }
    }

}
