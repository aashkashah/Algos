using System;
using System.Collections.Generic;

namespace Algos
{
    public class Graph
    {
        // representing graphs:
        // edge list (array or list with vertex pairs/edges. good for knowing all edges), 
        // adjacency list (list of list or array of list. good for looking up all neighbors of a vertex),
        // adjacency matrix (N x N matrix form. good for looking up if there's a connection between two vertices)

        int V;
        public static Dictionary<int, List<int>> graph;
        public Dictionary<int, List<int>> adjList;
        
        /// Add an edge to a graph, provided source and dstination  
        public static void AddEdge(int source, int dest)
        {
            List<int> neighbors = graph[source];
            neighbors.Add(dest);

            graph[source] = neighbors;

            // add two directional connection since it's an un-directed graph impl.
            neighbors = graph[dest];
            neighbors.Add(source);

            graph[dest] = neighbors;
        }

        /// Find if an edge exists in a graph, returns a boolean 
        public static bool FindEdge(int source, int dest)
        {
            if (graph.ContainsKey(source))
            {
                List<int> neighbors = graph[source];
                if (neighbors.Contains(dest))
                {
                    return true;
                }
            }

            return false;
        }

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
}
