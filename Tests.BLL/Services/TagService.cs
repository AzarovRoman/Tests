using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.BLL.Models;
using Tests.DAL.Entities;
using Tests.DAL.Interfaces;
using Tests.BLL.Exceptions;
using Tests.BLL.Interfaces;

namespace Tests.BLL.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Добавление тега в бд
        /// </summary>
        public void AddTag(TagModel model)
        {
            var result = _tagRepository.AddTag(_mapper.Map<Tag>(model));

            if (result < 1)
            {
                throw new ServerExeption("не удалось добавить тег в базу данных");//Неправильно написан EXCEPTION 
            }
        }

        /// <summary>
        /// Получение тега по id
        /// </summary>
        public TagModel GetTag(int id)
        {
            var tag = _tagRepository.GetTagById(id);
            var tagModel = _mapper.Map<TagModel>(tag);

            if (tagModel == null)
            {
                throw new ServerExeption($"Объект с id {id} не существует");
            }
            return tagModel;
        }

        /// <summary>
        /// Удаление тега из бд
        /// </summary>
        public void DeleteTag(int id)
        {
            var tagToDelete = _tagRepository.GetTagById(id);
            var result = -1;
            if (tagToDelete != null)
            {
               result =  _tagRepository.DeleteTag(tagToDelete);
            }

            if (result < 1)
            {
                throw new ServerExeption("Не удалось удалить тег по id");
            }

        }
    }
}
