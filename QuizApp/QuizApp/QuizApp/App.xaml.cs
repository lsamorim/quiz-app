using Microsoft.Practices.Unity;
using Prism.Unity;
using QuizApp.Models;
using QuizApp.Views;
using Xamarin.Forms;

namespace QuizApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }
        
        protected override void OnInitialized()
        {
            InitializeComponent();

            //NavigationService.NavigateAsync("NavigationPage/MainPage?title=Hello%20from%20Xamarin.Forms");
            NavigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms");

        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<QuizPage>();

            Container.RegisterInstance(typeof(GameManager), new GameManager());
        }
    }
}
