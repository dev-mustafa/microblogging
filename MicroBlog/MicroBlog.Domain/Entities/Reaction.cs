﻿namespace MicroBlog.Domain.Entities;

public class Reaction
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public Guid PostId { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; }
    public Post Post { get; set; }
}