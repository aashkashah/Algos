using System;
using System.Collections.Generic;
using System.Linq;

namespace Algos
{
    public class Graphv2
    {
        int vertices;
        LinkedList<int>[] adjList;

        public Graphv2(int vertices)
        {
            this.vertices = vertices;

            adjList = new LinkedList<int>[vertices];
            //Initialize lists
            for (int i = 0; i < vertices; i++)
            {
                adjList[i] = new LinkedList<int>();
            }
        }

        public void addEdge(int source, int destination)
        {
            //add forward edge
            adjList[source].AddFirst(destination);
            //add backward edge
            adjList[destination].AddFirst(source);
        }


        public void checkifTree()
        {

            printGraph();

            //If cycle is not present and graph is connected, its a tree

            //create visited array
            bool[] visited = new bool[vertices];

            //DFS for original graph start from first vertex
            bool isCycle = isCycleUtil(0, visited, -1);

            if (isCycle)
            {
                //graph is disconnected, its not tree
                Console.WriteLine("Given Graph is not Tree");
                return;
            }

            //check the visited array to determine graph is connected or not
            for (int i = 0; i < vertices; i++)
            {
                if (!visited[i])
                {
                    Console.WriteLine("Given Graph is not Tree");
                    return;
                }
            }
            //if here, means graph is tree
            Console.WriteLine("Given Graph is Tree");
        }

        bool isCycleUtil(int currVertex, bool[] visited, int parent)
        {

            //add this vertex to visited vertex
            visited[currVertex] = true;

            //visit neighbors except its direct parent
            for (int i = 0; i < adjList[currVertex].Count(); i++)
            {
                int vertex = adjList[currVertex].ElementAt(i);
                //check the adjacent vertex from current vertex
                if (vertex != parent)
                {
                    //if destination vertex is not its direct parent then
                    if (visited[vertex])
                    {
                        //if here means this destination vertex is already visited
                        //means cycle has been detected
                        return true;
                    }
                    else
                    {
                        //recursion from destination node
                        if (isCycleUtil(vertex, visited, currVertex))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void printGraph()
        {
            for (int i = 0; i < vertices; i++)
            {
                LinkedList<int> nodeList = adjList[i];
                Console.WriteLine("Vertex connected from vertex: " + i);

                for (int j = 0; j < nodeList.Count(); j++)
                {
                    Console.WriteLine("->" + nodeList.ElementAt(j));
                }
                Console.WriteLine();
            }
        }

        public static void Main(string[] args)
        {
            Graphv2 graph = new Graphv2(5);
            graph.addEdge(1, 0);
            graph.addEdge(3, 1);
            graph.addEdge(3, 2);
            graph.addEdge(3, 4);
            graph.checkifTree();
            Console.WriteLine("----------------------------");
            Graphv2 graph1 = new Graphv2(5);
            graph1.addEdge(1, 0);
            graph1.addEdge(3, 1);
            graph1.addEdge(3, 2);
            graph1.addEdge(3, 4);
            graph1.addEdge(4, 0);
            graph1.checkifTree();
            Console.WriteLine("----------------------------");
            Graphv2 graph2 = new Graphv2(5);
            graph2.addEdge(1, 0);
            graph2.addEdge(3, 1);
            graph2.addEdge(3, 2);
            graph2.checkifTree();
        }
    }
}
