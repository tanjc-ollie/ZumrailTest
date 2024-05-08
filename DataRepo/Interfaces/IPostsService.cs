using DataRepo.Models;

namespace DataRepo.Interfaces;

public interface IPostsService
{
    public Task<List<Post>> GetPostsByTagAsync(string tag);
}
