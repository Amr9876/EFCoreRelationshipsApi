namespace EFCoreRelationshipsApi.Core;

public static class DataSeederExtensions
{

    public static IApplicationBuilder UseDataDestroyer(this IApplicationBuilder app) 
    {
        using var scope = app.ApplicationServices.CreateScope();

        var db = scope.ServiceProvider.GetRequiredService<DataContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        db.Comments.RemoveRange(db.Comments);
        db.Posts.RemoveRange(db.Posts);
        
        db.SaveChangesAsync().Wait();

        return app;
    }    
    
    public static IApplicationBuilder UseDataSeeder(this IApplicationBuilder app) 
    {

        using var scope = app.ApplicationServices.CreateScope();

        var db = scope.ServiceProvider.GetRequiredService<DataContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        
        if(db.Posts.Any() || db.Comments.Any())
        {
            logger.LogInformation("Data already seeded");
            return app;
        }

        var posts = new List<Post>
        {
            new Post { Title = "Post 1" },
            new Post { Title = "Post 2" },
            new Post { Title = "Post 3" }
        };

        var comments = new List<Comment>
        {
            new Comment { Body = "Comment 1", PostId = posts[0].Id, Post = posts[0] },
            new Comment { Body = "Comment 2", PostId = posts[0].Id, Post = posts[0] },
            new Comment { Body = "Comment 3", PostId = posts[1].Id, Post = posts[1] },
            new Comment { Body = "Comment 4", PostId = posts[1].Id, Post = posts[1] },
            new Comment { Body = "Comment 5", PostId = posts[2].Id, Post = posts[2] },
            new Comment { Body = "Comment 6", PostId = posts[2].Id, Post = posts[2] }
        };

        posts[0].Comments.Add(comments[0]);
        posts[0].Comments.Add(comments[1]);
        posts[1].Comments.Add(comments[2]);
        posts[1].Comments.Add(comments[3]);
        posts[2].Comments.Add(comments[4]);
        posts[2].Comments.Add(comments[5]);

        db.Posts.AddRange(posts);
        db.Comments.AddRange(comments);

        db.SaveChangesAsync().Wait();

        logger.LogInformation("Seeding complete");

        return app;

    }

}
