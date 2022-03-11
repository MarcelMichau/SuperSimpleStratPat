namespace SuperSimpleStratPat;
internal class LaserPrinter : IPrinter
{
    public string Print()
    {
        return "Laser Printer Printing...";
    }

    public bool SupportsPrintJob(string jobType)
    {
        return jobType == "fast";
    }
}
