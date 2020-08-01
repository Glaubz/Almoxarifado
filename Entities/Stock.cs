using System.Collections.Generic;
using System.Text;
using System.Linq; //Linq library to order the relatory in alphabetic order

namespace Atividade_VI.Entities
{
    public class Stock
    {
        public List<Product> products { get; set; } = new List<Product>();
        
        public Stock(){
        }

        public void addProduct(Product product){ //The method verify if the product already exists, if not the product is adding to the list of products
            bool alreadyExist = false;
            foreach(Product prod in products){
                if(product == prod){
                    alreadyExist = true;
                    throw new StockException("\n! - The product already exists\n");
                    //break;
                }
            }
            if(!alreadyExist) products.Add(product);
        }

        public void editProduct(){
            isEmpty();
            string nameOrCode = this.nameOrCode();
            bool exist = false;
            foreach(Product product in products){
                if(nameOrCode == product.Name || int.Parse(nameOrCode) == product.Code){
                    exist = true;
                    string name = product.Name; //string to storage the old name of the product
                    System.Console.Write("\nInsert a new name: ");
                    product.Name = System.Console.ReadLine();
                    int code = product.Code; //string to storage the old name of the product
                    System.Console.Write("Insert a new code: ");
                    product.Code = int.Parse(System.Console.ReadLine());
                    int quantity = product.Quantity; //storage old number of quantity
                    System.Console.Write("Insert the updated quantity: ");
                    product.Quantity = int.Parse(System.Console.ReadLine());
                    
                    System.Console.WriteLine($"\nName: {name}, Code: {code}, Quantity: {quantity} edited to Name: {product.Name}, Code: {product.Code}, Quantity: {product.Quantity}");
                    break;
                }
            }
            if(exist == false) throw new StockException("! - Not exist a product with this information");
        }

        public void deleteProduct(){
            isEmpty();
            string nameOrCode = this.nameOrCode();
            bool exist = false;
            foreach(Product product in products){
                if(nameOrCode == product.Name || int.Parse(nameOrCode) == product.Code){
                    products.Remove(product);
                    System.Console.WriteLine($"\nProduct {product.Name}, Code {product.Code} removed");
                    exist = true;
                    break;
                }
            }
            if(exist == false) throw new StockException("\n! - Not exist a product with this information");
        }

        public string nameOrCode(){
            System.Console.Write("\nInsert a name or code: ");
            string nameOrCode = System.Console.ReadLine();
            return nameOrCode;
        }

        public void relatory(){
            isEmpty();
            StringBuilder sb = new StringBuilder("\nSTOCK LIST\n");
            var products2 = products.OrderBy(x => x.Name); //Used method of Linq library to order the relatory with help of Lambda
            foreach(Product prod in products2){
                sb.AppendLine(prod.ToString()); //Put a ToString to receive the ToString text defined in the Product class
                sb.AppendLine();
            }
            System.Console.Write(sb.ToString());
        }

        public void isEmpty(){ //Method to verify if exist product is the stock
            if(products.Count == 0) throw new StockException("! - The stock is empty");
        }

    }
}