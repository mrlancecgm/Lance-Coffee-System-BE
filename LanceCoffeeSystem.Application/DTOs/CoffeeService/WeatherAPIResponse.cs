using System.Collections.Generic;

public class WeatherAPIResponse
{
    public string name { get; set; }
    public MainInfo main { get; set; }
    public List<WeatherInfo> weather { get; set; }
}

public class MainInfo
{
    public double temp { get; set; }
    public double feels_like { get; set; }
    public int humidity { get; set; }
}

public class WeatherInfo
{
    public string main { get; set; }
    public string description { get; set; }
}