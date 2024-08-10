using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.BLL.Models;

namespace Tests.BLL.Validations
{
    public static class Validation
    {
        /// <summary>
        /// Метод проверяет вопрос на наличие 3 неправильных и 1 правильного ответа, а так же выполняет проверку на отсутствие пустых строк)
        /// </summary>       
        public static bool IsCorrectQuestion(QuestionModel question)
        {
            List<AnswerModel> answers = question.Answers;

            //Счетчики правильных и неправильных ответов
            int counterTrue = answers.Where(answer => answer.IsRight == true).ToList().Count;
            int counterFalse = answers.Where(answer => answer.IsRight == false).ToList().Count;

            if ((counterTrue == 1 && counterFalse == 3) && (question.Text != null || question.Text != string.Empty))
            {
                return true;
            }
            return false;
        }
    }
}