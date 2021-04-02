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

        public void addAccount(Accounts accounts)
        {
            _context.Accounts.Add(accounts);
            _context.SaveChanges();
            return;
        }

        public bool deleteAccount(int id)
        {
            var deleteItm = _context.Accounts.Find(id);
            if (deleteItm == null)
            {
                return false;
            }
            else
            {
                _context.Accounts.Remove(deleteItm);
                _context.SaveChanges();
                return true;
            }
        }

        
        public Accounts getAccount(int id)
        {
            var acc = _context.Accounts.Find(id);
            if (acc == null)
            {
                return null;
            }
            else
            {
                return acc;
            }
        }

   
        public IEnumerable<Accounts> getAllAccounts()
        {
            return _context.Accounts.ToList();
        }

        public void updateAccount(Accounts accounts)
        {
            var t = _context.Accounts.Attach(accounts);
            t.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return;
        }
    }
}
