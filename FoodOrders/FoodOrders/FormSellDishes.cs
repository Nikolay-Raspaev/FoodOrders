using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.SearchModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodOrdersView
{
    public partial class FormSellDishes : Form
    {
        private readonly ILogger _logger;
        private readonly IDishLogic _logicC;
        private readonly IShopLogic _logicS;
        public FormSellDishes(ILogger<FormCreateOrder> logger, IDishLogic logicC, IShopLogic logicS)
        {
            InitializeComponent();
            _logger = logger;
            _logicC = logicC;
            _logicS = logicS;
        }

        private void FormSellDishes_Load(object sender, EventArgs e)
        {
            _logger.LogInformation("Загрузка блюд под продажу");
            try
            {
                var list = _logicC.ReadList(null);
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
        private void ButtonSell_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле 'Количество'", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxDish.SelectedValue == null)
            {
                MessageBox.Show("Выберите блюдо", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Продажа блюд");
            try
            {
                var operationResult = _logicS.SellDishes(_logicC.ReadElement
                    (new DishSearchModel { DishName = comboBoxDish.Text})!,
                    Convert.ToInt32(textBoxCount.Text));
                if (!operationResult)
                {
                    throw new Exception("Ошибка при продаже блюд. В магазинах недостаточно блюд.");
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка продажи блюд");
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
