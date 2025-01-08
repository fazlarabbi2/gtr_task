using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Frontend.Controllers
{
    public class AccountController : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:7001/api/";

        public async Task<ActionResult> Login(string? ReturnUrl = null)
        {
            var loginUrl = $"{apiBaseUrl}Account/login";
            var loginData = new { ReturnUrl };

            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(loginUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    // Handle successful login, e.g., redirect to ReturnUrl or another page
                    return Redirect(ReturnUrl ?? "/");
                }
                else
                {
                    // Handle login failure, e.g., show error message
                    ModelState.AddModelError(string.Empty, "Login failed. Please try again.");
                    return View();
                }
            }
        }
    }
}
