using EFGetStarted.Models;
using Spectre.Console;
using static EFGetStarted.Enums;

namespace EFGetStarted
{
    static internal class UserInterface
    {
        internal static void ShowMainMenu()
        {
            var isAppRunning = true;

            while (isAppRunning)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<Enums.MenuOptions>()
                    .Title("What would you like to do?")
                    .AddChoices(
                        MenuOptions.AddProduct,
                        MenuOptions.DeleteProduct,
                        MenuOptions.UpdateProduct,
                        MenuOptions.ViewAllProducts,
                        MenuOptions.ViewProduct));
                switch (option)
                {
                    case MenuOptions.AddProduct:
                        ProductService.InsertProduct();
                        break;
                    case MenuOptions.DeleteProduct:
                        ProductService.DeleteProduct();
                        break;
                    case MenuOptions.UpdateProduct:
                        ProductService.UpdateProduct();
                        break;
                    case MenuOptions.ViewAllProducts:
                        ProductService.GetProducts();

                        break;
                    case MenuOptions.ViewProduct:
                        ProductService.GetProduct();

                        break;
                }
            }
        }
        internal static void ShowProduct(Product product)
        {
            var panel = new Panel($@"Id: {product.ProductId}
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
                    product.ProductId.ToString(), 
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
