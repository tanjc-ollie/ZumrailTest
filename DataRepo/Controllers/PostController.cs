using System.ComponentModel.DataAnnotations;
using DataRepo.Interfaces;
using DataRepo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataRepo.Controllers;

[ApiController]
[Route("posts")]
public class PostController : BaseController
{
    private readonly IPostSorterService _postSorterService;

    public PostController(IPostsService postsService,
                          IPostSorterService postSorterService) 
        : base(postsService)
    {
        _postSorterService = postSorterService ?? throw new ArgumentNullException();
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetPostsAsync([Required]string tags, string? sortBy, string? direction)
    {
        IList<string> lTags = tags.Split(',')
            .Where(t => !string.IsNullOrEmpty(t))
            .ToList();
        List<Post> posts = new List<Post>();

        try
        {
            IEnumerable<Task<List<Post>>> postTasks = lTags.Select(t => this._postsService.GetPostsByTagAsync(t));
            IEnumerable<List<Post>> postTaskResults = await Task.WhenAll(postTasks).ConfigureAwait(false);
            IList<Post> postResult = postTaskResults.SelectMany(p => p)
                .DistinctBy(p => p.id)
                .ToList();
            posts.AddRange(_postSorterService.SortPosts(postResult, sortBy ?? "id", direction ?? "asc"));
        }
        catch(Exception ex)
        {
            // some form of logging
            Console.WriteLine("Exception occured [PostController:GetPostsAsync] " + Environment.NewLine + ex.Message);
        }

        return Ok(posts);
    } 
}
