using Core.Entities;
using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Frontend.Controllers
{

    public class HomeController : Controller
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

                    employees = JsonConvert.DeserializeObject<List<Employee>>(data)!;
                }
            }
            return View(employees);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null) return BadRequest();

            Employee employee = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);

                // Call the api
                HttpResponseMessage response = await client.GetAsync($"Employees/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    employee = JsonConvert.DeserializeObject<Employee>(data)!;
                }
            }

            if (employee == null) return NotFound();

            return View(employee);
        }

        public async Task<ActionResult> Edit(Employee employee, int? id)
        {
            if (id == null) return BadRequest();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                var json = JsonConvert.SerializeObject(employee);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                // Call the api
                HttpResponseMessage response = await client.PutAsync($"Employees/{id}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(employee);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);

                // Call the api
                HttpResponseMessage response = await client.DeleteAsync($"Employees/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
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
}
