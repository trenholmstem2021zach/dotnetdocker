using System;
using System.Threading;



var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var randomGenerator = new Random();
var num = 1;

app.Use(async (context, next) =>
{
    context.Response.Headers["MyResponseHeader"] =
        new string[] { "My Response Header Value" };
    num =    randomGenerator.Next(1, 8);

    Thread.Sleep(num * 1000);
    await next();
});

app.MapGet("/", () => "Waited !" + num);

app.Run();
