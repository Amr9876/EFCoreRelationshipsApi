var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options 
    => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(options 
    => options.AddProfile<MappingProfile>());

var app = builder.Build();

var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<DataContext>();
var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseDataSeeder();
app.UseDataDestroyer();

// Post Endpoints
app.MapEndpoints(new GetAllPosts(db, mapper), 
                 new GetPost(db, mapper),
                 new AddPost(db, mapper));

// Comment Endpoints
app.MapEndpoints(new AddComment(db, mapper));

app.Run();