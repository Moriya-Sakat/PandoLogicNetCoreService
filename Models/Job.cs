using JsonApiDotNetCore.Resources;

namespace PandoLogic.Models;

public class Job: Identifiable<int>
{
    public Job()
    {
    }

    public override int Id { get; set; }
    public DateTime CreationTime { get; set; }
    public List<View> Views { get; set; } = null!;
    public bool IsActive { get; set; }
}