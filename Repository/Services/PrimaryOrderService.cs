using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        public DataTable GetDataToReport(DateTime From, DateTime To)
        {
            DataTable dt = new DataTable();
            //DataColumn column = new DataColumn();
            DataRow row;
            dt.Columns.Add("Day", typeof(DateTime));
            dt.Columns.Add("Total", typeof(Double));
            //column.DataType = System.Type.GetType("System.DateTime");
            //column.ColumnName = "Day";
            //dt.Columns.Add(column);
            //column = new DataColumn();
            //column.DataType = System.Type.GetType("System.Double");
            //column.ColumnName = "Total";
            //dt.Columns.Add(column);
            _orderRepo.GetAll()
                .Where(x => x.OrderDate >= From)
                .Where(x => x.OrderDate <= To)
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
