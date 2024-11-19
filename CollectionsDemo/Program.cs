using System;
using System.Collections.Generic;

namespace CollectionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store names
            List<string> Names = new List<string>();

            // Add initial names to the list
            Names.Add("Linus Torvalds");
            Names.Add("Donald Knuth");
            Names.Add("Grace Hopper");

            // Main loop to work with the list
            string doAnother;
            do
            {
                // Display the names
                DisplayNames(Names);

                // Show options to the user
                Console.Write("(A)dd, (R)emove, (S)earch: ");
                string operation = Console.ReadLine()?.ToUpper();

                switch (operation)
                {
                    case "A": // Add a name
                        Console.Write("Name: ");
                        Names.Add(Console.ReadLine());
                        break;

                    case "R": // Remove a name by index or value
                        Console.Write("Index or name: ");
                        string nameOrIndex = Console.ReadLine();
                        if (int.TryParse(nameOrIndex, out int index))
                        {
                            if (index > 0 && index <= Names.Count)
                            {
                                Names.RemoveAt(index - 1); // Convert to zero-based index
                            }
                            else
                            {
                                Console.WriteLine("Invalid index!");
                            }
                        }
                        else
                        {
                            if (Names.Remove(nameOrIndex))
                            {
                                Console.WriteLine($"'{nameOrIndex}' removed from the list.");
                            }
                            else
                            {
                                Console.WriteLine($"'{nameOrIndex}' not found in the list.");
                            }
                        }
                        break;

                    case "S": // Search for a name
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        int foundIndex = Names.IndexOf(name);
                        if (foundIndex != -1)
                        {
                            Console.WriteLine($"Index is {foundIndex + 1}"); // Display one-based index
                        }
                        else
                        {
                            Console.WriteLine("Name not found.");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid option! Please choose A, R, or S.");
                        break;
                }

                // Ask if the user wants to continue
                Console.Write("Do another (y/n)? ");
                doAnother = Console.ReadLine()?.ToLower();
            } while (doAnother == "y");
        }

        // Method to display the names in the list
        private static void DisplayNames(List<string> Names)
        {
            Console.WriteLine("\nCurrent Names in the List:");
            for (int i = 0; i < Names.Count; ++i)
            {
                Console.WriteLine($"{i + 1}: {Names[i]}"); // Display one-based index
            }
            Console.WriteLine($"\nCount of list: {Names.Count}");
            Console.WriteLine($"Capacity of list: {Names.Capacity}");
            Console.WriteLine();
        }
    }
}
