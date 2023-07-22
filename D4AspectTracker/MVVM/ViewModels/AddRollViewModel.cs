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
        public ObservableCollection<D4Aspect> SearchResults { get; set; }

        public AddRollViewModel()
        {
            // grab all aspects 
            Aspects = new ObservableCollection<D4Aspect>(App.DBManager.GetAllD4Aspects());
            SearchResults = new ObservableCollection<D4Aspect>();
        }

        public void OnSearchButtonPressed(object sender, EventArgs e)
        {
            SearchBar sb = (SearchBar)sender;

            SearchResults = GetSearchResults(sb.Text);

        }

        // TODO
        // this search method needs to be way more tolerant, but its functional for now
        private ObservableCollection<D4Aspect> GetSearchResults(string aspectName)
        {
            ObservableCollection<D4Aspect> results = new ObservableCollection<D4Aspect>();

            foreach(D4Aspect aspect in Aspects)
            {
                if(aspect.AspectName.ToLower().Contains(aspectName.ToLower()))
                {
                    // TODO is this by reference???
                    results.Append(aspect);
                    Debug.Print("Found a match");
                        
                }
            }

            return results;
        }


    }

    
}
