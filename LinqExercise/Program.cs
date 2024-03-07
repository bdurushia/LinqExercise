using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            PrintSpacing();

            Console.WriteLine($"Sum all of Numbers: {numbers.Sum()}");

            //TODO: Print the Average of numbers
            Console.WriteLine($"Average of numbers: {numbers.Average()}");

            //TODO: Order numbers in ascending order and print to the console
            PrintSpacing();
            Console.WriteLine("Numbers Ascending:");

            var numbersAscending = numbers.OrderBy(number => number).ToArray();
            foreach (var num in numbersAscending) { Console.WriteLine(num); }

            //TODO: Order numbers in descending order and print to the console
            PrintSpacing();
            Console.WriteLine("Nunbers Descending:");

            var numbersDescend = numbers.OrderByDescending(number => number).ToArray();
            foreach (var num in numbersDescend) { Console.WriteLine(num); }

            //TODO: Print to the console only the numbers greater than 6
            PrintSpacing();
            Console.WriteLine("Numbers Greater Than 6:");

            var greaterThanSix = numbers.Where(number => number > 6).ToArray();
            foreach (var num in greaterThanSix) { Console.WriteLine(num); }

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            PrintSpacing();
            Console.WriteLine("Only Print Four:");

            var onlyFour = numbers.OrderBy(number => number).Take(4).ToArray();
            foreach (var num in onlyFour) { Console.WriteLine(num); }

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            PrintSpacing();
            Console.WriteLine("Replace num at Index 4.\nOrder by descending:\n");

            var switchItUp = numbers.Select(number => number == numbers[4] ? number = 29 : number).OrderByDescending(number => number).ToArray();
            foreach (var num in switchItUp) { Console.WriteLine(num); }

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            PrintSpacing();
            Console.WriteLine("Employees: Printing Full Name for anyone who's first name starts with 'C' or 'S':\n");

            var employeesAthruZ = employees.OrderBy(employee => employee.FullName).ToList();

            foreach (var employee in employeesAthruZ)
                if (employee.FirstName.Contains("S") || employee.FirstName.Contains("C"))
                    Console.WriteLine(employee.FullName);
                else
                    Console.WriteLine(employee.FirstName);

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            PrintSpacing();
            Console.WriteLine("Employees Full Name and Age older than 26:\n");

            employees
                .Where(employee => employee.Age > 26)
                .OrderBy(employee => employee.Age)
                .ThenBy(employee => employee.FirstName)
                .ToList()
                .ForEach(employee => Console.WriteLine($"{employee.FullName},\nAge: {employee.Age}\n"));


            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            PrintSpacing();
            Console.WriteLine("Sum of employees' years of experience with a bunch contingencies.");

            var yoeSum = employees
                .Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35)
                .Sum(employee => employee.YearsOfExperience);

            Console.WriteLine($"YoE Sum: {yoeSum}");
            
            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            PrintSpacing();
            Console.WriteLine("Employee YoE average if YoE is <= 10 and Age is > 35:");

            var yoeAverage = employees
                .Where(emp => emp.YearsOfExperience <= 10 && emp.Age > 35)
                .Average(emp => emp.YearsOfExperience);

            Console.WriteLine($"YoE Average: {yoeAverage}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            PrintSpacing();

            employees
                .Append(new Employee("Mack", "McCall", 24, 2))
                .ToList().ForEach(employee => 
                    Console.WriteLine($"{employee.FullName},\n  Age: {employee.Age}\n  Years of Experience: {employee.YearsOfExperience}\n"));

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion

        public static void PrintSpacing() { Console.WriteLine("\n------------------------------------"); }
    }
}
