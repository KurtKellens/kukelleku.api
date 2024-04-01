namespace Kukelleku.Dto.VrtNews
{
    using System.Xml.Serialization;

    public class AuthorDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }

}
