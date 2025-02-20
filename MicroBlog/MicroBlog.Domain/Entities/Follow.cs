namespace MicroBlog.Domain.Entities;

public class Follow
{
    public Guid Id { get; set; }
    public string FollowerId { get; set; }
    public string FollowingId { get; set; }
    public DateTime CreatedAt { get; set; }

    public User Follower { get; set; }
    public User Following { get; set; }
}