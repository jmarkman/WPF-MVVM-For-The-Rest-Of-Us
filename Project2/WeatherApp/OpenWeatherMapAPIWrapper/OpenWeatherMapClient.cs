using Newtonsoft.Json;
using OpenWeatherMapAPIWrapper.JsonObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMapAPIWrapper
{
    public class OpenWeatherMapClient
    {
        /// <summary>
        /// The API key that gives us permission to use the OpenWeatherMap API
        /// </summary>
        private readonly string apiKey;

        /// <summary>
        /// Static instance of <see cref="HttpClient"/> to interact with the OpenWeatherMap API
        /// </summary>
        private readonly static HttpClient httpClient = CreateAPIHttpClient();

        public OpenWeatherMapClient(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<WeatherData> GetWeatherDataForZipCodeAsync(string zipCode)
        {
            WeatherData weatherData;
            string urlParams = $"weather?zip={zipCode},us&units=Imperial&appid={apiKey}";

            var response = await httpClient.GetAsync(urlParams);
            if (response.IsSuccessStatusCode)
            {
                var apiData = await response.Content.ReadAsStringAsync();
                weatherData = JsonConvert.DeserializeObject<WeatherData>(apiData);
            }
            else
            {
                throw new InvalidOperationException($"The weather data for ZIP code '{zipCode}' could not be retrieved. {Environment.NewLine}API query status code: {response.StatusCode.ToString()}");
            }

            return weatherData;
        }

        private static HttpClient CreateAPIHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/weather");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
