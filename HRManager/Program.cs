using System;

namespace HRManager
{
    // Base class Employee
    public class Employee
    {
        // Properties for employee information
        public int EmpNum { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Virtual method to get pay summary
        public virtual string GetPaySummary()
        {
            return "No pay for base class employee.";
        }

        // Virtual property for pay summary
        public virtual string PaySummary
        {
            get { return "No pay for base class employee."; }
        }

        // Override ToString method to show employee info
        public override string ToString()
        {
            return $"Employee {FirstName} {LastName} (#{EmpNum})";
        }
    }

    // Derived class HourlyEmployee, inherits from Employee
    public class HourlyEmployee : Employee
    {
        // Property specific to HourlyEmployee
        public decimal HourlyRate { get; set; }

        // Constructor to set default hourly rate
        public HourlyEmployee() : base()
        {
            HourlyRate = 15.0M; // Default hourly rate
        }

        // Override method to provide hourly employee pay summary
        public override string GetPaySummary()
        {
            return "This employee is paid " + HourlyRate + " per hour.";
        }

        // Override virtual property
        public override string PaySummary
        {
            get { return "This employee is paid " + HourlyRate + " per hour."; }
        }

        // Override ToString method to include employee type
        public override string ToString()
        {
            return base.ToString() + " (Hourly Employee)";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creating a base class Employee
            Employee emp = new Employee
            {
                EmpNum = 1,
                FirstName = "Steve",
                LastName = "Jobs"
            };

            // Creating an HourlyEmployee which inherits from Employee
            HourlyEmployee hourEmp = new HourlyEmployee
            {
                EmpNum = 2,
                FirstName = "Bill",
                LastName = "Gates",
                HourlyRate = 20.00M
            };

            // Displaying pay summaries
            Console.WriteLine("emp.GetPaySummary: " + emp.GetPaySummary());
            Console.WriteLine("hourEmp.GetPaySummary: " + hourEmp.GetPaySummary());

            // Demonstrating polymorphism
            Employee emp2 = hourEmp;
            Console.WriteLine("emp2.GetPaySummary: " + emp2.GetPaySummary());

            // Using properties instead of methods
            Console.WriteLine("emp.PaySummary: " + emp.PaySummary);
            Console.WriteLine("hourEmp.PaySummary: " + hourEmp.PaySummary);
            Console.WriteLine("emp2.PaySummary: " + emp2.PaySummary);

            // Method hiding
            Console.WriteLine("emp.ToString: " + emp.ToString());
            Console.WriteLine("hourEmp.ToString: " + hourEmp.ToString());
            Console.WriteLine("emp2.ToString: " + emp2.ToString());
        }
    }
}
