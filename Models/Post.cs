namespace EFCoreRelationshipsApi.Models;

public class Post
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Title { get; set; } = string.Empty;

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
