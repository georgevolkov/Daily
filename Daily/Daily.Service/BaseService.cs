using AutoMapper;
using Questionnaire.Data.Interfaces;
using Questionnaire.Service.Interfaces;
using System;

namespace Questionnaire.Service
{
    public class BaseService : IBaseService
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _uow;

        protected Guid Id => Guid.NewGuid();

        public BaseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
    }
}
