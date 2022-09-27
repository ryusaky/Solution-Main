using System.Text.Json.Serialization;
using Solution.Services.ChallengeServer.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Solution.CoreApp.BetterPlan.Data.Models;
using Solution.CoreApp.BetterPlan.Repositories;

var builder = WebApplication.CreateBuilder(args);
const int Port = 5000;

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
builder.WebHost.ConfigureKestrel(options =>
{
  // Setup a HTTP/2 endpoint without TLS.
  options.ListenLocalhost(Port, o => o.Protocols =
      HttpProtocols.Http2);
});
//
var services = builder.Services;
var env = builder.Environment;
services.AddEntityFrameworkNpgsql().AddDbContext<ChallengeContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("ChallengeDbConnection")));

services.AddControllers().AddJsonOptions(x =>
{
    // serialize enums as strings in api responses (e.g. Role)
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    // ignore omitted parameters on models to enable optional params (e.g. User update)
    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IGoalRepository, GoalRepository>();


// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<UserService>();

// Enable reflection in Debug mode.
if (app.Environment.IsDevelopment())
{
  app.MapGrpcReflectionService();
}
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");


app.Run();
