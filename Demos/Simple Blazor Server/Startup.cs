using Microsoft.AspNetCore.Authentication.Cookies;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        //Configuration = configuration;
        string applicationExeDirectory = ApplicationExeDirectory();

        var builder = new ConfigurationBuilder()
            .SetBasePath(applicationExeDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        Configuration = builder.Build();
    }

    private static string ApplicationExeDirectory()
    {
        var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
        var appRoot = Path.GetDirectoryName(location);

        return appRoot;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

        services.AddAuthorizationCore();

        services.AddRazorPages();
        services.AddServerSideBlazor().AddCircuitOptions(o =>
            o.DetailedErrors = true
        );
        services.AddSignalR();

        services.AddHttpContextAccessor();
        services.AddScoped<HttpContextAccessor>();

        services.AddHttpClient();
        services.AddScoped<HttpClient>();

        services.AddOptions();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
        } else {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCookiePolicy();
        app.UseAuthentication();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
            endpoints.MapControllers();
            endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
        });
    }
}