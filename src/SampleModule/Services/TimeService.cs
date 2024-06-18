namespace SampleModule.Services
{
    public class TimeService : ITimeService
    {
        public async Task<DateTime> GetTimeAsync()
        {
            return await Task.FromResult(DateTime.Now);
        }
    }
}