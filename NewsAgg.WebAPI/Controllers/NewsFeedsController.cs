using Microsoft.AspNetCore.Mvc;
using NewsAgg.Application;
using NewsAgg.Domain;
using NewsAgg.Domain.DTO;
using System.ComponentModel.DataAnnotations;

namespace NewsAgg.WebAPI.Controllers
{
    // TODO: Add CancellationToken cancellationToken
    [Route("api/[controller]")]
    [ApiController]
    public class NewsFeedsController : ControllerBase
    {
        private readonly INewsAggService _newsAggService;

        public NewsFeedsController(INewsAggService newsAggService)
        {
            _newsAggService = newsAggService;
        }
        /*
        [HttpGet]
        [Route("GetAllNewsfeeds")]
        public ActionResult<List<NewsFeed>> Get()
        {
            var newsFromServes = _newsAggService.GetAllNewsFeeds();
            return Ok(newsFromServes);
        }
        */
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<NewsFeed>>> GetAsync()
        {
            var newsFromServes = await _newsAggService.GetAllNewsAsync();
            return Ok(newsFromServes);
        }

        [HttpGet]
        [Route("GetByTitle")]
        public async Task<ActionResult<List<NewsFeed>>> GetAllNewsfeedsByTitle(string searchLine)
        {
            var newsFromServes = await _newsAggService.FindNewsFeedByTitle(searchLine);
            return Ok(newsFromServes);
        }

        [HttpGet]
        [Route("GetDescription")]
        public async Task<ActionResult<List<NewsFeed>>> GetAllNewsfeedsByDescription(string searchLine)
        {
            var newsFromServes = await _newsAggService.FindNewsFeedByDescription(searchLine);
            return Ok(newsFromServes);
        }

        [HttpGet]
        [Route("GetByTitleOrDescription")]
        public async Task<ActionResult<List<NewsFeed>>> GetNewsfeedsByTitleOrDescription(string searchLine)
        {
            var newsFromServes = await _newsAggService.FindNewsFeedByTitleAndDescription(searchLine);
            return Ok(newsFromServes);
        }
        /*
        [HttpPost]
        [Route("PostNewsfeed")]
        public ActionResult<NewsFeed> PostNewsFeed(NewsFeed newsFeed)
        {
            if (newsFeed is null)
                return BadRequest();

            NewsFeed? newModelNewsFeed = _newsAggService.CreateNewsFeed(newsFeed);
            return newModelNewsFeed is not null ? Ok(newModelNewsFeed) : BadRequest();
        }
        */
        //TODO: remove id from incoming NewsFeed model
        [HttpPost]
        [Route("PostNewsfeedByModel")]
        public async Task<ActionResult<CreateNewsFeedDto>> PostNewsFeedAsync(CreateNewsFeedDto newsFeedDto)
        {
            if (newsFeedDto is null)
                return BadRequest();

            CreateNewsFeedDto? newModelNewsFeed = await _newsAggService.CreateNewsFeedAsync(newsFeedDto);
            return newModelNewsFeed is not null ? Ok(newModelNewsFeed) : BadRequest();
        }
        [HttpPost]
        [Route("PostNewsFeedsByLink")]
        public async Task<ActionResult<int>> PostNewsFeedAsync([Required] string requestLink)
        {
            var res = await _newsAggService.CreateNewsFeeds(requestLink);
            return Ok(res);
        }

    }
}
