namespace WeatherConsole;

public class WeatherView
{
    public void DisplayTemperature(double temperature)
    {
        Console.WriteLine(Math.Round(temperature - 273.15, 1));
    }

    public void DisplayError(string errorMessage)
    {
        Console.WriteLine("Error: " + errorMessage);
    }
}