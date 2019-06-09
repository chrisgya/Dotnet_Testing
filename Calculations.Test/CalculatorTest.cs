using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculations.Test
{
    public class CalculatorFixture
    {
         public Calculator Calc => new Calculator();
    }


  public  class CalculatorTest: IClassFixture<CalculatorFixture>
    {
       private readonly CalculatorFixture _calculatorFixture;

        public CalculatorTest(CalculatorFixture calculatorFixture)
        {
            _calculatorFixture = calculatorFixture;
        }

        [Fact]
        public void Add_GivenTwoIntValues_ReturnsInt()
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.Add(1, 2);
            Assert.Equal(3, result);
        }

        [Fact]
       public void Add_GivenTwoDouble_ReturnsDouble()
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.AddDouble(1.23, 3.55);
            Assert.Equal(4.7, result, 0);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboDoesNotIncludeZero()
        {
            var calc = _calculatorFixture.Calc;
            //  Assert.All(calc.FindNumbers, n => Assert.NotEqual(0, n)); // loop through the collection to check if does not contain 0
            Assert.DoesNotContain(0, calc.FindNumbers); // another way of checking same
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboDoesInclude13()
        {
            var calc = _calculatorFixture.Calc;
            Assert.Contains(13, calc.FindNumbers); // another way of checking same
        }

        [Fact]
        public void CheckCollection()
        {
            var calc = _calculatorFixture.Calc;

            var expectedCol = new List<int> { 1, 1, 2, 3, 5, 8, 13};
            Assert.Equal(expectedCol, calc.FindNumbers);
        }

        [Fact]
        public void IsOdd_GivenOddValue_ReturnsTrue()
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.IsOdd(1);
            Assert.True(result);
        }

        [Fact]
        public void IsOdd_GivenEvenValue_ReturnsFalse()
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.IsOdd(2);
            Assert.False(result);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(200, false)]
        public void IsOdd_TestOddAndEven(int value, bool expected)
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TestDataShare.IsOddOrEvenData), MemberType = typeof(TestDataShare))]
        public void IsOdd_TestOddAndEven_WithSharableTestData(int value, bool expected)
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TestDataShare.IsOddOrEvenExternalData), MemberType = typeof(TestDataShare))]
        public void IsOdd_TestOddAndEven_WithExternalSharableTestData(int value, bool expected)
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [IsOddOrEvenDataAttribute]
        public void IsOdd_TestOddAndEven_WithCustomAttribute(int value, bool expected)
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
        }


    }
}
