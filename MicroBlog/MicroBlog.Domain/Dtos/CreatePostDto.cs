using MicroBlog.Domain.Entities;
using Microsoft.Extensions.Hosting;

namespace MicroBlog.Domain.Dtos
{
    public record CreatePostDto
    {
        public required string Content { get; set; }
        public string UserId { get; set; }
        public ImageDto? Image { get; set; }
    }

    public class PostDto(Post post)
    {
        public string Content { get; init; } = post.Content;
        public string CreatedAt { get; init; } = post.CreatedAt.ToShortDateString();
        public UserDto User { get; init; } = new(post.User);
        public List<ReactionDto> Reactions { get; init; } = post.Reactions.Select(x=> new ReactionDto(x)).ToList();
    }

    public class ReactionDto(Reaction reaction)
    {
        public string CreatedAt { get; init; } = reaction.CreatedAt.ToShortDateString();
        public UserDto User { get; init; } = new(reaction.User);
    }
}
