using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
	public class AdminTagsController : Controller
	{
		private readonly BloggieDbContext db;
        public AdminTagsController(BloggieDbContext bloggieDbContext)
        {
            db = bloggieDbContext;
        }

        [HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(AddTagRequest addTagRequest)
		{
			var name = addTagRequest.Name;
			var displayName = addTagRequest.DisplayName;
			var tag = new Tag
			{
				Name = name,
				DisplayName = displayName
			};
			db.Tags.Add(tag);
			db.SaveChanges();

			return View("Add");
		}
	}
}
