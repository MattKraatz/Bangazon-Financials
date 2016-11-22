using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bangazon_Financials;
using Xunit;

namespace Bangazon_Financials_Testing
{
    public class RevenueFactoryTests
    {
        [Fact]
        public void CanGetRevenueFromPastWeek()
        {
            var conn = new DatabaseConnection();
            List<Revenue> rev = conn.getWeek();
            Assert.NotNull(rev);
            Assert.True(rev.Count > 1);
            rev.ForEach(delegate (Revenue item)
            {
                Assert.NotNull(item.CustomerAddress);
                Assert.NotNull(item.CustomerFirstName);
                Assert.NotNull(item.CustomerLastName);
                Assert.NotNull(item.CustomerZipCode);
                Assert.NotNull(item.Id);
                Assert.NotNull(item.ProductCost);
                Assert.NotNull(item.ProductName);
                Assert.NotNull(item.ProductRevenue);
                Assert.NotNull(item.ProductSupplierState);
                Assert.NotNull(item.PurchaseDate);
                Assert.IsType<DateTime>(item.PurchaseDate);
                Assert.True(item.PurchaseDate > DateTime.Today.AddDays(-7));
            });
        }

        [Fact]
        public void CanGetRevenueFromPastMonth()
        {
            var conn = new DatabaseConnection();
            List<Revenue> rev = conn.getMonth();
            Assert.NotNull(rev);
            Assert.True(rev.Count > 1);
            rev.ForEach(delegate (Revenue item)
            {
                Assert.NotNull(item.CustomerAddress);
                Assert.NotNull(item.CustomerFirstName);
                Assert.NotNull(item.CustomerLastName);
                Assert.NotNull(item.CustomerZipCode);
                Assert.NotNull(item.Id);
                Assert.NotNull(item.ProductCost);
                Assert.NotNull(item.ProductName);
                Assert.NotNull(item.ProductRevenue);
                Assert.NotNull(item.ProductSupplierState);
                Assert.NotNull(item.PurchaseDate);
                Assert.IsType<DateTime>(item.PurchaseDate);
                Assert.True(item.PurchaseDate > DateTime.Today.AddMonths(-1));
            });
        }

        [Fact]
        public void CanGetRevenueFromPastQuarter()
        {
            var conn = new DatabaseConnection();
            List<Revenue> rev = conn.getQuarter();
            Assert.NotNull(rev);
            Assert.True(rev.Count > 1);
            rev.ForEach(delegate (Revenue item)
            {
                Assert.NotNull(item.CustomerAddress);
                Assert.NotNull(item.CustomerFirstName);
                Assert.NotNull(item.CustomerLastName);
                Assert.NotNull(item.CustomerZipCode);
                Assert.NotNull(item.Id);
                Assert.NotNull(item.ProductCost);
                Assert.NotNull(item.ProductName);
                Assert.NotNull(item.ProductRevenue);
                Assert.NotNull(item.ProductSupplierState);
                Assert.NotNull(item.PurchaseDate);
                Assert.IsType<DateTime>(item.PurchaseDate);
                Assert.True(item.PurchaseDate > DateTime.Today.AddMonths(-3));
            });
        }

        [Fact]
        public void CanGetRevenueByCustomer()
        {
            var conn = new DatabaseConnection();
            List<Revenue> rev = conn.getByCustomer();
            Assert.NotNull(rev);
            Assert.True(rev.Count > 1);
            rev.ForEach(delegate (Revenue item)
            {
                Assert.NotNull(item.CustomerFirstName);
                Assert.NotNull(item.CustomerLastName);
                Assert.NotNull(item.ProductRevenue);
            });
        }
    }
}
