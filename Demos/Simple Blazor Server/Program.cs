using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Simple_Blazor_Server.Data;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureServices((context, services) => {                
            });
}
