using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;

namespace FoodOrdersView
{
    public partial class FormSetOfDishesDishes : Form
    {
        private readonly List<DishViewModel>? _list;
        public int Id
        {
            get
            {
                return Convert.ToInt32(comboBoxDish.SelectedValue);
            }
            set
            {
                comboBoxDish.SelectedValue = value;
            }
        }
        public IDishModel? ComponentModel
        {
            get
            {
                if (_list == null)
                {
                    return null;
                }
                foreach (var elem in _list)
                {
                    if (elem.Id == Id)
                    {
                        return elem;
                    }
                }
                return null;
            }
        }
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set { textBoxCount.Text = value.ToString(); }
        }
        public FormSetOfDishesDishes(IDishLogic logic)
        {
            InitializeComponent();
            _list = logic.ReadList(null);
            if (_list != null)
            {
                comboBoxDish.DisplayMember = "DishName";
                comboBoxDish.ValueMember = "Id";
                comboBoxDish.DataSource = _list;
                comboBoxDish.SelectedItem = null;
            }
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
                MessageBox.Show("Выберите Блюдо", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
