using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.GUI
{
    public static class GUITools
    {
        public static Color COLOR_Dividers_Light = Color.FromArgb(255, 77, 81, 99);
        public static Color COLOR_Dividers_Dark = Color.FromArgb(255, 35, 37, 48);

        public static Color COLOR_DarkMode_Dark = Color.FromArgb(255, 39, 41, 54);
        public static Color COLOR_DarkMode_Light = Color.FromArgb(255, 49, 52, 67);
        public static Color COLOR_DarkMode_TextBoxBackColor = Color.FromArgb(255, 129, 132, 247);
        public static Color COLOR_DarkMode_Lighter = Color.FromArgb(255, 57, 61, 79);

        public static Color COLOR_DarkMode_Text_Light = Color.FromArgb(255, 122, 129, 154);
        public static Color COLOR_DarkMode_Text_Bright = Color.FromArgb(255, 162, 169, 214);

        public static Color COLOR_Controls_Border = Color.FromArgb(255, 102, 109, 138);

        public static Color COLOR_RedText = Color.FromArgb(255, 255, 50, 0);

        // Fonts

        public static Font FONT_WallText = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Pixel);
        public static Font FONT_WallText_Small = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel);
        public static Font FONT_WallText_Big = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);


        public static string ShortenFileName(string original, int maxLenght)
        {
            if (original.Length > maxLenght)
            {
                return original.Substring(0, maxLenght - 1) + "..";
            }
            else
            {
                return original;
            }
        }
        
        /// <summary>
        /// Returns a version of the given text that fits into the given label width wise in pixels.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        public static string FitTextLenghtToLabelSize(string original, Label label)
        {
            string newText = original;
            int clipCount = 1;

            while (TextRenderer.MeasureText(newText, label.Font).Width > label.Width)
            {
                if(clipCount >= original.Length)
                {
                    return "<ERROR>"; // Something went wrong with the width and the loop kept going. Safe way out
                }

                newText = ShortenFileName(original, original.Length - clipCount);
                clipCount++;
            }

   
            return newText;
        }

        /// <summary>
        /// Returns a version of the given text that fits into the given label width wise in pixels.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        public static string FitTextLenghtToWidth(string original, Font font, int width)
        {
            string newText = original;
            int clipCount = 1;

                

            while (TextRenderer.MeasureText(newText, font).Width > width)
            {
                if (clipCount >= newText.Length)
                {
                    return "<ERROR>"; // Something went wrong with the width and the loop kept going. Safe way out
                }

                newText = ShortenFileName(original, original.Length - clipCount);
                clipCount++;
            }
  

            return newText;
        }



        public static SizeF GetLabelTextLenght(string text, Label label)
        {
            using(Graphics g = Graphics.FromHwnd(label.Handle))
            {
                g.PageUnit = GraphicsUnit.Pixel;
                return g.MeasureString(text, label.Font);
            }
        }

    }
}
