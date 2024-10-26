using System;
using System.Collections.Generic;

// Base class for all activities
public abstract class Activity
{
    private DateTime _date;
    private int _durationMinutes;

    public Activity(DateTime date, int durationMinutes)
    {
        _date = date;
        _durationMinutes = durationMinutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} - Duration: {_durationMinutes} min, ";
    }
}

// Derived class for Running
public class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, int durationMinutes, double distance) 
        : base(date, durationMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / 60) * (60.0 / GetDuration());
    }

    public override double GetPace()
    {
        return GetDuration() / GetDistance();
    }

    public override string GetSummary()
    {
        return base.GetSummary() + 
            $"Running - Distance: {GetDistance()} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }

    private int GetDuration()
    {
        return (int)(GetDurationMinutes());
    }
}

// Derived class for Cycling
public class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(DateTime date, int durationMinutes, double speed) 
        : base(date, durationMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return _speed * (GetDurationMinutes() / 60.0);
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / GetSpeed();
    }

    public override string GetSummary()
    {
        return base.GetSummary() + 
            $"Cycling - Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }

    private int GetDurationMinutes()
    {
        return (int)(GetDurationMinutes());
    }
}

// Derived class for Swimming
public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int durationMinutes, int laps) 
        : base(date, durationMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 / 1000.0; // in kilometers
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetDurationMinutes()) * 60; // km/h
    }

    public override double GetPace()
    {
        return GetDurationMinutes() / GetDistance();
    }

    public override string GetSummary()
    {
        return base.GetSummary() + 
            $"Swimming - Distance: {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }

    private int GetDurationMinutes()
    {
        return (int)(GetDurationMinutes());
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a list of activities
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 4), 45, 15.0),
            new Swimming(new DateTime(2022, 11, 5), 30, 20)
        };

        // Display summaries of each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
