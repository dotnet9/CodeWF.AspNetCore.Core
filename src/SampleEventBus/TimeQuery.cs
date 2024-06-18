using CodeWF.EventBus;

namespace SampleEventBus
{
    public class TimeQuery : Query<string>
    {
        public override string Result { get; set; }
    }
}