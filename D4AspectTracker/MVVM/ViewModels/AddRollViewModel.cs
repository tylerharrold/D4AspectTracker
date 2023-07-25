
using D4AspectTracker.MVVM.Models;
using D4AspectTracker.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SQLite.SQLite3;

namespace D4AspectTracker.MVVM.ViewModels
{
    class AddRollViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<D4Aspect> Aspects { get; set; }
        public ObservableCollection<D4Aspect> SearchResults { get; set; }

        private D4Aspect _selectedAspect;
        public D4Aspect SelectedAspect 
        { 
            get { return _selectedAspect; } 
            set 
            { 
                _selectedAspect = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedAspect"));
                RangeOrValueAspectSelected?.Invoke(SelectedAspect.AspectType.ToString());

            } 
        }

        public AddRollViewModel()
        {
            // grab all aspects 
            Aspects = new ObservableCollection<D4Aspect>(App.DBManager.GetAllD4Aspects());
            SearchResults = new ObservableCollection<D4Aspect>();

           
        }

        // event handler for property changes
        public event PropertyChangedEventHandler PropertyChanged;

        // custom event handler to enable the input of values for range and value types
        public delegate void RangeOrValueAspectSelectedHandler(string type);
        public event RangeOrValueAspectSelectedHandler RangeOrValueAspectSelected;

        

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
            D4Aspect selected = e.CurrentSelection.FirstOrDefault() as D4Aspect;

            SelectedAspect = selected;

        }


    }

    
}
