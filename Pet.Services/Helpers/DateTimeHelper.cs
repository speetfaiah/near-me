using System;

namespace Pet.Services.Helpers
{
    public static class DateTimeHelper
    {
        private static readonly DateTime _unixOriginDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        public static DateTime ConvertFromUnixTimestamp(long timestamp) => _unixOriginDate.AddSeconds(timestamp);
    }
}
