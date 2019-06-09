using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculations.Test
{
    public class NamesTest
    {
        [Fact]
       public void MakeFullName()
        {
            var names = new Names();
            var result = names.MakeFullName("Chris", "Gya");
            Assert.Equal("Chris Gya", result);
            Assert.Equal("chris gya", result, ignoreCase: true);
            Assert.Contains("Gya", result);
            Assert.Contains("gya", result, StringComparison.InvariantCultureIgnoreCase);
            Assert.StartsWith("Ch", result);
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", result);
        }

        [Fact]
       public void NickName_MustBeNull()
        {
            var names = new Names();
            Assert.Null(names.NickName);
            names.NickName = "Great Man";
            Assert.NotNull(names.NickName);
        }

        [Fact]
        public void MakeFullName_AlwaysReturnValue()
        {
            var names = new Names();
            var result = names.MakeFullName("Christian", "Gyaban");

            Assert.NotNull(result);
            //  Assert.True(!string.IsNullOrEmpty(result));
            Assert.False(string.IsNullOrEmpty(result));
        }
    }
}
