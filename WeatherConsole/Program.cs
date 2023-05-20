namespace WeatherConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("state:");
            var state = Console.ReadLine();

            var view = new WeatherView();
            var controller = new WeatherController(view);
            controller.GetWeather(state);

            Console.ReadKey();
        }
    }
}