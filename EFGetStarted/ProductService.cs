using EFGetStarted.Models;
using Spectre.Console;

namespace EFGetStarted
{
    internal class ProductService
    {
       static private Product GetProductOptionInput()
        {
            var products = ProductController.GetProducts();
            var productsArray = products.Select(x => x.Name).ToArray();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose Product")
                .AddChoices(productsArray));
            var id = products.Single(product => product.Name.Equals(option)).ProductId;
            var product = ProductController.GetProductById(id);
            return product;
        }
        static internal void GetProducts()
        {
            var products = ProductController.GetProducts();
            UserInterface.ShowProductTable(products);
        }
        static internal void DeleteProduct()
        {
            var product = GetProductOptionInput();
            ProductController.DeleteProduct(product);
        }
        static internal void InsertProduct()
        {
            var product = new Product();
            product.Name = AnsiConsole.Ask<string>("Product's name: ");
            product.Price = AnsiConsole.Ask<decimal>("Product's price: ");
            ProductController.AddProduct(product);
            
        }

        internal static void GetProduct()
        {
            var product =  GetProductOptionInput();
            UserInterface.ShowProduct(product);

        }

        internal static void UpdateProduct()
        {
            var product = GetProductOptionInput();
            product.Name = AnsiConsole.Confirm("Update name?")
                ? AnsiConsole.Ask<string>("Product's name: ")
                : product.Name;
            product.Price = AnsiConsole.Confirm("Update price?")
                ? AnsiConsole.Ask<decimal>("Product's price: ")
                : product.Price;
            ProductController.UpdateProduct(product);
        }
    }
}
