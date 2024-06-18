using CodeWF.EventBus;
using Microsoft.AspNetCore.Mvc;
using SampleEventBus;

namespace WebAPISample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController(IEventBus eventBus) : ControllerBase
    {
        [HttpGet(Name = "get")]
        public async Task<string> GetAsync()
        {
            var query = new TimeQuery();
            await eventBus.PublishAsync(query);
            return query.Result;
        }
    }
}