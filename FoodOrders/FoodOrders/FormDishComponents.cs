using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;

namespace FoodOrdersView
{
    public partial class FormDishComponents : Form
    {
        private readonly List<ComponentViewModel>? _list;
        public int Id
        {
            get
            {
                return Convert.ToInt32(comboBoxComponent.SelectedValue);
            }
            set
            {
                comboBoxComponent.SelectedValue = value;
            }
        }
        public IComponentModel? ComponentModel
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
        public FormDishComponents(IComponentLogic logic)
        {
            InitializeComponent();
            _list = logic.ReadList(null);
            if (_list != null)
            {
                comboBoxComponent.DisplayMember = "ComponentName";
                comboBoxComponent.ValueMember = "Id";
                comboBoxComponent.DataSource = _list;
                comboBoxComponent.SelectedItem = null;
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
            if (comboBoxComponent.SelectedValue == null)
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
