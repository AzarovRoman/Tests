﻿using AutoMapper;
using Tests.BLL.Exceptions;
using Tests.BLL.Interfaces;
using Tests.BLL.Models;
using Tests.BLL.Validations;
using Tests.DAL;
using Tests.DAL.Entities;
using Tests.DAL.Interfaces;

namespace Tests.BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IMapper mapper, IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;

            _mapper = mapper;
        }


        public QuestionModel? GetQuestionById(int id)
        {
            var question = _questionRepository.GetQuestionById(id);
            var questionModel = _mapper.Map<QuestionModel>(question);

            if (questionModel == null)
            {
                throw new Exception($"Объект с id {id} не существует");
            }
            return questionModel;
        }
        public QuestionModel GetQuestionRandom()
        {
            var question = _questionRepository.GetRandomQuestion();
            var questionModel = _mapper.Map<QuestionModel>(question);

            if (questionModel != null)
            {
                return questionModel;
            }
            else
            {
                throw new Exception("Вопроса в базе данных не существует, повторите попытку");
            }

        }

        public int AddQuestion(QuestionModel model)
        {

            if (Validation.IsCorrectQuestion(model) == false)
            {
                throw new Exception("Список ответов не удовлетворяет требования создания вопроса - (1 правильный и 3 неправильных ответа)");
            }
            var result = _questionRepository.AddQuestion(_mapper.Map<Question>(model));

            if (result < 1)
            {
                throw new ServerExeption("Не удалось создать новый вопрос для теста");
            }            

            return result;
        }
        public void DeleteQuestion(int id)
        { 
            var result = _questionRepository.DeleteQuestion(id);

            if (result < 1) 
            {
                throw new ServerExeption("Не удалось удалить вопрос по id");
            }
        }

    }
}
