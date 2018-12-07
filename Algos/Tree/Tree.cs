
namespace Algos
{
    public class Tree
    {
        public class Node
        {
            public int data;
            public int level;
            public Node left;
            public Node right;
        }

        public static Node CreateTree()
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
