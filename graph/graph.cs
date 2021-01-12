using System;
using System.Collections.Generic;
using System.Linq;

namespace SemesterWork_Algs
{
    public class graph
    {
        private List<Node> nodes = new List<Node>();

        public Node this[int index]
        {
            get { return nodes[index]; }
        }
        
        public IEnumerable<Node> AllNodes
        {
            get
            {
                foreach (var e in nodes)
                    yield return e;
            }
        }
        

        private Node FindNode(string node)
            => nodes.FirstOrDefault(x => x.City == node);
        
        public void Connect(string node1, string node2)
        {
            FindNode(node1).Edges.Add(new Edge(FindNode(node1), FindNode(node2)));
        }

        public void AddNode(Node node1, Node node2)
        {
            if (nodes.Contains(node2)) return;
            if(node1 == null) 
                nodes.Add(node2);
            else
            {
                nodes.Add(node2); 
                Connect(node1.City,node2.City);
            }
        }

        public void AddNode(Node node)
        {
            if (nodes.Contains(node)) return;
            nodes.Add(node);
        }

        public void RemoveEdge(Edge edge)
        {
            edge.From.Dissconnect(edge);
        }

        void RemoveNode(Node node)
        {
            foreach(var e in node.Edges)
                node.Dissconnect(e);
            nodes.Remove(node);
        }

        public bool Cotains(Node node)
        {
            return nodes.Contains(node);
        }


        
    }
}