using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBlog.Domain.Dtos
{
    public record CreatePostDto
    {
        public required string Content { get; set; }
        public string UserId { get; set; }
        public ImageDto? Image { get; set; }
    }

}
