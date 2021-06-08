using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using dwp.ms.demo.webapp.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace dwp.ms.demo.webapp.Pages
{
    public class VehicleModel : PageModel
    {
        public IConfiguration _configuration;
        public VehicleModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Vehicle Vehicle { get; set; }
        [BindProperty(SupportsGet = true)]
        public string EngineNo { get; set; }
        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(EngineNo))
            {
                HttpClient myClnt = new HttpClient();
                var URL = _configuration["ApiURLVehicle"];
                HttpResponseMessage response = await myClnt.GetAsync(URL + '/' + EngineNo);
                string responseBody = await response.Content.ReadAsStringAsync();
                Vehicle = JsonConvert.DeserializeObject<Vehicle>(responseBody);

            }

        }
    }
}