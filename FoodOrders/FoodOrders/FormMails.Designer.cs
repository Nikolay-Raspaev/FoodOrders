using DocumentFormat.OpenXml.Wordprocessing;

namespace FoodOrdersView
{
	partial class FormMails
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
			dataGridView = new DataGridView();
			buttonPrevPage = new Button();
			buttonNextPage = new Button();
			labelInfoPages = new Label();
			((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
			SuspendLayout();
			// 
			// dataGridView
			// 
			dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView.Location = new Point(0, 0);
			dataGridView.Name = "dataGridView";
			dataGridView.RowTemplate.Height = 25;
			dataGridView.Size = new Size(730, 454);
			dataGridView.TabIndex = 0;
			dataGridView.RowHeaderMouseClick += dataGridView_RowHeaderMouseClick;
			// 
			// buttonPrevPage
			// 
			buttonPrevPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			buttonPrevPage.Location = new Point(12, 460);
			buttonPrevPage.Name = "buttonPrevPage";
			buttonPrevPage.Size = new Size(75, 23);
			buttonPrevPage.TabIndex = 1;
			buttonPrevPage.Text = "<<<";
			buttonPrevPage.UseVisualStyleBackColor = true;
			buttonPrevPage.Click += ButtonPrevPage_Click;
			// 
			// buttonNextPage
			// 
			buttonNextPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			buttonNextPage.Location = new Point(203, 460);
			buttonNextPage.Name = "buttonNextPage";
			buttonNextPage.Size = new Size(75, 23);
			buttonNextPage.TabIndex = 2;
			buttonNextPage.Text = ">>>";
			buttonNextPage.UseVisualStyleBackColor = true;
			buttonNextPage.Click += ButtonNextPage_Click;
			// 
			// labelInfoPages
			// 
			labelInfoPages.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			labelInfoPages.Location = new Point(93, 464);
			labelInfoPages.Name = "labelInfoPages";
			labelInfoPages.Size = new Size(104, 19);
			labelInfoPages.TabIndex = 3;
			labelInfoPages.Text = "{0} страница";
			labelInfoPages.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// FormViewMail
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(727, 498);
			Controls.Add(labelInfoPages);
			Controls.Add(buttonNextPage);
			Controls.Add(buttonPrevPage);
			Controls.Add(dataGridView);
			Name = "FormViewMail";
			Text = "Письма";
			Load += FormMails_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView dataGridView;
		private Button buttonPrevPage;
		private Button buttonNextPage;
		private Label labelInfoPages;
	}
}