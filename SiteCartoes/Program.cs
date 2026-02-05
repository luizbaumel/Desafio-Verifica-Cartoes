using SiteCartoes.Services;

var builder = WebApplication.CreateBuilder(args);

// Razor Pages
builder.Services.AddRazorPages();

// Services
builder.Services.AddScoped<ICardValidator, CardValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ⚠️ ISSO É O MAIS IMPORTANTE
app.MapRazorPages();

app.Run();