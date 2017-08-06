namespace QuizApp.Models
{
    public class Question
    {
        public string Text { get; set; }

        public Answer Answer { get; set; }

        public bool ValidateAnswer(bool yes)
        {
            return Answer.IsTrue == yes;
        }
    }
}
