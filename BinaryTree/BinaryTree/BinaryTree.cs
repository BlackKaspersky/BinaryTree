using System.Security;
using System.Threading;

namespace BinaryTree
{
    public class BinaryTree<T> where T : IComparable
    {
        private BinaryTreeNode<T>? Root { get; set; }

        int count;

        public int Count { get { return count; } }

        public void Clear()
        {
            Root = null;
            count = 0;
        }

        public void Add(T item)
        {
            if (Root == null)
                Root = new BinaryTreeNode<T>(item);
            else
                AddTo(Root, item);
            count++;
        }

        private void AddTo(BinaryTreeNode<T> node, T item)
        {
            if(item.CompareTo(node.Data) < 0)
            {
                if (node.Left == null)
                    node.Left = new BinaryTreeNode<T>(item);

                else
                    AddTo(node.Left, item);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new BinaryTreeNode<T>(item);
                else
                    AddTo(node.Right,item);
            }
                
        }

        public bool Contains(T item)
        {
            BinaryTreeNode<T> parent;
            return FindWithParent(item, out parent) != null;

        }

        private BinaryTreeNode<T> FindWithParent(T item, out BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T>? current = Root;
            parent = null;
            while (current != null)
            {
                int result = current.CompareTo(item);
                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if(result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }
            return current!;
        }
        public bool Remove(T value)
        {
            BinaryTreeNode<T> current, parent;

            
            current = FindWithParent(value, out parent);

            if (current == null)
            {
                return false;
            }

            count--;

           
            if (current.Right == null)
            {
                if (parent == null)
                {
                    Root = current.Left;
                }
                else
                {
                    int result = parent.CompareTo(current.Data);
                    if (result > 0)
                    {
                        
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        
                        parent.Right = current.Left;
                    }
                }
            }
            
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (parent == null)
                {
                    Root = current.Right;
                }
                else
                {
                    int result = parent.CompareTo(current.Data);
                    if (result > 0)
                    {
                        
                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        
                        parent.Right = current.Right;
                    }
                }
            }
            
            else
            {
                
                BinaryTreeNode<T> leftmost = current.Right.Left;
                BinaryTreeNode<T> leftmostParent = current.Right;
                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost; leftmost = leftmost.Left;
                }
                
                leftmostParent.Left = leftmost.Right;
                
                var Left = current.Left;
                leftmost.Right = current.Right;
                if (parent == null)
                {
                    Root = leftmost;
                }
                else
                {
                    int result = parent.CompareTo(current.Data);
                    if (result > 0)
                    {
                        
                        parent.Left = leftmost;
                    }
                    else if (result < 0)
                    {
                        
                        parent.Right = leftmost;
                    }
                }
            }

            return true;
        }
    }
}
