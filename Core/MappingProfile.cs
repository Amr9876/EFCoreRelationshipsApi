namespace EFCoreRelationshipsApi.Core;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CommentDto, Comment>();
        CreateMap<Comment, CommentDto>();
        CreateMap<AddPostDto, Post>();
        CreateMap<Post, PostDto>();
    }
}
