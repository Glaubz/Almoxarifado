namespace Atividade_VI.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public int Quantity { get; set; }

        public Product(){
        }

        public Product(string name, int code, int quantity){
            Name = name;
            Code = code;
            Quantity = quantity;
        }

        public override string ToString(){
            return "Name: " + Name + "\n" + "Code: " + Code + "\n" + "Quantity: " + Quantity;
        }

    }
}