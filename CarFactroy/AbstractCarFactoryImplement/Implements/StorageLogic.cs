using AbstractFactoryBusinessLogic.BindingModels;
using AbstractFactoryBusinessLogic.Interfaces;
using AbstractFactoryBusinessLogic.ViewModels;
using AbstractFactoryListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryListImplement.Implements
{
    public class StorageLogic : IStorageLogic
    {
        private readonly DataListSingleton source;
        public StorageLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<StorageViewModel> GetList()
        {
            List<StorageViewModel> result = new List<StorageViewModel>();
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                List<StorageAutoPartViewModel> StorageAutoParts = new
    List<StorageAutoPartViewModel>();
                for (int j = 0; j < source.StorageAutoParts.Count; ++j)
                {
                    if (source.StorageAutoParts[j].StorageId == source.Storages[i].Id)
                    {
                        string AutoPartName = string.Empty;
                        for (int k = 0; k < source.AutoParts.Count; ++k)
                        {
                            if (source.StorageAutoParts[j].AutoPartId ==
                           source.AutoParts[k].Id)
                            {
                                AutoPartName = source.AutoParts[k].AutoPartName;
                                break;
                            }
                        }
                        StorageAutoParts.Add(new StorageAutoPartViewModel
                        {
                            Id = source.StorageAutoParts[j].Id,
                            StorageId = source.StorageAutoParts[j].StorageId,
                            AutoPartId = source.StorageAutoParts[j].AutoPartId,
                            AutoPartName = AutoPartName,
                            Count = source.StorageAutoParts[j].Count
                        });
                    }
                }
                result.Add(new StorageViewModel
                {
                    Id = source.Storages[i].Id,
                    StorageName = source.Storages[i].StorageName,
                    StorageAutoParts = StorageAutoParts
                });
            }
            return result;
        }
        public StorageViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                List<StorageAutoPartViewModel> StorageAutoParts = new
    List<StorageAutoPartViewModel>();
                for (int j = 0; j < source.StorageAutoParts.Count; ++j)
                {
                    if (source.StorageAutoParts[j].StorageId == source.Storages[i].Id)
                    {
                        string AutoPartName = string.Empty;
                        for (int k = 0; k < source.AutoParts.Count; ++k)
                        {
                            if (source.StorageAutoParts[j].AutoPartId ==
                           source.AutoParts[k].Id)
                            {
                                AutoPartName = source.AutoParts[k].AutoPartName;
                                break;
                            }
                        }
                        StorageAutoParts.Add(new StorageAutoPartViewModel
                        {
                            Id = source.StorageAutoParts[j].Id,
                            StorageId = source.StorageAutoParts[j].StorageId,
                            AutoPartId = source.StorageAutoParts[j].AutoPartId,
                            AutoPartName = AutoPartName,
                            Count = source.StorageAutoParts[j].Count
                        });
                    }
                }
                if (source.Storages[i].Id == id)
                {
                    return new StorageViewModel
                    {
                        Id = source.Storages[i].Id,
                        StorageName = source.Storages[i].StorageName,
                        StorageAutoParts = StorageAutoParts
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(StorageBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id > maxId)
                {
                    maxId = source.Storages[i].Id;
                }
                if (source.Storages[i].StorageName == model.StorageName)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            source.Storages.Add(new Storage
            {
                Id = maxId + 1,
                StorageName = model.StorageName
            });
        }
        public void UpdElement(StorageBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Storages[i].StorageName == model.StorageName &&
                source.Storages[i].Id != model.Id)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Storages[index].StorageName = model.StorageName;
        }
        public void DelElement(int id)
        {
            for (int i = 0; i < source.StorageAutoParts.Count; ++i)
            {
                if (source.StorageAutoParts[i].StorageId == id)
                {
                    source.StorageAutoParts.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id == id)
                {
                    source.Storages.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void FillStorage(StorageAutoPartBindingModel model)
        {
            int foundItemIndex = -1;
            for (int i = 0; i < source.StorageAutoParts.Count; ++i)
            {
                if (source.StorageAutoParts[i].AutoPartId == model.AutoPartId
                    && source.StorageAutoParts[i].StorageId == model.StorageId)
                {
                    foundItemIndex = i;
                    break;
                }
            }
            if (foundItemIndex != -1)
            {
                source.StorageAutoParts[foundItemIndex].Count =
                    source.StorageAutoParts[foundItemIndex].Count + model.Count;
            }
            else
            {
                int maxId = 0;
                for (int i = 0; i < source.StorageAutoParts.Count; ++i)
                {
                    if (source.StorageAutoParts[i].Id > maxId)
                    {
                        maxId = source.StorageAutoParts[i].Id;
                    }
                }
                source.StorageAutoParts.Add(new StorageAutoPart
                {
                    Id = maxId + 1,
                    StorageId = model.StorageId,
                    AutoPartId = model.AutoPartId,
                    Count = model.Count
                });
            }
        }
    }
}