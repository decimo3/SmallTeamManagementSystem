var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(new WebApplicationOptions
    {
        Args = args,
        EnvironmentName = Environments.Development
    });
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

app.Urls.Add("http://*:80");
// app.Urls.Add("https://*:4433");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
