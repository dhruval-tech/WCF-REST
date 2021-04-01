using EBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBanking.Data
{
    public interface IBankingRepo
    {
         IEnumerable<Accounts> GetAllAccounts();
         Accounts GetAccountById(int id);
    }
}
