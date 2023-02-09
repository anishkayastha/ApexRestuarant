using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using ApexRestaurant.Mvc.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Formatting;

namespace ApexRestaurant.Mvc.Controllers
{
    public class CustomerController : Controller
    {
        private string baseUri;

        public CustomerController(IConfiguration configuration)
        {
            // Get baseUri of Web API from appsettings.json > ApiBaseUrl
            baseUri = configuration.GetValue<string>("ApiBaseUrl");
        }

        // GET: Customer
        public ActionResult Index()
        {
            IEnumerable<CustomerViewModel> customers = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Add("accept", "application/json");
                var responseTask = client.GetAsync("/api/customer");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var apiResponse = result.Content.ReadAsStringAsync();
                    apiResponse.Wait();
                    customers = JsonConvert.DeserializeObject<IList<CustomerViewModel>>(apiResponse.Result);
                }
                else //web api sent error response
                {
                    customers = Enumerable.Empty<CustomerViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(customers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModel customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                
                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<CustomerViewModel>("/api/customer", customer);
                    postTask.Wait();
                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View(customer);
        }


        public ActionResult Edit(int id)
        {
            CustomerViewModel customer = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);

                //HTTP GET
                var responseTask = client.GetAsync("/api/customer/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CustomerViewModel>();
                    readTask.Wait();
                    customer = readTask.Result;
                }
            }

            return View(customer);
        }


        [HttpPost]
        public ActionResult Edit(CustomerViewModel customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);

                //HTTP POST
                var putTask = client.PutAsJsonAsync<CustomerViewModel>("/api/customer", customer);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }

            return View(customer);
        }

        public ActionResult Delete(int id)
        {  
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("/api/customer/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }

            return RedirectToAction("Index");
        }
    }
}