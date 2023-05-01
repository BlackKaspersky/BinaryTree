namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var binaryTree = new BinaryTree<int>();
            binaryTree.Add(6);
            binaryTree.Add(10);
            binaryTree.Add(5);
            Console.WriteLine(binaryTree.Contains(5));
            Console.WriteLine(binaryTree.Count);
        }
    }
}