using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace CRUDprojectV2
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductRepository repo = new ProductRepository();
            Console.WriteLine("Welcome to Best Buy! I understand you're here to  update are catalogue.\n" +
                "Let's get started with showing you the current catalogue.");
            
            repo.ReadCatalogue();  //read
            Console.ReadLine();
            Console.WriteLine("\n Okay, so I was informed you needed to add a product, what's it called?");
            Product createdProduct = new Product();
            createdProduct.Name = Console.ReadLine();
            Console.WriteLine("Okay, what about the price?\n");

            repo.CreateProduct(createdProduct.Name, createdProduct.Price, 1); //create
            Console.WriteLine($"Okay, that completes the addition of {createdProduct.Name}. Let's make sure it went through.");
            repo.ReadCatalogue();
            Console.WriteLine($"\nGreat! \n{createdProduct.Name} was properly created...\n but now we need to remove a product. " +
                $"You can just tell me the name of the product you want to removed.");
            Console.ReadLine();
            Product deletedProduct = new Product();
            deletedProduct.Name = Console.ReadLine();

            repo.DeleteProductByName(deletedProduct.Name);  //delete
            Console.WriteLine("Let's make sure the update went through...");
            repo.ReadCatalogue();
            Console.ReadLine();

            Product updatedProduct = new Product();
            Console.WriteLine("\n Fantastic!\n As a way of saying thanks, the GM said you can set the price of any product you want.\n" +
                "So what product do you want to alter?.");
            updatedProduct.Name = Console.ReadLine();
            Console.WriteLine("And what is the new price going to be ? ");
            updatedProduct.Price = Convert.ToDecimal(Console.Read());
            Console.WriteLine("And what is the new category supposed to be ? ");
            updatedProduct.CategoryID = Convert.ToInt32(Console.Read());
            
            repo.UpdateProductPrice(updatedProduct.Name, updatedProduct.Price, 4);//update
            Console.WriteLine("Great! Thanks for all of your help. Have a nice day!");
        }
    }
}
