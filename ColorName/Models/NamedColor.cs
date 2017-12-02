using System.ComponentModel.DataAnnotations;

namespace ColorName.Models
{
    public class NamedColor
    {
        [Key]
        public string Argb { get; set; }

        [Required]
        public string Name { get; set; }
    }
}