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
       IOrderLogic orderLogic)
        {
            this.ProductLogic = ProductLogic;
            this.AutoPartLogic = AutoPartLogic;
            this.orderLogic = orderLogic;
        }

        public List<ReportProductAutoPartViewModel> GetProductAutoPart()
        {
            var Products = ProductLogic.Read(null);
            var list = new List<ReportProductAutoPartViewModel>();
            foreach (var Product in Products)
            {
                foreach (var AutoPart in Product.ProductAutoParts)
                {
                    var record = new ReportProductAutoPartViewModel
                    {
                        ProductName = Product.ProductName,
                        AutoPartName = AutoPart.Value.Item1,
                        Count = AutoPart.Value.Item2,
                    };
                    list.Add(record);
                }
            }
            return list;
        }
        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = orderLogic
            .Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .GroupBy(rec => rec.DateCreate.Date)
            .OrderBy(recG => recG.Key)
            .ToList();

            return list;
        }
        public void SaveProductsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                Products = ProductLogic.Read(null)
            });
        }
        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }
        public void SaveProductsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список компонентов по частям автомобиля",
                ProductAutoParts = GetProductAutoPart(),
            });
        }
    }
}

