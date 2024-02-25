using Microsoft.AspNetCore.Mvc;
using NewsAgg.Application;
using NewsAgg.Domain;

namespace NewsAgg.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsFeedsController : ControllerBase
    {
        private readonly INewsAggService _newsAggService;

        public NewsFeedsController(INewsAggService newsAggService)
        {
            _newsAggService = newsAggService;
        }

        [HttpGet]
        public ActionResult<List<NewsFeed>> Get()
        {
            var newsFromServes = _newsAggService.GetAllNewsFeeds();
            return Ok(newsFromServes);
        }
        //TODO: remove id from incoming NewsFeed model
        [HttpPost]
        public ActionResult<NewsFeed> PostNewsFeed(NewsFeed newsFeed)
        {
            if (newsFeed is null)
                return BadRequest();

            NewsFeed? newModelNewsFeed = _newsAggService.CreateNewsFeed(newsFeed);
            return newModelNewsFeed is not null ? Ok(newModelNewsFeed) : BadRequest();
        }
    }
}
