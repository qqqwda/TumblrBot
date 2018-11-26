using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> ejemplo = new List<string>();
            ejemplo.Add("Z");
            ejemplo.Add("A");
            ejemplo.Add("B");
            ejemplo.Add("A");
            ejemplo.Add("B");
            ejemplo.Add("A");
            ejemplo.Add("A");
            ejemplo.Add("U");
            foreach (var item in ejemplo)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------");
            var ans = ejemplo.Distinct();
            foreach (var item in ans)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
