using FoodOrdersView;
using FoodOrdersBusinessLogic.BusinessLogics;
using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersDataModels.Enums;
using Microsoft.Extensions.Logging;
using FoodOrdersContracts.DI;
using System.Windows.Forms;

namespace FoodOrdersView
{
    public partial class FormMain : Form
    {
        private readonly ILogger _logger;
        private readonly IOrderLogic _logicO;
        private readonly IWorkProcess _workProcess;
        private readonly IReportLogic _logicR;
        private readonly IBackUpLogic _backUpLogic;
        public FormMain(ILogger<FormMain> logger, IOrderLogic orderLogic, IReportLogic reportLogic, IWorkProcess workProcess, IBackUpLogic backUpLogic)
        {
            InitializeComponent();
            _logger = logger;
            _logicO = orderLogic;
            _logicR = reportLogic;
            _workProcess = workProcess;
            _backUpLogic = backUpLogic;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                dataGridView.FillAndConfigGrid(_logicO.ReadList(null));
                _logger.LogInformation("Загрузка заказов");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки заказов");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ComponentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormComponents>();
            form.ShowDialog();
        }
        private void DishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormComponents>();
            form.ShowDialog();
        }
        private void ButtonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormComponents>();
            form.ShowDialog();
            LoadData();
        }

        private void ButtonIssuedOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                _logger.LogInformation("Заказ №{id}. Меняется статус на 'Выдан'", id);
                try
                {
                    var operationResult = _logicO.DeliveryOrder(new OrderBindingModel
                    {
                        Id = id
                    });
                    if (!operationResult)
                    {
                        throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                    }
                    _logger.LogInformation("Заказ №{id} выдан", id);
                    LoadData();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка отметки о выдачи заказа");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _logicR.SaveComponentsToWordFile(new ReportBindingModel { FileName = dialog.FileName });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ComponentDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormReportDishComponents>();
            form.ShowDialog();
        }

        private void OrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormReportOrders>();
            form.ShowDialog();
        }

        private void ClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormClients>();
            form.ShowDialog();
        }

        private void ImplementersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormViewImplementers>();
            form.ShowDialog();
        }

        private void DoWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _workProcess.DoWork(DependencyManager.Instance.Resolve<IImplementerLogic>(), _logicO);
            MessageBox.Show("Процесс обработки запущен", "Сообщение",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormMails>();
            form.ShowDialog();
        }

        private void createBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_backUpLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        _backUpLogic.CreateBackUp(new BackUpSaveBinidngModel
                        {
                            FolderName = fbd.SelectedPath
                        });
                        MessageBox.Show("Бекап создан", "Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}