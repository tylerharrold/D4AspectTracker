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

            // if the search bar contains empty string, clear search results and return
            if(string.IsNullOrEmpty(sb.Text))
            {
                ClearSearchResults();
                return;
            }

            // remove all current items from search results collection
            ClearSearchResults();
            GetSearchResults(sb.Text);

        }

        public void OnSearchTextChanged(object sender, EventArgs e)
        {
            SearchBar sb = (SearchBar)sender;

            if (string.IsNullOrEmpty(sb.Text))
            {
                ClearSearchResults();
                return;
            }

            // remove all current items from search results collection
            ClearSearchResults();
            GetSearchResults(sb.Text);
        }


        // get search results
        private void GetSearchResults(string s)
        {
            // seems inelegant, but should work for now
            foreach (D4Aspect aspect in Aspects)
            {
                if (aspect.AspectName.ToLower().Contains(s.ToLower()))
                {
                    // TODO is this by reference???
                    SearchResults.Add(aspect);


                }
            }
        }

        // Clear search results list of entries
        private void ClearSearchResults()
        {
            SearchResults.Clear();
        }

        // handler for when an aspect template is selected to base new roll entry off of
        public void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // enter text of selection into search bar

            // clear other search items

            // enable view that shows all information about the selected roll
        }


    }

    
}
