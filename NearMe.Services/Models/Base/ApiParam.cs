using System;

namespace NearMe.Services.Models.Base
{
    public class ApiParam
    {
        public ApiParam(string key, object value, UsageFlags usage = UsageFlags.Query)
        {
            Key = key;
            Value = value;
            Usage = usage;
        }

        public string Key { get; protected set; }
        public object Value { get; protected set; }
        public UsageFlags Usage { get; protected set; }
        public bool IsOk => !string.IsNullOrEmpty(Key) && Value != null;
    }

    [Flags]
    public enum UsageFlags
    {
        Header = 1,
        Query = 2
    }
}
