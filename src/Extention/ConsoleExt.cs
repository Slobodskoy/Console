using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Extention
{
    public static class ConsoleExt
    {
        public const int ScreenWidth = 80;
        public static void H(string text, char filler = '=')
        {
            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine(new string(filler, ScreenWidth));
                return;
            }

            Console.WriteLine(AlignCenter(text.Trim().PadLeft(text.Length+1).PadRight(text.Length + 2), filler));
        }

        public static void Br()
        {
            Console.WriteLine(AlignCenter(string.Empty, '='));
        }

        private static string AlignCenter(string text, char filler)
        {
            var fillerLen = ScreenWidth - text.Length;
            return text.ToUpper()
                .PadLeft(fillerLen / 2 + text.Length, filler)
                .PadRight(ScreenWidth, filler);
        }
    }
}
