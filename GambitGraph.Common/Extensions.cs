using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class Extensions
    {
        public static string LowerFirstLetter(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            return char.ToLower(input[0]) + input.Substring(1);
        }
    }
}
