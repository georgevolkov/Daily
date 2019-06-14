using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Daily.Data.Enums;
using Daily.Service.Enums;
using Daily.Service.Interfaces;
using Daily.Service.Models;
using Daily.Service.Query;
using Daily.Web.Models;
using System.Threading.Tasks;

namespace Daily.Web.Controllers.Base
{
    public class BaseController : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly IDailyService _dailyService;
        protected readonly UserManager<User> _userManager;
        protected readonly SignInManager<User> _signInManager;

        public BaseController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public BaseController(IMapper mapper, IDailyService dailyService, UserManager<User> userManager)
        {
            _userManager = userManager;
            _dailyService = dailyService;
            _mapper = mapper;
        }

        protected async Task<QueryResponse<DailyModel>> GetData(int pageSize, int pageNumber, string query = null)
        {
            return await _dailyService.GetAsync(new QueryRequest<SortType>
            {
                Start = (pageSize * (pageNumber - 1)),
                Length = pageSize,
                OrderQueries = new[]
                {
                    new QueryOrder<SortType>
                    {
                        Direction = SortDirectionType.Descending,
                        OrderType = SortType.Date
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