using System;
using System.Collections.Generic;
using System.Text;

namespace Znaki.Extensions
{
    public static class Extensions
    {
        public static bool IsNumber(this string text)
        {
            return int.TryParse(text, out _);
        }

        public static int AsNumber(this string text)
        {
            return int.Parse(text);
        }
    }
}
