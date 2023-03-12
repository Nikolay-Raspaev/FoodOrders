namespace FoodOrdersView
{
    partial class FormDeliveryDishes
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
            this.labelShop = new System.Windows.Forms.Label();
            this.labelDish = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.comboBoxShop = new System.Windows.Forms.ComboBox();
            this.comboBoxDish = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelShop
            // 
            this.labelShop.AutoSize = true;
            this.labelShop.Location = new System.Drawing.Point(12, 25);
            this.labelShop.Name = "labelShop";
            this.labelShop.Size = new System.Drawing.Size(54, 15);
            this.labelShop.TabIndex = 0;
            this.labelShop.Text = "Магазин";
            // 
            // labelDish
            // 
            this.labelDish.AutoSize = true;
            this.labelDish.Location = new System.Drawing.Point(12, 66);
            this.labelDish.Name = "labelDish";
            this.labelDish.Size = new System.Drawing.Size(76, 15);
            this.labelDish.TabIndex = 1;
            this.labelDish.Text = "Блюдо";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(12, 110);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(72, 15);
            this.labelCount.TabIndex = 2;
            this.labelCount.Text = "Количество";
            // 
            // comboBoxShop
            // 
            this.comboBoxShop.FormattingEnabled = true;
            this.comboBoxShop.Location = new System.Drawing.Point(99, 22);
            this.comboBoxShop.Name = "comboBoxShop";
            this.comboBoxShop.Size = new System.Drawing.Size(286, 23);
            this.comboBoxShop.TabIndex = 3;
            // 
            // comboBoxDish
            // 
            this.comboBoxDish.FormattingEnabled = true;
            this.comboBoxDish.Location = new System.Drawing.Point(99, 63);
            this.comboBoxDish.Name = "comboBoxDish";
            this.comboBoxDish.Size = new System.Drawing.Size(286, 23);
            this.comboBoxDish.TabIndex = 4;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(99, 107);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(286, 23);
            this.textBoxCount.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(223, 154);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(310, 154);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormDeliveryDishes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 206);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxDish);
            this.Controls.Add(this.comboBoxShop);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelDish);
            this.Controls.Add(this.labelShop);
            this.Name = "FormDeliveryDishes";
            this.Text = "Поступление блюд";
            this.Load += new System.EventHandler(this.FormDeliveryDishes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelShop;
        private Label labelDish;
        private Label labelCount;
        private ComboBox comboBoxShop;
        private ComboBox comboBoxDish;
        private TextBox textBoxCount;
        private Button buttonSave;
        private Button buttonCancel;
    }
}