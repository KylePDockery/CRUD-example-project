using System;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Collections.Generic;

namespace CRUDprojectV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ProductRepository repo = new ProductRepository();
            Console.WriteLine("Welcome to Best Buy! I understand you're here to  update are catalogue.\n" +
                "Let's get started with showing you the current catalogue.");
            Console.ReadLine();
            List<Product> products = repo.ReadCatalogue();  //read
            foreach (var product in products)
            {
                Console.WriteLine(product.Name + " " + product.Price);
            }

            Console.ReadLine(); 

            Console.WriteLine("\nOkay, so I was informed you needed to add a product, what's it called?");
            Product createdProduct = new Product();
            createdProduct.Name = Console.ReadLine();
            Console.WriteLine("Okay, what about the price?\n");
            createdProduct.Price = Convert.ToDecimal(Console.ReadLine());
            repo.CreateProduct(createdProduct.Name, createdProduct.Price, 1); //create

            Console.WriteLine($"Okay, that completes the addition of {createdProduct.Name}. Let's make sure it went through.");
            products = repo.ReadCatalogue();
            foreach (var product in products)
            {
                Console.WriteLine(product.Name + " " + product.Price);
            }

            Console.WriteLine($"\nGreat! \n{createdProduct.Name} was properly created...\nNow we need to remove a product. " +
                $"You can just tell me the name of the product you want to removed.");
            Product deletedProduct = new Product();

            
            deletedProduct.Name = Console.ReadLine();
            

            repo.DeleteProductByName(deletedProduct.Name);  //delete

            Console.WriteLine("Let's make sure the update went through...");
            products = repo.ReadCatalogue();
            foreach (var product in products)
            {
                Console.WriteLine(product.Name + " " + product.Price);
            }
            Console.ReadLine();

            Product updatedProduct = new Product();
            Console.WriteLine("\nFantastic!\nAs a way of saying thanks, the GM said you can set the price of any product you want.\n" +
                "So what product do you want to alter?.");
            updatedProduct.Name = Console.ReadLine();
            Console.WriteLine("And what is the new price going to be ? ");
            updatedProduct.Price = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("And what is the new category supposed to be ? ");
            updatedProduct.CategoryID = Convert.ToInt32(Console.ReadLine());
            
            repo.UpdateProductPrice(updatedProduct.Name, updatedProduct.Price, 4);//update
            Console.WriteLine("Great! Thanks for all of your help. Have a nice day!");
        }
    }
}
