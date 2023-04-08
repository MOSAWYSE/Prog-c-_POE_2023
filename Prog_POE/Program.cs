using System.Xml.Linq;
using System.Text;

public class recipe
{

    static int noSteps = 0;
    static int noOfIngredients = 0;
    static int Quanity;
    static double scale = 0;
    static string name = "", quantity="", unitNo="";


    static string[] ingredientName = new string[100];//this array will be storing the ingredient name
    static string[] stepDescription = new string[100];//this will be storing the information of each step description
    static int[] ingredientQuantity = new int[100];//this array will be storing the quanity of the ingredient
    static double[] noOfMeasurement = new double[100];//this array will be storing the number of the unit of measurement               
    static string[] ingredientUnit = new string[100];//this array will be storing the name of the unit of measurement eg.Tablespoons, litres ,Cups and etc


    static void captureInfo()
    {

  
        Console.WriteLine("Enter the number of ingredients to be captured:");

        string noIngredients = Console.ReadLine();
        noOfIngredients = int.Parse(noIngredients);

        //  ingredient[0] = noIngredients;

        //THIS FOR LOOP WILL STORE THE DATA OF EACH INGREDIENT

        for (int v = 0; v < noOfIngredients; ++v)
        {
            Console.WriteLine("");
            Console.WriteLine($"Enter the name of the ingredient:");
             name += Console.ReadLine();

            Console.WriteLine($"Enter the quantity of {name} :");
             quantity += Console.ReadLine();
            Quanity = int.Parse(quantity);
            
            try {   Console.WriteLine($"Enter the number of the unit of measurement for eg (input 4 only) instead of (4 spoons) :");
             unitNo += Console.ReadLine();
            
            double unitNoDouble = int.Parse(unitNo);


            Console.WriteLine($"Enter the unit of measurement to be used eg(spoons, Cups, ml and etc.");
            string unit = Console.ReadLine();

            //ingredient[v+1] = name;//this will store the ingredient name on the first position of the array
            //ingredient[v+2] = quantity;//the quanity will be stored on the second position
            //ingredient[v+3] = unit;

            ingredientName[v] += name;//this will store the ingredient name on the first position of the array
            ingredientQuantity[v] += Quanity;//the quanity will be stored on the second position
            noOfMeasurement[v] += unitNoDouble;//this will be the number stored of the unit of measurement
            ingredientUnit[v] += unit;//this will be the unit of measurement used eg spoons, ml and etc.


            }
            catch (Exception e) { Console.WriteLine("An exception has occured. " + e.Message); }



        }



        Console.WriteLine("Enter the number of steps of the recipe:");
        string steps = Console.ReadLine();
        noSteps += int.Parse(steps);//this will be the number of steps of the recipe
        stepDescription[0] = steps;


        //this for loop will iterate the number of steps until there are no steps available
        for (int b = 0; b < noSteps; b++)
        {
            Console.WriteLine($"Enter the description of step {b + 1} :");
            string stepInfo = Console.ReadLine();
            stepDescription[b + 1] = stepInfo;

        }




    }

    static void printRecipe()
    {
        Console.WriteLine($"\n*********RECIPE RESULTS*************");
        // Console.WriteLine($"\nNumber of ingredients: {ingredient[0]} \nIngredient name : {ingredient[1]} \nIngredient quantity : {ingredient[2]} \nIngredient unit of measurement : {ingredient[3]}");

        Console.WriteLine($"\nNumber of ingredients : {noOfIngredients}");

        for (int i = 0; i < noOfIngredients; i++)
        {
            Console.WriteLine($"\nIngredient name: {ingredientName[i]} \nIngredient quantity : {ingredientQuantity[i]}\nNumber of units for the measurement : {noOfMeasurement[i]} \nIngredient unit of measurement : {ingredientUnit[i]}");
        }


        //use the number of steps to display the steps and a for loop

        Console.WriteLine($"\nNumber of steps : {stepDescription[0]}");
        for (int i = 0; i < noSteps; i++)
        {
            Console.WriteLine($"\nStep {i + 1} description :{stepDescription[i + 1]}. ");
        }




    }

    static void scaleRecipe(double scale)
    {
        double scaledQuanity;



        for (int i = 0; i < noOfIngredients; ++i)
        {
            scaledQuanity = noOfMeasurement[i] * scale;
            // Console.WriteLine($"new unit is >> {scaledQuanity}");
            noOfMeasurement[i] = scaledQuanity;
        }



    }

    static void resetQuanity(double scale)
    {//THIS METHOD WILL BE RESITING THE QUANITIES OF THE INGREDIENT
        double resetQuanity;

        for (int i = 0; i < noOfIngredients; ++i)
        {
            resetQuanity = noOfMeasurement[i] / scale;
            noOfMeasurement[i] = resetQuanity;
        }


    }


    static void clearData()
    {
        //this for loop will set all the array data to default values to clear all the arrays
        string clear = "";
        for (int i = 0; i < noOfIngredients; ++i)
        {
            ingredientName[i] = clear;
            stepDescription[i] = clear;
            ingredientQuantity[i] = 0;
            noOfMeasurement[i] = 0;
            ingredientUnit[i] = clear;
        }

    }



    public static void Main(string[] args)
    {


        startUpMenu();


    }





    static void startUpMenu()
    {
        Console.WriteLine("\n**************RECIPE CONSOLE APP*************\n1.Capture new recipe data.\n2.Display recipe steps. \n3.Scale the recipe. \n4.Reset quanities to original values.\n5.Clear the recipe data.\n6.Exit Application.\nYour selection :");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                {
                    captureInfo();
                    startUpMenu();
                    break;
                }//store recipe data
            case "2":
                {
                    printRecipe();
                    startUpMenu();
                    break;
                }    //display recipe steps
            case "3":
                {
                    Console.WriteLine("Enter your scale factor number : ");
                    string newScale = Console.ReadLine();
                     scale = int.Parse(newScale);
                    scaleRecipe(scale);
                    startUpMenu();

                    break;
                }    //scale the recipe 
            case "4":
                {
                    resetQuanity(scale);
                    startUpMenu();
                    break;
                }//reset quanities
            case "5":
                {
                    clearData();
                    startUpMenu();
                   
                    break;
                } //clear the recipe data 

                    case "6": 
                {
                    System.Environment.Exit(0);
                    break;
                }
        }
       



    


    }
}