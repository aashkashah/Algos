﻿using System;
using System.Collections.Generic;
using System.Linq;
using Node = Algos.Tree.Node;

namespace Algos
{
    public class TreeChallenges
    {
        /// checks if a tree is BST
        static bool checkBST(Node root) {
            return checkBSTHelper2(root, int.MinValue, int.MaxValue);
        }

        static bool checkBSTHelper(Node node, int min, int max)
        {
            // base case
            if (node == null) // ?
            {
                return true;
            }

            // recurse small pieces
            bool result = true;
            if (node.left != null)
            {
                if (node.left.data > node.data || node.left.data > max || node.left.data < min)
                {
                    return false;
                }
            }
            if (node.right != null)
            {
                if (node.right.data < node.data || node.right.data < min || node.right.data > max)
                {
                    return false;
                }
            }

            result = checkBSTHelper(node.left, min, node.data);
            result = result && checkBSTHelper(node.right, node.data, max);
            return result;
            
        }

        static bool checkBSTHelper2(Node node, int min, int max)
        {
            // base case
            if (node == null)
            {
                return true;
            }

            if (min < node.data && max > node.data)
            {
                return checkBSTHelper2(node.left, min, node.data) && checkBSTHelper2(node.right, node.data, max);
            }
            else
                return false;

        }

        /// Find the lowest common ancestor of two nodes in a tree
        static Node lca(Node root, int v1, int v2)
        {   
            Queue<Node> v1Path = new Queue<Node>();
            Queue<Node> v2Path = new Queue<Node>();

            v1Path = FindPath(root, v1, v1Path);
            v2Path = FindPath(root, v2, v2Path);

            // loop through queue and stop when nodes are uncommon,
            // return last common node
            Node previous = new Node();
            while (v1Path.Count != 0 && v2Path.Count() != 0)
            {
                if (v1Path.Peek().data != v2Path.Peek().data)
                {
                    return previous;
                }
                previous = v1Path.Dequeue();
                v2Path.Dequeue();
            }

            return previous;
        }

        /// LCA helper, finds path to a node and returns in a queue form 
        static Queue<Node> FindPath(Node root, int key, Queue<Node> path)
        {
            path.Enqueue(root);

            if (root.data == key)
            {   
                return path;
            }
            else
            {
                if (key < root.data)
                {
                    return FindPath(root.left, key, path);
                }
                else if (key > root.data)
                {
                    return FindPath(root.right, key, path);
                }
            }
            return null; // when will this hit ?
        }

        /// Convert tree to a mirror image of itself
        static Node MirrorImageATree(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();
                SwapChildNodes(node);

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            return root;
        }

        // Mirror image sub function to swap child nodes 
        static Node SwapChildNodes(Node node)
        {
            if (node != null)
            {
                Node temp = node.left;
                node.left = node.right;
                node.right = temp;
            }

            return node;
        }

        /// Prints the tree nodes in a level order traversal
        static void LevelOrder(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                Node node = queue.Dequeue();
                Console.WriteLine(node.data);

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
            
        }

        /// Insert given value into a BST and return pointer to the root
        static Node InsertIntoBST(Node root, int data)
        {
            InsertHelper(ref root, data);
            return root;
        }

        /// Insert node into BST helper 
        static void InsertHelper(ref Node root, int data)
        {
            if (data < root.data)
            {
                if (root.left == null)
                {
                    Node node = new Node() { data = data };
                    root.left = node;
                }
                else
                {
                    InsertIntoBST(root.left, data);
                }
            }
            else
            {
                if (root.right == null)
                {
                    Node node = new Node() { data = data };
                    root.right = node;
                }
                else
                {
                    InsertIntoBST(root.right, data);
                }
            }
        }

        /// Find sum of all leaf nodes at the level nearest to root 
        /// https://www.geeksforgeeks.org/sum-leaf-nodes-minimum-level/
        static int SumOfLeafNodeAtMinLevel(Node root)
        {
            int minLevel = FindMinLevel(root);
            Queue<Node> queue = new Queue<Node>();
            
            root.level = 0;
            queue.Enqueue(root);

            int sum = 0;

            while(queue.Count > 0)
            {
                Node node = queue.Dequeue();

                if (node.level < minLevel)
                {
                    if (node.left != null)
                    {
                        node.left.level = node.level + 1;
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        node.right.level = node.level + 1;
                        queue.Enqueue(node.right);
                    }
                }
                else if (node.level == minLevel)
                {
                    if(node.left == null && node.right == null)
                    {
                        sum += node.data;
                    }
                }
            }

            return sum;
        }
        
        /// Sum of leaf nodes helper to find the minimum level 
        static int FindMinLevel(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            root.level = 0;
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();

                if (node.left == null && node.right == null)
                {
                    return node.level;
                }

                if (node.left != null)
                {
                    node.left.level = node.level + 1;
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    node.right.level = node.level + 1;
                    queue.Enqueue(node.right);
                }
            }

            return 0;
        }


        /// Given 2 nodes, find the distance between them
        ///  https://www.geeksforgeeks.org/find-distance-between-two-nodes-of-a-binary-tree/
        static int FindDistanceBetweenTwoNodes(Node root, int firstNode, int secondNode)
        {
            Queue<Node> firstNodePath = FindPathNonBST(root, firstNode, new Queue<Node>());
            Queue<Node> secondNodePath = FindPathNonBST(root, secondNode, new Queue<Node>());

            while (firstNodePath.Count > 0 && secondNodePath.Count > 0)
            {
                if (firstNodePath.Peek().data != secondNodePath.Peek().data)
                {
                    // lca hit
                    break;
                }
                firstNodePath.Dequeue();
                secondNodePath.Dequeue();
            }

            int distance = 0;

            while (firstNodePath.Count > 0)
            {
                distance++;
                firstNodePath.Dequeue();
            }
            while (secondNodePath.Count > 0)
            {
                distance++;
                secondNodePath.Dequeue();
            }
            
            return distance;
        }

        static Queue<Node> FindPathNonBST(Node root, int key, Queue<Node> path)
        {
            path.Enqueue(root);

            if (root.data == key)
            {
                return path;
            }
            else
            {
                FindPathNonBST(root.left, key, path);
                FindPathNonBST(root.right, key, path);
            }

            return null;
        }
        
        public void Main_Tree(string[] args)
        {
            Node tree = Tree.CreateTree();

            //bool result = checkBST(tree);

            //Node lowestCommonAncentor = lca(tree, 10, 14);
            //Console.WriteLine(lowestCommonAncentor.data);

            //MirrorImageATree(tree);

            //LevelOrder(tree);

            //Node root = InsertIntoBST(tree, 8);

            var sum = SumOfLeafNodeAtMinLevel(tree);
            Console.WriteLine(sum);
        }
    }
}


// mirror image of a binary tree
// convert this to :
//              10
//      6                 15
//  2       7       11          18
//              9                   22

// this :
//              10
//      15                 6
// 18       11       7             2
//    22                9  


// level order traversal
// height of a binary tree
// bfs, dfs of a tree/graph

// sliding window
// trapping rain water