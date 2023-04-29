using Microsoft.Extensions.Logging;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersView;

namespace FoodOrdersView
{
    public partial class FormMails : Form
    {
        private readonly ILogger _logger;
        private readonly IMessageInfoLogic _logic;

        public FormMails(ILogger<FormMails> logger, IMessageInfoLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }

        private void FormMails_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView.FillAndConfigGrid(_logic.ReadList(null));
                _logger.LogInformation("Загрузка списка писем");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки писем");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
