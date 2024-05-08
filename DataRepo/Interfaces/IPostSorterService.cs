using DataRepo.Models;

namespace DataRepo.Interfaces;

public interface IPostSorterService
{
    public List<Post> SortPosts(IList<Post> posts, string sortBy, string direction);
}
