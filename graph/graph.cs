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

        public void Connect(int index1, int index2)
        {
            if (!AllNodes.Contains(nodes[index1]) || !AllNodes.Contains(nodes[index2])) throw new ArgumentException();
            nodes[index1].Connect(nodes[index2]);
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
                node1.Connect(node2);
                nodes.Add(node2); 
            }
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