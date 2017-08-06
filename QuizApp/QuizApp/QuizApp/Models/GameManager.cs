using System;
using System.Collections.Generic;

namespace QuizApp.Models
{
    public class GameManager
    {
        public List<Question> Questions { get; set; }

        public int Score { get; private set; }

        private int _currentQuestionIndex = -1;
        
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

        public void Reset()
        {
            Score = 0;
            _currentQuestionIndex = -1;
        }

        public bool AnswerCurrentQuestion(bool yes)
        {
            if (CurrentQuestion == null) return false;

            var correct = CurrentQuestion.ValidateAnswer(yes);

            if (correct)
                Score++;

            return correct;
        }

        public Question NextQuestion()
        {
            _currentQuestionIndex++;

            return CurrentQuestion;
        }

        public bool IsLastQuestion()
        {
            return (_currentQuestionIndex == Questions.Count - 1);
        }
    }
}
