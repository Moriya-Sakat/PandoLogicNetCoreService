using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PandoLogic.Data;
using PandoLogic.Services;

namespace PandoLogic;

public class TestStartup
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _env;

    public TestStartup(IConfiguration configuration, IWebHostEnvironment env)
    {
        _configuration = configuration;
        _env = env;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers().AddNewtonsoftJson(options=>
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);;

        services.AddDbContext<JobViewsContext>(options =>
        {
            options.UseInMemoryDatabase("pandologic");
        });

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