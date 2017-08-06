using Prism.Commands;
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

        private bool _answered;
        public bool Answered
        {
            get { return _answered; }
            set { SetProperty(ref _answered, value); }
        }

        public DelegateCommand YesCommand { get; private set; }

        public DelegateCommand NoCommand { get; private set; }

        public DelegateCommand NextCommand { get; private set; }

        #endregion

        public QuizPageViewModel(INavigationService navigationService, GameManager game)
        {
            _navigationService = navigationService;
            _game = game;

            YesCommand = new DelegateCommand(OnYesClick, () => { return !Answered; });
            NoCommand = new DelegateCommand(OnNoClick);
            NextCommand = new DelegateCommand(OnNextClick).ObservesCanExecute(() => Answered);

            ShowFirstQuestion();
        }
        
        public void OnYesClick()
        {
            ShowAnswer();
        }

        public void OnNoClick()
        {
            ShowAnswer();
        }

        public void OnNextClick()
        {
            ShowNextQuestion();
        }

        protected void ShowFirstQuestion()
        {
            var question = _game.CurrentQuestion;
            Question = question.Text;
        }

        protected void ShowNextQuestion()
        {
            var question = _game.NextQuestion();
            Question = question.Text;
        }

        protected void ShowAnswer()
        {
            Answered = true;
            Answer = _game.CurrentQuestion.Answer.Text;
        }
    }
}
