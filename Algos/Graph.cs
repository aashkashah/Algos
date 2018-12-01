using System;
using System.Collections.Generic;
using System.Linq;

namespace Algos
{
    public static class Graph
    {
        public static Dictionary<int, List<int>> graph;

        public static void AddVertex(int vertex)
        {
            graph.Add(vertex, new List<int>());
        }
        
        public static void AddVertex(int vertex, List<int> neighbors)
        {
            graph.Add(vertex, neighbors);
        }
        
        public static void RemoveVertex(int vertex)
        {
            graph.Remove(vertex);
        }

        public static void RemoveEdge(int vertex, int neighbor)
        {
            List<int> edges;
            graph.TryGetValue(vertex, out edges);

            edges.Remove(neighbor);
            graph.Remove(vertex);
            graph.Add(vertex, edges);
        }
    }

    class GraphAlgo
    {
        // representing graphs:
        // edge list (array or list with vertex pairs/edges. good for knowing all edges), 
        // adjacency list (list of list or array of list. good for looking up all neighbors of a vertex),
        // adjacency matrix (N x N matrix form. good for looking up if there's a connection between two vertices)

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
        
        static List<int> FindShortestPath2(Dictionary<int, List<int>> graph, int start, int end)
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

        public static void Main2(string[] args)
        {
            Graph.AddVertex(1, new List<int>() { 2, 3, 7 });
            Graph.AddVertex(2, new List<int>() { 4, 5 });
            Graph.AddVertex(4, new List<int>() { 3 });
            Graph.AddVertex(5, new List<int>() { 3, 8 });
            Graph.AddVertex(8, new List<int>() { 10, 11 });


            // shortest path between two cities
            // most cost efficient flight path between two cities
        }
    }
}
