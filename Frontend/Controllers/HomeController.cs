using Core.Entities;
using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Frontend.Controllers
{
    
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:7001/api/";

        public async Task<IActionResult> Index()
        {
            List<Employee> employees = new List<Employee>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(apiBaseUrl);

                //Call the api
                HttpResponseMessage response = await client.GetAsync("Employees");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();

                    employees = JsonConvert.DeserializeObject<List<Employee>>(data) ?? new List<Employee>();
                }
            }
            return View(employees);
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
}
