using SQLite;

namespace D4AspectTracker.MVVM.Models
{
    [Table("d4aspect")]
    public class D4Aspect
    {
        // primary key for d4aspect table, will autoincrment values per column added
        [PrimaryKey , AutoIncrement]
        public int Id { get; set; }

        // this is the table for aspect definitions, so there only needs to be one
        [MaxLength(250) , Unique]
        public string AspectName { get; set; }
        public AspectType AspectType { get; set; }
        public double MinRangeValue { get; set; }
        public double MaxRangeValue { get; set; }
        public int FlatValue { get; set; }
        public string StaticValue { get; set; }

    }



    public enum AspectType
    {
        Range,
        Value,
        Static
    }
}
