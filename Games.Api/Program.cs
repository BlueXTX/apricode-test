using FluentValidation;
using FluentValidation.AspNetCore;
using Games.Application;
using Games.Application.Validators;
using Games.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGamesApplication();
builder.Services.AddGamesInfrastructure();

builder.Services.AddValidatorsFromAssemblyContaining<GameCreateDtoValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
