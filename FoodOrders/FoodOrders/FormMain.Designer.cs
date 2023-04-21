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
            // 
            // guidesToolStripMenuItem
            // 
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
            // 
            clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            clientToolStripMenuItem.Size = new Size(180, 22);
            clientToolStripMenuItem.Text = "Клиенты";
            clientToolStripMenuItem.Click += ClientToolStripMenuItem_Click;
            // 
            // shopsToolStripMenuItem
            // 
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
            // 
            // ordersToolStripMenuItem
            // 
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
            // 
            // buttonSetToFinish
            // 
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
            // 
            buttonAddDishInShop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonAddDishInShop.Location = new Point(780, 377);
            buttonAddDishInShop.Name = "buttonAddDishInShop";
            buttonAddDishInShop.Size = new Size(170, 61);
            buttonAddDishInShop.TabIndex = 13;
            buttonAddDishInShop.Text = "Пополнение магазина";
            buttonAddDishInShop.UseVisualStyleBackColor = true;
            buttonAddDishInShop.Click += ButtonDeliveryDish_Click;
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
        }

        #endregion

        private MenuStrip menuStrip;
        private Button buttonUpdate;
        private Button buttonSetToFinish;
        private Button buttonSetToDone;
        private Button buttonSetToWork;
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
    }
}