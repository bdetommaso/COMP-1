using System;

namespace StudentClassDemo
{
    public class Student
    {
        // Private fields
        private string studentNumber;
        private string studentFirstName;
        private string studentLastName;
        private int score1;
        private int score2;
        private int score3;
        private string major;

        //-------------------------------------
        // Constructors
        //-------------------------------------

        // Default constructor
        public Student() : this("Number Pending", "TBD", "TBD", -1, -1, -1, "Undeclared")
        {
        }

        // Single parameter constructor
        public Student(string sID)
            : this(sID, "TBD", "TBD", -1, -1, -1, "Undeclared")
        {
        }

        // First overloaded constructor
        public Student(string sID, string firstName, string lastName)
            : this(sID, firstName, lastName, -1, -1, -1, "Undeclared")
        {
        }

        // Second overloaded constructor
        public Student(string sID, string firstName, string lastName, int s1, int s2, int s3, string maj)
        {
            studentNumber = sID;
            studentFirstName = firstName;
            studentLastName = lastName;
            score1 = s1;
            score2 = s2;
            score3 = s3;
            major = maj;
        }

        //-------------------------------------
        // Methods
        //-------------------------------------

        // Getters for student data
        public string GetStudentNumber()
        {
            return studentNumber;
        }

        public string GetFirstName()
        {
            return studentFirstName;
        }

        public string GetLastName()
        {
            return studentLastName;
        }

        public string GetMajor()
        {
            return major;
        }

        //-------------------------------------
        // Destructor
        //-------------------------------------
        ~Student()
        {
            Console.WriteLine("Student {0} data no longer in memory!", studentNumber);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Using default constructor
            Student myStudent1 = new Student();
            Console.WriteLine("Default Constructor:");
            Console.WriteLine("Student Number: {0}", myStudent1.GetStudentNumber());
            Console.WriteLine("First Name: {0}", myStudent1.GetFirstName());
            Console.WriteLine("Last Name: {0}", myStudent1.GetLastName());
            Console.WriteLine("Student Major: {0}\n", myStudent1.GetMajor());

            // Using first overloaded constructor
            Student myStudent2 = new Student("S001", "John", "Smith");
            Console.WriteLine("Overloaded Constructor:");
            Console.WriteLine("Student Number: {0}", myStudent2.GetStudentNumber());
            Console.WriteLine("First Name: {0}", myStudent2.GetFirstName());
            Console.WriteLine("Last Name: {0}", myStudent2.GetLastName());
            Console.WriteLine("Student Major: {0}\n", myStudent2.GetMajor());

            // Using second overloaded constructor
            Student myStudent3 = new Student("S002", "Jane", "Doe", 85, 90, 95, "Mathematics");
            Console.WriteLine("Chained Constructor:");
            Console.WriteLine("Student Number: {0}", myStudent3.GetStudentNumber());
            Console.WriteLine("First Name: {0}", myStudent3.GetFirstName());
            Console.WriteLine("Last Name: {0}", myStudent3.GetLastName());
            Console.WriteLine("Student Major: {0}\n", myStudent3.GetMajor());

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
