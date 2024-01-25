using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Tests
{
    public class CustomerServiceTests
    {
        [TestClass]

        public class CustomerServiceTest
        {
            private DbContextOptions<TestDbContext> _cpx;

            [TestMethod]
            public async Task<bool> CanPurshaseEqualszero(int customerId, decimal purchaseValue)
            {
                TestDbContext _ctx = new TestDbContext(_cpx);

                customerId = 0;

                purchaseValue = 0;

                CustomerService svc = new CustomerService(_ctx);

                return await svc.CanPurchase(customerId, purchaseValue);

            }

            [TestMethod]

            public void CanCustomerZero(int customerID)
            {
                TestDbContext _ctx = new TestDbContext(_cpx);

                CustomerService svc = new CustomerService(_ctx);

                customerID = 0;

                var retorno =  _ctx.Customers.FindAsync(customerID);
                
            }

            [TestMethod]

            public async Task<bool>  CanSingleTime()
            {
                TestDbContext _ctx = new TestDbContext(_cpx);

                OrderService svc = new OrderService();

                var customerId = 0;
                var baseDate = DateTime.UtcNow.AddMonths(2);
                var ordersInThisMonth = await _ctx.Orders.CountAsync(s => s.CustomerId == customerId && s.OrderDate >= baseDate);
                if (ordersInThisMonth > 0)
                    return false;

                return false;

            }

            [TestMethod]

            public async Task<bool> CanMaxPay()
            {
                TestDbContext _ctx = new TestDbContext(_cpx);

                OrderService svc = new OrderService();

                var purchaseValue = 101;

                var customerId = 0;

                var haveBoughtBefore = await _ctx.Customers.CountAsync(s => s.Id == customerId && s.Orders.Any());
                if (haveBoughtBefore == 0 && purchaseValue > 100)
                    return false;

                return false;

            }

        }

    }
}
