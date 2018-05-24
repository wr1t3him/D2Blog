﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace D2Blog.Models
{
    public class BlogPost
    {
        public BlogPost()
        {
            this.Comments = new HashSet<Comment>();
        }
        public int id{get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public string mediaURL { get; set; }
        public bool published { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}