namespace LendingTest;

public class RuleProcesserTest
{
    [Fact]
    public void TestRuleProcessor_SuccessOverOneM()
    {
        var processor = new RuleProcessor(new Reporter());

        var result = processor.ProcessApplication( 1200000 , 2400000 , 990);

        Assert.True(result);
    }

    [Fact]
    public void TestRuleProcessor_FailOverOneM()
    {
        var processor = new RuleProcessor(new Reporter());

        var result = processor.ProcessApplication( 1200000 , 2400000 , 550);

        Assert.False(result);
    }

    [Fact]
    public void TestRuleProcessor_Success_UnderOneM()
    {
        var processor = new RuleProcessor(new Reporter());

        var result = processor.ProcessApplication( 600000 , 2400000 , 990);

        Assert.True(result);
    }

    [Fact]
    public void TestRuleProcessor_Fail_UnderOneM()
    {
        var processor = new RuleProcessor(new Reporter());

        var result = processor.ProcessApplication( 600000 , 2400000 , 550);

        Assert.False(result);
    }

}