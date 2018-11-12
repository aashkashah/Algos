﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Algos
{
    class Node {
        public int data;
        public Node left;
        public Node right;
    }

    public class Tree
    {
        // checks if a tree is BST
        static bool checkBST(Node root) {
            return CheckBSTHelper2(root, int.MinValue, int.MaxValue);
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

        static bool CheckBSTHelper2(Node node, int min, int max)
        {
            // base case
            if (node == null)
            {
                return true;
            }

            if (min < node.data && max > node.data)
            {
                return CheckBSTHelper2(node.left, min, node.data) && CheckBSTHelper2(node.right, node.data, max);
            }
            else
                return false;

        }

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

        public static void Main(string[] args)
        {
            Node tree = CreateTree();

            // call tree traversal
            //bool result = checkBST(tree);

            // call lca
            //Node lowestCommonAncentor = lca(tree, 10, 14);
            //Console.WriteLine(lowestCommonAncentor.data);

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
            //  22                9  

            MirrorImageATree(tree);

        }

        static Node CreateTree()
        {
            // create tree
            //          10
            //    5            15
            // 2     7      12     18
            //          9      14

            Node tree = new Node()
            {
                data = 10,
                left = new Node()
                {
                    data = 5,
                    left = new Node()
                    {
                        data = 2
                    },
                    right = new Node()
                    {
                        data = 7,
                        right = new Node()
                        {
                            data = 9
                        }
                    }
                },
                right = new Node()
                {
                    data = 15,
                    left = new Node()
                    {
                        data = 12,
                        right = new Node()
                        {
                            data = 14
                        }
                    },
                    right = new Node()
                    {
                        data = 18
                    }
                }
            };

            return tree;
        }
    }
}
