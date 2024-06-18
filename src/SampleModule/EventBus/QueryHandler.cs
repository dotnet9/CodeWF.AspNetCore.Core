using CodeWF.EventBus;
using SampleEventBus;
using SampleModule.Services;

namespace SampleModule.EventBus
{
    [Event]
    public class QueryHandler(ITimeService timeService)
    {
        [EventHandler]
        public async Task GetTimeAsync(TimeQuery query)
        {
            query.Result = (await timeService.GetTimeAsync()).ToString("yyyy-MM-dd HH:mm:ss fff");
        }
    }
}