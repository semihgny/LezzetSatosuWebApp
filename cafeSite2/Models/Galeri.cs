using System.ComponentModel.DataAnnotations;

namespace cafeSite2.Models
{
    public class Galeri
    {
        [Key]
        public int Id { get; set; }
        public string? Image { get; set; }
    }
}
