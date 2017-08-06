using System.Collections.Generic;

namespace QuizApp.Models
{
    public class GameManager
    {
        public List<Question> Questions { get; set; }

        private int _currentQuestionIndex = 0;
        
        public Question CurrentQuestion
        {
            get
            {
                return _currentQuestionIndex < Questions.Count ? Questions[_currentQuestionIndex] : null;
            }
        }

        public GameManager()
        {
            Questions = new List<Question>();
        }

        public Question NextQuestion()
        {
            _currentQuestionIndex++;

            return CurrentQuestion;
        }
    }
}
