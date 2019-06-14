﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Questionnaire.Common.Interfaces;
using Questionnaire.Data;
using Questionnaire.Data.Interfaces;
using Questionnaire.Service.Interfaces;
using Questionnaire.Service;

namespace Questionnaire.Common
{
    public class PlatformInitializer : IPlatformInitializer
    {
        protected IConfiguration _configuration;

        public PlatformInitializer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // configure database
            ConfigureDatabase(services);

            // add singletone instances
            services.AddSingleton(Mapping.Configuration.CreateDefaultMapper());

            // add scoped registrations
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAnswerService, AnswerService>();
        }

        protected virtual void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<DbContext, Data.AppContext>(options =>
               options.UseSqlServer(
                   _configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
