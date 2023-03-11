using Microsoft.Extensions.Logging;
using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.SearchModels;

namespace FoodOrdersView
{
    public partial class FormCreateOrder : Form
    {
        private readonly ILogger _logger;
        private readonly IDishLogic _logicS;
        private readonly IOrderLogic _logicO;
        public FormCreateOrder(ILogger<FormCreateOrder> logger, IDishLogic logicS, IOrderLogic logicO)
        {
            InitializeComponent();
            _logger = logger;
            _logicS = logicS;
            _logicO = logicO;
        }
        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            _logger.LogInformation("Загрузка Набор блюд для заказа");
            try
            {
                var list = _logicS.ReadList(null);
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
                _logger.LogError(ex, "Ошибка загрузки списка Набор блюд");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalcSum()
        {
            if (comboBoxDish.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxDish.SelectedValue);
                    var product = _logicS.ReadElement(new DishSearchModel { Id = id });
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = Math.Round(count * (product?.Price ?? 0), 2).ToString();
                    _logger.LogInformation("Расчет суммы заказа");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка расчета суммы заказа");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void ComboBoxDish_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле 'Количество'", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxDish.SelectedValue == null)
            {
                MessageBox.Show("Выберите Набор блюд", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Создание заказа");
            try
            {
                var operationResult = _logicO.CreateOrder(new OrderBindingModel
                {
                    DishId = Convert.ToInt32(comboBoxDish.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDouble(textBoxSum.Text)
                });
                if (!operationResult)
                {
                    throw new Exception("Ошибка при создании заказа. Дополнительная информация в логах.");
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания заказа");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
