﻿namespace NearMe.WebApp.Models
{
    public class DataRequest
    {
        public string Query { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        public int Radius { get; set; }
    }
}
