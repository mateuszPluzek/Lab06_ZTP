using Xunit;
using FluentAssertions;

namespace Program;

public class CalculatorTests
{
    private readonly Calculator _calculator = new Calculator();

    [Fact]
    public void Addition_Returns_CorrectSum()
    {
        var result = _calculator.Add(1, 5);
        result.Should().Be(6);
    }
    
    [Theory]
    [InlineData(10, 2, 8)]
    [InlineData(0, 0, 0)]
    [InlineData(-5, -3, -2)]
    public void Subtraction_Returns_CorrectDifference(int a, int b, int expected)
    {
        var result = _calculator.Subtract(a, b);
        result.Should().Be(expected);
    }
    
    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        Action act = () => _calculator.Divide(5, 0);
        act.Should().Throw<DivideByZeroException>();
    }
    
    // dotnet-coverage collect --output coverage-report.coverage --format cobertura dotnet test   
    
}