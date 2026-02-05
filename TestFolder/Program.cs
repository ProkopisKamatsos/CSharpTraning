public class OrderEventArgs : EventArgs
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
}

public class OrderProcessor
{
    // Using EventHandler<T> to define an event with custom event data
    // Nullable to indicate no subscribers initially
    public event EventHandler<OrderEventArgs>? OrderProcessed;

    protected virtual void OnOrderProcessed(OrderEventArgs e)
    {
        OrderProcessed?.Invoke(this, e);
    }

    public void ProcessOrder(int orderId)
    {
        Console.WriteLine($"Processing order {orderId}...");
        OnOrderProcessed(new OrderEventArgs
        {
            OrderId = orderId,
            OrderDate = DateTime.Now
        });
    }
}

// Subscribing to the event
public class Program
{
    public static void Main()
    {
        OrderProcessor processor = new OrderProcessor();
        processor.OrderProcessed += (sender, e) =>
        {
            Console.WriteLine($"Order {e.OrderId} processed on {e.OrderDate}");
        };

        processor.ProcessOrder(123); // Output: "Processing order 123..."
                                     // Output: "Order 123 processed on [current date and time]"
    }
}
