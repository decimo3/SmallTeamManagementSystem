var builder = WebApplication.CreateBuilder(new WebApplicationOptions
    {
        Args = args,
        EnvironmentName = Environments.Development
    });

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

app.Urls.Add($"http://*:{System.Environment.GetEnvironmentVariable("WEBAPP_PORT")}");
// app.Urls.Add("https://*:4433");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
