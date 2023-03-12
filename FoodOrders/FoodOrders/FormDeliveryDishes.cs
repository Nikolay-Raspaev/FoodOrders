using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.SearchModels;
using Microsoft.Extensions.Logging;
namespace FoodOrdersView
{
    public partial class FormDeliveryDishes : Form
    {
        private readonly ILogger _logger;
        private readonly IDishLogic _logicD;
        private readonly IShopLogic _logicS;
        public FormDeliveryDishes(ILogger<FormDeliveryDishes> logger, IDishLogic logicC, IShopLogic logicS)
        {
            InitializeComponent();
            _logger = logger;
            _logicD = logicC;
            _logicS = logicS;
        }
        private void FormDeliveryDishes_Load(object sender, EventArgs e)
        {
            _logger.LogInformation("Загрузка магазина");
            try
            {
                var list = _logicS.ReadList(null);
                if (list != null)
                {
                    comboBoxShop.DisplayMember = "ShopName";
                    comboBoxShop.ValueMember = "Id";
                    comboBoxShop.DataSource = list;
                    comboBoxShop.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки списка магазинов");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _logger.LogInformation("Загрузка блюд");
            try
            {
                var list = _logicD.ReadList(null);
                if (list != null)
                {
                    comboBoxDish.DisplayMember = "DishName";
                    comboBoxDish.ValueMember = "Id";
                    comboBoxDish.DataSource = list;
                    comboBoxDish.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки списка блюд");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxShop.SelectedValue == null)
            {
                MessageBox.Show("Выберите магазин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxDish.SelectedValue == null)
            {
                MessageBox.Show("Выберите блюдо", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Пополнение магазина");
            try
            {
                var operationResult = _logicS.DeliveryDishes(
                    new ShopSearchModel { ShopName = comboBoxShop.Text,}, 
                    _logicD.ReadElement(new DishSearchModel{ DishName = comboBoxDish.Text })!,
                    Convert.ToInt32(textBoxCount.Text)
                );
                if (!operationResult)
                {
                    throw new Exception("Ошибка при пополнении магазина. Дополнительная информация в логах.");
                }
                MessageBox.Show("Пополнение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка пополнения магазина");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}