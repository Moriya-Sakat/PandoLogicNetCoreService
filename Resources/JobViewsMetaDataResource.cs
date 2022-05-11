using JsonApiDotNetCore.Resources;

namespace PandoLogic.Resources;

public class JobViewsMetaDataResource : Identifiable
{
    public DateTime Date { get; set; }
    public int TotalJobs { get; set; }
    public int TotalViews { get; set; }
    public int TotalPredictedJobsViews { get; set; }
}