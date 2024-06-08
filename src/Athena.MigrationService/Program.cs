using Athena.Infrastructure;
using Athena.MigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.AddNpgsqlDbContext<AthenaContext>("postgresdb");
builder.Services.AddHostedService<Worker>();

var host = builder.Build();

host.Run();