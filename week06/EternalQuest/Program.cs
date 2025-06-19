// Base class
public abstract class Goal
{
    public string Name { get; private set; }
    public int Value { get; private set; }
    public bool IsComplete { get; private set; }

    public Goal(string name, int value)
    {
        Name = name;
        Value = value;
        IsComplete = false;
    }

    public void MarkComplete()
    {
        IsComplete = true;
        UpdateScore();
    }

    protected abstract void UpdateScore();
}
// Derived class
public class ChecklistGoal : Goal
{
    public int TargetCount { get; private set; }
    public int CompletedCount { get; private set; }

    public ChecklistGoal(string name, int value, int targetCount)
        : base(name, value)
    {
        TargetCount = targetCount;
        CompletedCount = 0;
    }

    protected override void UpdateScore()
    {
        CompletedCount++;
        // award base value each time; if reached target, add bonus
        if (CompletedCount == TargetCount)
        {
            // bonus logic here
        }
    }
}

