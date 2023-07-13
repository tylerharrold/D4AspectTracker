using SQLite;
using D4AspectTracker.MVVM.Models;
using System.Diagnostics;

namespace D4AspectTracker.MVVM.ViewModels
{
    // TODO i have accidentally conflated a viewmodel and a db utility class here. This is misnamed, should not be a vew model,
    //      this becomes a singleton of the app, should be used by a viewmodel not be named a viewmodel
    public class AddAspectViewModel
    {
        private string _dbPath;

        public string StatusMessage { get; set; }

        private SQLiteConnection _connection;

        // simple constructor that requires a path to stored database
        public AddAspectViewModel(string dbPath)
        {
            _dbPath = dbPath;
        }

        // init function to set up the database (if not already set up)
        public void Init()
        {
            // if we are already connected to db, simply return
            if(_connection != null)
            {
                return;
            }

            // 
            _connection = new SQLiteConnection(_dbPath);
            _connection.CreateTable<D4Aspect>(); // this will not create a new table if one already exists
        }

        public void AddNewD4Aspect(string aspectName , string aspectType, string aspectCategory , double minRangeVal,
            double maxRangeVal , string staticVal)
        {
            // setup aspect to add
            D4Aspect aspect = GetNewAspect(aspectName , aspectType , aspectCategory , minRangeVal , maxRangeVal , staticVal);

            // test print lol
            //Debug.Print($"new aspect created:\nAspect Name:{aspect.AspectName}\nAspect Type:{aspect.AspectType}\nAspect Category:{aspect.AspectCategory}\nMin Range:{aspect.MinRangeValue}\nMaxRange:{aspect.MaxRangeValue}\nStatic Val:{aspect.StaticValue}");

            
            int result = 0;
            try
            {
                Init(); // ensure db is set up

                result = _connection.Insert(aspect);
                StatusMessage = "Added new aspect to database";
            }
            catch (Exception ex)
            {
                StatusMessage = ex.Message;
            }
            
        }



        // function to propertly set up the D4Aspect to be entered into database
        private D4Aspect GetNewAspect(string aspectName, string aspectType, string aspectCategory, double minRangeVal,
            double maxRangeVal, string staticVal)
        {
            D4Aspect newAspect = new D4Aspect();

            // enter in string and enum associated values
            newAspect.AspectName = aspectName;
            newAspect.AspectType = GetAspectType(aspectType);
            newAspect.AspectCategory = GetAspectCategory(aspectCategory);
            newAspect.Img = GetImagePath(newAspect.AspectCategory);
            newAspect.StaticValue = string.IsNullOrEmpty(staticVal) ? "" : staticVal;
            newAspect.MinRangeValue = minRangeVal;
            newAspect.MaxRangeValue = maxRangeVal;

            return newAspect;
        }

        // assigns the aspect type based on input string
        private AspectType GetAspectType(string aspectType)
        {
            switch(aspectType)
            {
                case "rangedrollvalue":
                    return AspectType.Range;
                case "staticvalue":
                    return AspectType.Static;
                default:
                    return AspectType.Value;

            }
        }

        // assigns the aspect category based on input string
        private AspectCategory GetAspectCategory(string aspectCategory)
        {

            switch(aspectCategory)
            {
                case "Mobility Aspect":
                    return AspectCategory.Mobility;
                case "Defensive Aspect":
                    return AspectCategory.Defensive;
                case "Utility Aspect":
                    return AspectCategory.Utility;
                case "Resource Aspect":
                    return AspectCategory.Resource;
                default:
                    return AspectCategory.Offensive;
            }
        }

        // returns an image path based on the aspect category
        private string GetImagePath(AspectCategory cat)
        {
            switch (cat)
            {
                case AspectCategory.Offensive:
                    return "offensive_aspect.png";
                case AspectCategory.Defensive:
                    return "defensive_aspect.png";
                case AspectCategory.Utility:
                    return "utility_aspect.png";
                case AspectCategory.Resource:
                    return "resource_aspect.png";
                case AspectCategory.Mobility:
                    return "mobility_aspect.png";
                default:
                    return "offensive_aspect.png";
            }
        }



    }
}
