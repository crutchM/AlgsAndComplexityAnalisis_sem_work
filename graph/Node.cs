using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace SemesterWork_Algs
{
    public class Node
    {
        public readonly List<Edge> Edges = new List<Edge>();
        public readonly string City;

        public Node(string name)
        {
            City = name;
        }
        

        public void Connect( Node node)
        {
            Edges.Add(new Edge(this, node));
            node.Edges.Add(new Edge(this, node));
        }

        public void Dissconnect(Edge edge)
        {
            Edges.Remove(edge);
        }

        public IEnumerable<Node> ConnectedNodes
        {
            get    
            {
                foreach (var e in Edges)
                    yield return e.To;
            }
        }
        
        public List<Node>IncidentNodes()
        {
            List<Node> neighbours = new List<Node>();
            foreach(var e in Edges)
                neighbours.Add(e.To);
            return neighbours;
        }

    }
}