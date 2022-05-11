using PandoLogic.Resources;

namespace PandoLogic.Services;

public interface IJobViewsMetaDataService
{
    public List<JobViewsMetaDataResource> GetMetaData(DateTime startDate, DateTime endDate,
        CancellationToken cancellationToken);
}