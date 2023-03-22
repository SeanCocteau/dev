namespace LendingTest;

public class RuleTestingOverOneMillion
{
    [Fact]
    public void TestRuleOverOneMillion_Success()
    {
        var rule = new LendingBusiness.RuleOverOneMillion();
        ProcessStatus status = rule.ProcessApplication(Guid.NewGuid(), 150000, 10000000, 950);
        Assert.True(status.Success);
    }

[Fact]
    public void TestRuleOverOneMillion_FailCreditScore()
    {
        var rule = new LendingBusiness.RuleOverOneMillion();
        ProcessStatus status = rule.ProcessApplication(Guid.NewGuid(), 150000, 10000000, 700);
        Assert.False(status.Success);
    }

[Fact]
    public void TestRuleOverOneMillion_FailOver1500000()
    {
        var rule = new LendingBusiness.RuleOverOneMillion();
        ProcessStatus status = rule.ProcessApplication(Guid.NewGuid(), 2000000, 10000000, 950);
        Assert.False(status.Success);
    }

[Fact]
    public void TestRuleOverOneMillion_FailUnder100000()
    {
        var rule = new LendingBusiness.RuleOverOneMillion();
        ProcessStatus status = rule.ProcessApplication(Guid.NewGuid(), 90000, 10000000, 950);
        Assert.False(status.Success);
    }

[Fact]
    public void TestRuleOverOneMillion_FailLTV()
    {
        var rule = new LendingBusiness.RuleOverOneMillion();
        ProcessStatus status = rule.ProcessApplication(Guid.NewGuid(), 200000, 150000, 950);
        Assert.False(status.Success);
    }
}