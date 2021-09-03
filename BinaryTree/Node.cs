namespace BinaryTree
{
    /// <summary>
    /// BinaryTree使用的節點
    /// </summary>
    public class Node
    {
        public int Value { get; set; }
        public Node Left, Right;

        public Node(int value)
        {
            Value = value;
            Left = Right = null;
        }
    }
}