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

/*
Модель (StateData и WeatherData) отвечает за хранение данных о состоянии и погоде. 
В данном коде они представлены в виде свойств соответствующих классов.

Представление (WeatherView) отвечает за отображение данных пользователю. 
В данном коде, класс WeatherView содержит методы DisplayTemperature для отображения температуры 
и DisplayError для отображения ошибок.

Контроллер (WeatherController) обрабатывает действия пользователя и взаимодействует с моделью и представлением. 
В методе GetWeather контроллера выполняется взаимодействие с API для получения данных о состоянии и погоде. 
Метод CreateStateRequest и CreateWeatherRequest отвечают за создание запросов к API с помощью библиотеки RestSharp. 
Метод DeserializeResponse используется для десериализации JSON-ответа API в объекты моделей.

Метод Main является точкой входа в приложение. Он создает экземпляры классов WeatherView и WeatherController, 
и вызывает метод GetWeather контроллера для получения данных о погоде на основе введенного пользователем состояния.
*/