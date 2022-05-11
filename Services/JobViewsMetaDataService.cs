using Microsoft.EntityFrameworkCore;
using PandoLogic.Data;
using PandoLogic.Resources;

namespace PandoLogic.Services;

public class JobViewsMetaDataResourceService : IJobViewsMetaDataService
{
    private readonly JobViewsContext _jobViewsContext;

    public JobViewsMetaDataResourceService(JobViewsContext jobViewsContext)
    {
        _jobViewsContext = jobViewsContext;
    }

    public async Task<List<JobViewsMetaDataResource>> GetMetaData(CancellationToken cancellationToken)
    {
        var metadata = await _jobViewsContext.Jobs
            .Join(_jobViewsContext.Views.Include(x=>x.Job), job => job.Id, view => view.Job.Id, (job, view) => new { job, view })
            .GroupBy(x => x.job.CreationTime)
            .Select(x => new JobViewsMetaDataResource
            {
                Date = x.Key,
                TotalJobs = x.Select(jv => jv.job).Count(),
                TotalViews = x.Select(jv => jv.view).Count(tv => !tv.IsPredicted),
                TotalPredictedJobsViews = x.Select(jv => jv.view).Count(tv => tv.IsPredicted)
            })
            .ToListAsync();

        return metadata;

    }
}