namespace LilyFNServer
{
    public class LilyFNServer
    {
        public static WebApplicationBuilder? builder;
        public static WebApplication? app;

        public static void Start(string[] args)
        {
            builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            app = builder.Build();

            app.MapGet("/", () => "Hello World! Hot Realod pt2!");

            app.MapControllers();

            app.Run();
        }
    }
}
