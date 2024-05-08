using DataRepo.Interfaces;
using DataRepo.Models;

namespace DataRepo.Services;

public class PostSorterService : IPostSorterService
{
    public List<Post> SortPosts(IList<Post> posts, string sortBy, string direction)
    {
        switch (sortBy.ToLower())
        {
            case "reads":
                return direction.ToLower() == "desc" ?
                    posts.OrderByDescending(p => p.reads).ToList() :
                    posts.OrderBy(p => p.reads).ToList();

            case "likes":
                return direction.ToLower() == "desc" ?
                    posts.OrderByDescending(p => p.likes).ToList() :
                    posts.OrderBy(p => p.likes).ToList();

            case "popularity":
                return direction.ToLower() == "desc" ?
                    posts.OrderByDescending(p => p.popularity).ToList() :
                    posts.OrderBy(p => p.popularity).ToList();

            default:
                return direction.ToLower() == "desc" ?
                    posts.OrderByDescending(p => p.id).ToList() :
                    posts.OrderBy(p => p.id).ToList();
        }
    }
}
