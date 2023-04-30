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
            clientToolStripMenuItem = new ToolStripMenuItem();
            исполнителиToolStripMenuItem = new ToolStripMenuItem();
            shopsToolStripMenuItem = new ToolStripMenuItem();
            reportToolStripMenuItem = new ToolStripMenuItem();
            listDishesToolStripMenuItem = new ToolStripMenuItem();
            componentDishToolStripMenuItem = new ToolStripMenuItem();
            listOrdersToolStripMenuItem = new ToolStripMenuItem();
            listShopsToolStripMenuItem = new ToolStripMenuItem();
            shopDishToolStripMenuItem = new ToolStripMenuItem();
            listOrderToDateToolStripMenuItem = new ToolStripMenuItem();
            DoWorkToolStripMenuItem = new ToolStripMenuItem();
            письмаToolStripMenuItem = new ToolStripMenuItem();
            createBackupToolStripMenuItem = new ToolStripMenuItem();
            dishesToolStripMenuItem = new ToolStripMenuItem();
            buttonUpdate = new Button();
            buttonCreateOrder = new Button();
            dataGridView = new DataGridView();
            buttonAddDishInShop = new Button();
            buttonSetToFinish = new Button();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { справочникиToolStripMenuItem, reportToolStripMenuItem, DoWorkToolStripMenuItem, письмаToolStripMenuItem, createBackupToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1123, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            справочникиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { БлюдаToolStripMenuItem, наборблюдToolStripMenuItem, clientToolStripMenuItem, исполнителиToolStripMenuItem, shopsToolStripMenuItem });
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
            // clientToolStripMenuItem
            // 
            clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            clientToolStripMenuItem.Size = new Size(149, 22);
            clientToolStripMenuItem.Text = "Клиенты";
            clientToolStripMenuItem.Click += ClientToolStripMenuItem_Click;
            // 
            // исполнителиToolStripMenuItem
            // 
            исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            исполнителиToolStripMenuItem.Size = new Size(149, 22);
            исполнителиToolStripMenuItem.Text = "Исполнители";
            исполнителиToolStripMenuItem.Click += ImplementersToolStripMenuItem_Click;
            // 
            // shopsToolStripMenuItem
            // 
            shopsToolStripMenuItem.Name = "shopsToolStripMenuItem";
            shopsToolStripMenuItem.Size = new Size(149, 22);
            shopsToolStripMenuItem.Text = "Магазины";
            shopsToolStripMenuItem.Click += ShopsToolStripMenuItem_Click;
            // 
            // reportToolStripMenuItem
            // 
            reportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listDishesToolStripMenuItem, componentDishToolStripMenuItem, listOrdersToolStripMenuItem, listShopsToolStripMenuItem, shopDishToolStripMenuItem, listOrderToDateToolStripMenuItem });
            reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            reportToolStripMenuItem.Size = new Size(60, 20);
            reportToolStripMenuItem.Text = "Отчеты";
            // 
            // listDishesToolStripMenuItem
            // 
            listDishesToolStripMenuItem.Name = "listDishesToolStripMenuItem";
            listDishesToolStripMenuItem.Size = new Size(310, 22);
            listDishesToolStripMenuItem.Text = "Список блюд";
            listDishesToolStripMenuItem.Click += ToolStripMenuItem_Click;
            // 
            // componentDishToolStripMenuItem
            // 
            componentDishToolStripMenuItem.Name = "componentDishToolStripMenuItem";
            componentDishToolStripMenuItem.Size = new Size(310, 22);
            componentDishToolStripMenuItem.Text = "Блюда с компонентами";
            componentDishToolStripMenuItem.Click += ComponentDishesToolStripMenuItem_Click;
            // 
            // listOrdersToolStripMenuItem
            // 
            listOrdersToolStripMenuItem.Name = "listOrdersToolStripMenuItem";
            listOrdersToolStripMenuItem.Size = new Size(310, 22);
            listOrdersToolStripMenuItem.Text = "Список заказов";
            listOrdersToolStripMenuItem.Click += OrdersToolStripMenuItem_Click;
            // 
            // listShopsToolStripMenuItem
            // 
            listShopsToolStripMenuItem.Name = "listShopsToolStripMenuItem";
            listShopsToolStripMenuItem.Size = new Size(310, 22);
            listShopsToolStripMenuItem.Text = "Список магазинов";
            listShopsToolStripMenuItem.Click += ShopsReportToolStripMenuItem_Click;
            // 
            // shopDishToolStripMenuItem
            // 
            shopDishToolStripMenuItem.Name = "shopDishToolStripMenuItem";
            shopDishToolStripMenuItem.Size = new Size(310, 22);
            shopDishToolStripMenuItem.Text = "Магазин с блюдо";
            shopDishToolStripMenuItem.Click += ShopDishToolStripMenuItem_Click;
            // 
            // listOrderToDateToolStripMenuItem
            // 
            listOrderToDateToolStripMenuItem.Name = "listOrderToDateToolStripMenuItem";
            listOrderToDateToolStripMenuItem.Size = new Size(310, 22);
            listOrderToDateToolStripMenuItem.Text = "Список заказов, сгрупированных по датам";
            listOrderToDateToolStripMenuItem.Click += OrdersGroupedByDateToolStripMenuItem_Click;
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
            // dishesToolStripMenuItem
            // 
            dishesToolStripMenuItem.Name = "dishesToolStripMenuItem";
            dishesToolStripMenuItem.Size = new Size(310, 22);
            dishesToolStripMenuItem.Text = "Список Блюд";
            dishesToolStripMenuItem.Click += ToolStripMenuItem_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(924, 206);
            buttonUpdate.Margin = new Padding(3, 2, 3, 2);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(170, 58);
            buttonUpdate.TabIndex = 12;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += ButtonRef_Click;
            // 
            // buttonCreateOrder
            // 
            buttonCreateOrder.Location = new Point(924, 26);
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
            dataGridView.Size = new Size(899, 426);
            dataGridView.TabIndex = 7;
            // 
            // buttonAddDishInShop
            // 
            buttonAddDishInShop.Location = new Point(924, 292);
            buttonAddDishInShop.Name = "buttonAddDishInShop";
            buttonAddDishInShop.Size = new Size(170, 61);
            buttonAddDishInShop.TabIndex = 13;
            buttonAddDishInShop.Text = "Пополнение магазина";
            buttonAddDishInShop.UseVisualStyleBackColor = true;
            buttonAddDishInShop.Click += ButtonDeliveryDish_Click;
            // 
            // buttonSetToFinish
            // 
            buttonSetToFinish.Location = new Point(924, 116);
            buttonSetToFinish.Margin = new Padding(3, 2, 3, 2);
            buttonSetToFinish.Name = "buttonSetToFinish";
            buttonSetToFinish.Size = new Size(170, 58);
            buttonSetToFinish.TabIndex = 14;
            buttonSetToFinish.Text = "Заказ выдан";
            buttonSetToFinish.UseVisualStyleBackColor = true;
            buttonSetToFinish.Click += ButtonIssuedOrder_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1123, 450);
            Controls.Add(buttonSetToFinish);
            Controls.Add(buttonAddDishInShop);
            Controls.Add(buttonUpdate);
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
        private Button buttonUpdate;
        private Button buttonCreateOrder;
        private DataGridView dataGridView;
        private ToolStripMenuItem справочникиToolStripMenuItem;
        private ToolStripMenuItem БлюдаToolStripMenuItem;
        private ToolStripMenuItem наборблюдToolStripMenuItem;
        private ToolStripMenuItem dishesToolStripMenuItem;
        private ToolStripMenuItem guidesToolStripMenuItem;
        private ToolStripMenuItem clientToolStripMenuItem;
        private ToolStripMenuItem shopsToolStripMenuItem;
        private ToolStripMenuItem reportToolStripMenuItem;
        private ToolStripMenuItem listDishesToolStripMenuItem;
        private ToolStripMenuItem componentDishToolStripMenuItem;
        private ToolStripMenuItem listOrdersToolStripMenuItem;
        private ToolStripMenuItem listShopsToolStripMenuItem;
        private ToolStripMenuItem shopDishToolStripMenuItem;
        private ToolStripMenuItem listOrderToDateToolStripMenuItem;
        private Button buttonAddDishInShop;
        private ToolStripMenuItem ClientToolStripMenuItem;
        private ToolStripMenuItem исполнителиToolStripMenuItem;
        private ToolStripMenuItem DoWorkToolStripMenuItem;
        private Button buttonSetToFinish;
        private ToolStripMenuItem письмаToolStripMenuItem;
        private ToolStripMenuItem createBackupToolStripMenuItem;
    }
}