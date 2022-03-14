namespace SuperSimpleStratPat;
internal class SinglePrintingJob
{
    private readonly IPrinter _printer;

    public SinglePrintingJob(IPrinter printer)
    {
        _printer = printer;
    }

    public string ExecutePrintJob()
    {
        return _printer.Print();
    }
}
