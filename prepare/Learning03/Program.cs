using System;

class Program
{
    static void Main(string[] args)
    {
        //Test Constructors
 
        Fraction f1 = new Fraction();       // no-argument constructor -> 1/1
        Fraction f2 = new Fraction(5);      // one-argument constructor -> 5/1
        Fraction f3 = new Fraction(3, 4);   // two-argument constructor -> 3/4
        Fraction f4 = new Fraction(1, 3);   // two-argument constructor -> 1/3
 
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());
 
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());
 
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());
 
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());
 
        //Test Getter and Setter
 
        Fraction f5 = new Fraction();
        f5.SetTop(7);
        f5.SetBottom(8);
 
        Console.WriteLine("After using setters:");
        Console.WriteLine(f5.GetFractionString());
        Console.WriteLine(f5.GetDecimalValue());
 
        //Fraction Practice Loop
 
        Fraction randomFraction = new Fraction();
        Random random = new Random();
 
        for (int i = 1; i <= 20; i++)
        {
            // random.Next(1, 100) picks a whole number from 1-100 (but not including 100)
            //  Starting at 1 means the bottom number can never be 0, which would break down division
            
            int randomTop = random.Next(1, 100);
            int randomBottom = random.Next(1, 100);
 
            randomFraction.SetTop(randomTop);
            randomFraction.SetBottom(randomBottom);
 
            Console.WriteLine("Fraction " + i + ": string: " +
                randomFraction.GetFractionString() + " Number: " +
                randomFraction.GetDecimalValue());
        }
    }
}
