using D4AspectTracker.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D4AspectTracker.MVVM.ViewModels
{
    class AddRollViewModel
    {

        public ObservableCollection<D4Aspect> Aspects;

        public AddRollViewModel()
        {
            // grab all aspects 
            Aspects = new ObservableCollection<D4Aspect>(App.DBManager.GetAllD4Aspects());
        }

        public void OnSearchButtonPressed(object sender, EventArgs e)
        {
            SearchBar sb = (SearchBar)sender;

            // search the aspects collection for an aspect matching the name 
            foreach(D4Aspect aspect in Aspects)
            {
                if(aspect.AspectName == sb.Text)
                {
                    Debug.Print($"Found {aspect.AspectName}");
                    break;
                }
            }

        }


    }

    
}
