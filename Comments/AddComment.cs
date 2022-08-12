namespace EFCoreRelationshipsApi.Comments;

public class AddComment : IEndpoint
{
    private readonly DataContext _context;

    private readonly IMapper _mapper;

    public AddComment(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public string Pattern => "/comments";

    public HttpMethod Method => HttpMethod.Post;

    public Delegate Handler => async (CommentDto request) => await AddCommentAsync(request);
    
    public async Task<PostDto> AddCommentAsync(CommentDto request) 
    {
        request.Id = Guid.NewGuid().ToString();
        
        var post = await _context.Posts
            .ProjectTo<PostDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(p => p.Id == request.PostId);

        if(post is null) return new();

        var comment = _mapper.Map<Comment>(request);

        _context.Comments.Add(comment);
        post.Comments.Add(request);
 
        await _context.SaveChangesAsync();

        return post;
    }
}
