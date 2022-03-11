namespace SuperSimpleStratPat;
internal interface IPrinter
{
    string Print();
    bool SupportsPrintJob(string jobType);
}
