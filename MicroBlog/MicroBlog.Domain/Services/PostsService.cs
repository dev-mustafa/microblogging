
using MicroBlog.Domain.Dtos;
using MicroBlog.Domain.Entities;
using MicroBlog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroBlog.Domain.Services
{
    public class PostsService(ApplicationDbContext context) : GenericService<Post>(context), IPostsService
    {
        async Task<Guid> IPostsService.CreatePost(CreatePostDto dto)
        {
            var location = GeoLocationHelper.GenerateRandomCoordinates();
            var post = new Post
            {
                Content = dto.Content,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                CreatedAt = DateTime.UtcNow,
                UserId = dto.UserId,
                Images = new List<Image> { new Image { Url = dto.Image?.Url ?? ""} }
            };
            await CreateAsync(post);
            return post.Id;        
        }

        async Task<List<PostDto>> IPostsService.ListPosts(int pageNumber, int pageSize)
        {
            var start = (pageNumber - 1) * pageSize;
            var posts = await context.Posts
                .Include(x => x.Reactions)
                .Include(x => x.User)
                .OrderByDescending(x => x.CreatedAt)
                .Skip(start)
                .Take(pageSize)
                .ToListAsync();
            return posts.Select(x => new PostDto(x)).ToList();
        }
    }
}
