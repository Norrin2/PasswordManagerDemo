using PasswordManager.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPasswordCardRepository, PasswordCardRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PasswordManagerPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.UseCors("PasswordManagerPolicy");

app.Run();