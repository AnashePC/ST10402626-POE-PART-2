using CookBook;

class Program
{
    static void Main(string[] args)
    {
        RecipeApp recipeApp = new RecipeApp();
        recipeApp.OnCalorieExceeded += message => Console.WriteLine(message);

        while (true)
        {
            Console.WriteLine("1. Create Recipe");
            Console.WriteLine("2. Display All Recipes");
            Console.WriteLine("3. Display Recipe by Name");
            Console.WriteLine("4. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    recipeApp.CreateRecipe();
                    break;
                case "2":
                    recipeApp.DisplayAllRecipes();
                    break;
                case "3":
                    Console.WriteLine("Enter recipe name:");
                    string name = Console.ReadLine();
                    recipeApp.DisplayRecipeByName(name);
                    break;
                case "4":
                    return;
            }
        }
    }
}
