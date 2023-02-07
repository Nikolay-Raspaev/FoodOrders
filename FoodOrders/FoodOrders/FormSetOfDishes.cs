using FoodOrders;
using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.SearchModels;
using FoodOrdersDataModels.Models;
using Microsoft.Extensions.Logging;

namespace FoodOrdersView
{
    public partial class FormSetOfDishes : Form
    {
        private readonly ILogger _logger;
        private readonly ISetOfDishesLogic _logic;
        private int? _id;
        private Dictionary<int, (IDishModel, int)> _set_of_dishesDishes;
        public int Id { set { _id = value; } }
        public FormSetOfDishes(ILogger<FormSetOfDishes> logger, ISetOfDishesLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
            _set_of_dishesDishes = new Dictionary<int, (IDishModel, int)>();
        }
        private void FormSetOfDishes_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                _logger.LogInformation("Загрузка набор блюд");
                try
                {
                    var view = _logic.ReadElement(new SetOfDishesearchModel
                    {
                        Id = _id.Value
                    });
                    if (view != null)
                    {
                        textBoxName.Text = view.SetOfDishesName;
                        textBoxPrice.Text = view.Price.ToString();
                        _set_of_dishesDishes = view.SetOfDishesDishes ?? new Dictionary<int, (IDishModel, int)>();
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка загрузки набор блюд");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
        private void LoadData()
        {
            _logger.LogInformation("Загрузка Блюдо набор блюд");
            try
            {
                if (_set_of_dishesDishes != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var sc in _set_of_dishesDishes)
                    {
                        dataGridView.Rows.Add(new object[] { sc.Key, sc.Value.Item1.DishName, sc.Value.Item2 });
                    }
                    textBoxPrice.Text = CalcPrice().ToString();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки Блюдо набор блюд");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormSetOfDishesDishes));
            if (service is FormSetOfDishesDishes form)
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.ComponentModel == null)
                    {
                        return;
                    }
                    _logger.LogInformation("Добавление нового блюда: { DishName} - { Count}", form.ComponentModel.DishName, form.Count);
                    if (_set_of_dishesDishes.ContainsKey(form.Id))
                    {
                        _set_of_dishesDishes[form.Id] = (form.ComponentModel,
                       form.Count);
                    }
                    else
                    {
                        _set_of_dishesDishes.Add(form.Id, (form.ComponentModel,
                       form.Count));
                    }
                    LoadData();
                }
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormSetOfDishesDishes));
                if (service is FormSetOfDishesDishes form)
                {
                    int id =
                   Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    form.Id = id;
                    form.Count = _set_of_dishesDishes[id].Item2;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (form.ComponentModel == null)
                        {
                            return;
                        }
                        _logger.LogInformation("Изменение блюда: { DishName} - { Count} ", form.ComponentModel.DishName, form.Count);
                        _set_of_dishesDishes[form.Id] = (form.ComponentModel, form.Count);
                        LoadData();
                    }
                }
            }
        }
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _logger.LogInformation("Удаление блюда: { DishName} - { Count} ", 
                            dataGridView.SelectedRows[0].Cells[1].Value); _set_of_dishesDishes?.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (_set_of_dishesDishes == null || _set_of_dishesDishes.Count == 0)
            {
                MessageBox.Show("Заполните Блюда", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Сохранение набор блюд");
            try
            {
                var model = new SetOfDishesBindingModel
                {
                    Id = _id ?? 0,
                    SetOfDishesName = textBoxName.Text,
                    Price = Convert.ToDouble(textBoxPrice.Text),
                    SetOfDishesDishes = _set_of_dishesDishes
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
                _logger.LogError(ex, "Ошибка сохранения набор блюд");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private double CalcPrice()
        {
            double price = 0;
            foreach (var elem in _set_of_dishesDishes)
            {
                price += ((elem.Value.Item1?.Cost ?? 0) * elem.Value.Item2);
            }
            return Math.Round(price * 1.1, 2);
        }
    }
}
