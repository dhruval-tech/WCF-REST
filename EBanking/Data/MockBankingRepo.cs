using EBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBanking.Data
{
    public class MockBankingRepo : IBankingRepo
    {
        public IEnumerable<Accounts> GetAllAccounts()
        {
            var users = new List<Accounts> {
                 new Accounts { Id = 0, FirstName = "Dhruval", LastName = "Gandhi", Address = "B102", Email = "abc@gmail.com", Password = "Abc@123", Balance = 200000, Contact = 123456789, },
                 new Accounts { Id = 1, FirstName = "ruval", LastName = "Gandhi", Address = "B102", Email = "abc@gmail.com", Password = "Abc@123", Balance = 200000, Contact = 123456789, },
                 new Accounts { Id = 2, FirstName = "val", LastName = "Gandhi", Address = "B102", Email = "abc@gmail.com", Password = "Abc@123", Balance = 200000, Contact = 123456789, },

            };
            return users;
        }

        public Accounts GetAccountById(int id)
        {
            return new Accounts { Id = 0, FirstName = "Dhruval", LastName = "Gandhi", Address = "B102", Email = "abc@gmail.com", Password = "Abc@123", Balance = 200000, Contact = 123456789, };
        }

    }
}
