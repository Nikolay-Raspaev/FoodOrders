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
            guidesToolStripMenuItem = new ToolStripMenuItem();
            componentToolStripMenuItem = new ToolStripMenuItem();
            dishToolStripMenuItem = new ToolStripMenuItem();
            clientToolStripMenuItem = new ToolStripMenuItem();
            shopsToolStripMenuItem = new ToolStripMenuItem();
            исполнителиToolStripMenuItem1 = new ToolStripMenuItem();
            reportToolStripMenuItem = new ToolStripMenuItem();
            listDishesToolStripMenuItem = new ToolStripMenuItem();
            componentDishToolStripMenuItem = new ToolStripMenuItem();
            listOrdersToolStripMenuItem = new ToolStripMenuItem();
            listShopsToolStripMenuItem = new ToolStripMenuItem();
            shopDishToolStripMenuItem = new ToolStripMenuItem();
            listOrderToDateToolStripMenuItem = new ToolStripMenuItem();
            DoWorkToolStripMenuItem = new ToolStripMenuItem();
            справочникиToolStripMenuItem = new ToolStripMenuItem();
            БлюдаToolStripMenuItem = new ToolStripMenuItem();
            наборблюдToolStripMenuItem = new ToolStripMenuItem();
            исполнителиToolStripMenuItem = new ToolStripMenuItem();
            отчётыToolStripMenuItem = new ToolStripMenuItem();
            componentsToolStripMenuItem = new ToolStripMenuItem();
            componentDishesToolStripMenuItem = new ToolStripMenuItem();
            ordersToolStripMenuItem = new ToolStripMenuItem();
            DoWorkToolStripMenuItem = new ToolStripMenuItem();
            письмаToolStripMenuItem = new ToolStripMenuItem();
            dishesToolStripMenuItem = new ToolStripMenuItem();
            buttonUpdate = new Button();
            buttonCreateOrder = new Button();
            dataGridView = new DataGridView();
            createBackupToolStripMenuItem = new ToolStripMenuItem();
            buttonAddDishInShop = new Button();
            buttonSetToFinish = new Button();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { createBackupToolStripMenuItem guidesToolStripMenuItem, reportToolStripMenuItem, справочникиToolStripMenuItem, отчётыToolStripMenuItem, DoWorkToolStripMenuItem, письмаToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1157, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // guidesToolStripMenuItem
            // 
            guidesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { componentToolStripMenuItem, dishToolStripMenuItem, shopsToolStripMenuItem, исполнителиToolStripMenuItem1 });
            guidesToolStripMenuItem.Name = "guidesToolStripMenuItem";
            guidesToolStripMenuItem.Size = new Size(94, 20);
            guidesToolStripMenuItem.Text = "Справочники";
            // 
            // componentToolStripMenuItem
            // 
            componentToolStripMenuItem.Name = "componentToolStripMenuItem";
            componentToolStripMenuItem.Size = new Size(149, 22);
            componentToolStripMenuItem.Text = "Компоненты";
            componentToolStripMenuItem.Click += ComponentsToolStripMenuItem_Click;
            // 
            // dishToolStripMenuItem
            // 
            dishToolStripMenuItem.Name = "dishToolStripMenuItem";
            dishToolStripMenuItem.Size = new Size(149, 22);
            dishToolStripMenuItem.Text = "Блюда";
            dishToolStripMenuItem.Click += DishToolStripMenuItem_Click;
            // 
            // clientToolStripMenuItem
            // 
            clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            clientToolStripMenuItem.Size = new Size(149, 22);
            clientToolStripMenuItem.Text = "Клиенты";
            clientToolStripMenuItem.Click += ClientToolStripMenuItem_Click;
            // 
            // shopsToolStripMenuItem
            // 
            shopsToolStripMenuItem.Name = "shopsToolStripMenuItem";
            shopsToolStripMenuItem.Size = new Size(149, 22);
            shopsToolStripMenuItem.Text = "Магазины";
            shopsToolStripMenuItem.Click += ShopsToolStripMenuItem_Click;
            // 
            // исполнителиToolStripMenuItem1
            // 
            исполнителиToolStripMenuItem1.Name = "исполнителиToolStripMenuItem1";
            исполнителиToolStripMenuItem1.Size = new Size(149, 22);
            исполнителиToolStripMenuItem1.Text = "Исполнители";
            исполнителиToolStripMenuItem1.Click += ImplementersToolStripMenuItem_Click;
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
            // справочникиToolStripMenuItem
            // 
            справочникиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { БлюдаToolStripMenuItem, наборблюдToolStripMenuItem, clientToolStripMenuItem, исполнителиToolStripMenuItem });
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
            // письмаToolStripMenuItem
            // 
            письмаToolStripMenuItem.Name = "письмаToolStripMenuItem";
            письмаToolStripMenuItem.Size = new Size(62, 20);
            письмаToolStripMenuItem.Text = "Письма";
            письмаToolStripMenuItem.Click += MailsToolStripMenuItem_Click;
            // 
            // письмаToolStripMenuItem
            // 
            письмаToolStripMenuItem.Name = "письмаToolStripMenuItem";
            письмаToolStripMenuItem.Size = new Size(62, 20);
            письмаToolStripMenuItem.Text = "Письма";
            письмаToolStripMenuItem.Click += MailsToolStripMenuItem_Click;
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
            buttonUpdate.Location = new Point(962, 238);
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
            buttonCreateOrder.Location = new Point(962, 58);
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
            dataGridView.Size = new Size(956, 426);
            dataGridView.TabIndex = 7;
            // 
            // buttonAddDishInShop
            // 
            buttonAddDishInShop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonAddDishInShop.Location = new Point(962, 327);
            buttonAddDishInShop.Name = "buttonAddDishInShop";
            buttonAddDishInShop.Size = new Size(170, 61);
            buttonAddDishInShop.TabIndex = 13;
            buttonAddDishInShop.Text = "Пополнение магазина";
            buttonAddDishInShop.UseVisualStyleBackColor = true;
            buttonAddDishInShop.Click += ButtonDeliveryDish_Click;
            // 
            // buttonSetToFinish
            // 
            buttonSetToFinish.Location = new Point(962, 148);
            buttonSetToFinish.Margin = new Padding(3, 2, 3, 2);
            buttonSetToFinish.Name = "buttonSetToFinish";
            buttonSetToFinish.Size = new Size(170, 58);
            buttonSetToFinish.TabIndex = 14;
            buttonSetToFinish.Text = "Заказ выдан";
            buttonSetToFinish.UseVisualStyleBackColor = true;
            buttonSetToFinish.Click += ButtonIssuedOrder_Click;
            //
            // createBackupToolStripMenuItem
            //
            createBackupToolStripMenuItem.Name = "createBackupToolStripMenuItem";
            createBackupToolStripMenuItem.Size = new Size(97, 20);
            createBackupToolStripMenuItem.Text = "Создать бекап";
            createBackupToolStripMenuItem.Click += createBackupToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1157, 450);
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
        private ToolStripMenuItem отчётыToolStripMenuItem;
        private ToolStripMenuItem componentsToolStripMenuItem;
        private ToolStripMenuItem dishesToolStripMenuItem;
        private ToolStripMenuItem componentDishesToolStripMenuItem;
        private ToolStripMenuItem ordersToolStripMenuItem;
        private ToolStripMenuItem guidesToolStripMenuItem;
        private ToolStripMenuItem componentToolStripMenuItem;
        private ToolStripMenuItem dishToolStripMenuItem;
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
        private ToolStripMenuItem исполнителиToolStripMenuItem1;
        private Button buttonSetToFinish;
        private ToolStripMenuItem письмаToolStripMenuItem;
        private ToolStripMenuItem createBackupToolStripMenuItem;
    }
}