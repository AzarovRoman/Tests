﻿using Microsoft.EntityFrameworkCore;
using Tests.DAL.Entities;
using Tests.DAL.Interfaces;

namespace Tests.DAL.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly Context _context;

        public QuestionRepository(Context context)
        {
            _context = context;
        }
        /// <summary>
        /// Получение вопроса по id
        /// </summary>       
        public Question? GetQuestionById(int id)
        {
            var question = _context.Questions.Include(x => x.Answers).FirstOrDefault(x => x.Id == id);

            return question;
        }

        /// <summary>
        /// Получение рандомного вопроса из базы данных
        /// </summary>        
        public Question GetRandomQuestion() 
        {
            Random random = new Random();
            int skipper = random.Next(0, _context.Questions.Count());
            var question = _context.Questions.Include(x => x.Answers).Skip(skipper).Take(1).FirstOrDefault();
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

        /// <summary>
        /// Удаление сущности вопроса из базы данных по id
        /// </summary>       
        public int DeleteQuestion(int id)
        {            
            _context.Questions.Remove(GetQuestionById(id));
            var result = _context.SaveChanges();

            return result;
        }

        public List<Question>? GetQuestionByIds(List<int> ids)
        {
            var question = _context.Questions.AsNoTracking().Where(q => ids.Contains(q.Id)).ToList();

            return question;
        }
    }
}