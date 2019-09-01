using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeOrder
{
    class Student : IComparable
    {
        // Implement the Student class here
        // ...
        private string firstName, lastName, degree;
        private int grade;

        public Student(string _firstName, string _lastName, string _degree, int _grade)
        {
            this.firstName = _firstName;
            this.lastName = _lastName;
            this.degree = _degree;
            this.grade = _grade;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1} ({2}) Grade: {3}", this.lastName, this.firstName, this.degree, this.grade);
        }

        public int CompareTo(object obj)
        {
            int compareResult;

            Student student = (Student)obj;
            int firstNameResult = string.Compare(student.firstName, this.firstName, StringComparison.Ordinal);

            //First names in descending order, followed by...
            if (firstNameResult == 0)
            {
                //Grades in ascending order, followed by...
                if (this.grade > student.grade)
                {
                    compareResult = 1;
                }
                else if (this.grade < student.grade)
                {
                    compareResult = -1;
                }
                else
                {
                    //Degrees in ascending order, followed by...
                    int degreeResult = string.Compare(this.degree, student.degree, StringComparison.Ordinal);
                    if (degreeResult == 0)
                    {
                        //Last names in ascending order.
                        int lastNameResult = string.Compare(this.lastName, student.lastName, StringComparison.Ordinal);
                        compareResult = lastNameResult;
                    }
                    else
                    {
                        compareResult = degreeResult;
                    }
                }
            }
            else
            {
                compareResult = firstNameResult;
            }

            return compareResult;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = {
                new Student("Jane", "Smith", "Bachelor of Engineering", 6),
                new Student("John", "Smith", "Bachelor of Engineering", 7),
                new Student("John", "Smith", "Bachelor of IT", 7),
                new Student("John", "Smith", "Bachelor of IT", 6),
                new Student("Jane", "Smith", "Bachelor of IT", 6),
                new Student("John", "Bloggs", "Bachelor of IT", 6),
                new Student("John", "Bloggs", "Bachelor of Engineering", 6),
                new Student("John", "Bloggs", "Bachelor of IT", 7),
                new Student("John", "Smith", "Bachelor of Engineering", 6),
                new Student("Jane", "Smith", "Bachelor of Engineering", 7),
                new Student("Jane", "Bloggs", "Bachelor of IT", 6),
                new Student("Jane", "Bloggs", "Bachelor of Engineering", 6),
                new Student("Jane", "Bloggs", "Bachelor of Engineering", 7),
                new Student("Jane", "Smith", "Bachelor of IT", 7),
                new Student("John", "Bloggs", "Bachelor of Engineering", 7),
                new Student("Jane", "Bloggs", "Bachelor of IT", 7),
            };

            Array.Sort(students);
            foreach (Student student in students)
            {
                Console.WriteLine("{0}", student);
            }

            Console.WriteLine("\nPress enter to exit.");
            Console.ReadLine();
        }
    }
}