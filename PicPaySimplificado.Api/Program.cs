using Microsoft.EntityFrameworkCore;
using PicPaySimplificado.Api.Data;
using PicPaySimplificado.Api.Handlers;
using PicPaySimplificado.Core;
using PicPaySimplificado.Core.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient(Configuration.HttpClientName, opt =>
{
    opt.BaseAddress = new Uri(Configuration.ClientUrl);
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddTransient<IUserTransactionHandler, UserTransactionHandler>();
builder.Services.AddTransient<IAuthorizedServiceHandler, AuthorizedServiceHandler>();
builder.Services.AddTransient<IUserHandler, UserHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
await app.RunAsync();