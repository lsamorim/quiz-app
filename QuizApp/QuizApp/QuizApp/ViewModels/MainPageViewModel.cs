using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            _game.Questions.Add(
                new Question()
                {
                    Text = "O doce mais doce que o doce de batata doce é o doce de batata doce???",
                    Answer = new Answer()
                    {
                        Text = "Sim! O doce mais doce que o doce de batata doce é o doce de batata doce!!"
                    }
                }
            );

            await System.Threading.Tasks.Task.Delay(2000);

            await _navigationService.NavigateAsync("/NavigationPage/QuizPage");
        }
    }
}
