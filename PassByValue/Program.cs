using System;

class Program
{
    public static void Test(int aValue)
    {
        aValue = 111;
        Console.WriteLine("In Test Value is {0}", aValue);
    }

    static void Main()
    {
        // Pass by value
        Console.WriteLine("Pass by value test:");
        int testVal1 = 1;
        Console.WriteLine("Original value: {0}", testVal1);
        Test(testVal1);
        Console.WriteLine("Returned value: {0}", testVal1);
    }
}
