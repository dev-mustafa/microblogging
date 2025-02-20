
namespace MicroBlog.API.Controllers;

using Domain.Dtos;
using Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Authorize]
[ApiController]
[Route("api/posts")]
public class PostController(IValidator<CreatePostDto> validator, IPostsService postsService)
    : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreatePost([FromForm] CreatePostDto request)
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        request.UserId = userId;

        if (request.Image is not null)
        {
            request.Image.Url = "/uploads/" + Guid.NewGuid() + Path.GetExtension(request.Image.OriginalFileName);
        }
        var id = await postsService.CreatePost(request);

        return CreatedAtAction(nameof(CreatePost), new { id }, request);
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> CreatePost(int pageNumber, int pageSize)
    {
        var posts = await postsService.ListPosts(pageNumber, pageSize);
        return Ok(posts);
    }

}

