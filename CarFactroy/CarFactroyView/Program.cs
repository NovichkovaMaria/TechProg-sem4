using AbstractFactoryBusinessLogic;
using AbstractFactoryBusinessLogic.BusinessLogics;
using AbstractFactoryBusinessLogic.HelperModels;
using AbstractFactoryBusinessLogic.Interfaces;
using AbstractFactoryDatabaseImplement.Implements;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Configuration;
using System.Threading;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using System.Collections.Generic;
using AbstractFactoryBusinessLogic.ViewModels;

namespace AbstractCarFactoryView
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IAutoPartLogic, AutoPartLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductLogic, ProductLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderLogic, OrderLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientLogic, ClientLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<MainLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new
           HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}

