using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculations.Test
{

    [Collection("Customer")]
  public class CustomerTest
    {
        private readonly CustomerFixture _customerFixture;
        public CustomerTest(CustomerFixture customerFixture)
        {
            _customerFixture = customerFixture;
        }

        [Fact]
        public void CheckNameNotEmpty()
        {
            var cust = _customerFixture.Culc;

            Assert.NotNull(cust.Name);
            Assert.False(string.IsNullOrEmpty(cust.Name));
        }

        [Fact]
        public void CheckLegiForDiscount()
        {
            var cust = _customerFixture.Culc;
            Assert.InRange(cust.Age, 25, 40);
        }

        [Fact]
        public void GetOrdersByNameNotNull()
        {
            var cust = _customerFixture.Culc;

            Assert.Throws<ArgumentException>(() => cust.GetOrdersByName(""));
            var exceptionDetails = Assert.Throws<ArgumentException>(() => cust.GetOrdersByName(""));
            Assert.Equal("Hello", exceptionDetails.Message);
        }


        [Fact]
        public void LoyalCustomerForOrdersG100()
        {
            var customer = CustomerFactory.CreateCustomerInstance(101);
            var loyalCustomer = Assert.IsType<LoyalCustomer>(customer);
            Assert.Equal(10, loyalCustomer.Discount);

        }

    }
}
