using Tests.BLL.MapperProfiles;
using Tests.Extensions;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

// ��������� �������� ���� ������ � Di-���������
builder.Services.RegisterDbContext(configuration, args[0]);
// ��������� ����������� (DAL) � Di-���������
builder.Services.RegisterProjectRepositories();
// ��������� ������� (BLL) � Di-���������
builder.Services.RegisterProjectServices();
// ��������� ������ (BLL) � Di-���������
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
