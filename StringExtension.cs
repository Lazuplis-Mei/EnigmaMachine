using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachine
{
    internal static class StringExtension
    {

        public const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static bool IsPureUpperLetters(this string text)
        {
            foreach (var item in text)
            {
                if (item < 'A' || item > 'Z')
                {
                    return false;
                }
            }
            return true;
        }

        public static char FromIndex(this string str, int index)
        {
            return str[(str.Length + index) % str.Length];
        }

        public static char MapedLetter(this string str, char c, int offset = 0)
        {
            return str.FromIndex(ALPHABET.IndexOf(c) + offset);
        }

        public static char InversedLetter(this string str, char c, int offset = 0)
        {
            return ALPHABET.FromIndex(str.IndexOf(c) - offset);
        }
    }

}
