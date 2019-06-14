using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Questionnaire.Data.Enums;
using Questionnaire.Service.Enums;
using Questionnaire.Service.Interfaces;
using Questionnaire.Service.Models;
using Questionnaire.Service.Query;
using Questionnaire.Web.Models;
using System.Threading.Tasks;

namespace Questionnaire.Web.Controllers.Base
{
    public class BaseController : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly IAnswerService _answerService;
        protected readonly UserManager<User> _userManager;
        protected readonly SignInManager<User> _signInManager;

        public BaseController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public BaseController(IMapper mapper, IAnswerService answerService, UserManager<User> userManager)
        {
            _userManager = userManager;
            _answerService = answerService;
            _mapper = mapper;
        }

        protected async Task<QueryResponse<AnswerModel>> GetData(int pageSize, int pageNumber, int sort, string query = null)
        {
            return await _answerService.GetAsync(new QueryRequest<SortType>
            {
                Start = (pageSize * (pageNumber - 1)),
                Length = pageSize,
                OrderQueries = new[]
                {
                    new QueryOrder<SortType>
                    {
                        Direction = SortDirectionType.Descending,
                        OrderType = sort == 0 ? SortType.Name : SortType.BirthDate
                    }
                },
                Search = new QuerySearch
                {
                    Value = query
                }
            });
        }
    }
}