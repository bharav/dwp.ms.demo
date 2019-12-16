using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using dwp.ms.demo.webapp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace dwp.ms.demo.webapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IConfiguration _configuration; 

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public Registration Registration { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        /*public void OnGet()
        {

        }*/

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                HttpClient myClnt = new HttpClient();
                var URL = _configuration["ApiURL"];
                HttpResponseMessage response = await myClnt.GetAsync(URL+ Id);
                string responseBody = await response.Content.ReadAsStringAsync();
                Registration = JsonConvert.DeserializeObject<Registration>(responseBody);
                
            }

        }
    }
}
