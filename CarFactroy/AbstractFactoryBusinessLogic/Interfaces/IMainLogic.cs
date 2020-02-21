using AbstractFactoryBusinessLogic.ViewModels;
using AbstractFactoryBusinessLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryBusinessLogic.Interfaces
{
    interface IMainLogic
    {
        List<OrderViewModel> GetOrders();
        void CreateOrder(OrderBindingModel model);
        void TakeOrderInWork(OrderBindingModel model);
        void FinishOrder(OrderBindingModel model);
        void PayOrder(OrderBindingModel model);
    }
}
