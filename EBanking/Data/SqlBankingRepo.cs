using EBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBanking.Data
{
    public class SqlBankingRepo : IBankingRepo
    {
        private readonly ApplicationDbContext _context;
        public SqlBankingRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public Accounts GetAccountById(int id)
        {
            return _context.Accounts.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Accounts> GetAllAccounts()
        {
            return _context.Accounts.ToList();
        }
    }
}
