IVehicle vehicle = new Car();
vehicle.Speed = 100;
vehicle.Color = "Red";
vehicle.Drive();

public class Car : IVehicle
{
    private int _speed;
    private string _color;

    public int Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public string Color
    {
        get { return _color; }
        set { _color = value; }
    }

    public void Drive()
    {
        // Implementation of the Drive method
        Console.WriteLine("The car is driving at speed " + Speed + " and color " + Color);
    }
}
public interface IVehicle
{
    int Speed { get; set; }
    string Color { get; set; }
    void Drive();
}