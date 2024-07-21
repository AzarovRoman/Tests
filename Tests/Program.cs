using Tests.BLL.MapperProfiles;
using Tests.Extensions;
using Tests.Middleware;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

// ��������� �������� ���� ������ � Di-���������
builder.Services.RegisterDbContext(configuration);
// ��������� ����������� (DAL) � Di-���������
builder.Services.RegisterProjectRepositories();
// ��������� ������� (BLL) � Di-���������
builder.Services.RegisterProjectServices();
// ��������� ������ (BLL) � Di-���������
builder.Services.AddAutoMapper(typeof(QuestionsMapper).Assembly, typeof(TestsMapper).Assembly);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// ����������� middleware

app.UseGlobalExceptionHandler();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
