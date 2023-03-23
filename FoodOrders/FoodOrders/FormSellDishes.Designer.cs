namespace FoodOrdersView
{
    partial class FormSellDishes
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
            buttonCancel = new Button();
            buttonSell = new Button();
            labelDish = new Label();
            labelCount = new Label();
            comboBoxDish = new ComboBox();
            textBoxCount = new TextBox();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(383, 167);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(112, 34);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // buttonSell
            // 
            buttonSell.Location = new Point(265, 167);
            buttonSell.Name = "buttonSell";
            buttonSell.Size = new Size(112, 34);
            buttonSell.TabIndex = 1;
            buttonSell.Text = "Продать";
            buttonSell.UseVisualStyleBackColor = true;
            buttonSell.Click += ButtonSell_Click;
            // 
            // labelDish
            // 
            labelDish.AutoSize = true;
            labelDish.Location = new Point(12, 37);
            labelDish.Name = "labelDish";
            labelDish.Size = new Size(118, 25);
            labelDish.TabIndex = 2;
            labelDish.Text = "Блюдо:";
            // 
            // labelCount
            // 
            labelCount.AutoSize = true;
            labelCount.Location = new Point(12, 81);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(111, 25);
            labelCount.TabIndex = 3;
            labelCount.Text = "Количество:";
            // 
            // comboBoxDish
            // 
            comboBoxDish.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDish.FormattingEnabled = true;
            comboBoxDish.Location = new Point(129, 37);
            comboBoxDish.Name = "comboBoxDish";
            comboBoxDish.Size = new Size(318, 33);
            comboBoxDish.TabIndex = 4;
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(129, 81);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(318, 31);
            textBoxCount.TabIndex = 5;
            // 
            // FormSellDishes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 213);
            Controls.Add(textBoxCount);
            Controls.Add(comboBoxDish);
            Controls.Add(labelCount);
            Controls.Add(labelDish);
            Controls.Add(buttonSell);
            Controls.Add(buttonCancel);
            Name = "FormSellDishes";
            Text = "Продажа блюд";
            Load += FormSellDishes_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCancel;
        private Button buttonSell;
        private Label labelDish;
        private Label labelCount;
        private ComboBox comboBoxDish;
        private TextBox textBoxCount;
    }
}