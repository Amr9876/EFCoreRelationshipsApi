namespace EFCoreRelationshipsApi.DTOs;

public class AddPostDto
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Title { get; set; } = string.Empty;
}
