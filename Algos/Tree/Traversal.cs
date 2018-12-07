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


        public void Main_Tree(string[] args)
        {
            PreOrder(Tree.CreateTree());
        }
    }
}
