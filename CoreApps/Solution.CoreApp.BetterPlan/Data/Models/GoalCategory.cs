using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.CoreApp.BetterPlan.Data.Models
{
    [Table(name: "goalcategory")]
    public class GoalCategory
    {
        public int id { get; set; }
        public string? code { get; set; }
        public string? uuid { get; set; }
        public string? title { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
    }
}

