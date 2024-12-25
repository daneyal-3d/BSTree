using System;


class Film : IComparable
{
    private int quantity;
    private string director;
    private string title;
    
    public Film Left;
    public Film Right;

    public Film(int quantity, string director, string title)
    {
        this.quantity = quantity;
        this.director = director;
        this.title = title;
        Left = null;
        Right = null;
    }
    
    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }
    
    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    
    public string Director
    {
        get { return director; }
        set { director = value; }
    }

    public int CompareTo(object? obj)
    {
        Film other = (Film)obj;
        return Title.CompareTo(other.Title);
    }
}

class BSTree
{
    public Film root;

    public BSTree()
    {
        root = null;
    }
    
    private void DisplayInOrder(Film Film)
    {
        if (Film != null)
        {
            DisplayInOrder(Film.Left);
            Console.Write("->"+Film.Title);
            DisplayInOrder(Film.Right);
        }
    }

    public void Display()
    {
        DisplayInOrder(root);
    }

    private void insertItem(int quantity, string director, string title, ref Film tree)
    {
        if (tree == null)
        {
            tree = new Film(quantity, director, title);
            Console.WriteLine($"Inserted {title} at a new Film.");
        }
        else if (title.CompareTo(tree.Title) < 0)  // compareTo returns -1 if item < Title
        {
            Console.WriteLine($"Inserting {title} to the left of {tree.Title}.");
            insertItem(quantity, director, title, ref tree.Left);
        }
        else if (title.CompareTo(tree.Title) > 0) // compareTo returns +1 if item > Title
        {
            Console.WriteLine($"Inserting {title} to the right of {tree.Title}.");
            insertItem(quantity, director, title, ref tree.Right);
        }
        else
        {
            Console.WriteLine($"Item {title} is already in the tree, skipping insertion.");
        }
    }

    public void InsertItem(int quantity, string director, string title)
    {
        insertItem(quantity, director,  title, ref root);
    }
    
    
    public int Height()
    {
        return CalculateHeight(root);
    }

    private int CalculateHeight(Film Film)
    {
        if (Film == null)
            return -1; // Height of an empty tree is -1

        int leftHeight = CalculateHeight(Film.Left);
        int rightHeight = CalculateHeight(Film.Right);

        return 1 + Math.Max(leftHeight, rightHeight);
    }
    
    
    // Delete a Film using the following code
    
    public void Delete(string title)
    {
        root = DeleteFilm(root, title);
    }

    private Film DeleteFilm(Film Film, string title)
    {
        if (Film == null)
        {
            Console.WriteLine($"Item {title} not found in the tree.");
            return null;
        }

        if (title.CompareTo(Film.Title) < 0)
        {
            // Item is in the left subtree
            Film.Left = DeleteFilm(Film.Left, title);
        }
        else if (title.CompareTo(Film.Title) > 0)
        {
            // Item is in the right subtree
            Film.Right = DeleteFilm(Film.Right, title);
        }
        else
        {
            // Film to be deleted found
            Console.WriteLine($"Deleting {title}");

            // Case 1: No children (leaf Film)
            if (Film.Left == null && Film.Right == null)
            {
                return null;
            }

            // Case 2: One child
            if (Film.Left == null)
            {
                return Film.Right;
            }
            else if (Film.Right == null)
            {
                return Film.Left;
            }

            // Case 3: Two children
            // Find the in-order successor (smallest value in the right subtree)
            Film successor = FindMin(Film.Right);
            Film.Title = successor.Title; 

            // Delete the in-order successor
            Film.Right = DeleteFilm(Film.Right, successor.Title);
        }

        return Film;
    }

    private Film FindMin(Film Film)
    {
        while (Film.Left != null)
        {
            Film = Film.Left;
        }
        return Film;
    }
    
    
}

class Program
{
    static void Main()
    {
        BSTree tree = new BSTree();
       

        // Insert items
        tree.InsertItem(8, "Talha", "Up" );
        tree.InsertItem(8, "Talha", "Bahuballi" );
        tree.InsertItem(8, "Talha", "Chicken Run" );
        tree.InsertItem(8, "Talha", "Frozen" );
        tree.InsertItem(10, "Talha", "Up" ); // To test repetition
        
        
        tree.Display();
        Console.WriteLine("\nHeight of the tree: " + tree.Height());
        

        // Output accumulated messages
        // Console.WriteLine(buffer.ToString());
    }
}