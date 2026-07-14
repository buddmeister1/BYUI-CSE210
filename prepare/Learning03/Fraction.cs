using System;
 
public class Fraction
{
    // Private attributes — hidden from the rest of the program.
    // No other class can reach in and change these directly.
    private int _top;
    private int _bottom;
 
    // Con 1: no par - defaults to 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
 
    // Con 2: one par - top is given, bottom defaults to 1
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }
 
    // Con 3: two par - both top and bottom are given
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }
 
    // Getter for _top
    public int GetTop()
    {
        return _top;
    }
 
    // Setter for _top
    public void SetTop(int top)
    {
        _top = top;
    }
 
    // Getter for _bottom
    public int GetBottom()
    {
        return _bottom;
    }
 
    // Setter for _bottom
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }
 
    // Returns fraction written as "top/bottom"
    public string GetFractionString()
    {
        return _top + "/" + _bottom;
    }
 
    // Returns fraction as a decimal
    public double GetDecimalValue()
    {
        // Cast _top to double first so we get decimal division not integer division
    
        return (double)_top / _bottom;
    }
}
 
