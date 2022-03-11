namespace SuperSimpleStratPat;
internal class InkJetPrinter : IPrinter
{
    public string Print()
    {
        return "Ink Jet Printer Printing...";
    }

    public bool SupportsPrintJob(string jobType)
    {
        return jobType == "slow";
    }
}
