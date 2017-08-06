﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using QuizApp.Models;

namespace QuizApp.ViewModels
{
    public class QuizPageViewModel : BindableBase
    {
        #region Properties

        private readonly INavigationService _navigationService;
        private readonly GameManager _game;

        private string _question;
        public string Question
        {
            get { return _question; }
            set { SetProperty(ref _question, value); }
        }

        private string _answer;
        public string Answer
        {
            get { return _answer; }
            set { SetProperty(ref _answer, value); }
        }

        private bool _isAnswered;
        public bool IsAnswered
        {
            get { return _isAnswered; }
            set { SetProperty(ref _isAnswered, value); }
        }

        private bool _isLastQuestion;
        public bool IsLastQuestion
        {
            get { return _isLastQuestion; }
            set { SetProperty(ref _isLastQuestion, value); }
        }

        private int _score;
        public int Score
        {
            get { return _score; }
            set { SetProperty(ref _score, value); }
        }

        public DelegateCommand YesCommand { get; private set; }

        public DelegateCommand NoCommand { get; private set; }

        public DelegateCommand NextCommand { get; private set; }

        public DelegateCommand EndCommand { get; private set; }

        #endregion

        public QuizPageViewModel(INavigationService navigationService, GameManager game)
        {
            _navigationService = navigationService;
            _game = game;
            _game.Reset();

            YesCommand = new DelegateCommand(OnYesClick);
            NoCommand = new DelegateCommand(OnNoClick);
            NextCommand = new DelegateCommand(OnNextClick).ObservesCanExecute(() => IsAnswered);
            EndCommand = new DelegateCommand(OnEndClick).ObservesCanExecute(() => IsAnswered);

            ShowNextQuestion();
        }
        
        public void OnYesClick()
        {
            TryAnswer(true);
        }

        public void OnNoClick()
        {
            TryAnswer(false);
        }

        public void OnNextClick()
        {
            ShowNextQuestion();
        }

        public void OnEndClick()
        {
            _navigationService.NavigateAsync("/MainPage");
        }
        
        protected void TryAnswer(bool yes)
        {
            IsAnswered = true;

            Answer = _game.CurrentQuestion.Answer.Text;

            _game.AnswerCurrentQuestion(yes);
            Score = _game.Score;
        }

        protected void ShowNextQuestion()
        {
            IsAnswered = false;

            var question = _game.NextQuestion();
            IsLastQuestion = _game.IsLastQuestion();

            Question = question.Text;
        }
    }
}
