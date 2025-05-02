using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

await Host.CreateDefaultBuilder(args)
    .UseEnvironment(Environments.Development)
    .ConfigureServices(services =>
    {
        services.AddHostedService<SampleHostedService>();
    })
    .ConfigureWebJobs(builder =>
    {
        builder.AddAzureStorageCoreServices();
        builder.AddAzureStorageQueues();
    })
    .ConfigureLogging((context, builder) =>
    {
        builder.SetMinimumLevel(LogLevel.Information);
        builder.AddConsole();
    })
    .Build()
    .RunAsync();

/*

az webapp webjob triggered run --resource-group rg-linux-webjobs --name app-yuta-linux-webjobs --webjob-name WebJobsSDKSample

*/
