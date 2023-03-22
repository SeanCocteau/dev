namespace Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var x = new Logic();
        Assert.Equal(25, x.Multiply(5,5));
    }

    [Fact]
    public void Test2()
    {
        var x = new Logic();
        Assert.Equal(36, x.Multiply(6,6));
    }

}