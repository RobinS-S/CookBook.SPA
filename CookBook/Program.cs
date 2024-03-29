namespace CookBook;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var startup = new Startup(builder.Configuration, builder.Environment);

        startup.ConfigureServices(builder.Services);
        var app = builder.Build();
        await startup.Configure(app);
        await app.RunAsync();
    }
}