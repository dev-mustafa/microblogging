using MicroBlog.Domain.Dtos;
using MicroBlog.Domain.Entities;

namespace MicroBlog.Domain.Interfaces;

public interface IPostsService : IGenericService<Post>
{
    Task<Guid> CreatePost(CreatePostDto dto);

    Task<List<PostDto>> ListPosts(int pageNumber, int pageSize);
}