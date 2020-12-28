using System;
using System.Collections.Generic;
using System.Text;

namespace SemesterWork_Algs
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphCreator gc = new GraphCreator();
            var graph = gc.CreateGraph();
            Performer performer = new Performer(graph);
            OutputResult(performer.perform());
            Console.ReadKey();
        }
        
        private static void OutputResult(List<Node> bestOrder)
        {
            Console.WriteLine("Best Oder:");
            var sb = new StringBuilder();
            foreach (var e in bestOrder)
                sb.Append(e.City + "->");
            Console.Write(sb + "\b" + "\b" + " " + " ");
        }
    }
}