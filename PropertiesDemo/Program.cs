using System;
using System.Collections.Generic;

namespace PropertiesDemo
{
    public class Student
    {
        // Auto-implemented properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentNumber { get; set; }
        public string Major { get; set; }
        public double Average { get; private set; } // Read-only property

        // Private fields for scores
        private int score1;
        private int score2;
        private int score3;

        // Fully defined properties for scores
        public int Score1
        {
            get { return score1; }
            set { score1 = value; CalcAverage(); }
        }

        public int Score2
        {
            get { return score2; }
            set { score2 = value; CalcAverage(); }
        }

        public int Score3
        {
            get { return score3; }
            set { score3 = value; CalcAverage(); }
        }

        // Method to calculate the average score
        public void CalcAverage()
        {
            Average = (score1 + score2 + score3) / 3.0;
        }

        // Override ToString() to display student information
        public override string ToString()
        {
            return $"{FirstName} {LastName}, Major: {Major}, Average: {Average:F2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // List to store students
            List<Student> students = new List<Student>();
            string doAnother;

            // Loop to collect student information
            do
            {
                Student st = new Student();

                st.FirstName = GetInput("First Name");
                st.LastName = GetInput("Last Name");
                st.Major = GetInput("Major");
                st.StudentNumber = GetInput("Student Number");
                st.Score1 = int.Parse(GetInput("Score 1"));
                st.Score2 = int.Parse(GetInput("Score 2"));
                st.Score3 = int.Parse(GetInput("Score 3"));

                students.Add(st);

                doAnother = GetInput("\nDo another (y/n)?");
            } while (doAnother.ToLower() == "y");

            // Display all student information
            Console.WriteLine("\nStudent Averages:");
            foreach (Student st in students)
            {
                Console.WriteLine(st.ToString());
            }
        }

        // Method to get input from the user with a prompt
        static private string GetInput(string prompt)
        {
            Console.Write($"{prompt}: ");
            return Console.ReadLine();
        }
    }
}
