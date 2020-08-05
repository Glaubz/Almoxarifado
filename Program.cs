using System;
using Atividade_VI.Entities;
using System.Collections.Generic;
using System.IO;

namespace Atividade_VI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = listUp();
            Stock stock = new Stock(products);

            bool loop = true;

            while(loop == true){

                try{
                    Console.WriteLine("STOCK MENU");
                    System.Console.Write("\n1 - Add a product\n2 - Delete a product\n3 - Edit a product\n4 - Stock list\n0 - Exit\n\nChoose an option: ");
                    int option = int.Parse(Console.ReadLine());
                    //Lembrar de colocar um tratamento caso não seja colocado um numero como opção
                
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
                            throw new StockException("! - Insert a valid option!");
                    }
                }
                catch(Exception m){
                    Console.WriteLine("\n" + m.Message);
                }

                //End of loop treatement
                Console.Write("\nPress key to continue...");
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
            string code = Console.ReadLine();
            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Product product = new Product(name, code, quantity);
            return product;
        }

        static List<Product> listUp(){
            List<Product> products = new List<Product>();
            if(File.Exists("BD_Products")){
                string origin = "BD_Products";
                using(StreamReader sr = new StreamReader(origin)){
                    string line;
                    while((line = sr.ReadLine()) != null){
                        string[] infos = line.Split(";");
                        string code = infos[0];
                        string name = infos[1];
                        int quantity = int.Parse(infos[2]);

                        Product product = new Product(name, code, quantity);
                        products.Add(product);
                    }
                }
                return products;
            }
            return products;
        }

    }
}
