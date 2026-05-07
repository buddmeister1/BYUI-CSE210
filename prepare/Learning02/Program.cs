using System;

class Program
{
    static void Main(string[] args)
    {
        //Creating first job (instance/object)
        Job job1 = new Job(); //referencing Job class in different file
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2019;
        job1._endYear = 2022;

        //Creating second job (instance/object)
        Job job2 = new Job();
        job2._company = "Apple";
        job2._jobTitle = "Manager";
        job2._startYear = 2022;
        job2._endYear = 2023;

        //Calling Display method(action) on each object/instance
        job1.Display(); //Tells C# to display every object under job1 and job 2 as formatted in Job.cs file
        job2.Display();

        //Creating Resume Objects
        Resume myResume = new Resume();
        myResume._name ="Allison Rose";

        //Add jobs to resume list
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        //Access the first Job Title Directly  --Shows objects in objects works. 
        Console.WriteLine(myResume. _jobs[0]. _jobTitle);

        //Display full resume
        myResume.Display();

    }

}