using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
    .AddPostgres("pg")
    .AddDatabase("postgresdb");

builder.AddProject<Athena_Web_API>("web-api")
    .WithReference(postgres);

builder.AddProject<Athena_MigrationService>("migration-service")
    .WithReference(postgres);

builder.Build().Run();