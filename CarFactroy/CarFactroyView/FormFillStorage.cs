﻿using AbstractFactoryBusinessLogic.BindingModels;
using AbstractFactoryBusinessLogic.BusinessLogics;
using AbstractFactoryBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace CarFactoryView
{
    public partial class FormFillStorage : Form
    {
        [Dependency]
        public new Unity.IUnityContainer Container { get; set; }
        private readonly IAutoPartLogic logicF;
        private readonly MainLogic logicM;
        private readonly IStorageLogic logicS;
        public FormFillStorage(IAutoPartLogic logicF, MainLogic logicM, IStorageLogic logicS)
        {
            InitializeComponent();
            this.logicF = logicF;
            this.logicM = logicM;
            this.logicS = logicS;
        }
        private void FormFillStorage_Load(object sender, EventArgs e)
        {
            try
            {
                var storageList = logicS.GetList();
                comboBoxStorage.DataSource = storageList;
                comboBoxStorage.DisplayMember = "StorageName";
                comboBoxStorage.ValueMember = "Id";
                var AutoPartList = logicF.Read(null);
                comboBoxAutoPart.DataSource = AutoPartList;
                comboBoxAutoPart.DisplayMember = "AutoPartName";
                comboBoxAutoPart.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните количество", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxStorage.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
MessageBoxIcon.Error);
                return;
            }
            if (comboBoxAutoPart.SelectedValue == null)
            {
                MessageBox.Show("Выберите продукт", "Ошибка", MessageBoxButtons.OK,
MessageBoxIcon.Error);
                return;
            }
            try
            {
                int storageId = Convert.ToInt32(comboBoxStorage.SelectedValue);
                int AutoPartId = Convert.ToInt32(comboBoxAutoPart.SelectedValue);
                int count = Convert.ToInt32(textBoxCount.Text);
                this.logicM.FillStorage(new StorageAutoPartBindingModel
                {
                    StorageId = storageId,
                    AutoPartId = AutoPartId,
                    Count = count
                });
                MessageBox.Show("Склад успешно пополнен", "Сообщение",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
MessageBoxIcon.Error);
            }
            Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
