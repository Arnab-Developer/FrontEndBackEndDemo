using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FrontEndBackEndDemo.Web.Models
{
    public class WeatherForecast
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("temperatureC")]
        [Display(Name = "Temperature in C")]
        public int TemperatureC { get; set; }

        [JsonPropertyName("temperatureF")]
        [Display(Name = "Temperature in F")]
        public int TemperatureF { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        public WeatherForecast()
        {
            Summary = string.Empty;
        }
    }
}
