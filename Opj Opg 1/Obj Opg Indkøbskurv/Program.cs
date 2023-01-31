using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Xml.Linq;

namespace Obj_Opg_Indkøbskurv
{
    internal class Program
    {
        static BackgroundWorker Worker;

        static List<Products> products = new List<Products>();
        static List<string> itemList = new List<string>();
        static void Main(string[] args)
        {
            Worker = new BackgroundWorker();
            Worker.DoWork += Timer;
            Worker.WorkerSupportsCancellation = true;
            products = getFile();
            Nav();
            Console.Read();
        }

        private static void Timer(object sender, DoWorkEventArgs e)
        {
            int counter = 0;
            for (; ; )
            {
                if (Worker.CancellationPending)
                {
                    break;
                }
                
                if (counter >= 10)//10 sekunder
                {
                    List<string> temp = new List<string>();
                    temp = itemList.ToList();
                    foreach (string item in temp)
                    {
                        foreach (var pro in products)
                        {
                            if (item.Split('x')[0].Trim() == pro.Title && pro.IsLimited)
                            {
                                itemList.Remove(item);
                            }
                        }
                    }
                    break;
                }
                counter++;
                Thread.Sleep(1000);
            }
        }

        public static void Display()
        {
            double sum = 0;
            int counter = 0;
            Console.WriteLine($"Shopping bag");
            foreach (string item in itemList)
            {
                Console.WriteLine($"{counter}. {item}");
                counter++;
                foreach (var litem in products)
                {
                    if (litem.Title == item.Split('x')[0].Trim())
                    {
                        sum += litem.Price * Convert.ToInt32(item.Split('x')[1].Trim());
                    }
                }
            }
            Console.WriteLine($"Sum of Shopping bag: {sum}$");
        }

        public static void Nav()
        {
            int counter = 0;
            Console.WriteLine("Available tickets and merchandise:");
            foreach (var item in products)
            {
                Console.WriteLine($"{counter} {item.Title}, {item.Stock}, {item.Price}");
                counter++;
            }
            Display();
            Console.WriteLine("Choose what to do");
            Console.WriteLine("1: Add item to your cart \n2: Remove item from cart \n3: Clear cart of all items");
            switch (Console.ReadLine())
            {
                case "1":
                    Add();
                    Console.WriteLine("Added to your cart");
                    break;
                case "2":
                    Remove();
                    Console.WriteLine("Removed from your cart");
                    break;
                case "3":
                    Clear();
                    itemList.Clear();
                    Console.WriteLine("Your cart have been cleared");
                    break;
                default:
                    Nav();
                    break;
            }
        }

        public static void Add()
        {
            Console.WriteLine("\nChose what you want to add to your cart:");
            string item = Console.ReadLine();
            int index = Convert.ToInt32(item);
            Console.WriteLine($"How many {products[index].Title} do you want?");
            string amount = Console.ReadLine();
            if (!amount.ToCharArray().Any(x => !char.IsDigit(x)))
            {
                itemList.Add($"{products[index].Title} x {amount}");
                products[index].Stock -= Convert.ToInt32(amount);
            }
            if (products[index].IsLimited == true)
            {
                Worker.RunWorkerAsync();
            }
            Nav();
        }

        public static void Remove()
        {
            Console.WriteLine("\nChose what item you want to remove from your cart:");
            string item = Console.ReadLine();
            int index = Convert.ToInt32(item);
            foreach (var items in products)
            {
                if (items.Title == itemList[index].Split('x')[0])
                {
                    items.Stock += Convert.ToInt32(itemList[index].Split('x')[1].Trim());
                }
            }
            itemList.RemoveAt(index);
            if (products[index].IsLimited == true)
            {
                Worker.CancelAsync();
            }
            Nav();
        }

        public static void Clear()
        {
            foreach (string item in itemList)
            {
                foreach (var litem in products)
                {
                    if (litem.Title == item.Split('x')[0])
                    {
                        litem.Stock += Convert.ToInt32(item.Split('x')[1].Trim());
                    }
                    if (litem.IsLimited == true)
                    {
                        Worker.CancelAsync();
                    }
                }
            }
            itemList.Clear();
            Nav();
        }

        static List<Products> getFile()
        {
            string filename = Path.Combine(Environment.CurrentDirectory, "Data/products.json");
            string data = File.ReadAllText(filename);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            return JsonSerializer.Deserialize<List<Products>>(data, options);
        }
    }
}
