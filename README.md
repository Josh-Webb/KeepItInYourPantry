# KeepItInYourPantry

THIS APP IS DEPLOYED!
Read through the description and then check it out at https://keepitinyourpantry.azurewebsites.net/.

Keep It In Your Pantry is a pantry tracking/recipe finding application built in C#, ASP.NET Core, the MVC framework, a local SQL Server and implements the Spoonacular API.
<img src="Pantry/Pantry/wwwroot/images/Screenshot (12).png">
A user can create ingredients to be added to their pantry.
<br />
They will be stored and organized by their category. Only a user with the email 'joshwebb42@gmail.com' (my email ;)) can add new categories.
<img src="Pantry/Pantry/wwwroot/images/Screenshot (13).png">
<img src="Pantry/Pantry/wwwroot/images/Screenshot (25).png">
<img src="Pantry/Pantry/wwwroot/images/Screenshot (26).png">
When a user has at least one ingredient in their pantry they can navigate to the recipes tab where they will be given recipes based on what they have stored.  
<br />
The initial page gives the title, a picture and a graph showing what percentage of the required ingredients they have.
<img src="Pantry/Pantry/wwwroot/images/Screenshot (27).png">
The recipe details page will present the user with all of that plus the serving size, cooktime, a complete list of ingredients with proportions, and the recipe step by step. 
<img src="Pantry/Pantry/wwwroot/images/Screenshot (28).png">
<img src="Pantry/Pantry/wwwroot/images/Screenshot (29).png">
<img src="Pantry/Pantry/wwwroot/images/Screenshot (30).png">


To run the app you will need .Net Core 2.2, Microsoft SQL server, Visual Studio and a Spoonacular API key.
<br />
After cloning it down open your Secrets.Json with 'Manage User Secrets'.
Create 
<br />
Keys {
 Spoonacular: 'yourApiKey'
}
<br />
Create a new migration, update your database and run the app. 
<br />
More features to come and if you have any suggestions or feedback please reach out at joshwebb42@gmail.com or https://www.linkedin.com/in/josh-b-webb.

