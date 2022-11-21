using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace GoogleBooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly RestClient _client;
        private readonly string BaseUrl;
        public BooksController(IConfiguration config)
        {
            _config = config;
            BaseUrl = _config.GetSection("BooksApiConfig:BaseUri").Value;
            _client = new RestClient(BaseUrl);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetBooks([FromQuery] string search)
        {
            var request = new RestRequest("/volumes/", Method.Get);
            request.AddQueryParameter("q", search);
            request.Method = Method.Get;
            RestResponse response = _client.ExecuteGet(request);       
            return Ok(response.Content);
        }
    }
}
