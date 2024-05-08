using DataRepo.Interfaces;
using DataRepo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddCors(options => 
{
    options.AddDefaultPolicy(policy  =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IPostSorterService, PostSorterService>();

builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<IPostsService, PostsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();

app.Run();
