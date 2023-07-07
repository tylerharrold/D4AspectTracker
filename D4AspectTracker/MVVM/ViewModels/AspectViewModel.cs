using D4AspectTracker.MVVM.Models;

namespace D4AspectTracker.MVVM.ViewModels
{
    class AspectViewModel
    {
        public Models.Aspect Aspect { get; set; }

        public AspectViewModel()
        {
            Aspect = new Models.Aspect
            {
                AspectName = "Accelerating Aspect",
                AspectType = AspectType.Range,
                MinRangeValue = 15,
                MaxRangeValue = 25
                
            };
        }

    }
}
