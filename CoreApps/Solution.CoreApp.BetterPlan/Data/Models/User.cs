using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.CoreApp.BetterPlan.Data.Models
{
    [Table(name: "user")]
    public class User
    {
        public int id { get; set; }
        public string? firstname { get; set; }
        public string? surname { get; set; }
        public int advisorid { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
        public int currencyid { get; set; }
        public User advisor { get; set; }

        public IEnumerable<Goal> goals { get; set; }
    }
}

