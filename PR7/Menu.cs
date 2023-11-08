using PR7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR7
{
    internal class Menu
    {
        public static int Cursor(int max)
        {
            ConsoleKeyInfo key;
            int pos = 0;
            do
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");

                key = Console.ReadKey();

                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  ");

                if (key.Key == ConsoleKey.UpArrow && pos > 0)
                {
                    pos--;
                }
                else if (key.Key == ConsoleKey.DownArrow && pos < max)
                {
                    pos++;
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    return -1;
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return pos;
        }
    }
}
