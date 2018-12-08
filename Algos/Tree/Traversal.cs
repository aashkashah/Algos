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

        public void Main_Tree(string[] args)
		{
			Node tree = Tree.CreateTree();

			LevelOrderSpiralTraversal(tree);
        }
    }
}
