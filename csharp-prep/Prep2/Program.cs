using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage? ");
        string input = Console.ReadLine();

        int score = int.Parse(input);

        string lett_grade;

        if (score >= 90)
        {
            lett_grade ="A";
            }
        else if (score >= 80) 
        {
                lett_grade = "B";
            }
        else if (score >= 70) {
             lett_grade = "C";
        }
        else if (score >= 60)
        {
            lett_grade = "D";
        }
        else
        {
            lett_grade = "F";
        }
        Console.WriteLine($"Your grade: {lett_grade}");

        if (score >=70)
            Console.WriteLine("Well done, you passed this course! ");
        else
        {
            Console.Write("Sorry, you failed this course. Better luck next time.");
        }   
    }
}