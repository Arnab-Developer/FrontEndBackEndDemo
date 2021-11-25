using FrontEndBackEndDemo.Web.Models;
using FrontEndBackEndDemo.Web.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Text.Json;

namespace FrontEndBackEndDemo.Web.Controllers;

public class HomeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IOptionsMonitor<BackEndOptions> _backEndOptionOptionsAccessor;

    public HomeController(
        IHttpClientFactory httpClientFactory,
        IOptionsMonitor<BackEndOptions> backEndOptionOptionsAccessor)
    {
        _httpClientFactory = httpClientFactory;
        _backEndOptionOptionsAccessor = backEndOptionOptionsAccessor;
    }

    public async Task<IActionResult> Index()
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();
        HttpResponseMessage backEndApiResponseMessage = await httpClient.GetAsync(
            _backEndOptionOptionsAccessor.CurrentValue.BackEndApiEndPoint);
        if (backEndApiResponseMessage.IsSuccessStatusCode)
        {
            using Stream backEndApiResponseStream =
                await backEndApiResponseMessage.Content.ReadAsStreamAsync();
            IEnumerable<WeatherForecast>? weatherForecast =
                await JsonSerializer.DeserializeAsync<IEnumerable<WeatherForecast>>(backEndApiResponseStream);
            return View(weatherForecast);
        }
        return NotFound();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}