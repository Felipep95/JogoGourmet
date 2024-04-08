using System;

namespace ObjectiveTestJogoGourmet.Model
{
    public class Node
    {
        private string Value { get; set; }
        private Node LeftChild { get; set; }
        private Node RightChild { get; set; }

        public Node(string data)
        {
            Value = data;
        }

        public bool IsLeaf()
        {
            return LeftChild == null && RightChild == null;
        }

        public void SetValue(string value)
        {
            Value = value;
        }

        public string GetValue()
        {
            return Value;
        }

        public void SetLeftChild(Node leftChild)
        {
            LeftChild = leftChild;
        }

        public Node GetLeftChild()
        {
            return LeftChild;
        }

        public void SetRightChild(Node rightChild)
        {
            RightChild = rightChild;
        }

        public Node GetRightChild()
        {
            return RightChild;
        }
    }
}
