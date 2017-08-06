using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using QuizApp.Models;

namespace QuizApp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        #region Properties

        private readonly INavigationService _navigationService;
        private readonly GameManager _game;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand StartCommand { get; private set; }

        #endregion

        public MainPageViewModel(INavigationService navigationService, GameManager game)
        {
            _navigationService = navigationService;
            _game = game;

            StartCommand = new DelegateCommand(OnStartClick);
        }

        #region Navigation Flow

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }

        #endregion

        public async void OnStartClick()
        {
            _game.Questions = new System.Collections.Generic.List<Question>()
            {
                new Question()
                {
                    Text = "Um raio pode derrubar o avião???",
                    Answer = new Answer()
                    {
                        Text = "Sim! Tecnicamente, um raio pode, sim, derrubar um avião. Mas as chances disso acontecer são extremamente raras.",
                        IsTrue = true
                    }
                },
                new Question()
                {
                    Text = "O doce mais doce que o doce de batata doce é o doce de batata doce???",
                    Answer = new Answer()
                    {
                        Text = "Sim! O doce mais doce que o doce de batata doce é o doce de batata doce!!",
                        IsTrue = true
                    }
                },
                new Question()
                {
                    Text = "A fórmula da Coca-Cola nunca foi descoberta.",
                    Answer = new Answer()
                    {
                        Text = "Falso! Muitos pensam que a fórmula da Coca-Cola é um segredo completo, mas não é bem assim. Para saber os ingredientes usados no refrigerante, tudo que você precisa fazer é olhar no rótulo da garrafa.",
                        IsTrue = false
                    }
                },
                new Question()
                {
                    Text = "Quem usa o lado esquerdo do cérebro é melhor em Matemática.",
                    Answer = new Answer()
                    {
                        Text = "Falso! Todos os hemisférios estão aptos a serem habilidosos em ambas as áreas.",
                        IsTrue = false
                    }
                }
            };

            //await System.Threading.Tasks.Task.Delay(2000);

            try
            {
                await _navigationService.NavigateAsync("/NavigationPage/QuizPage");
            }
            catch (System.Exception ex)
            {
            }
        }
    }
}
