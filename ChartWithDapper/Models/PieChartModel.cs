using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChartWithDapper.Models
{
    public class PieChartModel
    {
        public decimal amount { get; set; }
        public DateTime date { get; set; }
        public string transaction_type { get; set; }
    }
    public class PieChartDataModel
    {
        public List<decimal> amountList { get; set; }
        public List<DateTime> dateList { get; set; }
        public List<string> transaction_typeList { get; set; }
    }
}
