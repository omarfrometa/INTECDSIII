using DSIII.WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace DSIII.WebAPI.Controllers
{
    public class CRUDController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CRUDController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://localhost:7107/api/users");

            if (response.IsSuccessStatusCode)
            { 
                var content = await response.Content.ReadAsStringAsync();
                var users = JsonSerializer.Deserialize<List<User>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return View(users ?? new List<User>());
            }

            return View(new List<User>());
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user, string PasswordConfirm)
        {
            if(user.Password.Trim() != PasswordConfirm.Trim())
            {
                ViewBag.Error = "Las clave no coinciden.";
                //ModelState.AddModelError(string.Empty, );
                return View(user);
            }

            if(!ModelState.IsValid)
            {
                //return View(user);
            }

            var httpClient = _httpClientFactory.CreateClient();
            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:7107/api/users", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error creando el usuario.");
                return View(user);
            }
        }
    }
}
