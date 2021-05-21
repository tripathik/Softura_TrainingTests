using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WeatherClient.Models;

namespace WeatherClient.Controllers
{
    public class WeatherController : Controller
    {
        // GET: WeatherController
        public async Task<ActionResult> Index()
        {
            string Baseurl = "http://localhost:26469/";
            var ProdInfo = new List<Weather>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));  
                HttpResponseMessage Res = await client.GetAsync("api/Weathers");
                if (Res.IsSuccessStatusCode)
                {
                    var ProdResponse = Res.Content.ReadAsStringAsync().Result;
                    ProdInfo = JsonConvert.DeserializeObject<List<Weather>>(ProdResponse);
                }
                return View(ProdInfo);
            }
        }

        // GET: WeatherController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            TempData["Id"] = id;
            int bid = Convert.ToInt32(TempData["Id"]);
            Weather b = new Weather();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:26469/api/Weathers" + bid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<Weather>(apiResponse);
                }
            }
            return View(b);
        }

        // GET: WeatherController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Weather b)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(b), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:26469/api/Weathers/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<Weather>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            TempData["Id"] = id;
            Weather b = new Weather();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:26469/api/Weathers/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<Weather > (apiResponse);
                }
            }
            return View(b);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(Weather b)
        {
            int bid = Convert.ToInt32(TempData["Id"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:26469/api/Weathers/" + bid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                }
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            TempData["Id"] = id;
            Weather b = new Weather();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:26469/api/Weathers/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<Weather>(apiResponse);
                }
            }
            return View(b);
        }
        [HttpPost]

        public async Task<ActionResult> Edit(Weather b)
        {

            int bid = Convert.ToInt32(TempData["Id"]);
            using (var httpClient = new HttpClient())
            {
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(b), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("http://localhost:26469/api/Weathers/" + bid, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<Weather>(apiResponse);

                }
            }
            return RedirectToAction("Index");
        }
    }
}
