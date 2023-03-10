using FluentValidation;
using FluentValidationPlayground.Dtos;
using FluentValidationPlayground.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IValidator<SingleRuleDto>, SingleRuleValidator>();
builder.Services.AddScoped<IValidator<SeparateRulesDto>, SeparateRulesValidator>();

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
