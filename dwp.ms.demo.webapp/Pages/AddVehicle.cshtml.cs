using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using dwp.ms.demo.webapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace dwp.ms.demo.webapp.Pages
{
    public class AddVehicleModel : PageModel
    {
        public IConfiguration _configuration;
        public AddVehicleModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {

        }

        [BindProperty]
        public Vehicle Vehicle { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            HttpClient myClnt = new HttpClient();
            var URL = _configuration["ApiURLVehicle"];
            string stringData = JsonConvert.SerializeObject(Vehicle);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8,
                                   "application/json");
            HttpResponseMessage response = myClnt.PostAsync(URL, contentData).Result;
            var Message = response.Content.
            ReadAsStringAsync().Result;
            return RedirectToPage("./Vehicle");
        }
    }
}