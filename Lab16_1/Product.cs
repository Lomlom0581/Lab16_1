using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab16_1
{
    public class Product
    {
        
        public int Id;       

        public string Name;  
               
        public double Price { get; set; } 

        public Product() { }

        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
                
        public override string ToString() => $" Код товара:{Id}, Наименование:{Name}, Цена:{Price}";

    }
}
