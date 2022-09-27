using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Solution.CoreApp.BetterPlan.Data.Models
{
    [Table(name: "portfolio")]
    public class PortFolio
    {
        public int id { get; set; }
        public double maxrangeyear { get; set; }
        public double minrangeyear { get; set; }
        public string uuid { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public int financialentityid { get; set; }
        public int risklevelid { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
        public bool isdefault { get; set; }
        public JsonDocument? profitability { get; set; }
        public int investmentstrategyid { get; set; }
        public string version { get; set; } = string.Empty;
        public string extraprofitabilitycurrencycode { get; set; } = string.Empty;
        public double estimatedprofitability { get; set; }
        public double bpcomission { get; set; }

        public IEnumerable<Goal> Goals { get; set; }
    }
}

