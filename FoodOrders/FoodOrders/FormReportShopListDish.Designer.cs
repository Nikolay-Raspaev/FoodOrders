namespace FoodOrdersView
{
    partial class FormReportShopListDish
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnShop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnShop,
            this.ColumnDish,
            this.ColumnCount});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(0, 47);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(616, 510);
            this.dataGridView.TabIndex = 2;
            // 
            // ColumnShop
            // 
            this.ColumnShop.HeaderText = "Магазин";
            this.ColumnShop.Name = "ColumnShop";
            this.ColumnShop.ReadOnly = true;
            this.ColumnShop.Width = 200;
            // 
            // ColumnDish
            // 
            this.ColumnDish.HeaderText = "Блюда";
            this.ColumnDish.Name = "ColumnDish";
            this.ColumnDish.ReadOnly = true;
            this.ColumnDish.Width = 200;
            // 
            // ColumnCount
            // 
            this.ColumnCount.HeaderText = "Количество";
            this.ColumnCount.Name = "ColumnCount";
            this.ColumnCount.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "Сохранить в Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonSaveToExcel_Click);
            // 
            // FormReportShopListDish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 557);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormReportShopListDish";
            this.Text = "Блюда по магазинам";
            this.Load += new System.EventHandler(this.FormReportShopListDish_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ColumnShop;
        private DataGridViewTextBoxColumn ColumnDish;
        private DataGridViewTextBoxColumn ColumnCount;
        private Button button1;
    }
}