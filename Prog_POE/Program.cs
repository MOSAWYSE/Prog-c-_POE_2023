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
        noOfIngredients = int.Parse(noIngredients);//string data type will be converted into an integer for the number of the ingredients


        //THIS FOR LOOP WILL STORE THE DATA OF EACH INGREDIENT
        Console.WriteLine("************CAPTURE NEW RECIPE DATA************");
        for (int v = 0; v < noOfIngredients; ++v)
        {
            
            Console.WriteLine($"Enter the name of the ingredient:");//this will prompt the user to input the ingredient name
             name = Console.ReadLine();

            Console.WriteLine($"Enter the quantity of {name} :");//this will prompt the user to input the quanity of the ingredient
             quantity = Console.ReadLine();
            Quanity = int.Parse(quantity);//string data type will be converted into an integer for the quanity
            
            try {   
                Console.WriteLine($"Enter the number of the unit of measurement for eg (input 4 only) instead of (4 spoons) :");
             unitNo = Console.ReadLine();
            
            double unitNoDouble = double.Parse(unitNo);//string data type is being converted to a double


            Console.WriteLine($"Enter the unit of measurement to be used eg(spoons, Cups, ml and etc.");//this will prompt the user to input unit of measurement that will be used
            string unit = Console.ReadLine();

    
            ingredientName[v] = name;//this will store the ingredient name on the first position of the array
            ingredientQuantity[v] = Quanity;//the quanity will be stored on the second position
            noOfMeasurement[v] = unitNoDouble;//this will be the number stored of the unit of measurement
            ingredientUnit[v] = unit;//this will be the unit of measurement used eg spoons, ml and etc.

                Console.WriteLine("Enter the number of steps of the recipe:");
                string steps = Console.ReadLine();
                noSteps = int.Parse(steps);//this will be the number of steps of the recipe
               

                //this for loop will iterate the number of steps until there are no steps available
                for (int b = 0; b < noSteps; b++)
                {
                    Console.WriteLine($"Enter the description of step {b + 1} :");
                    string stepInfo = Console.ReadLine();
                    stepDescription[b] = stepInfo;

                }

            }
            catch (Exception e) { Console.WriteLine("An exception has occured. " + e.Message); }


        }



    }

    static void printRecipe()
    {
        Console.WriteLine($"\n*********RECIPE RESULTS*************");

        Console.WriteLine($"\nNumber of ingredients : {noOfIngredients}");

        for (int i = 0; i < noOfIngredients; i++)
        {
            Console.WriteLine($"\nIngredient name: {ingredientName[i]} \nIngredient quantity : {ingredientQuantity[i]}\nNumber of units for the measurement : {noOfMeasurement[i]} \nIngredient unit of measurement : {ingredientUnit[i]}");
        }


        //use the number of steps to display the steps and a for loop
        //this for loop will iterate through the array
        Console.WriteLine($"\nNumber of steps : {noSteps}");
        for (int i = 0; i < noSteps; i++)
        {
            Console.WriteLine($"\nStep {i+1} description :{stepDescription[i]}. ");//this will display the step description
        }


    }

    //this method will be used to scale the recipe of the captured ingredient
    static void scaleRecipe(double scale)
    {
        double scaledQuantity;//this variable will be storing the scaled quanity temporary

        for (int i = 0; i < noOfIngredients; ++i)
        {
            scaledQuantity = noOfMeasurement[i] * scale;//this is the formula used to calculate the new scaled quantity with the scale in the argument
            noOfMeasurement[i] = scaledQuantity;//the calculated scaled quantity will be stored in a array
        }

    }

    static void resetQuanity(double scale)
    {//THIS METHOD WILL BE RESETING THE QUANITIES OF THE INGREDIENT
        double resetQuantity;//this variable will be storing the reseted quantities

        for (int i = 0; i < noOfIngredients; ++i)
        {
            resetQuantity = noOfMeasurement[i] / scale;
            noOfMeasurement[i] = resetQuantity;
        }


    }

    //This method will be clearing the stored information on the arrays/tempData
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
        Console.WriteLine("\n**************RECIPE CONSOLE APP*************\n1.Capture new recipe data.\n2.Display recipe data. \n3.Scale the recipe. \n4.Reset recipe quanities to original values.\n5.Clear the recipe data.\n6.Exit Application.\nYour selection :");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                {
                    try 
                    {
                        captureInfo();
                        startUpMenu();
                    }
                    catch(Exception e) 
                    {
                        Console.WriteLine("An exception has occured while capturing recipe data. "+e.Message); 
                    }
                   
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
                    try
                    {
                    Console.WriteLine("Enter your scale factor number : ");//this will  be prompting the user to input the scale factor to be used
                    string newScale = Console.ReadLine();
                     scale = double.Parse(newScale);
                    scaleRecipe(scale);
                    startUpMenu();
                    }
                    catch (Exception ex) 
                    {
                    Console.WriteLine("An exception has occured please check your scale factor number." + ex.Message);
                    }

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