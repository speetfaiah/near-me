﻿namespace Pet.Hosting.Models
{
    public class ItemList<T>
    {
        public bool HasMore { get; set; }
        public T[] Items { get; set; }
    }
}
