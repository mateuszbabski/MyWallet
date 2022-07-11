using Microsoft.EntityFrameworkCore;
using Moq;
using MyWallet.Domain.Entities;
using MyWallet.Persistence.Context;
using MyWallet.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.UnitTest.BudgetTests
{
    public class BudgetRepositoryTests
    {
        [Fact]
        public void GetBudgetById_Returns_Budget()
        {
            // mocking db
            var dbContextMock = new Mock<ApplicationDbContext>();
            var dbSetMock = new Mock<DbSet<Budget>>();
            dbSetMock.Setup(s => s.FindAsync(It.IsAny<int>(), It.IsAny<int>)).Returns(ValueTask.FromResult(new Budget()));
            //dbContextMock.Setup(s => s.Budgets).Returns(dbSetMock.Object);
            dbContextMock.Setup(s => s.Set<Budget>()).Returns(dbSetMock.Object);

            var budgetRepository = new BudgetRepository(dbContextMock.Object);
            var budget = budgetRepository.GetBudgetByIdAsync(id: 1, userId: 1).Result;

            Assert.NotNull(budget);

        }
        //[Fact]
        //public void GetBudgetById_Returns_Budget()
        //{

        //}
        //[Fact]
        //public void GetBudgetById_DoesntReturn_NoId()
        //{

        //}
    }
}
