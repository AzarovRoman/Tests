﻿using AutoMapper;
using Tests.BLL.Interfaces;
using Tests.BLL.Models;
using Tests.DAL;
using Tests.DAL.Entities;
using Tests.DAL.Interfaces;

namespace Tests.BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly Context _context;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(Context ctx, IMapper mapper, IQuestionRepository questionRepository)
        {
            _context = ctx;
            _questionRepository = questionRepository;

            _mapper = mapper;
        }

        public int AddQuestion(QuestionModel model)
        {
            var result = _questionRepository.AddQuestion(_mapper.Map<Question>(model));

            if (result < 1)
            {
                throw new Exception("Не удалось создать новый вопрос для теста");
            }

            return result;
        }
    }
}
