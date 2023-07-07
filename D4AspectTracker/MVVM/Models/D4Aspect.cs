

namespace D4AspectTracker.MVVM.Models
{
    public class D4Aspect
    {
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
