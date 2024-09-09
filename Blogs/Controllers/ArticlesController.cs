// Controllers/ArticlesController.cs
using ArticleFetcher.Data;
using ArticleFetcher.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

namespace ArticleFetcher.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public ArticlesController(ApplicationDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("fetch")]
        public async Task<IActionResult> FetchArticles()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync("https://api.example.com/articles");
            var articles = JsonSerializer.Deserialize<List<Article>>(response);

            if (articles != null)
            {
                _context.Articles.AddRange(articles);
                await _context.SaveChangesAsync();
            }

            return Ok(articles);
        }
    }
}
