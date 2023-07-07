using D4AspectTracker.MVVM.Models;


namespace D4AspectTracker.MVVM.ViewModels
{
    internal class AspectListViewModel
    {
        public List<D4Aspect> Aspects { get; set; }

        public AspectListViewModel() 
        {
            Aspects = new List<D4Aspect>();

            Aspects.Add(new D4Aspect
            {
                AspectName = "Accelerating Aspect",
                AspectType = AspectType.Range,
                MinRangeValue = 15,
                MaxRangeValue = 25
            });

            Aspects.Add(new D4Aspect{
                AspectName = "Aspect of Ancesteral Echoes",
                AspectType = AspectType.Range, 
                MinRangeValue = 40,
                MaxRangeValue = 50
            });

            Aspects.Add(new D4Aspect
            {
                AspectName = "Aspect of Binding Embers",
                AspectType = AspectType.Range,
                MinRangeValue = 2,
                MaxRangeValue = 3
            });
        }

    }
}
