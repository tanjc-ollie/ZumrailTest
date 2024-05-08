namespace DataRepo.Models;

public class Post
{
    public string? author { get; set; }
    public long authorId {get; set; }
    public long id { get; set; }
    public int likes { get; set; }
    public decimal popularity { get; set; }
    public int reads { get; set; }
    public List<string> tags { get; set; } = new List<string>();
}
