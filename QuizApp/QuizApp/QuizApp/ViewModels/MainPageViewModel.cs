using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizApp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        #region Properties

        private readonly INavigationService _navigationService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand OnStartCommand { get; private set; }

        #endregion

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            OnStartCommand = new DelegateCommand(OnStartClick);
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

        public void OnStartClick()
        {
            _navigationService.NavigateAsync("/NavigationPage/QuizPage");
        }
    }
}
