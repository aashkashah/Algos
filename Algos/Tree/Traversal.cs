using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Node = Algos.Tree.Node;

namespace Algos
{
    public class Traversal
    {
        // DF traversals :
        // Inorder, PreOrder, PostOrder

        static void PreOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.data);
            PreOrder(node.left);
            PreOrder(node.right);
        }

        static void InOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            InOrder(node.left);
            Console.WriteLine(node.data);
            InOrder(node.right);
        }

        static void PostOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            PostOrder(node.left);
            PostOrder(node.right);
            Console.WriteLine(node.data);
        }

		static void LevelOrderSpiralTraversal(Node root)
		{
			if (root == null)
			{
				return;
			}

			Stack<Node> s1 = new Stack<Node>();
			Stack<Node> s2 = new Stack<Node>();
			
			s1.Push(root);

			while (s1.Count > 0 || s2.Count > 0)
			{	
				while (s1.Count > 0)
				{
					Node node = s1.Pop();
					Console.WriteLine(node.data + " ");

					if (node.right != null)
					{	
						s2.Push(node.right);
					}
					if (node.left != null)
					{	
						s2.Push(node.left);
					}
				}

				while (s2.Count > 0)
				{
					Node node = s2.Pop();
					Console.WriteLine(node.data + " ");

					if (node.left != null)
					{
						s1.Push(node.left);
					}
					if (node.right != null)
					{
						s1.Push(node.right);
					}
				}	
			}
		}

        /// Finds the maximum path sum across the tree 
        static int MaxPathSum(Node root)
        {
            int[] max = new int[1];
            max[0] = int.MinValue;
            MaxPathSumHelper(root, max);

            return max[0];
        }

        static int MaxPathSumHelper(Node root, int[] max)
        {
            if (root == null)
            {
                return 0;
            }

            int left = MaxPathSumHelper(root.left, max);
            int right = MaxPathSumHelper(root.right, max);

            int current = Math.Max(root.data, Math.Max(root.data + left, root.data + right));

            max[0] = Math.Max(max[0], Math.Max(current, left + root.data + right));

            return current;
        }

        /// Print left view of a binary tree
        /// https://www.geeksforgeeks.org/print-left-view-binary-tree/
        static void PrintLeftView(Node root)
        {
            Queue<Node> queue = new Queue<Node>();

            root.level = 0;
            queue.Enqueue(root);
            Console.Write(root.data + " ");

            int previousLevel = 0;

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();

                if (node.level > previousLevel)
                {
                    Console.Write(node.data + " ");
                    previousLevel = node.level;
                }

                if(node.left != null)
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

        }

        /// Check if binary tree is skewed
        /// Skewed binary tree: If each node has only one child or none
        static bool IsBinaryTreeSkewed(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();

                if (node.left != null && node.right != null)
                {
                    return false;
                }

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            return true;
        }

        public void Main_Tree()
		{
			Node tree = Tree.CreateTree();

            //LevelOrderSpiralTraversal(tree);

            //int maxPathSum = MaxPathSum(tree);

            // PrintLeftView(tree);

            //bool isTreeSkewed = IsBinaryTreeSkewed(tree);
            //Console.WriteLine(isTreeSkewed);
            
        }
    }
}
