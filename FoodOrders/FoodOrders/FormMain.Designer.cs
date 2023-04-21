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
            reportToolStripMenuItem = new ToolStripMenuItem();
            listDishesToolStripMenuItem = new ToolStripMenuItem();
            componentDishToolStripMenuItem = new ToolStripMenuItem();
            listOrdersToolStripMenuItem = new ToolStripMenuItem();
            listShopsToolStripMenuItem = new ToolStripMenuItem();
            shopDishToolStripMenuItem = new ToolStripMenuItem();
            listOrderToDateToolStripMenuItem = new ToolStripMenuItem();
            dishesToolStripMenuItem = new ToolStripMenuItem();
            componentDishesToolStripMenuItem = new ToolStripMenuItem();
            ordersToolStripMenuItem = new ToolStripMenuItem();
            buttonUpdate = new Button();
            buttonSetToFinish = new Button();
            buttonSetToDone = new Button();
            buttonSetToWork = new Button();
            buttonCreateOrder = new Button();
            dataGridView = new DataGridView();
            buttonAddDishInShop = new Button();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.БлюдаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.наборблюдToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentDishesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSetToFinish = new System.Windows.Forms.Button();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.DoWorkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исполнителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { guidesToolStripMenuItem, reportToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(975, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчётыToolStripMenuItem,
            this.DoWorkToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(975, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // guidesToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.БлюдаToolStripMenuItem,
            this.наборблюдToolStripMenuItem,
            this.ClientToolStripMenuItem,
            this.исполнителиToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            guidesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { componentToolStripMenuItem, dishToolStripMenuItem, clientToolStripMenuItem, shopsToolStripMenuItem });
            guidesToolStripMenuItem.Name = "guidesToolStripMenuItem";
            guidesToolStripMenuItem.Size = new Size(94, 20);
            guidesToolStripMenuItem.Text = "Справочники";
            // 
            // componentToolStripMenuItem
            // 
            componentToolStripMenuItem.Name = "componentToolStripMenuItem";
            componentToolStripMenuItem.Size = new Size(180, 22);
            componentToolStripMenuItem.Text = "Компоненты";
            componentToolStripMenuItem.Click += ComponentsToolStripMenuItem_Click;
            // 
            // dishToolStripMenuItem
            // 
            dishToolStripMenuItem.Name = "dishToolStripMenuItem";
            dishToolStripMenuItem.Size = new Size(180, 22);
            dishToolStripMenuItem.Text = "Блюда";
            dishToolStripMenuItem.Click += DishToolStripMenuItem_Click;
            // 
            // clientToolStripMenuItem
            // ClientToolStripMenuItem
            // 
            this.ClientToolStripMenuItem.Name = "ClientToolStripMenuItem";
            this.ClientToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ClientToolStripMenuItem.Text = "Клиент";
            this.ClientToolStripMenuItem.Click += new System.EventHandler(this.ClientToolStripMenuItem_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            clientToolStripMenuItem.Size = new Size(180, 22);
            clientToolStripMenuItem.Text = "Клиенты";
            clientToolStripMenuItem.Click += ClientToolStripMenuItem_Click;
            // 
            // shopsToolStripMenuItem
            // 
            this.componentsToolStripMenuItem.Name = "componentsToolStripMenuItem";
            this.componentsToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.componentsToolStripMenuItem.Text = "Список Компонентов";
            this.componentsToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            shopsToolStripMenuItem.Name = "shopsToolStripMenuItem";
            shopsToolStripMenuItem.Size = new Size(180, 22);
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
            // dishesToolStripMenuItem
            // 
            dishesToolStripMenuItem.Name = "dishesToolStripMenuItem";
            dishesToolStripMenuItem.Size = new Size(310, 22);
            dishesToolStripMenuItem.Text = "Список Блюд";
            dishesToolStripMenuItem.Click += ToolStripMenuItem_Click;
            // 
            // componentDishesToolStripMenuItem
            // 
            componentDishesToolStripMenuItem.Name = "componentDishesToolStripMenuItem";
            componentDishesToolStripMenuItem.Size = new Size(218, 22);
            componentDishesToolStripMenuItem.Text = "Компоненты по изделиям";
            componentDishesToolStripMenuItem.Click += ComponentDishesToolStripMenuItem_Click;
            this.componentDishesToolStripMenuItem.Name = "componentDishesToolStripMenuItem";
            this.componentDishesToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.componentDishesToolStripMenuItem.Text = "Компоненты по блюдам";
            this.componentDishesToolStripMenuItem.Click += new System.EventHandler(this.ComponentDishesToolStripMenuItem_Click);
            // 
            // ordersToolStripMenuItem
            // 
            this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            this.ordersToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.ordersToolStripMenuItem.Text = "Список заказов";
            this.ordersToolStripMenuItem.Click += new System.EventHandler(this.OrdersToolStripMenuItem_Click);
            ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            ordersToolStripMenuItem.Size = new Size(310, 22);
            ordersToolStripMenuItem.Text = "Список заказов";
            ordersToolStripMenuItem.Click += OrdersToolStripMenuItem_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(780, 314);
            buttonUpdate.Margin = new Padding(3, 2, 3, 2);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(170, 58);
            buttonUpdate.TabIndex = 12;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += ButtonRef_Click;
            this.buttonUpdate.Location = new System.Drawing.Point(780, 230);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(170, 58);
            this.buttonUpdate.TabIndex = 12;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // buttonSetToFinish
            // 
            this.buttonSetToFinish.Location = new System.Drawing.Point(780, 149);
            this.buttonSetToFinish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSetToFinish.Name = "buttonSetToFinish";
            this.buttonSetToFinish.Size = new System.Drawing.Size(170, 58);
            this.buttonSetToFinish.TabIndex = 11;
            this.buttonSetToFinish.Text = "Заказ выдан";
            this.buttonSetToFinish.UseVisualStyleBackColor = true;
            this.buttonSetToFinish.Click += new System.EventHandler(this.ButtonIssuedOrder_Click);
            buttonSetToFinish.Location = new Point(780, 252);
            buttonSetToFinish.Margin = new Padding(3, 2, 3, 2);
            buttonSetToFinish.Name = "buttonSetToFinish";
            buttonSetToFinish.Size = new Size(170, 58);
            buttonSetToFinish.TabIndex = 11;
            buttonSetToFinish.Text = "Заказ выдан";
            buttonSetToFinish.UseVisualStyleBackColor = true;
            buttonSetToFinish.Click += ButtonIssuedOrder_Click;
            // 
            // buttonSetToDone
            // 
            buttonSetToDone.Location = new Point(780, 190);
            buttonSetToDone.Margin = new Padding(3, 2, 3, 2);
            buttonSetToDone.Name = "buttonSetToDone";
            buttonSetToDone.Size = new Size(170, 58);
            buttonSetToDone.TabIndex = 10;
            buttonSetToDone.Text = "Заказ готов";
            buttonSetToDone.UseVisualStyleBackColor = true;
            buttonSetToDone.Click += ButtonOrderReady_Click;
            // 
            // buttonSetToWork
            // 
            buttonSetToWork.Location = new Point(780, 128);
            buttonSetToWork.Margin = new Padding(3, 2, 3, 2);
            buttonSetToWork.Name = "buttonSetToWork";
            buttonSetToWork.Size = new Size(170, 58);
            buttonSetToWork.TabIndex = 9;
            buttonSetToWork.Text = "Отдать на выполнение";
            buttonSetToWork.UseVisualStyleBackColor = true;
            buttonSetToWork.Click += ButtonTakeOrderInWork_Click;
            // 
            // buttonCreateOrder
            // 
            buttonCreateOrder.Location = new Point(780, 66);
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
            dataGridView.Size = new Size(755, 426);
            dataGridView.TabIndex = 7;
            // 
            // buttonAddDishInShop
            // DoWorkToolStripMenuItem
            // 
            this.DoWorkToolStripMenuItem.Name = "DoWorkToolStripMenuItem";
            this.DoWorkToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.DoWorkToolStripMenuItem.Text = "Запуск работ";
            this.DoWorkToolStripMenuItem.Click += new System.EventHandler(this.DoWorkToolStripMenuItem_Click);
            // 
            buttonAddDishInShop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonAddDishInShop.Location = new Point(780, 377);
            buttonAddDishInShop.Name = "buttonAddDishInShop";
            buttonAddDishInShop.Size = new Size(170, 61);
            buttonAddDishInShop.TabIndex = 13;
            buttonAddDishInShop.Text = "Пополнение магазина";
            buttonAddDishInShop.UseVisualStyleBackColor = true;
            buttonAddDishInShop.Click += ButtonDeliveryDish_Click;
            // исполнителиToolStripMenuItem
            // 
            this.исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            this.исполнителиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.исполнителиToolStripMenuItem.Text = "Исполнители";
            this.исполнителиToolStripMenuItem.Click += new System.EventHandler(this.ImplementersToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 450);
            Controls.Add(buttonAddDishInShop);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonSetToFinish);
            Controls.Add(buttonSetToDone);
            Controls.Add(buttonSetToWork);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 450);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonSetToFinish);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Набор блюд";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip;
        private Button buttonUpdate;
        private Button buttonSetToFinish;
        private Button buttonCreateOrder;
        private DataGridView dataGridView;
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
    }
}