namespace FoodOrdersView
{
	partial class FormImplementer
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
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			textBoxFio = new TextBox();
			textBoxPassword = new TextBox();
			numericUpDownWorkExperience = new NumericUpDown();
			numericUpDownQualification = new NumericUpDown();
			buttonCancel = new Button();
			buttonSave = new Button();
			((System.ComponentModel.ISupportInitialize)numericUpDownWorkExperience).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownQualification).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(79, 12);
			label1.Name = "label1";
			label1.Size = new Size(37, 15);
			label1.TabIndex = 0;
			label1.Text = "ФИО:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(69, 41);
			label2.Name = "label2";
			label2.Size = new Size(52, 15);
			label2.TabIndex = 1;
			label2.Text = "Пароль:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(78, 68);
			label3.Name = "label3";
			label3.Size = new Size(38, 15);
			label3.TabIndex = 2;
			label3.Text = "Стаж:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(25, 97);
			label4.Name = "label4";
			label4.Size = new Size(91, 15);
			label4.TabIndex = 3;
			label4.Text = "Квалификация:";
			// 
			// textBoxFio
			// 
			textBoxFio.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			textBoxFio.Location = new Point(127, 9);
			textBoxFio.Name = "textBoxFio";
			textBoxFio.Size = new Size(271, 23);
			textBoxFio.TabIndex = 4;
			// 
			// textBoxPassword
			// 
			textBoxPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			textBoxPassword.Location = new Point(127, 38);
			textBoxPassword.Name = "textBoxPassword";
			textBoxPassword.PasswordChar = '*';
			textBoxPassword.Size = new Size(271, 23);
			textBoxPassword.TabIndex = 5;
			// 
			// numericUpDownWorkExperience
			// 
			numericUpDownWorkExperience.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			numericUpDownWorkExperience.Location = new Point(127, 66);
			numericUpDownWorkExperience.Name = "numericUpDownWorkExperience";
			numericUpDownWorkExperience.Size = new Size(271, 23);
			numericUpDownWorkExperience.TabIndex = 6;
			// 
			// numericUpDownQualification
			// 
			numericUpDownQualification.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			numericUpDownQualification.Location = new Point(127, 95);
			numericUpDownQualification.Name = "numericUpDownQualification";
			numericUpDownQualification.Size = new Size(271, 23);
			numericUpDownQualification.TabIndex = 7;
			// 
			// buttonCancel
			// 
			buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonCancel.Location = new Point(309, 138);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(89, 33);
			buttonCancel.TabIndex = 8;
			buttonCancel.Text = "Отмена";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += ButtonCancel_Click;
			// 
			// buttonSave
			// 
			buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonSave.Location = new Point(214, 138);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(89, 33);
			buttonSave.TabIndex = 9;
			buttonSave.Text = "Сохранить";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += ButtonSave_Click;
			// 
			// FormImplementer
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(410, 183);
			Controls.Add(buttonSave);
			Controls.Add(buttonCancel);
			Controls.Add(numericUpDownQualification);
			Controls.Add(numericUpDownWorkExperience);
			Controls.Add(textBoxPassword);
			Controls.Add(textBoxFio);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "FormImplementer";
			Text = "Добавление / Редактирование исполнителя";
			Load += FormImplementer_Load;
			((System.ComponentModel.ISupportInitialize)numericUpDownWorkExperience).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownQualification).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private TextBox textBoxFio;
		private TextBox textBoxPassword;
		private NumericUpDown numericUpDownWorkExperience;
		private NumericUpDown numericUpDownQualification;
		private Button buttonCancel;
		private Button buttonSave;
	}
}