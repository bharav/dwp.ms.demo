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
            /*HttpResponseMessage response  = await myClnt.GetAsync("http://20.43.144.136:1432/api/v1/Registration/1");
            string responseBody = await response.Content.ReadAsStringAsync();
            var retData = JsonConvert.DeserializeObject<Registration>(responseBody);
            return RedirectToPage("./Index");*/

            string stringData = JsonConvert.SerializeObject(Registration);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8,
                                   "application/json");
            HttpResponseMessage response = myClnt.PostAsync("http://20.43.144.136:1432/api/v1/Registration", contentData).Result;
           var Message = response.Content.
        ReadAsStringAsync().Result;
            return RedirectToPage("./Index"); 
        }
    }
}