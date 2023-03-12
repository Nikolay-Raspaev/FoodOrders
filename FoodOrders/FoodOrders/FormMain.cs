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
        public FormMain(ILogger<FormMain> logger, IOrderLogic orderLogic)
        {
            InitializeComponent();
            _logger = logger;
            _logicO = orderLogic;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            _logger.LogInformation("Загрузка заказов");
            try
            {
                var list = _logicO.ReadList(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns["DishId"].Visible = false;
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
                        Id = id,
                        DishId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["DishId"].Value),
                        Status = Enum.Parse<OrderStatus>(dataGridView.SelectedRows[0].Cells["Status"].Value.ToString()),
                        Count = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Count"].Value),
                        Sum = double.Parse(dataGridView.SelectedRows[0].Cells["Sum"].Value.ToString()),
                        DateCreate = DateTime.Parse(dataGridView.SelectedRows[0].Cells["DateCreate"].Value.ToString()),
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
                        Id = id,
                        DishId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["DishId"].Value),
                        Status = Enum.Parse<OrderStatus>(dataGridView.SelectedRows[0].Cells["Status"].Value.ToString()),
                        Count = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Count"].Value),
                        Sum = double.Parse(dataGridView.SelectedRows[0].Cells["Sum"].Value.ToString()),
                        DateCreate = DateTime.Parse(dataGridView.SelectedRows[0].Cells["DateCreate"].Value.ToString()),
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
                        Id = id,
                        DishId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["DishId"].Value),
                        Status = Enum.Parse<OrderStatus>(dataGridView.SelectedRows[0].Cells["Status"].Value.ToString()),
                        Count = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Count"].Value),
                        Sum = double.Parse(dataGridView.SelectedRows[0].Cells["Sum"].Value.ToString()),
                        DateCreate = DateTime.Parse(dataGridView.SelectedRows[0].Cells["DateCreate"].Value.ToString()),
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
    }
}