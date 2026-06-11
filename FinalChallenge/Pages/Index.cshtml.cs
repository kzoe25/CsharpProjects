using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalChallenge.Pages
{
    public class IndexModel : PageModel
    {
        // This holds the time string for the frontend
        public string ServerTime { get; set; } = string.Empty;

        // This handler method runs when the page first loads
        public void OnGet()
        {
            // DateTime.Now grabs the server's current time
            ServerTime = DateTime.Now.ToString("F");
        }
    }
}
