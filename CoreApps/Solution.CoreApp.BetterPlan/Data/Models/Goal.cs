using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.CoreApp.BetterPlan.Data.Models
{
    [Table(name: "goal")]
    public class Goal
    {
        public int id { get; set; }
        public string? title { get; set; }
        public int years { get; set; }
        public int initialinvestment { get; set; }
        public int monthlycontribution { get; set; }
        public int targetamount { get; set; }
        public int userid { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
        public int goalcategoryid { get; set; }
        public int displaycurrencyid { get; set; }
        public int risklevelid { get; set; }
        public int portfolioid { get; set; }
        public int? financialentityid { get; set; }
        public int currencyid { get; set; }

        public FinancialEntity? FinancialEntity { get; set; }
        public GoalCategory GoalCategory { get; set; }
        public PortFolio PortFolio { get; set; }
    }
}

