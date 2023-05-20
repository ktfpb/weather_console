using System.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace WeatherConsole;

public class WeatherController
{
    private readonly WeatherView _view;
    private readonly string _apiUrl;
    private readonly string _apiKey;

    public WeatherController(WeatherView view)
    {
        _view = view;
        _apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        _apiKey = ConfigurationManager.AppSettings["ApiKey"];
    }

    public void GetWeather(string state)
    {
        var client = new RestClient(_apiUrl);
        var requestState = CreateStateRequest(state);
        var responseState = client.Get(requestState);

        if (responseState.IsSuccessful)
        {
            List<StateData> states = DeserializeResponse<List<StateData>>(responseState.Content);
            var requestWeather = CreateWeatherRequest(states[0]);
            var responseWeather = client.Get(requestWeather);

            if (responseWeather.IsSuccessful)
            {
                WeatherData weatherData = DeserializeResponse<WeatherData>(responseWeather.Content);
                _view.DisplayTemperature(weatherData.main.temp);
                    
                    
                Console.WriteLine(states[0].name);
                Console.WriteLine(states[0].country);
            }
            else
            {
                _view.DisplayError(responseWeather.ErrorException.ToString());
            }
        }
        else
        {
            _view.DisplayError(responseState.ErrorException.ToString());
        }
    }

    private RestRequest CreateStateRequest(string state)
    {
        var request = new RestRequest("/geo/1.0/direct");
        request.AddQueryParameter("q", state);
        request.AddQueryParameter("appid", _apiKey);
        return request;
    }

    private RestRequest CreateWeatherRequest(StateData stateData)
    {
        var request = new RestRequest("/data/2.5/weather");
        request.AddQueryParameter("lat", $"{stateData.lat}");
        request.AddQueryParameter("lon", $"{stateData.lon}");
        request.AddQueryParameter("appid", _apiKey);
        return request;
    }

    private T DeserializeResponse<T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    }
}