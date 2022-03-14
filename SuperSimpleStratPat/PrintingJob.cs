namespace SuperSimpleStratPat;
internal class PrintingJob
{
    private readonly IEnumerable<IPrinter> _printers;

    public PrintingJob(IEnumerable<IPrinter> printers)
    {
        _printers = printers;
    }

    public string ExecutePrintJob(string jobType)
    {
        return _printers.First(printer => printer.SupportsPrintJob(jobType)).Print();
    }
}
