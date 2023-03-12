using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.SearchModels;
using FoodOrdersDataModels.Models;
using Microsoft.Extensions.Logging;
namespace FoodOrdersView
{
    public partial class FormShop : Form
    {
        private readonly ILogger _logger;
        private readonly IShopLogic _logic;
        private int? _id;
        private Dictionary<int, (IDishModel, int)> _shopDishes;
        public int Id { set { _id = value; } }
        public FormShop(ILogger<FormShop> logger, IShopLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
            _shopDishes = new Dictionary<int, (IDishModel, int)>();
        }
        private void FormShop_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                _logger.LogInformation("Загрузка магазина");
                try
                {
                    var view = _logic.ReadElement(new ShopSearchModel
                    {
                        Id = _id.Value
                    });
                    if (view != null)
                    {
                        textBoxName.Text = view.ShopName;
                        textBoxAddress.Text = view.Address;
                        dateTimePicker.Value = view.DateOfOpening;
                        _shopDishes = view.ShopDishes ?? new Dictionary<int, (IDishModel, int)>();
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка загрузки магазина");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
        private void LoadData()
        {
            _logger.LogInformation("Загрузка блюд в магазине");
            try
            {
                if (_shopDishes != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var sc in _shopDishes)
                    {
                        dataGridView.Rows.Add(new object[] { sc.Key, sc.Value.Item1.DishName, sc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки блюд в магазине");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxAddress.Text))
            {
                MessageBox.Show("Заполните адрес", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Сохранение магазина");
            try
            {
                var model = new ShopBindingModel
                {
                    Id = _id ?? 0,
                    ShopName = textBoxName.Text,
                    Address = textBoxAddress.Text,
                    DateOfOpening = dateTimePicker.Value.Date,
                    ShopDishes = _shopDishes
                };
                var operationResult = _id.HasValue ? _logic.Update(model) : _logic.Create(model);
                if (!operationResult)
                {
                    throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка сохранения магазина");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
