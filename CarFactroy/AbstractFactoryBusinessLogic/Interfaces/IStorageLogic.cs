using AbstractFactoryBusinessLogic.BindingModels;
using AbstractFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryBusinessLogic.Interfaces
{
   public interface IStorageLogic
    {
        List<StorageViewModel> GetList();
        StorageViewModel GetElement(int id);
        void AddElement(StorageBindingModel model);
        void UpdElement(StorageBindingModel model);
        void DelElement(int id);
        void FillStorage(StorageAutoPartBindingModel model);
    }
}