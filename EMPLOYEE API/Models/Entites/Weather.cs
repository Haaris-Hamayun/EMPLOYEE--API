namespace EMPLOYEE_API.Models.Entites
{
    public class WeatherResponse
    {
        public MainWeather main { get; set; }
        public List<WeatherInfo> weather { get; set; }
        public string name { get; set; }
    }

    public class MainWeather
    {
        public float temp { get; set; }
        public int humidity { get; set; }
    }

    public class WeatherInfo
    {
        public string main { get; set; }
        public string description { get; set; }
    }


}
