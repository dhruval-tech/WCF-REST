using EBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBanking.Data
{
    public interface IBankingRepo
    {
         
        public void addAccount(Accounts accounts);
        public bool deleteAccount(int id);
        public void updateAccount(Accounts accounts);
        public IEnumerable<Accounts> getAllAccounts();
        public Accounts getAccount(int id);

    }
}
