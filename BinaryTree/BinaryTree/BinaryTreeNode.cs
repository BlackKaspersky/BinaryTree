namespace BinaryTree
{
    public  class BinaryTreeNode<T> where T : IComparable
    {

        public BinaryTreeNode<T>? Left { get; set; }
        public BinaryTreeNode<T>? Right { get; set; }
        public T Data { get; private set; }
        
        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }
    }
}
