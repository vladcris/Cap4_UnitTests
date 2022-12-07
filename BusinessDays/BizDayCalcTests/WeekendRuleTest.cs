using BizDayCal;

namespace BizDayCalcTests;

public class WeekendRuleTest
{
    public WeekendRule Rule { get; } = new WeekendRule();
    public static IEnumerable<object[]> Days 
    {
        get
        {
            yield return new object[] {true, new DateTime(2022, 12, 7)};
            yield return new object[] {true, new DateTime(2022, 12, 8)};
            yield return new object[] {false, new DateTime(2022, 12, 10)};
            yield return new object[] {false, new DateTime(2022, 12, 11)};
        }
    }


    [Fact]
    public void TestCheckIsBuisnessDay()
    {
        var rule = new WeekendRule();

        Assert.True(rule.CheckIsBusinessDay(new DateTime(2022, 12, 7)));
        Assert.False(rule.CheckIsBusinessDay(new DateTime(2022, 12, 31)));
    }

    [Theory]
    [MemberData(nameof(Days))]
    public void IsBusinessDayWithMemberData(bool expected, string date)
    {
        Assert.Equal(expected, Rule.CheckIsBusinessDay(DateTime.Parse(date)));
    }

    [Theory]
    [InlineData("2022-07-12")]
    [InlineData("2022-07-13")]
    [InlineData("2022-07-14")]
    [InlineData("2022-07-15")]
    public void TestBusinessDayWithTheory(string date)
    {
        var rule = new WeekendRule();
        Assert.True(rule.CheckIsBusinessDay(DateTime.Parse(date)));
    }

    [Theory]
    [InlineData("2022/12/10")]
    [InlineData("2022/12/31")]
    //[InlineData("2022/12/7")]
    public void IsNotBusinessDay(string date)
    {
        Assert.False(Rule.CheckIsBusinessDay(DateTime.Parse(date)));
    }

    [Theory]
    [InlineData(false, "2022/12/10")]
    [InlineData(true, "2022-07-14")]
    [InlineData(true, "2022-07-15")]
    public void DifferentTests(bool expected, string date)
    {
        Assert.Equal(expected, Rule.CheckIsBusinessDay(DateTime.Parse(date)));
    }
}