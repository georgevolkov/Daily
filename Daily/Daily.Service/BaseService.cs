using AutoMapper;
using Daily.Data.Interfaces;
using Daily.Service.Interfaces;
using System;

namespace Daily.Service
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
