using System.Collections.Generic;

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
                    throw new StockException("The product already exists");
                    //break;
                }
            }
            if(!alreadyExist) products.Add(product);
        }

        public void editProduct(string nameOrCode){ //For savety the Quantity attribute is not editable, this attribute only change in case of add or remove a product
            if(products == null) throw new StockException("The stock is empty");
            foreach(Product product in products){
                if(nameOrCode == product.Name || int.Parse(nameOrCode) == product.Code){
                    System.Console.Write("Insert a new name: ");
                    product.Name = System.Console.ReadLine();
                    System.Console.Write("Insert a new code: ");
                    product.Code = int.Parse(System.Console.ReadLine());
                    break;
                }
                else{
                    throw new StockException("The informed name or code doesn't exist in the list\n");
                }
            }
        }

        public void deleteProduct(string nameOrCode){
            if(products.Count == 0) throw new StockException("The stock is empty");
            foreach(Product product in products){
                if(nameOrCode == product.Name || int.Parse(nameOrCode) == product.Code){
                    products.Remove(product);
                    break;
                }
                else{
                    throw new StockException("The informed name or code doesn't exist in the list\n");
                }
            }
        }

        

    }
}