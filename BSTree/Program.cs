using System;


class Node<T> where T : IComparable<T>
{
    public T Data;
    public Node<T> Left;
    public Node<T> Right;

    public Node(T data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}

class BSTree<T> where T : IComparable<T>
{
    public Node<T> root;

    public BSTree()
    {
        root = null;
    }
    
    
    private void DisplayInOrder(Node<T> node)
    {
        if (node != null)
        {
            DisplayInOrder(node.Left);
            Console.Write("->"+node.Data);
            DisplayInOrder(node.Right);
        }
    }

    public void Display()
    {
        DisplayInOrder(root);
    }

    private void insertItem(T item, ref Node<T> tree)
    {
        if (tree == null)
        {
            tree = new Node<T>(item);
            Console.WriteLine($"Inserted {item} at a new node.");
        }
        else if (item.CompareTo(tree.Data) < 0)  // compareTo returns -1 if item < Data
        {
            Console.WriteLine($"Inserting {item} to the left of {tree.Data}.");
            insertItem(item, ref tree.Left);
        }
        else if (item.CompareTo(tree.Data) > 0) // compareTo returns +1 if item > Data
        {
            Console.WriteLine($"Inserting {item} to the right of {tree.Data}.");
            insertItem(item, ref tree.Right);
        }
        else
        {
            Console.WriteLine($"Item {item} is already in the tree, skipping insertion.");
        }
    }

    public void InsertItem(T item)
    {
        insertItem(item, ref root);
    }
}

class Program
{
    static void Main()
    {
        BSTree<int> tree = new BSTree<int>();
       

        // Insert items
        tree.InsertItem(8);
        tree.InsertItem(3);
        tree.InsertItem(10);
        tree.InsertItem(1);
        tree.InsertItem(6);
        tree.InsertItem(3); // to test repeated value
        
        tree.Display();

        // Output accumulated messages
        // Console.WriteLine(buffer.ToString());
    }
}