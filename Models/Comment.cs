namespace EFCoreRelationshipsApi.Models;

public class Comment
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Body { get; set; } = string.Empty;
    
    public string PostId { get; set; } = string.Empty;
    public Post Post { get; set; } = new();
}
