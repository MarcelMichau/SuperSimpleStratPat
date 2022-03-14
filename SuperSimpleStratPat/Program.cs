using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SuperSimpleStratPat;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostBuilderContext, services) =>
        {
            services.AddScoped<PrintingJob>();
            services.AddScoped<SinglePrintingJob>();

            var printerImplementation = 
                hostBuilderContext.Configuration.GetValue<string>("PrinterOverrides:IPrinter");

            if (!string.IsNullOrWhiteSpace(printerImplementation))
            {
                var overridePrinter = Type.GetType(printerImplementation);
                services.AddScoped(sp => (IPrinter)ActivatorUtilities.CreateInstance(sp, overridePrinter ?? typeof(InkJetPrinter)));
            }
            else
            {
                services.AddScoped<IPrinter, InkJetPrinter>();
            }
        }
    )
    .Build();

using var scope = host.Services.CreateScope();

//var printingJob = scope.ServiceProvider.GetRequiredService<PrintingJob>();

//Console.WriteLine(printingJob.ExecutePrintJob("fast"));
//Console.WriteLine(printingJob.ExecutePrintJob("slow"));

var singlePrintingJob = scope.ServiceProvider.GetRequiredService<SinglePrintingJob>();

Console.WriteLine(singlePrintingJob.ExecutePrintJob());

await host.RunAsync();