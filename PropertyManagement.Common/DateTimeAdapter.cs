namespace PropertyManagement.Common
{
    using System;

    public interface IDateTime
    {
        DateTime UtcNow { get; }
        DateTime Now { get; }
    }
    
    public class DateTimeAdapter : IDateTime
    {
        public DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow;
            }
        }

        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
