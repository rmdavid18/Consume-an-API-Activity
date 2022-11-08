using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RestSharp;

namespace renieldavid.APIActivity.Pages
{
    public class CardModel : PageModel
    {
        public worddata? Worddata { get; set; }
        public async Task <IActionResult> OnGet()
        {
           return Page();
        }
        public class worddata
        {
            public List<wordmeaning>? Word { get; set; }
        }
        public class wordmeaning
        {
            public string? Phonetics { get; set; }
        }
        public class wordmainmeanig
        {
            public string? meaning { get; set; }
        }
        public void OnPost()
        {
            var client = new RestClient("https://api.dictionaryapi.dev/api/v2/entries/en/");

            var request = new RestRequest("", Method.Post);

            RestResponse response = client.Execute(request);

            var content = response.Content;

             this.Worddata = JsonConvert.DeserializeObject<worddata>(content);
        }
    }
}
