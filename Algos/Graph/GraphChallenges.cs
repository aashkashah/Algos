using System;
using System.Collections.Generic;
using System.Linq;
using Graph = Algos.Graph;

namespace Algos
{
    public class GraphChallenges
    {
        static List<int> FindShortestPath(Dictionary<int, List<int>> graph, int start, int end)
        {
            // dfs implementation
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();

            List<int> edges;
            graph.TryGetValue(start, out edges);
            queue.Enqueue(start);
            
            visited.Add(start);
            
            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                visited.Add(vertex);

                if (vertex == end)
                {
                    // save past nodes
                }

                graph.TryGetValue(vertex, out edges);

                foreach (var edge in edges)
                {
                    if (!visited.Contains(edge))
                    {
                        queue.Enqueue(edge);
                    }
                }
            }

            return null;
        }

        public struct Node
        {
            public int data;
            public List<Node> neighbors;
        }

        public class ConAndDisGraph
        {
            // best way to represent this graph ?
            // edge list, adjacency list ?
            // tree type structure ?

            public Node connectedNodes;
            public SortedSet<int> disconnectedNodes;
        }
        
        /// <summary>
        /// A bfs algo that finds shortest path to each node/vertex from a given node/vertex
        /// </summary>
        /// <param name="n">Numer of nodes</param>
        /// <param name="e">Number of edges</param>
        /// <param name="edges">Array of edges</param>
        /// <param name="s">Starting node</param>
        /// <returns>Array of distances from start position</returns>
        static int[] bfs(int n, int e, int[][] edges, int s)
        {   
            var graph = CreateGraph(n, e, edges, s);

            int[] distances = new int[n - 1];

            for (int i = 0; i < n; i++)
            {
                 distances[i] = FindShortestPath(graph, i + 1, s);
            }

            return distances;
        }

        static ConAndDisGraph CreateGraph(int n, int e, int[][] edges, int s)
        {
            ConAndDisGraph graph = new ConAndDisGraph();

            for (int i = 0; i < edges.Length; i++)
            {
                graph.connectedNodes.data = edges[i][0];

                // Find node to be inserted, if present add the neighbor to it
                

            }

            return null;
        }

        static int FindShortestPath(ConAndDisGraph graph, int start, int end)
        {
            // check in discon first as it can be faster ?
            // check in connected via bfs, if not found in connected it is -1 
            int distance = 0;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(graph.connectedNodes);
            
            while(queue.Count > 0)
            {
                Node node = queue.Dequeue();

                foreach(Node n in node.neighbors)
                {
                    distance = distance + 6;
                    if (n.data == end)
                    {
                        return distance;
                    }
                    else
                    {
                        queue.Enqueue(n);
                    }
                }
            }

            // could not find end node
            return -1;
        }


        /// <summary>
        /// Topological sort
        /// https://www.geeksforgeeks.org/given-sorted-dictionary-find-precedence-characters/
        /// </summary>


        public void Main()
        {
            Graph.AddVertex(1, new List<int>() { 2, 3, 7 });
            Graph.AddVertex(2, new List<int>() { 4, 5 });
            Graph.AddVertex(4, new List<int>() { 3 });
            Graph.AddVertex(5, new List<int>() { 3, 8 });
            Graph.AddVertex(8, new List<int>() { 10, 11 });
            
        }
    }
}
