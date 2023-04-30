namespace FoodOrdersView
{
    partial class FormReplyMail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonSave = new Button();
            buttonCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxHead = new TextBox();
            textBoxMail = new TextBox();
            textBoxReply = new TextBox();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.Location = new Point(460, 291);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(117, 30);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(337, 291);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(117, 30);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // label1
            // 
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(117, 23);
            label1.TabIndex = 2;
            label1.Text = "Заголовок письма:";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(117, 23);
            label2.TabIndex = 3;
            label2.Text = "Текст письма:";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // label3
            // 
            label3.Location = new Point(12, 117);
            label3.Name = "label3";
            label3.Size = new Size(117, 31);
            label3.TabIndex = 4;
            label3.Text = "Ответ на письмо:";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // textBoxHead
            // 
            textBoxHead.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxHead.Location = new Point(135, 5);
            textBoxHead.Name = "textBoxHead";
            textBoxHead.ReadOnly = true;
            textBoxHead.Size = new Size(442, 23);
            textBoxHead.TabIndex = 5;
            // 
            // textBoxMail
            // 
            textBoxMail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxMail.Location = new Point(135, 35);
            textBoxMail.Multiline = true;
            textBoxMail.Name = "textBoxMail";
            textBoxMail.ReadOnly = true;
            textBoxMail.Size = new Size(442, 76);
            textBoxMail.TabIndex = 6;
            // 
            // textBoxReply
            // 
            textBoxReply.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxReply.Location = new Point(135, 117);
            textBoxReply.Multiline = true;
            textBoxReply.Name = "textBoxReply";
            textBoxReply.Size = new Size(442, 168);
            textBoxReply.TabIndex = 7;
            // 
            // FormReplyMail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 333);
            Controls.Add(textBoxReply);
            Controls.Add(textBoxMail);
            Controls.Add(textBoxHead);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Name = "FormReplyMail";
            Text = "Ответ на письмо";
            Load += FormReplyMail_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSave;
        private Button buttonCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxHead;
        private TextBox textBoxMail;
        private TextBox textBoxReply;
    }
}