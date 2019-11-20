using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleLinkedList2.models;
namespace DoubleLinkedList2
{
    class Program
    {
        static void Main(string[] args)
        {

            Car c1 = new Car("Porsche", "Panamera", Color.black);
            Car c2 = new Car("Audi", "Rs7", Color.white);

            DoubleLinkedList<Car> dll = new DoubleLinkedList<Car>();
            
            dll.Add(c1);
            dll.FindItem(c1);
            Console.WriteLine(dll);
            Console.ReadKey();
        }
    }
}
