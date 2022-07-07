using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Person.Application.Commands.User.Create;
using Person.Application.Commands.User.Update;
using Person.Application.Handlers.CommandHandlers;
using Person.Core.Repositories;
using Person.Core.Repositories.Base;
using Person.Infastructure.Data;
using Person.Infastructure.Repositories;
using Person.Infastructure.Repositories.Base;
using System.Diagnostics;
using System.Reflection;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddFluentValidation(options =>
{
    // Validate child properties and root collection elements
    options.ImplicitlyValidateChildProperties = true;
    options.ImplicitlyValidateRootCollectionElements = true;
    // Automatic registration of validators in assembly
    // options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    options.RegisterValidatorsFromAssemblyContaining<UpdateUserCommandValidator>();
    options.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
});

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Person.Api",
        Version = "v1"
    });
});
//builder.Services.AddHangfire(config =>
//{
//    config.UseSqlServerStorage(connectionString);
//});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(typeof(CreateUserHandler).GetTypeInfo().Assembly);
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IUserRepository, UserRepository>();

var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\Person\\EmailSender\\bin\\Debug\\net6.0\\EmailSender.exe";
var p = new Process();
p.StartInfo.FileName = projectPath;
var startTimeSpan = TimeSpan.Zero;
var periodTimeSpan = TimeSpan.FromMinutes(5);

var timer = new System.Threading.Timer((e) =>
{
    p.Start();
}, null, startTimeSpan, periodTimeSpan);

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHangfireDashboard("/myJobDashboard");
//RecurringJob.AddOrUpdate(() => HappyBirthDay.sendEmail(), Cron.Minutely());
//app.UseHangfireServer();
app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Person.Api"); });
app.MapControllers();
app.Run();
