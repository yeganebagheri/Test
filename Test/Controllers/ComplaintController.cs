using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Test.Helpers;
using Test.Models;

namespace Test.Controllers
{
    public class ComplaintController : Controller
    {
        ComplaintApi _api = new ComplaintApi();

        public async Task<ActionResult> Index()
        {
           
                List<ComplaintModel> EmpInfo = new List<ComplaintModel>();
                HttpClient client = _api.Initial();

                 
                    HttpResponseMessage Res = await client.GetAsync("api/Record2");

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        EmpInfo = JsonConvert.DeserializeObject<List<ComplaintModel>>(EmpResponse);

                    }
                    //returning the employee list to view  
                    return View(EmpInfo);
        }
            
        

        
        public ActionResult GetEdit(int id)
        {
            ComplaintModel model = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44315/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Record2/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ComplaintModel>();
                    readTask.Wait();

                    model = readTask.Result;
                }
            }

            return View(model);
        }
        

        [HttpPost]
        public ActionResult Edit(ComplaintModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44315/api/Status");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<ComplaintModel>("api/Status", model);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ComplaintModel model)
        {
            HttpClient client = _api.Initial();
            
            var postTask = client.PostAsJsonAsync<ComplaintModel>("api/Record2", model);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            return View();
        }

           
        }

   
}

