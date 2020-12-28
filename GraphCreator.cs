using System;
using System.Collections.Generic;
using System.IO;

namespace SemesterWork_Algs
{
    public class GraphCreator
    {
        private Dictionary<string, string[]> _textNodes = new Dictionary<string, string[]>();
        private graph _graph = new graph();
        
        public graph CreateGraph()
        {
            ReadFile();
            FillGraph();
            return _graph;
        }

        private void ReadFile()
        {
            StreamReader sr = new StreamReader("input.txt");
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                var str = line.Split(":");
                _textNodes.Add(str[0], str[1].Split(','));              
            }
        }

        private void FillGraph()
        {
            foreach (var e in _textNodes.Keys)
                _graph.AddNode(null, new Node(e));
            foreach (var e in _textNodes)
            {
                foreach (var c in e.Value)
                {
                    _graph.Connect(e.Key, c);
                }
            }
        }
       
    }
}