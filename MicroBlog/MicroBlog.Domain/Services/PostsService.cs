
using MicroBlog.Domain.Dtos;
using MicroBlog.Domain.Entities;
using MicroBlog.Domain.Interfaces;

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
    }
}
