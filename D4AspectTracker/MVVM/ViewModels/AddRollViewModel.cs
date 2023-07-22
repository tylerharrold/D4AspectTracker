using D4AspectTracker.MVVM.Models;
using D4AspectTracker.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SQLite.SQLite3;

namespace D4AspectTracker.MVVM.ViewModels
{
    class AddRollViewModel
    {

        public ObservableCollection<D4Aspect> Aspects { get; set; }
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

            // remove all current items from search results collection
            ClearSearchResults();

            // seems inelegant, but should work for now
            foreach (D4Aspect aspect in Aspects)
            {
                if (aspect.AspectName.ToLower().Contains(sb.Text.ToLower()))
                {
                    // TODO is this by reference???
                    SearchResults.Add(aspect);
                    

                }
            }





        }

        // TODO
        // this function is at least temporarily defunct. This was assigning a new list
        // to SearchResults, which would be fine, but the xaml data binding for collection view
        // was lost because its event firing was coming from old, garbage collected list assinged 
        // to search results. 
        // this search method needs to be way more tolerant, but its functional for now
        private ObservableCollection<D4Aspect> GetSearchResults(string aspectName)
        {
            ObservableCollection<D4Aspect> results = new ObservableCollection<D4Aspect>();
            foreach(D4Aspect aspect in Aspects)
            {
                if(aspect.AspectName.ToLower().Contains(aspectName.ToLower()))
                {
                    // TODO is this by reference???
                    results.Add(aspect);
                    Debug.Print("Found a match");
                        
                }
            }

            return results;
        }

        private void ClearSearchResults()
        {
            SearchResults.Clear();
        }


    }

    
}
