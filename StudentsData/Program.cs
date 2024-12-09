using System ;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "students.csv";
        List<Student> students = new List<Student>();

        // Placeholder string, used whenever we ask Yes/No
        string ans;

        bool repeat = true;

        // Check if file exists and create if needed
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Creating the Database, Please Hold...");
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Student Database:\n");
                }
                Console.WriteLine("Database Created, Title Created.");
            }
            else
            {
                Console.WriteLine("Database already Exists, Skipping to Reading step.");
            }

            // Read existing data from file
            Console.WriteLine("Reading Current Data...");
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            // Ask user if they want to add new students
            Console.WriteLine("Would you Like to add new Students? Y/N");
            ans = Console.ReadLine().ToUpper(); // Accept both lower or upper case
            while (ans != "Y" && ans != "N")
            {
                Console.WriteLine("Please Enter Either Y or N");
                ans = Console.ReadLine().ToUpper();
            }

            if (ans == "Y")
            {
                while (repeat)
                {
                    // Create a new student and add to the list
                    Student newStudent = new Student();
                    newStudent.CreateStudent();
                    students.Add(newStudent);

                    // Ask if the user wants to add another student
                    Console.WriteLine("Would you like to add another student? Y/N");
                    ans = Console.ReadLine().ToUpper();
                    while (ans != "Y" && ans != "N")
                    {
                        Console.WriteLine("Please enter Y or N.");
                        ans = Console.ReadLine().ToUpper();
                    }
                    if (ans == "N")
                     repeat = false;
                }

                // Append new students to the database file
                Console.WriteLine("Adding Students to Database...");
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Student student in students)
                    {
                        writer.WriteLine(student.ToString());
                    }
                }
            }
        }
        catch (IOException ioEx)
        {
            Console.WriteLine($"An I/O error has occurred: {ioEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"A general error has occurred: {ex.Message}");
        }
    }
}

