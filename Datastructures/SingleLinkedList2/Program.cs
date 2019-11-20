using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleLinkedList2.models;

namespace SingleLinkedList2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Klasse Person testen 
            Person p1 = new Person("Eliaass", "ristl", new DateTime(2000, 4, 24));
            //Console.WriteLine(p);
            Person p2 = new Person("Chris", "Ho", new DateTime(2000, 4, 24));
            Person p3 = new Person("Tobi", "Flocke", new DateTime(2000, 4, 24));
            
            SingleLinkedList<Person> sll = new SingleLinkedList<Person>();
            
            if(sll.ChangeData(p1, new Person("Marko", "Becarevic", new DateTime(2001, 6, 19))))
            {

                Console.WriteLine("Daten wurden geändert");
            }
            if (sll.ChangeData(null, null))
            {
                
                Console.WriteLine("Es existieren keinen Daten");
            }
            //if (sll.Remove(null))
            //{
            //    Console.WriteLine("Person wurde entfernt");
            //}
            //else
            //{
            //    Console.WriteLine("Person wurde nicht entfernt");

            //}

            //if (sll.Remove(p1))
            //{
            //    Console.WriteLine("Person wurde entfernt");
            //}
            //else
            //{
            //    Console.WriteLine("Person wurde nicht entfernt-Liste ist leeer ");

            //}

            //sll.Add(p1);
            //sll.Add(p2);
            //sll.Add(p3);

            //bool istStartItem;
            //SingleLinkedListItem<Person> personbefore = sll.FindItemBeforeItem(p3, out istStartItem);

            //if (istStartItem)
            //{
            //    Console.WriteLine("Es existiert kein Eintrag vom ges. Eintrag");
            //    Console.WriteLine("Die Person ist im Starteintrag enthalten");
            //}
            //else if(personbefore != null)
            //{
            //    Console.WriteLine("Item vor Person existiert");
            //    Console.WriteLine("Person vor der gesuchten Person lautet:");
            //    Console.WriteLine(personbefore);
            //}
            //else
            //{
            //    Console.WriteLine("gesuchte Person ist in der Liste nicht vorhanden");
            //}


            ////1.Fall
            //if (sll.Remove(p3))
            //{
            //    Console.WriteLine("Person wurde entfernt");
            //}
            //else
            //{
            //    Console.WriteLine("Person wurde nicht entfernt-Liste ist leeer ");

            //}
            //Console.WriteLine(sll);


            //if (p1 == p2)
            //{
            //    Console.WriteLine("p und p2 sind gleich");
            //}
            //else
            //{
            //    Console.WriteLine("p und p2 sind nicht gleich");
            //}
            //if (p1.Equals(p2))
            //{
            //    Console.WriteLine("p und p2 sind gleich");
            //}
            //else
            //{
            //    Console.WriteLine("p und p2 sind nicht gleich");
            //}
            //Console.ReadKey();

            //Klasse SingleLinkedListItem testen
            // generische Klasse verwenden 
            //SingleLinkedListItem<Person> item = new SingleLinkedListItem<Person>(p1,null);
            //Console.WriteLine(item);

            ////Sll testen
            ////Methode Add
            //SingleLinkedList<Person> singleLL = new SingleLinkedList<Person>();
            //if (singleLL.Add(p1))
            //{
            //    Console.WriteLine("PERSON WURDE HINZUGEFÜGT");
            //}
            //else
            //{
            //    Console.WriteLine("Person konnte nicht hinzugefügt werden");
            //}
            //Console.WriteLine("komplete Sll ausgeben");
            //Console.WriteLine(singleLL);



            Console.ReadKey();

        }
    }
}
