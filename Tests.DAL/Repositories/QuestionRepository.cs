﻿using Tests.DAL.Entities;
using Tests.DAL.Interfaces;

namespace Tests.DAL.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private Context _context;

        public QuestionRepository(Context context)
        {
            _context = context;
        }

        public Question? GetQuestionById(int id)
        {
            var question = _context.Questions.FirstOrDefault(x => x.Id == id);

            return question;
        }

        /// <summary>
        /// Добавление сущности вопроса в базу данных
        /// </summary>
        public int AddQuestion(Question question)
        {
            // Попытка записать вопрос в таблицу Questions
            _context.Questions.Add(question);

            // Сохранение изменений в базе данных. result - количество новых добавленных строк
            // если result меньше 1, то данные не сохранились
            var result = _context.SaveChanges();

            return result;
        }
    }
}