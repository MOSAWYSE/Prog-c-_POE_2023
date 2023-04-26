# Prog_POE 2023

Cooking Recipe Program 

This C# software is used to record and present recipe data. 


#Use these steps to compile and run the program:

1. Launch your favourite C#-compatible Integrated Development Environment (IDE).
2. Create a new project for a console application.
3. Into the project's "Program.cs" file, paste the code from the "recipe.cs" file.
4. Compile and run the program.

#Usage

The quantity of ingredients to be captured must be entered when the application is run. You will be requested to enter the name, quantity, and unit of measurement of each item after entering the total number of ingredients.

The amount of steps in the recipe's instructions will thereafter be required of you. You'll be requested to type a description for each step.

By using the printRecipe() method after you have collected all the necessary recipe information, you can see it in action. In addition to the step explanations, this will list the ingredients' names, quantities, and units of measurement.

You can scale the recipe by using the'scaleRecipe(double scale)' method and providing the desired scale as a parameter. Using this technique, the recipe data will be updated together with the new quantities determined using the scale. By using the'resetQuantity()' method, you can finally return the ingredient quantities to their initial values.



Project Github repository link: https://github.com/MOSAWYSE/Prog-c-_POE_2023

Make sure to include the namespaces "System.Xml.Linq" and "System.Formats.Asn1.AsnWriter" in your project because they are needed by the program.
