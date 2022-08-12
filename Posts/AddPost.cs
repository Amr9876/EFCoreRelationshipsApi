namespace EFCoreRelationshipsApi.Posts;

public class AddPost : IEndpoint
{
    private readonly DataContext _context;

    private readonly IMapper _mapper;

    public AddPost(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public string Pattern => "/posts";

    public HttpMethod Method => HttpMethod.Post;

    public Delegate Handler => async (AddPostDto request) => await AddPostAsync(request);

    public async Task<PostDto> AddPostAsync(AddPostDto request)
    {

        if(request is null) return new();

        var post = _mapper.Map<Post>(request);
        post.Id = Guid.NewGuid().ToString();

        _context.Posts.Add(post);

        await _context.SaveChangesAsync();

        return _mapper.Map<PostDto>(post);
    }    
}
