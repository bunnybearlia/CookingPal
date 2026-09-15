using CookingPal.Pages;
using CookingPal.Service;
using SQLite;

namespace CookingPal
{
    public partial class App : Application
    {
        public static LocalDb Database { get; private set; }

        public App()
        {
            InitializeComponent();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "ingredients.db");

            MainPage = new NavigationPage(new LoginPage());
            Database = new LocalDb();
        }
    }
}
