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
    
    
    public int Height()
    {
        return CalculateHeight(root);
    }

    private int CalculateHeight(Node<T> node)
    {
        if (node == null)
            return -1; // Height of an empty tree is -1

        int leftHeight = CalculateHeight(node.Left);
        int rightHeight = CalculateHeight(node.Right);

        return 1 + Math.Max(leftHeight, rightHeight);
    }
    
    
    // Delete a node using the following code
    
    public void Delete(T item)
    {
        root = DeleteNode(root, item);
    }

    private Node<T> DeleteNode(Node<T> node, T item)
    {
        if (node == null)
        {
            Console.WriteLine($"Item {item} not found in the tree.");
            return null;
        }

        if (item.CompareTo(node.Data) < 0)
        {
            // Item is in the left subtree
            node.Left = DeleteNode(node.Left, item);
        }
        else if (item.CompareTo(node.Data) > 0)
        {
            // Item is in the right subtree
            node.Right = DeleteNode(node.Right, item);
        }
        else
        {
            // Node to be deleted found
            Console.WriteLine($"Deleting {item}");

            // Case 1: No children (leaf node)
            if (node.Left == null && node.Right == null)
            {
                return null;
            }

            // Case 2: One child
            if (node.Left == null)
            {
                return node.Right;
            }
            else if (node.Right == null)
            {
                return node.Left;
            }

            // Case 3: Two children
            // Find the in-order successor (smallest value in the right subtree)
            Node<T> successor = FindMin(node.Right);
            node.Data = successor.Data; 

            // Delete the in-order successor
            node.Right = DeleteNode(node.Right, successor.Data);
        }

        return node;
    }

    private Node<T> FindMin(Node<T> node)
    {
        while (node.Left != null)
        {
            node = node.Left;
        }
        return node;
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
        Console.WriteLine("\nHeight of the tree: " + tree.Height());
        

        // Output accumulated messages
        // Console.WriteLine(buffer.ToString());
    }
}