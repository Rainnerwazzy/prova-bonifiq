﻿namespace ProvaPub.Models
{
    public class Pagination<T>
    {
        public bool HasNext { get; set; }
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }
    }
}
