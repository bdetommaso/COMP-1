using System;
using System.Text.RegularExpressions;

namespace CustomExceptionsDemo
{
    // Custom Exception Class
    public class SSNFormatException : Exception
    {
        public SSNFormatException() : base("Not a valid Social Security Number.")
        {
        }
    }

    // Class to handle Social Security Number validation
    public class SocialSecurityNumber
    {
        private string ssn;

        // Property to get and set SSN with validation
        public string SSN
        {
            get { return ssn; }
            set
            {
                string pattern = @"^\d{3}-\d{2}-\d{4}$"; // Regex pattern for valid SSN format
                
                if (Regex.IsMatch(value, pattern))
                {
                    ssn = value; // Set SSN if it matches pattern
                }
                else
                {
                    throw new SSNFormatException(); // Throw custom exception if SSN is invalid
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string doAnother;
            do
            {
                try
                {
                    // Prompt user for input and perform division
                    Console.Write("Please enter num1: ");
                    string num1str = Console.ReadLine();
                    int num1 = int.Parse(num1str);

                    Console.Write("Please enter num2: ");
                    string num2str = Console.ReadLine();
                    int num2 = int.Parse(num2str);

                    Console.WriteLine("Num1/Num2: {0}", num1 / num2);
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Not a number!");
                }
                catch (System.OverflowException)
                {
                    Console.WriteLine("Number is too large or small!");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Cannot divide by zero!");
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Error! " + exc.Message + "\nException type: " + exc.GetType());
                }
                finally
                {
                    Console.WriteLine("This section always executes!");
                }

                // Ask if user wants to enter another
                Console.Write("Do another (y/n): ");
                doAnother = Console.ReadLine();
            } while (doAnother.ToLower() == "y");

            // Now demonstrate custom exception for Social Security Number
            try
            {
                Console.Write("Please enter a social security number: ");
                string userInput = Console.ReadLine();
                SocialSecurityNumber ssn = new SocialSecurityNumber();
                ssn.SSN = userInput;
                Console.WriteLine("Valid SSN entered.");
            }
            catch (SSNFormatException ssnExc)
            {
                Console.WriteLine(ssnExc.Message);
            }
            catch (Exception exc)
            {
                Console.WriteLine("Error! " + exc.Message + "\nException type: " + exc.GetType());
            }
            finally
            {
                Console.WriteLine("This section always executes!");
            }
        }
    }
}
