using InfoTrackBusinnes;
using Microsoft.AspNetCore.Mvc;

namespace InfoTrackWeb.Controllers
{
    [Produces("application/json")]
    [Route("api/GoogleSearch")]
    public class GoogleSearchController : Controller
    {
        readonly ISearch provider;

        public GoogleSearchController(ISearch provider)
        {
            this.provider = provider;
        }

        public string Get(string keywords, string url)
        {
            return provider.Search(keywords, url);
        }
    }
}