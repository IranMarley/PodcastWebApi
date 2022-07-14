using Podcast.Application.Interfaces;
using Podcast.Application.Models;
using Podcast.Infra.CrossCutting.Support;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Podcast.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class PodcastsController : ControllerBase
    {
        private readonly ILogger<PodcastsController> _logger;
        private readonly IPodcastService _podcastService;
        private readonly Pagination _pagination;

        public PodcastsController(ILogger<PodcastsController> logger, IPodcastService podcastService, Pagination pagination)
        {
            _logger = logger;
            _podcastService = podcastService;
            _pagination = pagination;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] PodcastFilterModel filter)
        {
            _pagination.Page = filter.Page;
            _pagination.Size = filter.Size;

            var model = _podcastService.GetAll(filter, _pagination);
            var pagination = _pagination.CalcPagination(_pagination, _podcastService.Count(filter));

            return Ok(new PagedResponseModel<IEnumerable<PodcastModel>>(model, pagination.Page, pagination.Size, pagination.TotalPages, pagination.TotalRecords));
        }
    }
}