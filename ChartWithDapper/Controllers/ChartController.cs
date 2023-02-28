using ChartWithDapper.Models;
using ChartWithDapper.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChartWithDapper.Controllers
{
    public class ChartController : Controller
    {
        private readonly DapperService dapperService;
        public ChartController(DapperService service)
        {
            dapperService = service;
        }
        public IActionResult ChartIndex()
        {
            ViewBag.pie_chart = PieChart();
            return View();
        }
        public PieChartDataModel PieChart()
        {
            string query = @"select SUM(Amount) amount,CONVERT(varchar(7), Date, 126) date,
                            TransactionType transaction_type
                            from [dbo].[Tbl_ExpenseTracker] 
                            where CONVERT(varchar(7), Date, 126) = CONVERT(varchar(7), GETDATE() ,126)
                            group by CONVERT(varchar(7), Date, 126), TransactionType
                            ";
            var list = dapperService.getData<PieChartModel>(query);

            PieChartDataModel model = new PieChartDataModel
            {
                amountList = list.Select(item => item.amount).ToList()
            };

            return model;
        }
    }
}
