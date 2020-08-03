namespace Atividade_VI.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }

        public Product(){
        }

        public Product(string name, string code, int quantity){
            Name = name;
            Code = code;
            Quantity = quantity;
        }

        public string formatString(){
            return $"{Code};{Name};{Quantity}";
        }

        public override string ToString(){
            return "Name: " + Name + "\n" + "Code: " + Code + "\n" + "Quantity: " + Quantity;
        }

    }
}