using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTreeApp.models;



namespace BinaryTreeApp
{
    class Program
    {
        static void Main(string[] args)
        {

            BinaryTree bt = new BinaryTree();
            bt.Add(20);
            bt.Add(4);
            bt.Add(40);
            bt.Add(7);


            Console.WriteLine("MIN= {0} ",bt.MinRecursive(null,40));

            Console.ReadKey();

        }
    }
}
