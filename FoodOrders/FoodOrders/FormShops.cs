using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.DI;
using Microsoft.Extensions.Logging;
namespace FoodOrdersView
{
    public partial class FormShops : Form
    {
        private readonly ILogger _logger;
        private readonly IShopLogic _logicS;
        public FormShops(ILogger<FormShops> logger, IShopLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logicS = logic;
        }
        private void FormShops_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = _logicS.ReadList(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns["Id"].Visible = false;
                    dataGridView.Columns["ShopDishes"].Visible = false;
                    dataGridView.Columns["DateOfOpening"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                _logger.LogInformation("Загрузка магазинов");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки магазинов");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                    _logger.LogInformation("Удаление магазина");
                    try
                    {
                        if (!_logicS.Delete(new ShopBindingModel
                        {
                            Id = id
                        }))
                        {
                            throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
                        }
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка удаления магазина");
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormShop>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = DependencyManager.Instance.Resolve<FormShop>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                LoadData();
            }
        }
        private void ButtonSellDishes_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormSellDishes>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
