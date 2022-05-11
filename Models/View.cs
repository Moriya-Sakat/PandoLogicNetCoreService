using JsonApiDotNetCore.Resources;

namespace PandoLogic.Models;

public class View : Identifiable<int>
{
    public View()
    {
    }

    public override int Id { get; set; }
    public DateTime ViewDate { get; set; }
    public Job Job { get; set; } = null!;
}