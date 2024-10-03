using System;

public class Product
{
    public string Category { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }

    public Product(string category, string productName, decimal price)
    {
        Category = category;
        ProductName = productName;
        Price = price;
    }

    // Method to display product details with padding
    public void Display(bool highlight)
    {
        string categoryFormatted = $"{Category}";
        string productFormatted = $"";
        string priceFormatted =    Price.ToString("C");
        if (highlight)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Category}".PadRight(15) + "" + $"{ ProductName}".PadRight(15) +""+$"{priceFormatted}");
            Console.ResetColor();   
        }
        else
            Console.WriteLine($"{categoryFormatted.PadRight(15)}{productFormatted.PadRight(15)}{priceFormatted}");


    }
}
