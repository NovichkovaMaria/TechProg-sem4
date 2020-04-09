using AbstractFactoryBusinessLogic.BindingModels;
using AbstractFactoryBusinessLogic.HelperModels;
using AbstractFactoryBusinessLogic.Interfaces;
using AbstractFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactoryBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IAutoPartLogic AutoPartLogic;
        private readonly IProductLogic ProductLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(IProductLogic ProductLogic, IAutoPartLogic AutoPartLogic,
       IOrderLogic orderLLogic)
        {
            this.ProductLogic = ProductLogic;
            this.AutoPartLogic = AutoPartLogic;
            this.orderLogic = orderLLogic;
        }

        public List<ReportProductAutoPartViewModel> GetProductAutoPart()
        {
            var AutoParts = AutoPartLogic.Read(null);
            var Products = ProductLogic.Read(null);
            var list = new List<ReportProductAutoPartViewModel>();
            foreach (var AutoPart in AutoParts)
            {
                var record = new ReportProductAutoPartViewModel
                {
                    AutoPartName = AutoPart.AutoPartName,
                    Products = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var Product in Products)
                {
                    if (Product.ProductAutoParts.ContainsKey(AutoPart.Id))
                    {
                        record.Products.Add(new Tuple<string, int>(Product.ProductName,
                       Product.ProductAutoParts[AutoPart.Id].Item2));
                        record.TotalCount +=
                       Product.ProductAutoParts[AutoPart.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                ProductName = x.ProductName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }
        public void SaveAutoPartsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                AutoParts = AutoPartLogic.Read(null)
            });
        }
        public void SaveProductAutoPartToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                ProductAutoParts = GetProductAutoPart()
            });
        }
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}
