using System;

namespace Dijkstran_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            string Start_Node= Console.ReadLine();
            string Distanation_Node = Console.ReadLine();
            Dijkstran dijkstran = new Dijkstran();
            dijkstran.Print(Start_Node, Distanation_Node);
        }
    }
}
