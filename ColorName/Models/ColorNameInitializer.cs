using System.Collections.Generic;

namespace ColorName.Models
{
    public static class ColorNameInitializer
    {
        public static void Initialize(ColorNameContext colorNameContext)
        {
            // No migrations necessary any more for rapid prototyping/development...

            // https://docs.microsoft.com/en-us/ef/core/api/microsoft.entityframeworkcore.infrastructure.databasefacade

            colorNameContext.Database.EnsureDeleted();

            colorNameContext.Database.EnsureCreated();

            foreach (var namedColor in new[]
            {
                ("00ffff", "aqua"),
                ("000000", "black"),
                ("0000ff", "blue"),
                ("ff00ff", "fuchsia"),
                ("808080", "gray"),
                ("008000", "green"),
                ("00ff00", "lime"),
                ("800000", "maroon"),
                ("000080", "navy"),
                ("808000", "olive"),
                ("800080", "purple"),
                ("ff0000", "red"),
                ("c0c0c0", "silver"),
                ("008080", "teal"),
                ("ffffff", "white"),
                ("ffff00", "yellow")
            })
            {
                colorNameContext.NamedColors.Add(new NamedColor
                {
                    Argb = $"ff{namedColor.Item1}",
                    Name = namedColor.Item2
                });
            }

            colorNameContext.SaveChanges();
        }
    }
}