using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBanking.model
{
    public class Accounts
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Balance { get; set; }
        public int Contact { get; set; }

    }
}
