using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)

    //Asks for input,reads in string, then translates to int
    {
        Console.Write("Enter your grade percentage? ");
        string input = Console.ReadLine();

        int score = int.Parse(input);


     //This determines what the letter grade is.
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
       
        //This determines what string
        int lastdigit = score % 10;      // % allows us to find(identify)the last digit of the number
        string sign;

        if (lastdigit >=7){
            sign = "+";
        }
        else if (lastdigit <3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        //A and F special cases
        if (lett_grade == "A" && sign == "+")
        {
            sign = "";
        }
        if (lett_grade == "F")
        {
            sign = "";
        }
         Console.WriteLine($"Your grade: {lett_grade}{sign}");

        if (score >=70)
            Console.WriteLine("Well done, you passed this course! ");
        else
        {
            Console.Write("Sorry, you failed this course. Better luck next time.");
        }   


    }
}