using Newtonsoft.Json.Linq;

namespace APIExerciseTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var apiKeyObj = File.ReadAllText("appsettings.json");
            var apiKey = JObject.Parse(apiKeyObj).GetValue("apiKey").ToString();
            var client = new HttpClient();
            Console.WriteLine("Enter your zip code");
            var zip = Console.ReadLine();
            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip={zip}&appid={apiKey}";
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
            Console.WriteLine($"current temperature: {temperature} kelvin");
            Console.WriteLine($"minimum temperature: {tempMin} kelvin");
            Console.WriteLine($"maximum temperature: {tempMax} kelvin");
            Console.WriteLine($"humidity: {humidity} percent");
        }
    }
}