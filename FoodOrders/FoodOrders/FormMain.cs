using FoodOrdersBusinessLogic.BusinessLogics;
using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersDataModels.Enums;
using Microsoft.Extensions.Logging;

namespace FoodOrdersView
{
    public partial class FormMain : Form
    {
        private readonly ILogger _logger;
        private readonly IOrderLogic _logicO;
        private readonly IWorkProcess _workProcess;
        private readonly IReportLogic _logicR;
        public FormMain(ILogger<FormMain> logger, IOrderLogic orderLogic, IReportLogic reportLogic, IWorkProcess workProcess)
        {
            InitializeComponent();
            _logger = logger;
            _logicO = orderLogic;
            _logicR = reportLogic;
            _workProcess = workProcess;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = _logicO.ReadList(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns["DishId"].Visible = false;
                    dataGridView.Columns["ClientId"].Visible = false;
                    dataGridView.Columns["ImplementerId"].Visible = false;
                }
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
            var service = Program.ServiceProvider?.GetService(typeof(FormComponents));
            if (service is FormComponents form)
            {
                form.ShowDialog();
            }
        }
        private void DishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormDishes));
            if (service is FormDishes form)
            {
                form.ShowDialog();
            }
        }
        private void ButtonCreateOrder_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormCreateOrder));
            if (service is FormCreateOrder form)
            {
                form.ShowDialog();
                LoadData();
            }
        }
        private void ButtonTakeOrderInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                _logger.LogInformation("Заказ №{id}. Меняется статус на 'В работе'", id);
                try
                {
                    var operationResult = _logicO.TakeOrderInWork(new OrderBindingModel
                    {
                        Id = id
                    });
                    if (!operationResult)
                    {
                        throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка передачи заказа в работу");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonOrderReady_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                _logger.LogInformation("Заказ №{id}. Меняется статус на 'Готов'", id);
                try
                {
                    var operationResult = _logicO.FinishOrder(new OrderBindingModel
                    {
                        Id = id
                    });
                    if (!operationResult)
                    {
                        throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка отметки о готовности заказа");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void ButtonDeliveryDish_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormDeliveryDishes));
            if (service is FormDeliveryDishes form)
            {
                form.ShowDialog();
            }
        }

        private void ShopsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormShops));
            if (service is FormShops form)
            {
                form.ShowDialog();
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _logicR.SaveDishesToWordFile(new ReportBindingModel { FileName = dialog.FileName });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ComponentDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormReportDishComponents));
            if (service is FormReportDishComponents form)
            {
                form.ShowDialog();
            }
        }

        private void OrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormReportOrders));
            if (service is FormReportOrders form)
            {
                form.ShowDialog();
            }
        }

        private void ShopsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _logicR.SaveShopsToWordFile(new ReportBindingModel { FileName = dialog.FileName });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShopDishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormReportShopListDish));
            if (service is FormReportShopListDish form)
            {
                form.ShowDialog();
            }
        }

        private void OrdersGroupedByDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormReportOrdersGroupedByDate));
            if (service is FormReportOrdersGroupedByDate form)
            {
                form.ShowDialog();
            }
        }

        private void ClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormClients));
            if (service is FormClients form)
            {
                form.ShowDialog();
            }
        }

        private void ImplementersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormViewImplementers));
            if (service is FormViewImplementers form)
            {
                form.ShowDialog();
            }
        }

        private void DoWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _workProcess.DoWork((Program.ServiceProvider?.GetService(typeof(IImplementerLogic)) as IImplementerLogic)!, _logicO);
            MessageBox.Show("Процесс обработки запущен", "Сообщение",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormMails));
            if (service is FormMails form)
            {
                form.ShowDialog();
            }
        }
    }
}