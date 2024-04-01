namespace Kukelleku.Dto.VrtNews
{
    using System.Xml.Serialization;

    [XmlRoot("feed", Namespace = "http://www.w3.org/2005/Atom")]
    public class FeedDto
    {

        [XmlElement("title")]
        public string? Title { get; set; }

        [XmlElement("logo")]
        public string? Logo { get; set; }


        [XmlElement("id")]
        public string? Id { get; set; }

        [XmlElement("updated")]
        public DateTime Updated { get; set; }

        [XmlElement("author")]
        public AuthorDto? Author { get; set; }

        [XmlElement("link")]
        public List<LinkDto> Links { get; set; }

        [XmlElement("entry")]
        public required List<EntryDto> Entries { get; set; }
    }

}
