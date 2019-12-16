using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dwp.ms.demo.webapp.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json;

namespace dwp.ms.demo.registration.ui.Pages
{
    public class RegistrationModel : PageModel
    {
        public IConfiguration _configuration;
        public RegistrationModel(IConfiguration configuration)
        {
           _configuration = configuration;
        }
        public void OnGet()
        {

        }
        [BindProperty]
        public Registration Registration { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }



            HttpClient myClnt = new HttpClient();
            var URL = _configuration["ApiURL"];
            string stringData = JsonConvert.SerializeObject(Registration);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8,
                                   "application/json");
            HttpResponseMessage response = myClnt.PostAsync(URL, contentData).Result;
           var Message = response.Content.
        ReadAsStringAsync().Result;
            return RedirectToPage("./Index"); 
        }
    }
}