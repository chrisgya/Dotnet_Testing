using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculations.Test
{
    [Collection("Customer")]
    public class CustomerDetailsTest
    {
        private readonly CustomerFixture _customerFixture;
        public CustomerDetailsTest(CustomerFixture customerFixture)
        {
            _customerFixture = customerFixture;
        }

        [Fact]
        public void GetFullName_GivenFirstAndLastName_ReturnFullName()
        {
            var customer = _customerFixture.Culc;
            var result = customer.GetFullName("Christian", "Gyaban");

            Assert.Equal("Christian Gyaban", result);
        }
    }
}
