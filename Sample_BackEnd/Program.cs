using Microsoft.EntityFrameworkCore;
using Sample_BackEnd.Data;
using Sample_BackEnd.Mapper;
using Sample_BackEnd.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Database Injection
builder.Services.AddDbContext<SampleDbContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("TaskConnectionString")));

//Repository pattern Injection
builder.Services.AddScoped<TaskListRepository, SQLTaskListRepository>();

//AutoMapping Injection
builder.Services.AddAutoMapper(typeof(TaskListAutoMapper));

builder.Services.AddCors(option => option.AddPolicy("CorsPolicy", policy => {
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

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

app.UseCors("CorsPolicy");

app.Run();
