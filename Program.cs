﻿using Newtonsoft.Json.Linq;

namespace APIExerciseTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var apiKeyObj = File.ReadAllText("appsettings.json");
            var apiKey = JObject.Parse(apiKeyObj).GetValue("apiKey").ToString();
            var client = new HttpClient();
            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip=35114&appid={apiKey}";
            var response = client.GetStringAsync(weatherURL).Result;

            //Console.WriteLine(response);

            JObject formattedResponse = JObject.Parse(response);
            var weatherDescription = formattedResponse["weather"][0]["description"];
            var temperature = formattedResponse["main"]["temp"];
            var tempMin = formattedResponse["main"]["temp_min"];
            var tempMax = formattedResponse["main"]["temp_max"];
            var humidity = formattedResponse["main"]["humidity"];
            Console.WriteLine($"The current weather for {formattedResponse["name"]}");
            Console.WriteLine($"Description: {weatherDescription}");
            Console.WriteLine($"current temperature: {temperature}");
            Console.WriteLine($"minimum temperature: {tempMin}");
            Console.WriteLine($"maximum temperature: {tempMax}");
            Console.WriteLine($"humidity: {humidity}");
        }
    }
}