using System;
using System.Collections.Generic;

namespace BlogAnalyzerWeb.Models
{
    public class Post
    {
        public Author Author { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public string Title { get; set; }

        public string URL { get; set; }


    }
}