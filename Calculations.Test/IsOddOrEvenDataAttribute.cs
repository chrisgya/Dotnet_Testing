using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Calculations.Test
{
    public class IsOddOrEvenDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 1, true };
            yield return new object[] { 200, false };

            // you replace this content with database data or file for the test as well
        }
    }
}
