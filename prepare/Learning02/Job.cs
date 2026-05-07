public class Job //Job-name of class  public-can be used anywhere by anyone in the program
{  //calss- tells C# I am defining new data type

      //Member Variables
    public string _company = ""; //where this person worked  ""-has nothing in for strings instead of null.(cleaner looking)
    public string _jobTitle = ""; //What they did at this Job
    public int _startYear = 0; //When they started working at this job  0-placeholder until they input something
    public int _endYear = 0; //When they ended working at job
    
 //Methods
    public void Display() //Displays Job info in my desired format  void-return nothing
    {   //print whatever was inputed for these variables
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}"); //$-treat anything in curly braces as a variable and insert it's inputed value {here} 
  //Console.WriteLine -Print

    }
}