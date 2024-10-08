﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MTDotNetCore.RealtimeChartApp.Hubs;
using MTDotNetCore.RealtimeChartApp.Models;

namespace MTDotNetCore.RealtimeChartApp.Controllers
{
    public class PieChartController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHubContext<ChartHub> _hubContext;

        public PieChartController(AppDbContext db, IHubContext<ChartHub> hubContext)
        {
            _db = db;
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Index()
        {
            var lst = await _db.TblPieCharts.AsNoTracking().ToListAsync();
            var data = lst.Select(x => new PieChartDataModel
                {
                    name = x.PieChartName,
                    y = x.PieChartValue
                })
                .ToList();

            PieChartResponseModel resModel = new PieChartResponseModel { Data = data };

            return View(resModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Save(TblPieChart reqModel)
        {
            await _db.TblPieCharts.AddAsync(reqModel);
            await _db.SaveChangesAsync();

            var lst = await _db.TblPieCharts.AsNoTracking().ToListAsync();

            var data = lst.Select(x => new PieChartDataModel
                {
                    name = x.PieChartName,
                    y = x.PieChartValue
                })
                .ToList();

            await _hubContext.Clients.All.SendAsync("ReceivePieChart", data);
            return RedirectToAction("Create");
        }
    }
}
