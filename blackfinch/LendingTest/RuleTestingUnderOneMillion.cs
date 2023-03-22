namespace LendingTest;

public class RuleTestingUnderOneMillion
{
    [Fact]
    public void TestRuleOverOneMillion_Success_LTV60_CS750()
    {
        var rule = new LendingBusiness.RuleUnderOneMillion();
        ProcessStatus status = rule.ProcessApplication(Guid.NewGuid(), 150000, 10000000, 950);
        Assert.True(status.Success);
    }

    [Fact]
    public void TestRuleOverOneMillion_Fail_LTV60_CS750()
    {
        var rule = new LendingBusiness.RuleUnderOneMillion();
        ProcessStatus status = rule.ProcessApplication(Guid.NewGuid(), 150000, 10000000, 700);
        Assert.False(status.Success);
    }

    [Fact]
    public void TestRuleOverOneMillion_Success_LTV80_CS801()
    {
        var rule = new LendingBusiness.RuleUnderOneMillion();
        ProcessStatus status = rule.ProcessApplication(Guid.NewGuid(), 400000, 500001, 801);
        Assert.True(status.Success);
    }

    [Fact]
    public void TestRuleOverOneMillion_Fail_LTV80_CS801()
    {
        var rule = new LendingBusiness.RuleUnderOneMillion();
        ProcessStatus status = rule.ProcessApplication(Guid.NewGuid(), 400001, 500000, 801);
        Assert.False(status.Success);
    }

    [Fact]
    public void TestRuleOverOneMillion_Fail_LTV80_CS799()
    {
        var rule = new LendingBusiness.RuleUnderOneMillion();
        ProcessStatus status = rule.ProcessApplication(Guid.NewGuid(), 400001, 500000, 799);
        Assert.False(status.Success);
    }

    [Fact]
    public void TestRuleOverOneMillion_Success_LTV90_CS901()
    {
        var rule = new LendingBusiness.RuleUnderOneMillion();
        ProcessStatus status = rule.ProcessApplication(Guid.NewGuid(), 450000, 500001, 901);
        Assert.True(status.Success);
    }

    [Fact]
    public void TestRuleOverOneMillion_Fail_LTV90_CS901()
    {
        var rule = new LendingBusiness.RuleUnderOneMillion();
        ProcessStatus status = rule.ProcessApplication(Guid.NewGuid(), 450001, 500000, 901);
        Assert.False(status.Success);
    }

    [Fact]
    public void TestRuleOverOneMillion_Fail_LTV90_CS899()
    {
        var rule = new LendingBusiness.RuleUnderOneMillion();
        ProcessStatus status = rule.ProcessApplication(Guid.NewGuid(), 450000, 500001, 899);
        Assert.False(status.Success);
    }
}