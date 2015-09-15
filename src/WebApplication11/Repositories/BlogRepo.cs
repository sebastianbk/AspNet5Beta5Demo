using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication11.Models;

namespace WebApplication11.Repositories
{
    public class BlogRepo : IBlogRepo
    {
        public BlogPost GetBlogPost()
        {
            var post = new BlogPost
            {
                PostId = 123,
                Title = "Hello",
                Description = "This is a test!"
            };

            return post;
        }
    }
}
