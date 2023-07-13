using D4AspectTracker.MVVM.Models;
using System.Collections.ObjectModel;

namespace D4AspectTracker.MVVM.ViewModels
{
    internal class AspectListViewModel
    {
        //public ObservableCollection<D4Aspect> Aspects { get; set; }
        public ObservableCollection<D4Aspect> AllAspects { get; set; }

        public AspectListViewModel() 
        {
            AllAspects = new ObservableCollection<D4Aspect>(App.AddAspectVM.GetAllD4Aspects());
            /*
            Aspects = new ObservableCollection<D4Aspect>();

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
            */
        }

        public void RefreshAllAspects()
        {
            // manually garbage collect here???
            AllAspects = new ObservableCollection<D4Aspect>(App.AddAspectVM.GetAllD4Aspects());
        }

        public void OnAddAnotherD4Aspect(object sender, EventArgs e)
        {
            /*
            Aspects.Add(new D4Aspect
            {
                AspectName = "Balanced Aspect",
                AspectType = AspectType.Range,
                MinRangeValue = 30,
                MaxRangeValue = 50
            });
            */
        }

    }
}
