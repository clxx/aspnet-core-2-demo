using System.Drawing;
using System.Threading.Tasks;
using ColorName.Models;
using Microsoft.AspNetCore.Mvc;

namespace ColorName.Controllers
{
    public class ColorController : Controller
    {
        private readonly ColorNameContext _colorNameContext;

        public ColorController(ColorNameContext colorNameContext)
        {
            _colorNameContext = colorNameContext;
        }

        public async Task<IActionResult> Get(RgbColor rgbColor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var color = Color.FromArgb(rgbColor.Red, rgbColor.Green, rgbColor.Blue);

            var namedColor = await _colorNameContext.NamedColors.FindAsync(color.Name);

            return Content(namedColor?.Name ?? $"#{color.Name.Substring(2)}");
        }
    }
}