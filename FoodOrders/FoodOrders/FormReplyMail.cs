using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodOrdersBusinessLogic.MailWorker;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.ViewModels;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace FoodOrdersView
{
    public partial class FormReplyMail : Form
    {
        private readonly ILogger _logger;
        private readonly AbstractMailWorker _mailWorker;
        private readonly IMessageInfoLogic _logic;
        private MessageInfoViewModel _message;

        public string MessageId { get; set; } = string.Empty;

        public FormReplyMail(ILogger<FormReplyMail> logger, AbstractMailWorker mailWorker, IMessageInfoLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _mailWorker = mailWorker;
            _logic = logic;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            _mailWorker.MailSendAsync(new()
            {
                MailAddress = _message.SenderName,
                Subject = _message.Subject,
                Text = textBoxReply.Text,
            });
            _logic.Update(new()
            {
                MessageId = MessageId, 
                Reply = textBoxReply.Text,
                HasRead = true,
            });
            MessageBox.Show("Успешно отправлено письмо", "Отправка письма", MessageBoxButtons.OK);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FormReplyMail_Load(object sender, EventArgs e)
        {
            try
            {
                _message = _logic.ReadElement(new() { MessageId = MessageId });
                if (_message == null)
                    throw new ArgumentNullException("Письма с таким id не существует");
                Text += $"для {_message.SenderName}";
                textBoxHead.Text = _message.Subject;
                textBoxMail.Text = _message.Body;
                if (_message.HasRead is false)
                {
                    _logic.Update(new() { MessageId = MessageId, HasRead = true, Reply = _message.Reply });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения собщения");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
