public interface IDocumentFilter {
    void PerformTextFiltering(string documentText);
}
public class DocumentFilter() : IDocumentFilter
{
    public void PerformTextFiltering(string documentText)
    {
        char[] charArray = documentText.ToCharArray();
        charArray.ToList().ForEach(x=>Console.WriteLine(x.ToString().ToUpper()));
    }
}

public interface IMultiReportable : IReportablePdf,IReportableExcel;
public interface IReportablePdf {
    void GeneratePdf(IDocumentFilter documentFilter);
}
public interface IReportableExcel {
    void GenerateExcel(IDocumentFilter documentFilter);
}

public class SalaryReport : IMultiReportable
{
    public SalaryReport() {
    }
    public void GeneratePdf(IDocumentFilter documentFilter)
    {
        documentFilter.PerformTextFiltering("Performer");
    }

    public void GenerateExcel(IDocumentFilter documentFilter)
    {
        documentFilter.PerformTextFiltering("Siciak");
    }
}

public class Invoice : IReportablePdf
{
    public void GeneratePdf(IDocumentFilter documentFilter)
    {
        documentFilter.PerformTextFiltering("Azbest");
    }

}
internal class Program
{
    private static void Main(string[] args)
    {
    IMultiReportable multiReportable = new SalaryReport();
    multiReportable.GenerateExcel(new DocumentFilter());
    }
}