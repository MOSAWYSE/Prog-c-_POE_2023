using System.Xml.Linq;
using System.Text;
using static System.Formats.Asn1.AsnWriter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prog_POE
{

    public class displayRecipeInfo
    {//author: Mosa Tshikane(ST10036192)


        private static List<recipe> newRecipe = new List<recipe>();//this will be the recipe list that will be storing  the recipe data
        static double scale;


        //this  method will be sorting the recipes 
        static void displayRecipeAlphabetically()
        {
            Console.WriteLine("\n********RECIPES IN ALPHABETICAL ORDER^^^^^^");
            List<recipe> sortedRecipes = newRecipe.OrderBy(recipe => recipe.getName()).ToList();

            /*
            //this foreach loop will iterate through the sorted array list
            foreach (recipe recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.getName());
            }
            */

            //this for lopp will print out the sorted recipe names
            for (int i = 0; i < sortedRecipes.Count; i++)
            {
                Console.Write($"Recipe No.{i + 1} {sortedRecipes[i].getName()}\n");
            }

            Console.WriteLine("\nEnter the number of the recipe to display:");
            string selection = Console.ReadLine();

            if (int.TryParse(selection, out int recipeNumber))
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
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }


        }

        //this method will be having the app features
        public static void startUpMenu()
        {


            Console.WriteLine("\n**************RECIPE CONSOLE APP*************\n1.Capture new recipe data.\n2.Display recipe data. \n3.Scale the recipe. \n4.Reset recipe quanities to original values.\n5.Clear the recipe data.\n6.Display recipe data alphabetically.\n7.Exit the application.\nYour selection :");
            string option = Console.ReadLine();//this string will be capturing the function that the user wants to use

            switch (option)
            {
                case "1":
                    {
                        try
                        {
                            recipe obj = new recipe();//object for recipe
                            obj.captureInfo();//capture recipe data
                            newRecipe.Add(obj);//ADDING THE RECIPE DATA TO THE LIST
                            Console.WriteLine("Do you want to add more recipes?(YES/NO)");
                            string choice = Console.ReadLine();
                            recipePrompt(choice);


                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An exception has occured while capturing recipe data. " + e.Message);
                        }

                        break;
                    }//store recipe data
                case "2":
                    {
                        try
                        {//this for each loop will iterate through the newRecipe array list to print all the recipe details
                            foreach (recipe myRecipe in newRecipe)
                            {
                                myRecipe.printRecipe();//print each recipe data
                            }

                            startUpMenu();//display main menu
                        }
                        catch (Exception er)
                        {
                            Console.WriteLine("An exception has occured while printing recipe data. " + er.Message);
                        }
                        break;
                    }    //display recipe steps
                case "3":
                    {
                        try
                        {
                            Console.WriteLine("Enter your scale factor number : ");//this will  be prompting the user to input the scale factor to be used
                            string newScale = Console.ReadLine();

                            scale = double.Parse(newScale);
                            //this foreach loop will scale the recipes stored in the array list
                            foreach (recipe myRecipe in newRecipe)
                            {
                                myRecipe.scaleRecipe(scale);//scale recipe unit of measurement  
                            }

                            startUpMenu();//display menu
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine("An exception has occured please check your scale factor number." + ex.Message);
                        }

                        break;
                    }//scale the recipe 

                case "4":
                    {
                        try
                        {
                            foreach (recipe myRecipe in newRecipe)
                            {
                                myRecipe.resetQuanity(scale);//reset recipe unit of measurement
                            }
                            startUpMenu();//display menu
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("An exception has occured while scaling values. " + e.Message);
                        }

                        break;
                    }//reset quanities

                case "5":
                    {
                        try
                        {
                            newRecipe.Clear();//this will clear the recipe data stored in the array list
                            Console.WriteLine("The recipe data was successfully cleared.");
                            startUpMenu();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An exception has occured while clearing recipe data. " + e.Message);
                        }
                        break;
                    } //clear the recipe data 

                case "6":
                    {
                        //this method will display the recipes alphabetically
                        displayRecipeAlphabetically();
                        startUpMenu();
                        break;

                    }
                case "7":
                    {
                        System.Environment.Exit(0);//Exit app
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Please enter a valid option.");
                        startUpMenu();
                        break;
                    }


            }



        }

        public static void recipePrompt(string prompt)
        {



            switch (prompt.ToLower())
            {
                case "yes":
                    {
                        //this will allow users to capture another recipe data
                        try
                        {
                            recipe obj = new recipe();//instantiating a the recipe class
                            obj.captureInfo();
                            newRecipe.Add(obj);//Add the recipe data to the array list
                            startUpMenu();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An exception has occured. " + e.Message);
                        }
                        break;
                    }

                case "no":
                    {
                        //display start up menu
                        startUpMenu();
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Please enter a yes or no answer.");
                        break;
                    }

            }



        }
    }

}