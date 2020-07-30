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

        public void editProduct(){ //For savety the Quantity attribute is not editable, this attribute only change in case of add or remove a product
            if(products.Count == 0) throw new StockException("\n! - The stock is empty\n");
            string nameOrCode = this.nameOrCode();
            foreach(Product product in products){
                if(nameOrCode == product.Name || int.Parse(nameOrCode) == product.Code){
                    string name = product.Name; //string to storage the old name of the product
                    System.Console.Write("\nInsert a new name: ");
                    product.Name = System.Console.ReadLine();
                    int code = product.Code; //string to storage the old name of the product
                    System.Console.Write("Insert a new code: ");
                    product.Code = int.Parse(System.Console.ReadLine());
                    System.Console.WriteLine($"\nName: {name}, Code: {code} edited to Name: {product.Name},  Code: {product.Code}\n");
                    break;
                }
                else{
                    throw new StockException("\n! - The informed name or code doesn't exist in the list\n");
                }
            }
        }

        public void deleteProduct(){
            if(products.Count == 0) throw new StockException("\n ! - The stock is empty\n");
            string nameOrCode = this.nameOrCode();
            foreach(Product product in products){
                if(nameOrCode == product.Name || int.Parse(nameOrCode) == product.Code){
                    products.Remove(product);
                    System.Console.WriteLine($"\nProduct {product.Name}, Code {product.Code} removed");
                    break;
                }
                else{
                    throw new StockException("The informed name or code doesn't exist in the list\n");
                }
            }
        }

        public string nameOrCode(){
            System.Console.Write("\nInsert a name or code: ");
            string nameOrCode = System.Console.ReadLine();
            return nameOrCode;
        }

        public void relatory(){
            StringBuilder sb = new StringBuilder("\nCODE | NAME | QUANTITY\n");
            var products2 = products.OrderBy(x => x.Name); //Used method of Linq library to order the relatory with help of Lambda
            foreach(Product prod in products2){
                sb.AppendLine(prod.ToString()); //Put a ToString to receive the ToString text defined in the Product class
            }
            System.Console.WriteLine(sb.ToString());
        }

    }
}