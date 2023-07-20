using SQLite;
using System.Diagnostics;

namespace D4AspectTracker.MVVM.Models;

[Table("user")]
public class User
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(30) , Unique]
    public string UserName { get; set; }
}
