using System.ComponentModel.DataAnnotations;

namespace cafeSite2.Models
{
    public class rezervasyon
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        
        [Required]
        public string eMail { get; set; }

        [Required]
        public string telefonNo { get; set; }

        [Required]
        public int sayi { get; set; }
        public string saat { get; set; }
        public DateTime Tarih { get; set; }

    }
}
