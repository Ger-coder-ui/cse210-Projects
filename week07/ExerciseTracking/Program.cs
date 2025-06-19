using System;
using System.Collections.Generic;

public abstract class Activity
{
    public DateTime Date { get; set; }
    public int DurationMinutes { get; set; }

    public Activity(DateTime date, int durationMinutes)
    {
        Date = date;
        DurationMinutes = durationMinutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {GetType().Name} ({DurationMinutes} min): Distance {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }
}

public class Running : Activity
{
    public double DistanceKm { get; set; }

    public Running(DateTime date, int durationMinutes, double distanceKm)
        : base(date, durationMinutes)
    {
        DistanceKm = distanceKm;
    }

    public override double GetDistance() => DistanceKm;
    public override double GetSpeed() => (DistanceKm / DurationMinutes) * 60;
    public override double GetPace() => DurationMinutes / DistanceKm;
}

public class Cycling : Activity
{
    public double SpeedKph { get; set; }

    public Cycling(DateTime date, int durationMinutes, double speedKph)
        : base(date, durationMinutes)
    {
        SpeedKph = speedKph;
    }

    public override double GetDistance() => (SpeedKph * DurationMinutes) / 60;
    public override double GetSpeed() => SpeedKph;
    public override double GetPace() => 60 / SpeedKph;
}

public class Swimming : Activity
{
    public int Laps { get; set; }

    public Swimming(DateTime date, int durationMinutes, int laps)
        : base(date, durationMinutes)
    {
        Laps = laps;
    }

    public override double GetDistance() => (Laps * 50) / 1000.0;
    public override double GetSpeed() => (GetDistance() / DurationMinutes) * 60;
    public override double GetPace() => DurationMinutes / GetDistance();
}

class Program
{
    static void Main()
    {
        var activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 5.0),
            new Cycling(new DateTime(2022, 11, 4), 45, 20.0),
            new Swimming(new DateTime(2022, 11, 5), 60, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
