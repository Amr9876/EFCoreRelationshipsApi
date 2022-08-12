namespace EFCoreRelationshipsApi.DTOs;

public class PostDto
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Title { get; set; } = string.Empty;

    public List<CommentDto> Comments { get; set;} = new();
}
