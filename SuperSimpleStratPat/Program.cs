using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SuperSimpleStratPat;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services
            .AddScoped<PrintingJob>()
            .AddScoped<IPrinter, InkJetPrinter>()
            .AddScoped<IPrinter, LaserPrinter>()
    )
    .Build();

using var scope = host.Services.CreateScope();

var printingJob = scope.ServiceProvider.GetRequiredService<PrintingJob>();

Console.WriteLine(printingJob.ExecutePrintJob("fast"));
Console.WriteLine(printingJob.ExecutePrintJob("slow"));

await host.RunAsync();