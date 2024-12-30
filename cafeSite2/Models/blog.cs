using System.ComponentModel.DataAnnotations;

namespace cafeSite2.Models
{
    public class blog
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Name { get; set; }
        public required string eMail { get; set; }
        public string? Image { get; set; }
        public bool Onay { get; set; }
        public required string Mesaj { get; set; }
        public DateTime Tarih { get; set; }



    }
}
