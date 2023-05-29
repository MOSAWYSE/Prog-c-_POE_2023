# Prog_POE 2023

Cooking Recipe Program 

This C# software is used to record and present recipe data. 


#Use these steps to compile and run the program:

1. Launch your favourite C#-compatible Integrated Development Environment (IDE).
2. Create a new project for a console application.
3. Into the project's "Program.cs" file, paste the code from the "recipe.cs" file.
4. Compile and run the program.

OR
2. clone this project repository to download the project zip file
3. The downloaded file will be named Prog_Poe.zip and you need to extract it 
4. open the folder on the IDE 
5. To run the program use the Program.cs file
#Usage

 The application will ask you to input the total number of recipes that needs to be captured and the quantity of ingredients to be captured must be entered when the application is running if the user has choosen to capture a new recipe data from the main menu. You will be requested to enter the name, quantity, and unit of measurement of each recipe ingredient after entering the total number of ingredients.
 
The amount of steps in the recipe's instructions will thereafter be required of you. You'll be requested to type a description for each step.

By using the printRecipe() method after you have collected all the necessary recipe information, you can see it in action. In addition to the step explanations, this will list the ingredients' names, quantities, and units of measurement.

You can scale the recipe by using the'scaleRecipe(double scale)' method and providing the desired scale as a parameter. Using this technique, the recipe data will be updated together with the new quantities determined using the scale. By using the'resetQuantity()' method, you can finally return the ingredient quantities to their initial values.

The application has a printing feature that will display the stored recipes alphabetically, this feature can be accessed using the second number on the main menu.
The printing feature will be using a delegate to alert the user if the total number of the recipe calories has exceeded 300.

#Testing
The unit testing of this software requires some extra installation of IDE extensions to be able to run properly without errors. On the IDE console you need to write specific commands that will import needed libraries to begin with the testing which are as follows:
$dotnet add Microsoft.NET.tESTsdk
$dotnet new Nunit
$dotnet add Nunit3TestAdapter

You will need to make sure that the nUnit test adapater is installed by navigating to the 'extensions' tab and choose 'manage extensions' and search for 'nUnit test adapater' and install the testing adapater.

#Changes
On this program i used the generic collections to store the recipe data. I updated the recipe printing method to display the recipes alphabetically and modified the software to allow multiple number of recipes. The user is now able to enter a name of a recipe and store it in memory.
This enable users to be able to choose which recipe data they wish to display based on the recipe names stored. I added new functions on the recipe class to allow users to be able to input number of recipe calories and the food group of the ingredient. The software now can print the total number of calories that are on a single recipe and it will notify the user if the recipe calories exceed 300.



Project Github repository link: https://github.com/MOSAWYSE/Prog-c-_POE_2023

Make sure to include the namespaces "System.Xml.Linq" and "System.Formats.Asn1.AsnWriter" in your project because they are needed by the program.
