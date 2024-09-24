using System;

class ParametersDemo
{
    // Pass by value
    public static void Test(int aValue)
    {
        aValue = 111;
        Console.WriteLine("In Test Value is {0}", aValue);
    }

    // Pass in a reference type
    public static void TestArray(int[] anArray)
    {
        anArray[0] = 111;
        Console.WriteLine("In Test Value is {0}", anArray[0]);
    }

    // Out parameter test
    public static void TestOut(out int aValue)
    {
        aValue = 222;
        Console.WriteLine("In TestOut Value is {0}", aValue);
    }

    // Ref parameter test
    public static void TestRef(ref int aValue)
    {
        aValue = 333;
        Console.WriteLine("In TestRef Value is {0}", aValue);
    }

    // Optional parameters
    public static void TestOptional(int aValue = 444)
    {
        Console.WriteLine("In TestOptional Value is {0}", aValue);
    }

    // Multiple and Named Parameters
    public static void TestMultiple(int aValue, int bValue = 222, int cValue = 333)
    {
        Console.WriteLine("Inside TestMultiple - Values: {0}, {1}, {2}", aValue, bValue, cValue);
    }

    // Overloaded methods
    public static void TestOverloaded(string strParam)
    {
        Console.WriteLine("String overload called with a value of {0}", strParam);
    }

    public static void TestOverloaded(int intParam, double dblParam)
    {
        Console.WriteLine("Numeric overload called with values of {0} and {1}", intParam, dblParam);
    }

    static void Main(string[] args)
    {
        // Pass by value
        Console.WriteLine("Pass by value test:");
        int testVal1 = 1;
        Console.WriteLine("Original value: {0}", testVal1);
        Test(testVal1);
        Console.WriteLine("Returned value: {0}", testVal1);

        // Pass in a reference type
        Console.WriteLine("\nPass in a reference type test:");
        int[] testArray = { 1, 1, 1 };
        Console.WriteLine("Original value: {0}", testArray[0]);
        TestArray(testArray);
        Console.WriteLine("Returned value: {0}", testArray[0]);

        // Out parameter test
        Console.WriteLine("\nOut parameter test:");
        int testVal2 = 2;
        Console.WriteLine("Original value: {0}", testVal2);
        TestOut(out testVal2);
        Console.WriteLine("Returned value: {0}", testVal2);

        // Ref parameter test
        Console.WriteLine("\nRef parameter test:");
        int testVal3 = 3;
        Console.WriteLine("Original value: {0}", testVal3);
        TestRef(ref testVal3);
        Console.WriteLine("Returned value: {0}", testVal3);

        // Optional parameter test
        Console.WriteLine("\nCalling TestOptional with a parameter");
        TestOptional(4);
        Console.WriteLine("\nCalling TestOptional with no parameter");
        TestOptional();

        // Multiple and named parameters
        Console.WriteLine("\nTestMultiple all three set");
        TestMultiple(1, 2, 3);

        Console.WriteLine("\nTestMultiple set just first 2");
        TestMultiple(1, 2);

        Console.WriteLine("\nTestMultiple with named parameter");
        TestMultiple(1, cValue: 3);

        // Overloaded methods
        Console.WriteLine("\nTest overloaded method with string");
        TestOverloaded("Test with string");

        Console.WriteLine("\nTest overloaded method with numbers");
        TestOverloaded(5, 5.5);
    }
}
