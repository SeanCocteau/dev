namespace LendingTest;

public class ReporterTest
{
    [Fact]
    public void TestReporter_AddingEntries()
    {
        var reporter = new Reporter();
        var processor = new RuleProcessor(reporter);

        var result = processor.ProcessApplication( 1200000 , 2400000 , 990);

        // Process OK?
        Assert.True(result);

        // Then ensure there's a reportable item
        Assert.True(reporter.items.Count() == 1);
        Assert.True(reporter.items[0].Success);
    }

    [Fact]
    public void TestReporter_TestTotalApplicants()
    {
        var reporter = FillReporter();
        
        Assert.True(reporter.TotalNumberOfApplicants() == 3);
        Assert.True(reporter.TotalNumberOfSuccessfulApplicants() == 2);
        Assert.True(reporter.TotalNumberOfFailedApplicants() == 1);
    }

[Fact]
    public void TestReporter_TestWrittenLoans()
    {
        var reporter = FillReporter();
        
        Assert.True(reporter.TotalValueOfWrittenLoans() == 1800000);
    }

[Fact]
    public void TestReporter_TestAverageLtv()
    {
        var reporter = FillReporter();
        
        Assert.True(reporter.AverageLtvOfAll() == 0.44M);
    }

    private Reporter FillReporter(){
        var reporter = new Reporter();

        // Generates 3 applications
        // 2 = success
        // 1.8M in loans
        // 0.44 avg LTV

        reporter.RecordItem(new ReportItem(Guid.NewGuid() , 1200000 , 2400000, 990, true, 0.5M));
        reporter.RecordItem(new ReportItem(Guid.NewGuid() , 600000 , 1200000, 990, true, 0.7M));

        reporter.RecordItem(new ReportItem(Guid.NewGuid() , 1200000 , 1300000, 700, false, 0.12M));

        return reporter;
    }

}