using Kanban.Db;
using Kanban.Db.Context;
using Kanban.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Kanban.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Kanban API", Version = "v1" }));

builder.Services.AddDbContext<BoardContext>(options => 
                    options.UseNpgsql(builder.Configuration.GetConnectionString("BoardContext")));
builder.Services.AddScoped<IBoardRepository, BoardRepository>();
builder.Services.AddScoped<IBoardService, BoardService>();

builder.Services.AddAutoMapper(typeof(AppMappingProfile));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BoardContext>();
    context.Database.Migrate();
}

app.UseSwaggerUI();
app.UseSwagger();
app.MapControllers();
app.Urls.Add("http://0.0.0.0:5000");
// app.UseHttpsRedirection();
app.Run();
