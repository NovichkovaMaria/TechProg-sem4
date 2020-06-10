﻿using AbstractFactoryListImplement.Models;
using System.Collections.Generic;
using AbstractFactoryBusinessLogic.BindingModels;
using AbstractFactoryBusinessLogic.Interfaces;
using AbstractFactoryBusinessLogic.ViewModels;
using System;

namespace AbstractFactoryListImplement.Implements
{
    public class ProductLogic : IProductLogic
    {
        private readonly DataListSingleton source;
        public ProductLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(ProductBindingModel model)
        {
            Product tempProduct = model.Id.HasValue ? null : new Product { Id = 1 };
            foreach (var product in source.Products)
            {
                if (product.ProductName == model.ProductName && product.Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
                if (!model.Id.HasValue && product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
                else if (model.Id.HasValue && product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempProduct == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempProduct);
            }
            else
            {
                source.Products.Add(CreateModel(model, tempProduct));
            }
        }
        public void Delete(ProductBindingModel model)
        {
            for (int i = 0; i < source.ProductAutoParts.Count; ++i)
            {
                if (source.ProductAutoParts[i].ProductId == model.Id)
                {
                    source.ProductAutoParts.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].Id == model.Id)
                {
                    source.Products.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Product CreateModel(ProductBindingModel model, Product product)
        {
            product.ProductName = model.ProductName;
            product.Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.ProductAutoParts.Count; ++i)
            {
                if (source.ProductAutoParts[i].Id > maxPCId)
                {
                    maxPCId = source.ProductAutoParts[i].Id;
                }
                if (source.ProductAutoParts[i].ProductId == product.Id)
                {
                    if
                    (model.ProductAutoParts.ContainsKey(source.ProductAutoParts[i].AutoPartId))
                    {
                        source.ProductAutoParts[i].Count =
                        model.ProductAutoParts[source.ProductAutoParts[i].AutoPartId].Item2;                  
                        model.ProductAutoParts.Remove(source.ProductAutoParts[i].AutoPartId);
                    }
                    else
                    {
                        source.ProductAutoParts.RemoveAt(i--);
                    }
                }
            }
            foreach (var pc in model.ProductAutoParts)
            {
                source.ProductAutoParts.Add(new ProductAutoPart
                {
                    Id = ++maxPCId,
                    ProductId = product.Id,
                    AutoPartId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return product;
        }
        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            List<ProductViewModel> result = new List<ProductViewModel>();
            foreach (var AutoPart in source.Products)
            {
                if (model != null)
                {
                    if (AutoPart.Id == model.Id)
                    {
                        result.Add(CreateViewModel(AutoPart));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(AutoPart));
            }
            return result;
        }
        private ProductViewModel CreateViewModel(Product product)
        {
            Dictionary<int, (string, int)> productAutoParts = new Dictionary<int, (string, int)>();
            foreach (var pc in source.ProductAutoParts)
            {
                if (pc.ProductId == product.Id)
                {
                    string AutoPartName = string.Empty;
                    foreach (var AutoPart in source.AutoParts)
                    {
                        if (pc.AutoPartId == AutoPart.Id)
                        {
                            AutoPartName = AutoPart.AutoPartName;
                            break;
                        }
                    }
                    productAutoParts.Add(pc.AutoPartId, (AutoPartName, pc.Count));
                }
            }
            return new ProductViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                ProductAutoParts = productAutoParts
            };
        }
    }
}
