using SQLite;

namespace D4AspectTracker.MVVM.Models;

[Table("aspect_drop")]
public class AspectDrop
{
    [PrimaryKey , AutoIncrement] 
    public int Id { get; set; }

    public int UserId { get; set; }

    public int AspectID { get; set; }

    public double Value { get; set; }


}
