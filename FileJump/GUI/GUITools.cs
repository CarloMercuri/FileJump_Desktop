﻿using System;
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

            Graphics g = Graphics.FromHwnd(label.Handle);
            g.PageUnit = GraphicsUnit.Pixel;

            while (TextRenderer.MeasureText(newText, label.Font).Width > label.Width)
            {
                if(clipCount >= newText.Length)
                {
                    return "<ERROR>"; // Something went wrong with the width and the loop kept going. Safe way out
                }

                newText = ShortenFileName(original, original.Length - clipCount);
                clipCount++;
            }

            g.Dispose();

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
