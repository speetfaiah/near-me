using System.Collections.Generic;

namespace NearMe.Services.Models.Vk
{
    public class BaseItemListResponse<T>
    {
        public ItemList<T> Response { get; set; }
    }

    public class ItemList<T>
    {
        public long Count { get; set; }
        public List<T> Items { get; set; }
    }
}
