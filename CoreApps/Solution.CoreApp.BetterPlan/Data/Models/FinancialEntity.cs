using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.CoreApp.BetterPlan.Data.Models
{
    [Table(name: "financialentity")]
    public class FinancialEntity
    {
        [Key]
        public int id { get; set; }
        public string? title { get; set; }
        public string? logo { get; set; }

        public IEnumerable<Goal> Goals { get; set; }
    }
}

