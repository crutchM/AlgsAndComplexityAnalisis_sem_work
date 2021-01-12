using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemesterWork_Algs
{
    public class Performer
    {
        private graph _graph = new graph();
        

        public Performer(graph graph)
        {
            _graph = graph;
        }

        public List<Node> Start()
        {
            List<Node> currentRoute = new List<Node>();
            currentRoute.Add(_graph[0]);
            var bestRoute = new List<Node>();
            FindBestRoute(ref bestRoute, currentRoute);
            return bestRoute;
        }
            
        
        
        private List<Node> FindBestRoute(ref List<Node> bestRoute, List<Node> currentRoute)
        {
            var prev = Copy(currentRoute);    
            if(currentRoute[0].City != "Челябинск") return null;
            if (currentRoute.Distinct().Count() == _graph.AllNodes.Count())
            {
                if (currentRoute[^1].ConnectedNodes.Contains(currentRoute[0]))
                {
                    bestRoute = currentRoute;
                    bestRoute.Add(bestRoute[0]);
                    return bestRoute;
                }
                return null;
            }
            var lastNode = currentRoute.Last();
            var neighbours = lastNode.IncidentNodes().Where(x => !currentRoute.Contains(x));
            foreach (var e in neighbours)
            {
                currentRoute.Add(e);
                var br = FindBestRoute(ref bestRoute, currentRoute);
                if (br != null) return br;
                currentRoute = prev;
            }
            return null;
        }

        private List<Node> Copy(List<Node> list)
        {
            var newList = new List<Node>();
            foreach (var e in list)
            {
                newList.Add(e);
            }
            return newList;
        }
            
        
        
        
    }
}