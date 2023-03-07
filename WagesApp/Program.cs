// imports
using System;
using System.Collections.Generic;

namespace WagesApp
{
    class Program
    {
        // global variables
        static string topEarner = "";
        static int topEarnerHours = -1;

        // methods and/or function

        static string CheckFlag()
        {
            while (true)
            {
                // get users choice
                Console.WriteLine("Press <Enter> to add another employee or type 'XXX' to quit");
                string userInput = Console.ReadLine();

                // convert user input in uppercase
                userInput = userInput.ToUpper();

                if (userInput.Equals("XXX") || userInput.Equals(""))
                {
                    return userInput;
                }
                Console.WriteLine("Error: Please enter a correct choice");
            }
        }

        static string CheckName()
        {
            while (true)
            {
                // get name
                Console.WriteLine("Enter the employee's name:\n");
                string name = Console.ReadLine();

                if (!name.Equals(""))
                {
                    // convert name to capitalized name
                    name = name[0].ToString().ToUpper() + name.Substring(1);

                    return name;
                }
                Console.WriteLine("Error: You must enter a name for the employee");
            }
        }

        static void calculateWages(int totalHoursWorked, string employeeName)
        {
            // display the total weekly hours stored
            Console.WriteLine($"total hours worked: {totalHoursWorked}hrs");

            // add 5 hours if sumHours >30
            if (totalHoursWorked >= 30)
            {
                totalHoursWorked += 5;

                // display correct amount if 5 hours added
                Console.WriteLine($"5 bonus hours added: {totalHoursWorked}hrs");
            }

            if (totalHoursWorked > topEarnerHours)
            {
                topEarnerHours = totalHoursWorked;
                topEarner = employeeName;
            }

            //  calculate wage at a rate of $22/hr
            int wages = totalHoursWorked * 22;

            float tax = 0.07f;

            // calculate tax
            if (wages > 450)
            {
                tax = 0.08f;
            }

            // calculate final pay
            float finalPay = wages - (float)Math.Round(wages * tax, 2);

            // display the results of the calculations followed by two blank lines
            Console.WriteLine($"Weekly pay: {wages}\n Tax rate: {tax}\n Tax: {Math.Round(wages * tax, 2)}\n Final pay: {finalPay}\n\n\n");

        }

        static void OneEmployee()
        {
            List<string> weekDays = new List<string>() { "monday", "Tuesday", "Wednesday", "Thuraday", "Friday" };

            // Enter and store employee name
            string employeeName = CheckName();

            // Display employee name
            Console.WriteLine(employeeName);

            int sumHoursWorked = 0;

            // loop 5 times
            for (int dayIndex = 0; dayIndex < 5; dayIndex++)
            {
                Random randGen = new Random();

                // Randomly generate the number of hours worked by a worker each day
                int hoursWorked = randGen.Next(2, 7);

                // Assign the name of the day of the week to a variable called day
                string day = weekDays[dayIndex];

                // Store the total number of hours worked over the five days
                sumHoursWorked += hoursWorked;

                // Display the day and number of hours for each worker
                Console.WriteLine($"\thours worked on {day}: {hoursWorked}");
            }




            // call the CalculateWages()
            calculateWages(sumHoursWorked, employeeName);
        }


        // when run or main process

        static void Main(string[] args)
        {
            string flagMain = "";
            while (!flagMain.Equals("XXX"))
            {
                OneEmployee();

                flagMain = CheckFlag();
            }
            Console.WriteLine($"{topEarner} has the most hours worked: {topEarnerHours}hrs");
        }
    }
}
