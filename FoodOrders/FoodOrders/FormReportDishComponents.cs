using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.BusinessLogicsContracts;
using Microsoft.Extensions.Logging;

namespace FoodOrdersView
{
    public partial class FormReportDishComponents : Form
    {
        private readonly ILogger _logger;

        private readonly IReportLogic _logic;

        public FormReportDishComponents(ILogger<FormReportDishComponents> logger, IReportLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }

        private void FormReportDishComponents_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = _logic.GetDishComponent();
                if (dict != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridView.Rows.Add(new object[] { elem.DishName, "", "" });
                        foreach (var listElem in elem.Components)
                        {
                            dataGridView.Rows.Add(new object[] { "", listElem.Item1, listElem.Item2 });
                        }
                        dataGridView.Rows.Add(new object[] { "Итого", "", elem.TotalCount });
                        dataGridView.Rows.Add(Array.Empty<object>());
                    }
                }
                _logger.LogInformation("Загрузка списка изделий по компонентам");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки списка изделий по компонентам");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSaveToExcel_Click(object sender, EventArgs e)
        {
			using var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" };
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					_logic.SaveDishComponentToExcelFile(new ReportBindingModel
					{
						FileName = dialog.FileName
					});
                    _logger.LogInformation("Сохранение списка изделий по компонентам");
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка сохранения списка изделий по компонентам");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
    }
}