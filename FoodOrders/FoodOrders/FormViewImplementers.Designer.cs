namespace FoodOrdersView
{
	partial class FormViewImplementers
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
			buttonRef = new Button();
			buttonDel = new Button();
			buttonUpd = new Button();
			buttonAdd = new Button();
			dataGridView = new DataGridView();
			((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
			SuspendLayout();
			// 
			// buttonRef
			// 
			buttonRef.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonRef.Location = new Point(626, 202);
			buttonRef.Name = "buttonRef";
			buttonRef.Size = new Size(90, 37);
			buttonRef.TabIndex = 9;
			buttonRef.Text = "Обновить";
			buttonRef.UseVisualStyleBackColor = true;
			buttonRef.Click += ButtonRef_Click;
			// 
			// buttonDel
			// 
			buttonDel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonDel.Location = new Point(626, 151);
			buttonDel.Name = "buttonDel";
			buttonDel.Size = new Size(90, 33);
			buttonDel.TabIndex = 8;
			buttonDel.Text = "Удалить";
			buttonDel.UseVisualStyleBackColor = true;
			buttonDel.Click += ButtonDel_Click;
			// 
			// buttonUpd
			// 
			buttonUpd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonUpd.Location = new Point(626, 102);
			buttonUpd.Name = "buttonUpd";
			buttonUpd.Size = new Size(90, 34);
			buttonUpd.TabIndex = 7;
			buttonUpd.Text = "Изменить";
			buttonUpd.UseVisualStyleBackColor = true;
			buttonUpd.Click += ButtonUpd_Click;
			// 
			// buttonAdd
			// 
			buttonAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonAdd.Location = new Point(626, 57);
			buttonAdd.Name = "buttonAdd";
			buttonAdd.Size = new Size(90, 30);
			buttonAdd.TabIndex = 6;
			buttonAdd.Text = "Добавить";
			buttonAdd.UseVisualStyleBackColor = true;
			buttonAdd.Click += ButtonAdd_Click;
			// 
			// dataGridView
			// 
			dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView.Location = new Point(12, 12);
			dataGridView.Name = "dataGridView";
			dataGridView.RowTemplate.Height = 25;
			dataGridView.Size = new Size(553, 302);
			dataGridView.TabIndex = 5;
			// 
			// FormViewImplementers
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(722, 319);
			Controls.Add(buttonRef);
			Controls.Add(buttonDel);
			Controls.Add(buttonUpd);
			Controls.Add(buttonAdd);
			Controls.Add(dataGridView);
			Name = "FormViewImplementers";
			Text = "Просмотр списка исполнителей";
			Load += FormViewImplementers_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button buttonRef;
		private Button buttonDel;
		private Button buttonUpd;
		private Button buttonAdd;
		private DataGridView dataGridView;
	}
}