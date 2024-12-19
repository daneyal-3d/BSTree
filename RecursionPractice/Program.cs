using System;




class Program {
    
    static int power(int x, int y)
    {
        if (y == 1)
        {
            return x;
        }

        if (y == 0)
        {
            return 1;
        }
        
        return x*power(x, y-1); //5*5*5
    }



    
    static void Main()
    {
        int result = power(5, 3);
        Console.WriteLine(result);
        Console.ReadLine();
        
    }
}