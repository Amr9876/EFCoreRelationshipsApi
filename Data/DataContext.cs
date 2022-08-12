namespace EFCoreRelationshipsApi.Data;

public class DataContext : DbContext
{

    public DataContext(DbContextOptions<DataContext> options) 
        : base(options)
    {

    }

    public DbSet<Post> Posts => Set<Post>();

    public DbSet<Comment> Comments => Set<Comment>();

}
