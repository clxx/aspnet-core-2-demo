using System.Drawing;
using ColorName.Models;
using Microsoft.AspNetCore.Mvc;

namespace ColorName.Controllers
{
    public class ColorController : Controller
    {
        public IActionResult Get(RgbColor rgbColor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var color = Color.FromArgb(rgbColor.Red, rgbColor.Green, rgbColor.Blue);

            return Content($"#{color.Name.Substring(2)}");
        }
    }
}