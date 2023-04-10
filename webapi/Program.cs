var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder();
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    dotenv.net.DotEnv.Fluent().WithEnvFiles("../.env").Load();
    app.UseSwagger();
    app.UseSwaggerUI();
}
var port = System.Environment.GetEnvironmentVariable("WEBAPI_PORT");
app.Urls.Add($"http://*:{port}");
// app.Urls.Add("https://*:4433");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
