using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Product> productList = new List<Product>();
     static void Main(string[] args)
    {
        string input;
        while (true)
        {
            Console.WriteLine("Enter the following Categories, Products, and Price of Products (type Q or Quit to exit):");

            Console.Write("Enter a Category: ");
            input = Console.ReadLine();
            if (IsExitCommand(input) > 0) break;
            string category = input;

            Console.Write("Enter a Product Name: ");
            input = Console.ReadLine();
            if (IsExitCommand(input) > 0) break;
            string productName = input;

            Console.Write("Enter a Price: ");
            input = Console.ReadLine();
            if (IsExitCommand(input) > 0) break;
            decimal price = Convert.ToDecimal(input);

            // Add product to the list
            productList.Add(new Product(category, productName, price));
            Console.WriteLine("The product was successfully added!\n");

          

            // Ask for further actions
            Console.WriteLine("To enter a new product - enter: \"p\" | To search for product - enter: \"s\" | To quit - enter: \"Q\"");
            input = Console.ReadLine().ToLower();

            if (input == "q")
            {
                // Display the products in table format
                DisplayProducts();
                break;
            }
            else if (input == "s")
            {
                SearchProduct();
            }
        }
    }

    // Function to check if user wants to quit
    public static int IsExitCommand(string input)
    {
        int flag = 0;
    
        if (input.ToLower().Trim().Equals("Q") || input.ToLower().Trim().Equals("Quit"))
            flag = 1;
        return flag;
    }

    // Display products in table form
    static void DisplayProducts()
    {
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine($"{"Category".PadRight(15)}{"Product Name".PadRight(15)}{"Price"}");
        Console.WriteLine("---------------------------------------------");
        foreach (var product in productList)
        {
             
            product.Display(false);
        }
        Console.WriteLine("---------------------------------------------");
    }

    // Search and highlight filtered product
    static void SearchProduct()
    {
        Console.Write("Enter product name to search: ");
        string searchQuery = Console.ReadLine().ToLower();

        // Find the product using LINQ
        var filteredProducts = productList.Where(p => p.ProductName.ToLower().Contains(searchQuery)).ToList();

        if (filteredProducts.Count() > 0)
        {
            Console.WriteLine("\nSearch results:");
            Console.WriteLine("---------------------------------------------");
            
            Console.WriteLine($"{"Category".PadRight(15)}{"Product Name".PadRight(15)}{"Price".PadRight(15)}");
           
            Console.WriteLine("---------------------------------------------");
             
            foreach (var product in productList)
            {
                bool highlight = filteredProducts .Contains(product);
                product.Display(highlight);
                
            }

            Console.WriteLine("---------------------------------------------");
        }
        else
        {
            Console.WriteLine("No matching product found.");
        }
    }
}
