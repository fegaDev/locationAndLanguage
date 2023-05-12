using InternationalApi.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace InternationalApi.Resources.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IStringLocalizer<PostsController> _stringLocalizer;
        private readonly IStringLocalizer<SharedResource> _sharedResourcesLocalizer;


        public PostsController(IStringLocalizer<PostsController> stringLocalizer, IStringLocalizer<SharedResource> sharedResourcesLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _sharedResourcesLocalizer = sharedResourcesLocalizer;
        }
        [HttpGet]
        [Route("PostControllerResource")]
        public IActionResult GetUsingPostControllerResource() 
        {
            var article = _stringLocalizer["Article"];
            var postName = _stringLocalizer.GetString("welcome").Value ?? string.Empty;
            return Ok(new
            {
                PostType = article.Value,
                postName = postName,
            });
        }

        [HttpGet]
        [Route("sharedResources")]
        public IActionResult GetUsingShareResources()
        {
            var article = _stringLocalizer['Article'];
            var postName = _stringLocalizer.GetString("welcome").Value ?? string.Empty;
            var todayIs = string.Format(_sharedResourcesLocalizer.GetString("TodayIs"), DateTime.Now.ToLongDateString());

            return Ok(new
            {
                PostType = article.Value,
                PostName = postName,
                TodayIs = todayIs
            });
        }
    }
}
