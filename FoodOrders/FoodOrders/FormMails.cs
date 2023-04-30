using Microsoft.Extensions.Logging;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersView;
using FoodOrdersContracts.ViewModels;
using FoodOrdersContracts.DI;

namespace FoodOrdersView
{
	public partial class FormMails : Form
	{
		private readonly ILogger _logger;
		private readonly IMessageInfoLogic _logic;
		private int currentPage = 1;
		public int pageSize = 5;

		public FormMails(ILogger<FormMails> logger, IMessageInfoLogic logic)
		{
			InitializeComponent();
			_logger = logger;
			_logic = logic;
			buttonPrevPage.Enabled = false;
		}

		private void FormMails_Load(object sender, EventArgs e)
		{
			MailLoad();
		}
		private bool MailLoad()
		{
			try
			{
				var list = _logic.ReadList(new()
				{
					Page = currentPage,
					PageSize = pageSize,
				});
				if (list != null)
				{
					dataGridView.DataSource = list;
					dataGridView.Columns["ClientId"].Visible = false;
					dataGridView.Columns["MessageId"].Visible = false;
					dataGridView.Columns["Body"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}
				_logger.LogInformation("Загрузка списка писем");
				labelInfoPages.Text = $"{currentPage} страница";
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки писем");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return false;
			}
		}

		private void ButtonPrevPage_Click(object sender, EventArgs e)
		{
			if (currentPage == 1)
			{
				_logger.LogWarning("Неккоректный номер страницы {page}", currentPage - 1);
				return;
			}
			currentPage--;
			if (MailLoad())
			{
				buttonNextPage.Enabled = true;
				if (currentPage == 1)
				{
					buttonPrevPage.Enabled = false;
				}
			}
		}

		private void ButtonNextPage_Click(object sender, EventArgs e)
		{
			currentPage++;
			if (!MailLoad() || ((List<MessageInfoViewModel>)dataGridView.DataSource).Count == 0)
			{
				_logger.LogWarning("Out of range messages");
				currentPage--;
				MailLoad();
				buttonNextPage.Enabled = false;
			}
			else
			{
				buttonPrevPage.Enabled = true;
			}
		}

		private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
            var form = DependencyManager.Instance.Resolve<FormReplyMail>();
			form.MessageId = (string)dataGridView.Rows[e.RowIndex].Cells["MessageId"].Value;
			form.ShowDialog();
			MailLoad();
		}
	}
}