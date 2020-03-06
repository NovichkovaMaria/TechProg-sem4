using AbstractFactoryBusinessLogic.BindingModels;
using AbstractFactoryBusinessLogic.Interfaces;
using AbstractFactoryBusinessLogic.ViewModels;
using AbstractFactoryDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractFactoryDatabaseImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(OrderBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
