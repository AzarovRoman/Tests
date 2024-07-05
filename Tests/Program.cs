using Tests.BLL.MapperProfiles;
using Tests.Extensions;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

// Добавляем контекст базы данных в Di-контейнер
builder.Services.RegisterDbContext(configuration, args[0]);
// Добавляем репозитории (DAL) в Di-контейнер
builder.Services.RegisterProjectRepositories();
// Добавляем сервисы (BLL) в Di-контейнер
builder.Services.RegisterProjectServices();
// Добавляем маппер (BLL) в Di-контейнер
builder.Services.AddAutoMapper(typeof(QuestionsMapper).Assembly);

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
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
