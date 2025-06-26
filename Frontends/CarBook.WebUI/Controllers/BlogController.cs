using CarBook.Dto.BlogDtos;
using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace CarBook.WebUI.Controllers
{
	public class BlogController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BlogController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.v1 = "Bloglar";
			ViewBag.v2 = "Yazarlarımızın Blogları";
			return View();
		}
        [HttpGet]
        public async Task<IActionResult> GetBlogs(int page = 1, int pageSize = 3)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5000/api/Blogs/GetAllBlogsWithAuthorList");

            if (!responseMessage.IsSuccessStatusCode)
                return Json(new { success = false });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var allBlogs = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);

            // Yorum sayısı dahil
            foreach (var blog in allBlogs)
            {
                var commentResponse = await client.GetAsync($"http://localhost:5000/api/Comments/CommentCountByBlog?id={blog.BlogID}");
                if (commentResponse.IsSuccessStatusCode)
                {
                    var commentJson = await commentResponse.Content.ReadAsStringAsync();
                    blog.CommentCount = int.Parse(commentJson);
                }
            }

            var pagedBlogs = allBlogs.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var totalPages = (int)Math.Ceiling((double)allBlogs.Count / pageSize);

            return Json(new
            {
                success = true,
                data = pagedBlogs,
                totalPages,
                currentPage = page
            });
        }
        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Blog Detayı ve Yorumlar";
            ViewBag.blogid = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync($"http://localhost:5000/api/Comments/CommentCountByBlog?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.commentCount = jsonData2;
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5000/api/Comments/CreateCommentWithMediator", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
