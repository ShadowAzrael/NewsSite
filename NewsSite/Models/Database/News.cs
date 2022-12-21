using System;
using System.Collections.Generic;

#nullable disable

namespace NewsSite.Models.Database
{
    public partial class News
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public string Title { get; set; }
        public string NewsContent { get; set; }
        public string Photo { get; set; }
        public string Source { get; set; }
        public DateTime? Time { get; set; }
    }
}
