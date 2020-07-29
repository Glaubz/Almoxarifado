using System;
using Atividade_VI.Entities;

namespace Atividade_VI
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();

            bool loop = true;

            while(loop == true){

                Console.WriteLine("STOCK MENU");
                System.Console.Write("\n1 - Add a product\n2 - Delete a product\n3 - Edit a product\n4 - Stock list\n0 - Exit\n\nChoose an option: ");
                int option = int.Parse(Console.ReadLine());
                //Lembrar de colocar um tratamento caso não seja colocado um numero como opção

                try{
                    switch(option){
                        case 1:
                            Product product = productData();
                            stock.addProduct(product);
                            break;
                        case 2:
                            stock.deleteProduct();
                            break;
                        case 3:
                            stock.editProduct();
                            break;
                        case 4:
                            stock.relatory();
                            break;
                        case 0:
                            loop = false;
                            break;
                        default:
                            throw new StockException("\n! - Insert a valid option!\n");
                    }
                }
                catch(Exception m){
                    Console.WriteLine(m.Message);
                }

                //End of loop treatement
                Console.Write("Press key to continue...");
                if(loop == true){
                    Console.ReadKey(); //Case continue press key
                    Console.Clear();
                }
                else{
                    Console.Clear();
                    Console.WriteLine("Goodbye o/"); //Case exit, goodbye messenge
                }

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
