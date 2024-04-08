using System;

namespace ObjectiveTestJogoGourmet.Model
{
    public class BinarySearchTree
    {
        public Node root;

        public void Insert(Node parentNode, string value, bool choice)
        {
            root = InsertNewNode(parentNode, value, choice);
        }

        public void ShowTree(Node rootNode)
        {
            if (rootNode != null)
            {
                Console.WriteLine(rootNode.GetValue());
                ShowTree(rootNode.GetLeftChild());
                ShowTree(rootNode.GetRightChild());
            }
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        private Node InsertNewNode(Node parentNode, string value, bool choice)
        {
            if (parentNode == null)
            {
                parentNode = new Node(value);
                return parentNode;
            }
            else if (choice)
            {
                parentNode.SetRightChild(InsertNewNode(parentNode.GetRightChild(), value, choice));
            }
            else
            {
                parentNode.SetLeftChild(InsertNewNode(parentNode.GetLeftChild(), value, choice));
            }

            return parentNode;
        }
    }
}
