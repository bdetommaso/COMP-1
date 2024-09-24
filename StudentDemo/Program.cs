using System;

namespace StudentClassDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string doAnother;
            do
            {
                Student st = new Student();

                string firstName = GetInput("First Name: ");
                st.SetFirstName(firstName);

                string lastName = GetInput("Last Name: ");
                st.SetLastName(lastName);

                string major = GetInput("Major: ");
                st.SetMajor(major);

                string studentNum = GetInput("Student Number: ");
                st.SetStudentNumber(studentNum);

                int score1 = int.Parse(GetInput("Score 1: "));
                st.SetScore1(score1);

                int score2 = int.Parse(GetInput("Score 2: "));
                st.SetScore2(score2);

                int score3 = int.Parse(GetInput("Score 3: "));
                st.SetScore3(score3);

                Console.WriteLine(st.GetSummary());

                doAnother = GetInput("\nDo another (y/n): ");
            } while (doAnother.ToLower() == "y");
        }

        private static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }

    class Student
    {
        private string major;
        private int score1;
        private int score2;
        private int score3;
        private string firstName;
        private string lastName;
        private string studentNumber;
        private float average;

        public string GetMajor()
        {
            return major;
        }

        public void SetMajor(string major)
        {
            this.major = major;
        }

        public int GetScore1()
        {
            return score1;
        }

        public void SetScore1(int score1)
        {
            this.score1 = score1;
            Calc();
        }

        public int GetScore2()
        {
            return score2;
        }

        public void SetScore2(int score2)
        {
            this.score2 = score2;
            Calc();
        }

        public int GetScore3()
        {
            return score3;
        }

        public void SetScore3(int score3)
        {
            this.score3 = score3;
            Calc();
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public string GetStudentNum()
        {
            return studentNumber;
        }

        public void SetStudentNumber(string studentNumber)
        {
            this.studentNumber = studentNumber;
        }

        public float GetAverage()
        {
            return average;
        }

        public string GetSummary()
        {
            return firstName + " " + lastName + " (Student Number: " + studentNumber + ") " +
                "Major: " + major + " | Average Score: " + average;
        }

        private void Calc()
        {
            average = (score1 + score2 + score3) / 3.0f;
        }
    }
}
