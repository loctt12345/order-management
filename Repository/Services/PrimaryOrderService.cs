using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public interface IPrimaryOrderService
    {
        public void Create(PrimaryOrder PrimaryOrder);
        public void Update(PrimaryOrder PrimaryOrder);
        public void Delete(PrimaryOrder PrimaryOrder);
        public List<PrimaryOrder> GetAll();
    }
    public class PrimaryOrderService : IPrimaryOrderService
    {
        private readonly RepositoryBase<PrimaryOrder> _orderRepo = new RepositoryBase<PrimaryOrder>();
        public PrimaryOrderService() { }

        public PrimaryOrderService(RepositoryBase<PrimaryOrder> orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public void Create(PrimaryOrder PrimaryOrder)
        {
            _orderRepo.Create(PrimaryOrder);
        }

        public void Delete(PrimaryOrder PrimaryOrder)
        {
            _orderRepo.Delete(PrimaryOrder);
        }

        public List<PrimaryOrder> GetAll()
        {
            return _orderRepo.GetAll().ToList();
        }

        public void Update(PrimaryOrder PrimaryOrder)
        {
            _orderRepo.Update(PrimaryOrder);
        }
        public DataTable GetDataToReport(DateTime from, DateTime to)
        {
            DataTable dt = new DataTable();
            if (to.Subtract(from).Days <= 7)
            {
                dt = GetDataToReportForDays(from, to);
            }
            else if (to.Subtract(from).Days <= 31)
            {
                dt = GetDataToReportForWeeks(from, to);
            }
            else
            {
                dt = GetDataToReportForMonths(from, to);
            }
            return dt;
        }
        public DataTable GetDataToReportForWeeks(DateTime from, DateTime to)
        {
            DataTable dt = new DataTable();
            DataRow row;
            dt.Columns.Add("Week", typeof(String));
            dt.Columns.Add("Total", typeof(Double));
            DateTime[] weeks = new DateTime[]
            {
                from,
                from.AddDays(7),
                from.AddDays(14),
                from.AddDays(21),
                from.AddDays(28),
                from.AddDays(31)
            };
            for (int i = 0; i < weeks.Length - 1; i++)
            {
                if (to.Subtract(weeks[i]) >= new TimeSpan(7, 0, 0, 0))
                {
                    row = dt.NewRow();
                    row["Week"] = $"{weeks[i].Day}/{weeks[i].Month} - {weeks[i + 1].ToShortDateString()}";
                    Double total = _orderRepo.GetAll()
                                    .Where(x => x.OrderDate >= weeks[i] && x.OrderDate <= weeks[i + 1])
                                    .Where(x => x.Status == 3).Sum(x => x.Total);

                    if (total != 0)
                    {
                        row["Total"] = total;
                        dt.Rows.Add(row);
                    }
                }
                else
                {
                    row = dt.NewRow();
                    row["Week"] = $"{weeks[i].Day}/{weeks[i].Month} - {to.ToShortDateString()}";
                    Double total = _orderRepo.GetAll()
                                    .Where(x => x.OrderDate >= weeks[i] && x.OrderDate <= to)
                                    .Where(x => x.Status == 3).Sum(x => x.Total);

                    if (total != 0)
                    {
                        row["Total"] = total;
                        dt.Rows.Add(row);
                    }
                }

            }
            return dt;
        }
        public DataTable GetDataToReportForMonths(DateTime from, DateTime to)
        {
            DataTable dt = new DataTable();
            DataRow row;
            dt.Columns.Add("Month", typeof(String));
            dt.Columns.Add("Total", typeof(Double));
            //from = new DateTime(from.Year, from.Month, from.Day);
            //to = new DateTime(to.Year, to.Month, to.Day);
            DateTime[] months = new DateTime[13];
            DateTime now = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day
                                        , from.Hour,from.Minute, from.Second);
            for (int i = 0; i < months.Length; i++)
            {
                months[i] = new DateTime(from.Year, from.Month, 1, now.Hour, now.Minute, now.Second).AddMonths(i);
                DateTime endOfMonth = months[i].AddMonths(1).AddDays(-1);
                TimeSpan mainSpan = endOfMonth.Subtract(months[i]);
                string rowWholeOfMonth = $"{months[i].Month}/{months[i].Year}";
                row = dt.NewRow();
                if (to.AddDays(1).Subtract(months[i]) <= mainSpan)
                {
                    endOfMonth = to;
                    if (endOfMonth == months[i].AddMonths(1).AddDays(-1)) row["Month"] = rowWholeOfMonth;
                    else if (endOfMonth.Day == 1) row["Month"] = months[i].ToShortDateString();
                    else row["Month"] = $"{months[i].Day} - {endOfMonth.Day}/{months[i].Month}/{months[i].Year}";
                }
                else if (i == 0)
                {
                    months[i] = from;
                    if (months[i].Day == endOfMonth.Day) row["Month"] = months[i].ToShortDateString();
                    else if (months[i].Day == 1) row["Month"] = rowWholeOfMonth;
                    else row["Month"] = $"{months[i].Day} - {endOfMonth.Day}/{months[i].Month}/{months[i].Year}";
                }
                else
                {
                    row["Month"] = rowWholeOfMonth;
                }
                //if (months[i].Day == endOfMonth.Day) row["Month"] = rowWholeOfMonth;
                Double total = _orderRepo.GetAll()
                                    .Where(x => x.OrderDate >= months[i] && x.OrderDate <= endOfMonth)
                                    .Where(x => x.Status == 3).Sum(x => x.Total);

                if (total != 0)
                {
                    row["Total"] = total;
                    dt.Rows.Add(row);
                }
                if (to.AddDays(1).Subtract(months[i]) <= mainSpan) break;
            }
            return dt;
        }
        public DataTable GetDataToReportForDays(DateTime from, DateTime to)
        {
            DataTable dt = new DataTable();
            DataRow row;
            dt.Columns.Add("Day", typeof(DateTime));
            dt.Columns.Add("Total", typeof(Double));
            _orderRepo.GetAll()
                .Where(x => x.OrderDate >= from)
                .Where(x => x.OrderDate <= to)
                .Where(x => x.Status == 3)
                .OrderBy(x => x.OrderDate)
                .Select(x => x.OrderDate)
                .Distinct().ToList().ForEach(x =>
                {
                    row = dt.NewRow();
                    row["Day"] = x;
                    row["Total"] = _orderRepo.GetAll().Where(i => i.OrderDate == x).Where(i => i.Status == 3).Sum(i => i.Total);
                    dt.Rows.Add(row);
                });
            return dt;
        }
    }

}
