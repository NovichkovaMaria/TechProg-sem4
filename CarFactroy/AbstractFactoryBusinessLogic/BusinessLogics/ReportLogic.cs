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
        private readonly IProductLogic productLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(IProductLogic productLogic, IAutoPartLogic AutoPartLogic,
       IOrderLogic orderLLogic)
        {
            this.productLogic = productLogic;
            this.AutoPartLogic = AutoPartLogic;
            this.orderLogic = orderLLogic;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportProductAutoPartViewModel> GetProductAutoPart()
        {
            var AutoParts = AutoPartLogic.Read(null);
            var products = productLogic.Read(null);
            var list = new List<ReportProductAutoPartViewModel>();
            foreach (var AutoPart in AutoParts)
            {
                var record = new ReportProductAutoPartViewModel
                {
                    AutoPartName = AutoPart.AutoPartName,
                    Products = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var product in products)
                {
                    if (product.ProductAutoParts.ContainsKey(AutoPart.Id))
                    {
                        record.Products.Add(new Tuple<string, int>(product.ProductName,
                       product.ProductAutoParts[AutoPart.Id].Item2));
                        record.TotalCount +=
                       product.ProductAutoParts[AutoPart.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveAutoPartsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                AutoParts = AutoPartLogic.Read(null)
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveProductAutoPartToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                ProductAutoParts = GetProductAutoPart()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
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
