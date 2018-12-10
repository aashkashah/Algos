using System;
using System.Collections.Generic;
using System.Linq;
using Coordinate = Algos.Matrix.Coordinate;

namespace Algos
{
    public class ShortestPath
    {
        static int ShortestPathInMaze(int[,] maze, Coordinate start, Coordinate end)
        {
            Queue<Coordinate> queue = new Queue<Coordinate>();
            HashSet<Coordinate> visitedLocations = new HashSet<Coordinate>();
            visitedLocations.Add(new Coordinate() { X = 0, Y = 0 });

            List<Coordinate> nextMoves = FindNextMoves(maze, start, ref visitedLocations);
            AddNextMovesToQueue(ref queue, nextMoves);
            int path = 0;

            while (queue.Count > 0)
            {
                Coordinate location = queue.Dequeue();
                if(location.X == end.X && location.Y == end.Y)
                {
                    break;
                }

                nextMoves = FindNextMoves(maze, location, ref visitedLocations);
                AddNextMovesToQueue(ref queue, nextMoves);
                path++;
            }

            return path;
        }

        static List<Coordinate> FindNextMoves(int[,] maze, Coordinate currLocation, ref HashSet<Coordinate> visitedLocations)
        {
            List<Coordinate> moves = new List<Coordinate>();

            if(currLocation.X > 0)
            {
                if (!IsLocationVisited(ref visitedLocations, currLocation.X - 1, currLocation.Y) &&
                    maze[currLocation.X - 1, currLocation.Y] == 1)
                {
                    var coor = new Coordinate() { X = currLocation.X - 1, Y = currLocation.Y };

                    // add to next moves and mark visited
                    moves.Add(coor);
                    visitedLocations.Add(coor);
                }
            }

            if (currLocation.Y > 0)
            {
                if (!IsLocationVisited(ref visitedLocations, currLocation.X, currLocation.Y - 1) &&
                    maze[currLocation.X, currLocation.Y - 1] == 1)
                {
                    var coor = new Coordinate() { X = currLocation.X, Y = currLocation.Y -1 };

                    // add to next moves and mark visited
                    moves.Add(coor);
                    visitedLocations.Add(coor);
                }
            }


            if (currLocation.X < maze.GetLength(0) - 1)
            {
                if (!IsLocationVisited(ref visitedLocations, currLocation.X + 1, currLocation.Y) &&
                maze[currLocation.X + 1, currLocation.Y] == 1)
                {
                    var coor = new Coordinate() { X = currLocation.X + 1, Y = currLocation.Y };

                    // add to next moves and mark visited
                    moves.Add(coor);
                    visitedLocations.Add(coor);
                }
            }

            if (currLocation.Y < maze.GetLength(1) - 1)
            {
                if (!IsLocationVisited(ref visitedLocations, currLocation.X, currLocation.Y + 1) &&
                maze[currLocation.X, currLocation.Y + 1] == 1)
                {
                    var coor = new Coordinate() { X = currLocation.X, Y = currLocation.Y + 1 };

                    // add to next moves and mark visited
                    moves.Add(coor);
                    visitedLocations.Add(coor);
                }
            }

            return moves;
        }

        static bool IsLocationVisited(ref HashSet<Coordinate> visitedLocations, int x, int y)
        {
            Coordinate coor = new Coordinate() { X = x, Y = y };

            if (visitedLocations.Contains(coor))
            {
                return true;
            }

            return false;
        }

        static void AddNextMovesToQueue(ref Queue<Coordinate> queue, List<Coordinate> nextMoves)
        {
            foreach (Coordinate location in nextMoves)
            {
                queue.Enqueue(location);
            }
        }

        public void Main()
        {
            int[,] matrix = new int[,] 
            {
                { 1, 0, 1, 1, 1, 1, 0, 1, 1, 1 },
                { 1, 0, 1, 0, 1, 1, 1, 0, 1, 1 },
                { 1, 1, 1, 0, 1, 1, 0, 1, 0, 1 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 0, 1, 1, 1, 0, 1, 0 },
                { 1, 0, 1, 1, 1, 1, 0, 1, 0, 0 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 1, 1, 1, 1, 0, 1, 1, 1 },
                { 1, 1, 0, 0, 0, 0, 1, 0, 0, 1 }
            };

            var path = ShortestPathInMaze(matrix, new Coordinate() { X = 0, Y = 0 }, new Coordinate() { X = 3, Y = 4 });
            Console.WriteLine(path);
        }
    }
}
