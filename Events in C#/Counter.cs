using Events_in_C_;

public class Counter
{
    public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
    protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
    {
        ThresholdReached?.Invoke(this, e);
    }
    public int Total { get; private set; }
    public int Threshold { get; set; }

    public Counter(int threshold)
    {
        Threshold = threshold;
        Total = 0;
    }

    public void Add(int value)
    {
        Total += value;
        Console.WriteLine($"Current Total: {Total}");
        if (Total >= Threshold)
        {
            var args = new ThresholdReachedEventArgs
            {
                Threshold = Threshold,
                TimeReached = DateTime.Now
            };
            OnThresholdReached(args);
        }
    }

}
