namespace FoodOrdersView
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer Components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (Components != null))
            {
                Components.Dispose();
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
            menuStrip = new MenuStrip();
            справочникиToolStripMenuItem = new ToolStripMenuItem();
            БлюдаToolStripMenuItem = new ToolStripMenuItem();
            наборблюдToolStripMenuItem = new ToolStripMenuItem();
            ClientToolStripMenuItem = new ToolStripMenuItem();
            исполнителиToolStripMenuItem = new ToolStripMenuItem();
            отчётыToolStripMenuItem = new ToolStripMenuItem();
            componentsToolStripMenuItem = new ToolStripMenuItem();
            componentDishesToolStripMenuItem = new ToolStripMenuItem();
            ordersToolStripMenuItem = new ToolStripMenuItem();
            DoWorkToolStripMenuItem = new ToolStripMenuItem();
            письмаToolStripMenuItem = new ToolStripMenuItem();
            createBackupToolStripMenuItem = new ToolStripMenuItem();
            buttonUpdate = new Button();
            buttonSetToFinish = new Button();
            buttonCreateOrder = new Button();
            dataGridView = new DataGridView();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { справочникиToolStripMenuItem, отчётыToolStripMenuItem, DoWorkToolStripMenuItem, письмаToolStripMenuItem, createBackupToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1070, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            справочникиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { БлюдаToolStripMenuItem, наборблюдToolStripMenuItem, ClientToolStripMenuItem, исполнителиToolStripMenuItem });
            справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            справочникиToolStripMenuItem.Size = new Size(94, 20);
            справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // БлюдаToolStripMenuItem
            // 
            БлюдаToolStripMenuItem.Name = "БлюдаToolStripMenuItem";
            БлюдаToolStripMenuItem.Size = new Size(149, 22);
            БлюдаToolStripMenuItem.Text = "Блюда";
            БлюдаToolStripMenuItem.Click += ComponentsToolStripMenuItem_Click;
            // 
            // наборблюдToolStripMenuItem
            // 
            наборблюдToolStripMenuItem.Name = "наборблюдToolStripMenuItem";
            наборблюдToolStripMenuItem.Size = new Size(149, 22);
            наборблюдToolStripMenuItem.Text = "Набор блюд";
            наборблюдToolStripMenuItem.Click += DishToolStripMenuItem_Click;
            // 
            // ClientToolStripMenuItem
            // 
            ClientToolStripMenuItem.Name = "ClientToolStripMenuItem";
            ClientToolStripMenuItem.Size = new Size(149, 22);
            ClientToolStripMenuItem.Text = "Клиент";
            ClientToolStripMenuItem.Click += ClientToolStripMenuItem_Click;
            // 
            // исполнителиToolStripMenuItem
            // 
            исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            исполнителиToolStripMenuItem.Size = new Size(149, 22);
            исполнителиToolStripMenuItem.Text = "Исполнители";
            исполнителиToolStripMenuItem.Click += ImplementersToolStripMenuItem_Click;
            // 
            // отчётыToolStripMenuItem
            // 
            отчётыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { componentsToolStripMenuItem, componentDishesToolStripMenuItem, ordersToolStripMenuItem });
            отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            отчётыToolStripMenuItem.Size = new Size(60, 20);
            отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // componentsToolStripMenuItem
            // 
            componentsToolStripMenuItem.Name = "componentsToolStripMenuItem";
            componentsToolStripMenuItem.Size = new Size(210, 22);
            componentsToolStripMenuItem.Text = "Список Компонентов";
            componentsToolStripMenuItem.Click += ToolStripMenuItem_Click;
            // 
            // componentDishesToolStripMenuItem
            // 
            componentDishesToolStripMenuItem.Name = "componentDishesToolStripMenuItem";
            componentDishesToolStripMenuItem.Size = new Size(210, 22);
            componentDishesToolStripMenuItem.Text = "Компоненты по блюдам";
            componentDishesToolStripMenuItem.Click += ComponentDishesToolStripMenuItem_Click;
            // 
            // ordersToolStripMenuItem
            // 
            ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            ordersToolStripMenuItem.Size = new Size(210, 22);
            ordersToolStripMenuItem.Text = "Список заказов";
            ordersToolStripMenuItem.Click += OrdersToolStripMenuItem_Click;
            // 
            // DoWorkToolStripMenuItem
            // 
            DoWorkToolStripMenuItem.Name = "DoWorkToolStripMenuItem";
            DoWorkToolStripMenuItem.Size = new Size(92, 20);
            DoWorkToolStripMenuItem.Text = "Запуск работ";
            DoWorkToolStripMenuItem.Click += DoWorkToolStripMenuItem_Click;
            // 
            // письмаToolStripMenuItem
            // 
            письмаToolStripMenuItem.Name = "письмаToolStripMenuItem";
            письмаToolStripMenuItem.Size = new Size(62, 20);
            письмаToolStripMenuItem.Text = "Письма";
            письмаToolStripMenuItem.Click += MailsToolStripMenuItem_Click;
            // 
            // createBackupToolStripMenuItem
            // 
            createBackupToolStripMenuItem.Name = "createBackupToolStripMenuItem";
            createBackupToolStripMenuItem.Size = new Size(97, 20);
            createBackupToolStripMenuItem.Text = "Создать бекап";
            createBackupToolStripMenuItem.Click += createBackupToolStripMenuItem_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(871, 205);
            buttonUpdate.Margin = new Padding(3, 2, 3, 2);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(170, 58);
            buttonUpdate.TabIndex = 12;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += ButtonRef_Click;
            // 
            // buttonSetToFinish
            // 
            buttonSetToFinish.Location = new Point(871, 124);
            buttonSetToFinish.Margin = new Padding(3, 2, 3, 2);
            buttonSetToFinish.Name = "buttonSetToFinish";
            buttonSetToFinish.Size = new Size(170, 58);
            buttonSetToFinish.TabIndex = 11;
            buttonSetToFinish.Text = "Заказ выдан";
            buttonSetToFinish.UseVisualStyleBackColor = true;
            buttonSetToFinish.Click += ButtonIssuedOrder_Click;
            // 
            // buttonCreateOrder
            // 
            buttonCreateOrder.Location = new Point(871, 41);
            buttonCreateOrder.Margin = new Padding(3, 2, 3, 2);
            buttonCreateOrder.Name = "buttonCreateOrder";
            buttonCreateOrder.Size = new Size(170, 58);
            buttonCreateOrder.TabIndex = 8;
            buttonCreateOrder.Text = "Создать заказ";
            buttonCreateOrder.UseVisualStyleBackColor = true;
            buttonCreateOrder.Click += ButtonCreateOrder_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Left;
            dataGridView.Location = new Point(0, 24);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(841, 426);
            dataGridView.TabIndex = 7;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1070, 450);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonSetToFinish);
            Controls.Add(buttonCreateOrder);
            Controls.Add(dataGridView);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "FormMain";
            Text = "Набор блюд";
            Load += FormMain_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem справочникиToolStripMenuItem;
        private ToolStripMenuItem БлюдаToolStripMenuItem;
        private ToolStripMenuItem наборблюдToolStripMenuItem;
        private Button buttonUpdate;
        private Button buttonSetToFinish;
        private Button buttonCreateOrder;
        private DataGridView dataGridView;
        private ToolStripMenuItem отчётыToolStripMenuItem;
        private ToolStripMenuItem componentsToolStripMenuItem;
        private ToolStripMenuItem componentDishesToolStripMenuItem;
        private ToolStripMenuItem ordersToolStripMenuItem;
        private ToolStripMenuItem ClientToolStripMenuItem;
        private ToolStripMenuItem исполнителиToolStripMenuItem;
        private ToolStripMenuItem DoWorkToolStripMenuItem;
        private ToolStripMenuItem письмаToolStripMenuItem;
        private ToolStripMenuItem createBackupToolStripMenuItem;
    }
}