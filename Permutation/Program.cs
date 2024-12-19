using System;




class Program {
    
    static int permutation(int n, int r)
    {
        if (n == 0 || r == 0) return -1;
        return factorial(n)/factorial(n-r);
    }
    
    static int factorial(int x){
        if(x == 0){return 1;}
        return x*factorial(x-1);
    }




    
    static void Main()
    {
        int result = permutation(3, 3);
        Console.WriteLine(result);
        Console.ReadLine();
        
    }
}