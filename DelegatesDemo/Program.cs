using System;

namespace DelegatesDemo
{
    class Program
    {
        // Delegate signature: returns void, takes a string as a parameter
        delegate void DispStrDelegate(string param);

        static void Main(string[] args)
        {
            // Get a line of text to convert
            Console.Write("Please enter some text: ");
            string text = Console.ReadLine();

            // Instantiate delegate objects
            DispStrDelegate saying1 = new DispStrDelegate(Capitalize);
            DispStrDelegate saying2 = new DispStrDelegate(LowerCased);
            DispStrDelegate saying3 = new DispStrDelegate(Console.WriteLine);

            // Call delegates one after the other
            saying1(text);
            saying2(text);
            saying3(text);

            // Demonstrating multicast delegate
            DispStrDelegate sayings = new DispStrDelegate(Capitalize);
            sayings += new DispStrDelegate(LowerCased);
            sayings += new DispStrDelegate(Console.WriteLine);
            Console.WriteLine("Running multi cast directly: ");
            sayings(text);

            // Pass delegate to a method
            Console.WriteLine("Running by passing delegate to another method: ");
            RunMyDelegate(sayings, text);

            // Lambda expression as delegate
            Console.WriteLine("Running by passing in a lambda expression: ");
            RunMyDelegate((string t) => { Console.WriteLine("Lambda: " + t); }, text);

            // Lambda without type
            Console.WriteLine("Lambda without type: ");
            RunMyDelegate((t) => { Console.WriteLine("Lambda: " + t); }, text);

            // Lambda without parentheses
            Console.WriteLine("Lambda without parentheses: ");
            RunMyDelegate(t => { Console.WriteLine("Lambda2: " + t); }, text);

            // Adding a lambda expression to a multicast delegate
            sayings += t => { Console.WriteLine("Lambda3: " + t); };
            Console.WriteLine("Three Delegates and a lambda: ");
            RunMyDelegate(sayings, text);
        }

        // Method that capitalizes a string
        static void Capitalize(string text)
        {
            Console.WriteLine("Your input capitalized --> " + text.ToUpper());
        }

        // Method that lowercases a string
        static void LowerCased(string text)
        {
            Console.WriteLine("Your input lower cased --> " + text.ToLower());
        }

        // Method that takes a delegate as an argument
        static void RunMyDelegate(DispStrDelegate del, string textParam)
        {
            del(textParam);
        }
    }
}
