using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using EBanking.model;
using EBankingAPIClient.Models;

namespace EBankingAPIClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            Console.WriteLine("Index");
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44399/api/accounts");
            var response = await client.SendAsync(msg);

            if (response.IsSuccessStatusCode)
            {
                string responseStream = await response.Content.ReadAsStringAsync();
                var temp = JsonConvert.DeserializeObject<List<Accounts>>(responseStream);
                Console.WriteLine(temp);
                return View(temp);
            }
            else
            {   
                //GetBranchesError = true;
                var temp = Array.Empty<Accounts>();
                return View(temp);
            }
        }

        public async Task<dynamic> goToIndex()
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44399/api/accounts");
            var response = await client.SendAsync(msg);

            if (response.IsSuccessStatusCode)
            {
                string responseStream = await response.Content.ReadAsStringAsync();
                var temp = JsonConvert.DeserializeObject<List<Accounts>>(responseStream); 
                Console.WriteLine(temp);
                return View(temp);
            }
            else
            {
                //GetBranchesError = true;
                var temp = Array.Empty<Accounts>();
                return View(temp);
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Create(Accounts accounts)
        {

            if (ModelState.IsValid)
            {
                HttpClient client1 = new HttpClient();
                //client.BaseAddress = new Uri("https://localhost:44399/api/product");
                var myContent = JsonConvert.SerializeObject(accounts);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = client1.PostAsync("https://localhost:44399/api/accounts", byteContent).Result;

                if (result.IsSuccessStatusCode)
                {
                    HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44399/api/accounts");
                    var response = await client1.SendAsync(msg);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseStream = await response.Content.ReadAsStringAsync();
                        var temp = JsonConvert.DeserializeObject<List<Accounts>>(responseStream);

                        return View("Index", temp);
                    }
                    else
                    {
                        //GetBranchesError = true;
                        var temp = Array.Empty<Accounts>();
                        return View("Index", temp);
                    }

                }
                else
                {
                    return View();
                }

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44399/api/accounts/" + id);
            var response = await client.SendAsync(msg);

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var model = JsonConvert.DeserializeObject<Accounts>(data);
                return View(model);
            }
            else
            {
                //GetBranchesError = true;
                var temp = Array.Empty<Accounts>();
                return View(temp[0]);
            }

            //return View();
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            //Console.WriteLine(id);
            //Console.WriteLine("Hello");
            using var httpResponse = await client.DeleteAsync("https://localhost:44399/api/accounts/" + id);

            httpResponse.EnsureSuccessStatusCode();
            //RedirectToAction("Index");
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44399/api/accounts");
            var response = await client.SendAsync(msg);

            if (response.IsSuccessStatusCode)
            {
                string responseStream = await response.Content.ReadAsStringAsync();
                var temp = JsonConvert.DeserializeObject<List<Accounts>>(responseStream);
                return View("Index", temp);
            }
            else
            {
                //GetBranchesError = true;
                var temp = Array.Empty<Accounts>();
                return View("Index", temp);
            }

            //return View("Index");
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Accounts accounts)
        {

            var todoItemJson = new StringContent(
            System.Text.Json.JsonSerializer.Serialize(accounts),Encoding.UTF8,"application/json");

            using var httpResponse = await client.PutAsync("https://localhost:44399/api/accounts/" + accounts.Id, todoItemJson);

            httpResponse.EnsureSuccessStatusCode();
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44399/api/accounts");
            var response = await client.SendAsync(msg);

            if (response.IsSuccessStatusCode)
            {
                string responseStream = await response.Content.ReadAsStringAsync();
                var temp = JsonConvert.DeserializeObject<List<Accounts>>(responseStream);
                return View("Index", temp);
            }
            else
            {
                var temp = Array.Empty<Accounts>();
                return View("Index", temp);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel{ RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
