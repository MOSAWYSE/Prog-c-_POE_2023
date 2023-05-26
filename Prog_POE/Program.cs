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

            displayRecipeInfo.startUpMenu();//this will print out the menu

        if(int.TryParse(input, out int recipeNumber)) 
        {
            if (recipeNumber >= 1 && recipeNumber <= sortedRecipes.Count)
            {
                recipe selectedRecipe = sortedRecipes[recipeNumber - 1];
                selectedRecipe.printRecipe();
            }
            else 
            {
                Console.WriteLine("Please enter a valid recipe number.");
            }

        }
    }

}
