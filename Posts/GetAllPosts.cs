
namespace EFCoreRelationshipsApi.Posts;

public class GetAllPosts : IEndpoint
{
    private readonly DataContext _context;
    
    private readonly IMapper _mapper;

    public GetAllPosts(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public string Pattern => "/posts";

    public HttpMethod Method => HttpMethod.Get;

    public Delegate Handler => async () => await GetPostsAsync();

    public async Task<List<PostDto>> GetPostsAsync() 
    {
        var posts = await _context.Posts
                    .ProjectTo<PostDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

        return posts;
    }
}
