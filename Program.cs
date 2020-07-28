using System;
using Atividade_VI.Entities;

namespace Atividade_VI
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();

            Console.WriteLine("STOCK");
            System.Console.Write("\n1 - Add a product\n2 - Delete a product\n3 - Edit a product\n4 - Stock list\n0 - Exit\n\nChoose an option: ");
            int option = int.Parse(Console.ReadLine());

            try{
                switch(option){
                    case 1:
                        Product product = productData();
                        stock.addProduct(product);
                        break;
                    case 2:
                        Console.Write("To delete a product insert a name or a code: ");
                        string nameOrCode = Console.ReadLine();
                        stock.deleteProduct(nameOrCode);
                        break;
                    case 3:
                        Console.Write("To edit a product insert a name or a code: ");
                        nameOrCode = Console.ReadLine();
                        stock.editProduct(nameOrCode);
                        break;
                    default:
                        System.Console.WriteLine("Insert a valid option!\n");
                        break;
                }
            }
            catch(Exception m){
                Console.WriteLine(m.Message);
            }

        }

        static Product productData() //Function to receive product informations and return a product
        {
            Console.WriteLine("\nPRODUCT DATA");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Code: ");
            int code = int.Parse(Console.ReadLine());
            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Product product = new Product(name, code, quantity);
            return product;
        }

    }
}
