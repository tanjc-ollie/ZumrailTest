using System.Text.Json;
using DataRepo.Interfaces;
using DataRepo.Models;

namespace DataRepo.Services;

public class PostsService : IPostsService
{
    private const string DATA_REPO_URL = "https://api.hatchways.io/assessment/blog/posts";
    private readonly IHttpService _httpService;

    public PostsService(IHttpService httpService)
    {
        _httpService = httpService ?? throw new ArgumentNullException();
    }

    public async Task<List<Post>> GetPostsByTagAsync(string tag)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>()
        {
            { "tag", tag }
        };
        List<Post> posts = new List<Post>();

        try
        {
            string responseText = await _httpService.GetAsync(DATA_REPO_URL, parameters).ConfigureAwait(false);
            PostResponse? response = JsonSerializer.Deserialize<PostResponse>(responseText);
            if (response?.posts == null || response.posts.Count == 0)
                return posts;
            
            posts.AddRange(response.posts);
        }
        catch(Exception ex)
        {
            // some form of logging
            Console.WriteLine("Exception occured [PostsService:GetPostsByTagAsync] " + Environment.NewLine + ex.Message);
        }

        return posts;
    }
}
