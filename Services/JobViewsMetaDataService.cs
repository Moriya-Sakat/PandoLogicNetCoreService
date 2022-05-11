using Microsoft.EntityFrameworkCore;
using PandoLogic.Data;
using PandoLogic.Resources;

namespace PandoLogic.Services;

public class JobViewsMetaDataService : IJobViewsMetaDataService
{
    private readonly JobViewsContext _jobViewsContext;
    private readonly ILogger<JobViewsMetaDataService> _logger;
    
    public JobViewsMetaDataService(JobViewsContext jobViewsContext, ILogger<JobViewsMetaDataService> logger)
    {
        _jobViewsContext = jobViewsContext;
        _logger = logger;
    }

    public List<JobViewsMetaDataResource> GetMetaData(DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
    {
        try
        {
            var data = new List<JobViewsMetaDataResource>();

            for (var date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
            {
                var jobs = _jobViewsContext.Jobs.Where(x => x.IsActive && x.CreationTime.Date <= date).ToList()
                           .Select(job => new
                           {
                               Id = job.Id,
                               DaysExisting = (date - job.CreationTime.Date).Days
                           });

                var totalViews = _jobViewsContext.Views
                                .Include(x => x.Job)
                                .Count(x => x.ViewDate.Date == date && jobs.Select(x => x.Id).Contains(x.Job.Id));
                
                var TotalPredictedJobsViews = jobs.Sum(job => 
                                        job.DaysExisting < 5 ? job.DaysExisting * 2 : 
                                        job.DaysExisting < 15 ? job.DaysExisting * 1.5 : 
                                        job.DaysExisting < 25 ? job.DaysExisting : 
                                        job.DaysExisting * 0.5);

                data.Add(new JobViewsMetaDataResource
                {
                    Date = date,
                    TotalJobs = jobs.Count(),
                    TotalViews = totalViews,
                    TotalPredictedJobsViews = Convert.ToInt32(TotalPredictedJobsViews)
                });
            }
            return data;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to get metaData for Jobs Views for date rage: {StartDate} - {EndDate}",
                startDate, endDate);
            throw;
        }
    }
}