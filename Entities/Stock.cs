using System.Collections.Generic;
using System.Text;
using System.Linq; //Linq library to order the relatory in alphabetic order
using System.IO;

namespace Atividade_VI.Entities
{
    public class Stock
    {
        public List<Product> products { get; set; } = new List<Product>();
        
        public Stock(){
        }

        public Stock(List<Product> products){
            this.products = products;
        }

        public void addProduct(Product product){ //The method verify if the product already exists, if not the product is adding to the list of products
            bool alreadyExist = false;
            foreach(Product prod in products){
                if(product.Name == prod.Name){
                    alreadyExist = true;
                    throw new StockException("! - Already exists a product with this name");
                }
                else if(product.Code == prod.Code){
                    alreadyExist = true;
                    throw new StockException("! - Already exists a product with this code");
                }
            }
            if(!alreadyExist) products.Add(product);

            //The next lines include more products in the text archive
            FileInfo fi = new FileInfo("BD_Products");
            using(StreamWriter sw = fi.AppendText()){
                sw.WriteLine(product.formatString());
            }
        }

        public void editProduct(){
            isEmpty();
            string nameOrCode = this.nameOrCode();
            bool exist = false;
            using(StreamReader archive = new StreamReader("BD_Products")){
                StringBuilder text = new StringBuilder(); //StringBuilder to receive the new text to put in the archive
                foreach(Product product in products){
                    string line = archive.ReadLine();
                    if(nameOrCode == product.Name || nameOrCode == product.Code){
                        exist = true;
                        System.Console.Write($"\nProduct in edition\nName: {product.Name}\nCode: {product.Code}\nQuantity: {product.Quantity}\n");
                        string name = product.Name; //string to storage the old name of the product
                        System.Console.Write("\nInsert a new name: ");
                        product.Name = System.Console.ReadLine();
                        string code = product.Code; //string to storage the old name of the product
                        System.Console.Write("Insert a new code: ");
                        product.Code = System.Console.ReadLine();
                        int quantity = product.Quantity; //storage old number of quantity
                        System.Console.Write("Insert the updated quantity: ");
                        product.Quantity = int.Parse(System.Console.ReadLine());
                        
                        //Replacing the old attributes with the new informations
                        line = line.Replace(code, product.Code);
                        line = line.Replace(name, product.Name);
                        line = line.Replace(quantity.ToString(), product.Quantity.ToString());

                        System.Console.WriteLine($"\nName: {name}, Code: {code}, Quantity: {quantity} => edited to => Name: {product.Name}, Code: {product.Code}, Quantity: {product.Quantity}");
                    }
                    text.AppendLine(line); //Adding lines in the text
                }
                if(exist == false) throw new StockException("! - Not exist a product with this information");
                using(StreamWriter newArchive = new StreamWriter("BD_Products")){
                    newArchive.Write(text); //Rewriting the archive with the new text
                }
            }
        }

        public void deleteProduct(){
            isEmpty();
            string nameOrCode = this.nameOrCode();
            bool exist = false;
            //using(StreamReader archive = new StreamReader("BD_Products")){
                StringBuilder text = new StringBuilder();
                string[] archive = File.ReadAllLines("BD_Products");
                int i = 0;
                foreach(Product product in products){
                    if(nameOrCode == product.Name || nameOrCode == product.Code){
                        products.Remove(product);
                        System.Console.WriteLine($"\nProduct {product.Name}, Code {product.Code} removed");
                        exist = true;
                        break;
                    }
                    i++;
                }
                if(exist == false) throw new StockException("! - Not exist a product with this information");
                using(StreamWriter newArchive = new StreamWriter("BD_Products")){
                    for(int j=0; j<archive.Length; j++)
                    if(j != i) newArchive.WriteLine(archive[j]);
                }
            //}
        }

        public string nameOrCode(){
            System.Console.Write("\nInsert a name or code: ");
            string nameOrCode = System.Console.ReadLine();
            return nameOrCode;
        }

        public void relatory(){
            isEmpty();
            StringBuilder sb = new StringBuilder("\nSTOCK LIST\n\n");
            var products2 = products.OrderBy(x => x.Name); //Used method of Linq library to order the relatory with help of Lambda
            int quantTotal = 0;
            foreach(Product prod in products2){
                sb.AppendLine(prod.ToString()); //Put a ToString to receive the ToString text defined in the Product class
                sb.AppendLine();
                quantTotal += prod.Quantity;
            }
            sb.Append("Total amount of products: " + quantTotal);
            System.Console.WriteLine(sb.ToString());
        }

        public void isEmpty(){ //Method to verify if exist product is the stock
            if(products.Count == 0) throw new StockException("! - The stock is empty");
        }

        public void archive(){ //Inacabado
            using(StreamReader sr = new StreamReader("BD_Products")){
                string line;
                while((line = sr.ReadLine()) != null){
                    string[] vect = line.Split(";");
                }
            }
        }

    }
}