using System;
using System.Xml.Linq;

public class ExceptionDemo
{
    public static void Run()
    {
        try
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Enter a divisor: ");
            int divisor = int.Parse(Console.ReadLine());

            int result = number / divisor;

            Console.WriteLine($"Result: {result}");
        }
        catch (FormatException)
        {
            Console.WriteLine("⚠️ You must enter valid numbers.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("⚠️ Cannot divide by zero.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Unexpected error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("✅ Operation attempted.");
        }
    }
}

public class StudentNotFoundException : Exception
{
    public StudentNotFoundException(string name)
        : base($"Student '{name}' not found.") { }
}



class ScoreTableExample
{
    public static void Main()
    {
        // [3 students][3 subjects]
        int[,] scores = new int[3, 3]
        {
            { 85, 92, 78 },  // Student 0
            { 88, 94, 91 },  // Student 1
            { 72, 84, 89 }   // Student 2
        };

        Console.WriteLine("📊 Student Scores:");

        for (int i = 0; i < scores.GetLength(0); i++) // rows
        {
            Console.Write($"Student {i + 1}: ");
            for (int j = 0; j < scores.GetLength(1); j++) // columns
            {
                Console.Write($"{scores[i, j]} ");
            }
            Console.WriteLine();
        }

        // Example: Average score of Student 2
        int total = 0;
        for (int j = 0; j < scores.GetLength(1); j++)
        {
            total += scores[2, j]; // student 2's scores
        }
        double average = total / (double)scores.GetLength(1);
        Console.WriteLine($"\n🎯 Student 3's average score: {average:F2}");
    }
}

