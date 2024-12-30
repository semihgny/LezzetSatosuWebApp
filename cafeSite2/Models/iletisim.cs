using System.ComponentModel.DataAnnotations;

namespace cafeSite2.Models
{
    public class iletisim
    {
        [Key]
        public int id { get; set; }
        public string eMail { get; set; }
        public string telefon { get; set; }
        public string adres { get; set; }
    }
}
