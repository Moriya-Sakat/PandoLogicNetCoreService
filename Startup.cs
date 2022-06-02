using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PandoLogic.Data;
using PandoLogic.Services;

namespace PandoLogic;

public class Startup
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _env;

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        _configuration = configuration;
        _env = env;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers().AddNewtonsoftJson(options=>
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);;
        
        var mysqlConnectionString = _configuration.GetConnectionString("MySql");

        services.AddDbContext<JobViewsContext>(options =>
            options.UseMySql(mysqlConnectionString, MySqlServerVersion.LatestSupportedServerVersion,
                static dbContextOptions => dbContextOptions.EnableRetryOnFailure(3)));
        
        services.AddScoped<IJobViewsMetaDataService, JobViewsMetaDataService>();
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseDeveloperExceptionPage();
        
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}