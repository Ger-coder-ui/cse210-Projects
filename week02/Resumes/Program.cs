using System;

class Program
{
    static void Main()
    {
        Resume myResume = new Resume("John Doe");

        Job job1 = new Job("Software Engineer", "Microsoft", 2019, 2022);
        Job job2 = new Job("Manager", "Apple", 2022, 2023);

        myResume.AddJob(job1);
        myResume.AddJob(job2);

        myResume.Display();
    }
}
