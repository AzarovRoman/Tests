using Tests.BLL.MapperProfiles;
using Tests.Extensions;
using Tests.DAL.Repositories;
using Tests.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.RegisterDbContext(configuration);
builder.Services.RegisterProjectRepositories();
builder.Services.RegisterProjectServices();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

builder.Services.AddAutoMapper(typeof(QuestionsMapper).Assembly);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
