using SQLite;
using D4AspectTracker.MVVM.Models;

namespace D4AspectTracker.MVVM.ViewModels
{
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

    }
}
