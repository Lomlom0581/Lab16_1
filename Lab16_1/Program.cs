using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace Lab16_1
{
    class Program
    {

        private static string GetFilePath()
        {           
            string UserFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            return System.IO.Path.Combine(UserFolder, "Desktop", "Products.json");
        }

        public static void Exercice1()
        {            
            Product[] products = new Product[5];

            for (int i = 0; i < 5; i++)
            {                 
                Console.Write($"Укажите код товара {i + 1} [{i + 1}]:");
                string input = Console.ReadLine();
                int id = input == "" ? i + 1 : int.Parse(input);

                Console.Write($"Укажите название товара {i + 1}: ");
                string name = Console.ReadLine();

                Console.Write($"Укажите цену товара {i + 1}: ");
                double price = double.Parse(Console.ReadLine());

                products[i] = new Product(id, name, price);
            }
         
            string SerializedText = Newtonsoft.Json.JsonConvert.SerializeObject(products);
                        
            string FilePath = GetFilePath();
                       
            File.WriteAllText(FilePath, SerializedText);

            Console.Write($"Данные записаны в : {FilePath}");
            Console.ReadKey();
        }


        public static void Exercice2()
        {

            string FilePath = GetFilePath();
            Console.WriteLine("Пытаемся счиать данные с файла: " + FilePath);

            if (!File.Exists(FilePath))
            {
                Console.WriteLine("Файл не найден! " + FilePath);
                Console.WriteLine("Сначала выполните запись");
                Console.ReadKey();
            }

            string Json = File.ReadAllText(FilePath);
                        
            Product[] rez = JsonConvert.DeserializeObject<Product[]>(Json);

            Product MostExpensveOne = null;

            for (int i = 0; i < rez.Count(); i++)
            {
                Product Current = rez[i];
                                
                if (MostExpensveOne == null) MostExpensveOne = Current;
                                
                if (Current.Price > MostExpensveOne.Price) MostExpensveOne = Current;
            }

            Console.WriteLine("Самое дорогое: " + MostExpensveOne.Name + " - " + MostExpensveOne.Price);
            Console.ReadKey();

        }


        static void Main(string[] args)
        {

            Console.WriteLine("Программа упаковывает данные о товарах в JSON и умеет потом считывать");

        begin:
            Console.WriteLine("Укажите нужную операцию:\n  1 - записать\n  2 - считать\n  3 - выход");

            switch (Console.ReadLine())
            {
                case "1": Exercice1(); break;
                case "2": Exercice2(); break;
                case "3": return;
                default:
                    Console.WriteLine("Неверный ввод");
                    goto begin;
            }
        }
    }
}
