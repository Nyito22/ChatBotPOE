using System.IO;
using System;
using System.Drawing;

namespace ChatBotPOE
{
    public class logo
    {
        public logo()
        {
            // creating a logo for the chat bot


            string logo_location = AppDomain.CurrentDomain.BaseDirectory;

            // Replace "bin\\Debug\\" with an empty string
            string new_location = logo_location.Replace("bin\\Debug\\", "");

            // Combine paths
            string full_location = Path.Combine(new_location, "LogoAscii.png");

           
            // Load and resize the image
            Bitmap image = new Bitmap(full_location);
            image = new Bitmap(image, new Size(70, 50));

            //Changing the color
            Console.ForegroundColor = ConsoleColor.Gray;


            // Convert to ASCII and print
            for (int height = 0; height < image.Height; height++)
            {
                for (int width = 0; width < image.Width; width++)
                {
                    Color pixelColor = image.GetPixel(width, height);
                    int blue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    char asciiChar = blue > 200 ? '.' : blue > 150 ? '*' : blue > 100 ? '&' : blue > 50 ? '%' : '$';
                    Console.Write(asciiChar);
                }
                Console.WriteLine(); // Move to the next row
            }

            Console.WriteLine();


        }
    }
}