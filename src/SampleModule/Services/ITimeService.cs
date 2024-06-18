namespace SampleModule.Services
{
    public interface ITimeService
    {
        Task<DateTime> GetTimeAsync();
    }
}