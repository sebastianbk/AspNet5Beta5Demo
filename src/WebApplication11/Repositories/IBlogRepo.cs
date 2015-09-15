using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication11.Models;

namespace WebApplication11.Repositories
{
    public interface IBlogRepo
    {
        BlogPost GetBlogPost();
    }
}
