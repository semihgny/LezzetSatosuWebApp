
using System.ComponentModel.DataAnnotations;

namespace cafeSite2.Models
{
    public class About
    {
        [Key]
        public int Id{ get; set; }
        public string Title { get; set; }

    }
}
