using BusinessLogical.Logical;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/GetFile", (string url) => UrlHandler.GetFile(url));
app.MapGet("/GetPage", (string url) => UrlHandler.GetPdf(url));

app.Run();