using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon.UI
{
    public class SetColorToText
    {
        public static void SetColorToYellow(string str)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(str+"\n");
            Console.ResetColor();
        }

        public static void SetColorToRed(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(str + "\n");
            Console.ResetColor();
        }
        public static void SetColorToMagenta(string str)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(str);
            Console.ResetColor();
        }
        public static void SetColorToSkyBlue(string str)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(str + "\n");
            Console.ResetColor();
        }
        public static void SetColorToDarkCyan(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(str + "\n");
            Console.ResetColor();
        }
    }
}
