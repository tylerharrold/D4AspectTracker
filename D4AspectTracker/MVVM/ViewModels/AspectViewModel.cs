using D4AspectTracker.MVVM.Models;

namespace D4AspectTracker.MVVM.ViewModels
{
    class AspectViewModel
    {
        public D4Aspect Aspect { get; set; }

        public AspectViewModel()
        {
            Aspect = new D4Aspect
            {
                AspectName = "Accelerating Aspect",
                AspectType = AspectType.Range,
                MinRangeValue = 15,
                MaxRangeValue = 25
                
            };
        }

    }
}
