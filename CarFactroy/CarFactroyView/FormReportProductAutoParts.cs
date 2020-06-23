using AbstractFactoryBusinessLogic.BindingModels;
using AbstractFactoryBusinessLogic.BusinessLogics;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;
using Unity;

namespace AbstractCarFactoryView
{
    public partial class FormReportProductAutoParts : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportProductAutoParts(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void buttonMake_Click(object sender, EventArgs e)
        {
            try
            {
                var dataSource = logic.GetProductAutoPart();
                ReportDataSource source = new ReportDataSource("DataSetProductAutoPart", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonToPdf_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveProductsToPdfFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void FormReportProductAutoParts_Load(object sender, EventArgs e)
        {
        }
    }
}
