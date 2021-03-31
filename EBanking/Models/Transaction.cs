using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBanking.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public int Money { get; set; }
    }
}
