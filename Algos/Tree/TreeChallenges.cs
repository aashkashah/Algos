using System;
using System.Collections.Generic;
using System.Linq;

namespace Algos
{
    class Node {
        public int data;
        public Node left;
        public Node right;
    }

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

        public static void Main2(string[] args)
        {
            Node tree = CreateTree();

            //bool result = checkBST(tree);

            //Node lowestCommonAncentor = lca(tree, 10, 14);
            //Console.WriteLine(lowestCommonAncentor.data);

            //MirrorImageATree(tree);

            //LevelOrder(tree);

            //Node root = InsertIntoBST(tree, 8);



            Console.ReadLine();
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