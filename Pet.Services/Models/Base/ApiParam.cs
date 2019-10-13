using System;

namespace Pet.Services.Models.Base
{
    public class ApiParam
    {
        public ApiParam(string key, string value, UsageFlags usage)
        {
            Key = key;
            Value = value;
            Usage = usage;
        }

        public string Key { get; protected set; }

        public string Value { get; protected set; }

        public UsageFlags Usage { get; protected set; }

        public bool IsOk => !string.IsNullOrEmpty(Key) && !string.IsNullOrEmpty(Value);
    }

    [Flags]
    public enum UsageFlags
    {
        Header = 1,
        Query = 2
    }
}
