using System.ComponentModel.DataAnnotations;

namespace ColorName.Models
{
    public class RgbColor
    {
        [Required]
        [Range(0, 255)]
        public int Red { get; set; }

        [Required]
        [Range(0, 255)]
        public int Green { get; set; }

        [Required]
        [Range(0, 255)]
        public int Blue { get; set; }
    }
}