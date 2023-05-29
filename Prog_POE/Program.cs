using System.Xml.Linq;
using System.Text;
using static System.Formats.Asn1.AsnWriter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prog_POE
{
    class Program
    {
        public static void Main(string[] args)
        {
            ConsoleColor textColor = ConsoleColor.Black;
            ConsoleColor consoleColor = ConsoleColor.Gray;
            Console.BackgroundColor = consoleColor;
            Console.ForegroundColor = textColor;
            Console.Clear();
            displayRecipeInfo.startUpMenu();//this will print out the menu

            //Console.Clear();
        }
    }

}
