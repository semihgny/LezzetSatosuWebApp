using System.ComponentModel.DataAnnotations;

namespace cafeSite2.Models
{
    public class Contact
    {
        [Key]
        public int id { get; set; }
        public required string name { get; set; }
        public required string eMail { get; set; }
        public required string mesaj { get; set; }
        public required string telefon { get; set; }
        public DateTime Tarih { get; set; }
    }
}
