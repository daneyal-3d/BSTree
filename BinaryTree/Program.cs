using System;




class Program {
    
    static void Sum(int x, ref int y)
    {
        x++;
        y++;
        return;
    }
    
    static void Main()
    {
        int x = 5;
        int y = 15;
        
        Console.WriteLine($"{x}, {y}"); // Prints 5, 15;
        Sum(x, ref y);
        Console.WriteLine($"{x}, {y}"); // Prints 5, 16;
        
        
        
    }
}