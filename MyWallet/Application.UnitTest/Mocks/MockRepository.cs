﻿//using Moq;
//using MyWallet.Application.Interfaces;
//using MyWallet.Domain.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyWallet.Application.UnitTest.Mocks
//{
//    public static class MockRepository
//    {
//        public static Mock<IBudgetRepository> GetBudgetRepository()
//        {
//            var budgetList = new List<Budget>
//            {

//                new Budget()
//            {
//                Id = 1,
//                CreatedById = 1,
//                Name = "Budget1",
//                Description = "Test1"
//            },

//            new Budget()
//            {
//                Id = 2,
//                CreatedById = 1,
//                Name = "Budget2",
//                Description = "Test2"
//            }
//            };

//            var mockBudgetRepository = new Mock<IBudgetRepository>();
            
//            mockBudgetRepository.Setup(r => r.GetAllBudgetsAsync(It.IsAny<int>())).Returns(() =>
//            {
//                var userId = 1;
//                var budget = budgetList.Where(b => b.CreatedById == userId).AsEnumerable();
//                return Task.FromResult(budget);
//            });

//            //mockBudgetRepository.Setup(r => r.GetBudgetByIdAsync(It.IsAny<int>(), It.IsAny<int>())).Returns(
//            //    (int id, int userId) =>
//            //    {
//            //        userId = 1;
//            //        var budget = budgetList.Where(b => b.CreatedById == userId).FirstOrDefault(b => b.Id == id);
//            //        return budget;
//            //    });

//            //mockBudgetRepository.Setup(r => r.AddBudgetAsync(It.IsAny<Budget>())).ReturnsAsync(
//            //    (Budget budget) =>
//            //    {
//            //        budgetList.Add(budget);
//            //        return budget.Id;
//            //    });

//            //mockBudgetRepository.Setup(r => r.DeleteBudgetAsync(It.IsAny<Budget>())).Callback<Budget>((entity) =>
//            //budgetList.Remove(entity));

//            //mockBudgetRepository.Setup(r => r.UpdateBudgetAsync(It.IsAny<Budget>())).Callback<Budget>((entity) =>
//            //{
//            //    budgetList.Remove(entity);
//            //    budgetList.Add(entity);
//            //});

//            return mockBudgetRepository;
//        }

//        //private static List<Budget> GetBudgets()
//        //{

//        //    Budget b1 = new Budget()
//        //    {
//        //        Id = 1,
//        //        CreatedById = 1,
//        //        Name = "Budget1",
//        //        Description = "Test1"
//        //    };
//        //    Budget b2 = new Budget()
//        //    {
//        //        Id = 2,
//        //        CreatedById = 1,
//        //        Name = "Budget2",
//        //        Description = "Test2"
//        //    };
            

//        //    List<Budget> budgets = new List<Budget>();

//        //    budgets.Add(b1);
//        //    budgets.Add(b2);
            

//        //    return budgets;
//        //}

//        public static Mock<ITransactionRepository> GetTransactionRepository()
//        {
//            var transactions = GetTransactions();

//            var mockTransactionRepository = new Mock<ITransactionRepository>();

//            var userId = 1;

//            mockTransactionRepository.Setup(x => x.GetAllTransactionsAsync(It.IsAny<int>())).Returns(
//                (int userId) =>
//                {
//                    var transaction = transactions.Where(b => b.CreatedById == userId).ToList();
//                    return transaction;
//                });

//            mockTransactionRepository.Setup(x => x.GetTransactionByIdAsync(It.IsAny<int>(), It.IsAny<int>())).Returns(
//                (int id, int userId) =>
//                {
//                    var transaction = transactions.Where(b => b.CreatedById == userId).FirstOrDefault(b => b.Id == id);
//                    return transaction;
//                });

//            mockTransactionRepository.Setup(x => x.GetTransactionsBySearchAsync(It.IsAny<int>(), It.IsAny<string>())).Returns(
//                (int userId, string searchPhrase) =>
//                {
//                    var transaction = transactions
//                    .Where(b => b.CreatedById == userId)
//                    .Where(x => searchPhrase == null
//                                                     || (x.Category.ToLower().Contains(searchPhrase.ToLower())
//                                                     || x.Type.ToLower().Contains(searchPhrase.ToLower())))
//                    .ToList();

//                    return transaction;
//                });

//            mockTransactionRepository.Setup(x => x.GetTransactionsByBudgetIdAsync(It.IsAny<int>(), It.IsAny<int>())).Returns(
//                (int userId, int budgetId) =>
//                {
//                    var transaction = transactions
//                    .Where(b => b.CreatedById == userId)
//                    .Where(t => t.BudgetId == budgetId)
//                    .ToList();

//                    return transaction;
//                });

//            mockTransactionRepository.Setup(x => x.GetTransactionsByDateRangeAsync(It.IsAny<int>(),
//                It.IsAny<int>(),
//                It.IsAny<DateTime>(),
//                It.IsAny<DateTime>()))
//                .Returns(

//                (int userId, int budgetId, DateTime dateFrom, DateTime dateTo) =>
//                {
//                    var transaction = transactions
//                    .Where(b => b.CreatedById == userId)
//                    .Where(t => t.BudgetId == budgetId)
//                    .Where(t => t.TransactionDate > dateFrom)
//                    .Where(t => t.TransactionDate < dateTo)
//                    .ToList();

//                    return transaction;
//                });

//            mockTransactionRepository.Setup(r => r.AddTransactionAsync(It.IsAny<Transaction>())).ReturnsAsync(
//                (Transaction transaction) =>
//                {
//                    transactions.Add(transaction);
//                    return transaction.Id;
//                });

//            mockTransactionRepository.Setup(r => r.DeleteTransactionAsync(It.IsAny<Transaction>())).Callback<Transaction>(
//                (entity) =>
//                    transactions.Remove(entity));

//            mockTransactionRepository.Setup(r => r.UpdateTransactionAsync(It.IsAny<Transaction>())).Callback<Transaction>(
//                (entity) =>
//                {
//                    transactions.Remove(entity);
//                    transactions.Add(entity);
//                });




//            return mockTransactionRepository;
//        }

//        private static List<Transaction> GetTransactions()
//        {
//            Transaction b1 = new Transaction()
//            {
//                Id = 1,
//                CreatedById = 1,
//                BudgetId = 1,
//                Value = 500,
//                Category = "Transaction1",
//                Type = "Test1",
//                TransactionDate = DateTime.Parse("2022-06-01")
//            };
//            Transaction b2 = new Transaction()
//            {
//                Id = 2,
//                CreatedById = 1,
//                BudgetId = 1,
//                Value = 500,
//                Category = "Transaction2",
//                Type = "Test2",
//                TransactionDate = DateTime.Parse("2022-06-02")
//            };

//            List<Transaction> transactions = new List<Transaction>();

//            transactions.Add(b1);
//            transactions.Add(b2);

//            return transactions;
//        }

//    }
//}