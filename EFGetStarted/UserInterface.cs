﻿using Spectre.Console;

namespace EFGetStarted
{
    static internal class UserInterface
    {
        internal static void ShowProduct(Product product)
        {
            var panel = new Panel($@"Id: {product.Id}
Name: {product.Name}
Price: {product.Price}");
            panel.Header = new PanelHeader("Product Info");
            panel.Padding = new Padding(2,2,2,2);
            AnsiConsole.Write(panel);
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        static internal void ShowProductTable(List<Product> products)
        {
            var table = new Table();
            table.AddColumns("Id", "Name", "Price");
            foreach(var product in products)
            {
                table.AddRow(
                    product.Id.ToString(), 
                    product.Name, 
                    product.Price.ToString());
            }
            AnsiConsole.Write(table);  
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
