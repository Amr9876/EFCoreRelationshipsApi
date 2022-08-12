namespace EFCoreRelationshipsApi.Posts;

public class GetPost : IEndpoint
{
    private readonly DataContext _context;

    private readonly IMapper _mapper;

    public GetPost(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public string Pattern => "/posts/{id}";

    public HttpMethod Method => HttpMethod.Get;

    public Delegate Handler => async (string id) => await GetPostAsync(id);

    public async Task<PostDto> GetPostAsync(string id)
    {

        var post = await _context.Posts
                    .ProjectTo<PostDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(p => p.Id == id);

        if (post is null) return new();

        return post;

    }
}
