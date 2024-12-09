using System;
using System.Collections.Generic;



public class Student
{   //methods get and set
    public int ID { get; set; }
    public string fName { get; set; }
    public string lName { get; set; }
    public DateTime DOB { get; set; }
    public string Major { get; set; }
    public List<string> Classes { get; set; }
    public bool IsEnrolled { get; set; }

    // Parameterless constructor
    public Student()
    {
        ID = 0;
        fName = "Default";
        lName = "Student";
        DOB = DateTime.Now;
        IsEnrolled = true;
        Major = "Undeclared";
        Classes = new List<string>();
    }

    // Parameterized constructor
    public Student(int id, string firstName, string lastName, DateTime dob, bool isEnrolled, string major, List<string> classes)
    {
        ID = id;
        fName = firstName;
        lName = lastName;
        DOB = dob;
        IsEnrolled = isEnrolled;
        Major = major;
        Classes = classes;
    }

    public void CreateStudent()
    {
        // The Main collection
        bool validID = false;
        while (!validID)
        {
            Console.WriteLine("Please enter the student's ID:");
            try
            {
                ID = Convert.ToInt32(Console.ReadLine());
                validID = true;
            }
            catch
            {
                Console.WriteLine("This is not a valid ID.");
            }
        }

        Console.WriteLine("Please enter the student's first name:");
        fName = Console.ReadLine();

        Console.WriteLine("Please enter the student's last name:");
        lName = Console.ReadLine();

        int year = 0, month = 0, day = 0;
        while (year == 0)
        {
            Console.WriteLine("Please enter the student's year of birth:");
            try
            {
                year = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("This is not a valid year.");
            }
        }

        while (month == 0)
        {
            Console.WriteLine("Please enter the student's month of birth (numerical):");
            try
            {
                month = Convert.ToInt32(Console.ReadLine());
                if (month < 1 || month > 12)
                {
                    Console.WriteLine("Month must be between 1 and 12.");
                    month = 0;
                }
            }
            catch
            {
                Console.WriteLine("This is not a valid month.");
            }
        }

        while (day == 0)
        {
            Console.WriteLine("Please enter the student's day of birth:");
            try
            {
                day = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("This is not a valid day.");
            }
        }
        DOB = new DateTime(year, month, day);

        Console.WriteLine("Is this student enrolled? (Y/N)");
        string ans = Console.ReadLine().ToUpper();
        while (ans != "Y" && ans != "N")
        {
            Console.WriteLine("Please enter Y or N.");
            ans = Console.ReadLine().ToUpper();
        }

        IsEnrolled = ans == "Y";

        if (IsEnrolled)
        {
            Console.WriteLine("What is this student's major?");
            Major = Console.ReadLine();

            Console.WriteLine("How many classes is this student taking?");
            int numClasses = 0;
            while (numClasses <= 0)
            {
                try
                {
                    numClasses = Convert.ToInt32(Console.ReadLine());
                    if (numClasses <= 0) Console.WriteLine("Number of classes must be greater than zero.");
                }
                catch
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }

            Classes = new List<string>();
            for (int i = 0; i < numClasses; i++)
            {
                Console.WriteLine($"Enter class {(i + 1)}:");
                Classes.Add(Console.ReadLine());
            }
        }
        else
        {
            Major = "N/A";
            Classes = new List<string> { "N/A" };
        }
    }
     
     //TOString
    public override string ToString()
    {
        return $"ID: {ID}, First Name: {fName}, Last Name: {lName}, DOB: {DOB.ToString("MM/dd/yyyy")}, Major: {Major}, Classes: {Classes.Count}, Enrolled: {IsEnrolled}";
    }
}