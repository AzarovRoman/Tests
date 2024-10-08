﻿using Microsoft.EntityFrameworkCore;
using Tests.BLL.Interfaces;
using Tests.BLL.Services;
using Tests.DAL;
using Tests.DAL.Interfaces;
using Tests.DAL.Repositories;

namespace Tests.Extensions
{
    public static class ExtensionServiceProvider
    {
        public static void RegisterProjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
        }

        public static void RegisterProjectServices(this IServiceCollection services)
        {
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<ITagService, TagService>();
        }

        public static void RegisterDbContext(this IServiceCollection services, ConfigurationManager configManager, string databaseName = "RemoteDb")
        {
            services.AddDbContext<Context>(op => op.UseNpgsql(configManager.GetConnectionString(databaseName)));
        }
    }
}
