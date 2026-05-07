
//Holds a persons name and list of jobs

public class Resume //Class Shell - encapsulates the class. Everything fits inside it.
{
    public string _name = "";          // _jobs-tells that this list holds Job Objects?Instantiations
    public List<Job> _jobs = new List<Job>(); //creates actual empty list that can be added to


    public void Display()
    {
        //Displays persons name
        Console.WriteLine($"Name: {_name}");

        //Displays header for job section
        Console.WriteLine("Jobs:");

        foreach (Job job in _jobs) //loops though _jobs list one object at a time. Each loop it holds whatever the current object is in the list
        {
            job.Display(); //Calls the display method that belongs to each individual Job object/instance
        }

    }

}