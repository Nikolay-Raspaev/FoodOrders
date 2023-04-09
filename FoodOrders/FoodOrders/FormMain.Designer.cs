﻿namespace FoodOrdersView
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.БлюдаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.наборблюдToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.магазиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dishesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentDishesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокМагазиновToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.магазинСБлюдамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовСгрупированныхПоДатамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSetToFinish = new System.Windows.Forms.Button();
            this.buttonSetToDone = new System.Windows.Forms.Button();
            this.buttonSetToWork = new System.Windows.Forms.Button();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.ClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчётыToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(975, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.БлюдаToolStripMenuItem,
            this.наборблюдToolStripMenuItem,
            this.магазиныToolStripMenuItem});
            this.наборблюдToolStripMenuItem,
            this.ClientToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // БлюдаToolStripMenuItem
            // 
            this.БлюдаToolStripMenuItem.Name = "БлюдаToolStripMenuItem";
            this.БлюдаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.БлюдаToolStripMenuItem.Text = "Блюда";
            this.БлюдаToolStripMenuItem.Click += new System.EventHandler(this.ComponentsToolStripMenuItem_Click);
            // 
            // наборблюдToolStripMenuItem
            // 
            this.наборблюдToolStripMenuItem.Name = "наборблюдToolStripMenuItem";
            this.наборблюдToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.наборблюдToolStripMenuItem.Text = "Набор блюд";
            this.наборблюдToolStripMenuItem.Click += new System.EventHandler(this.DishToolStripMenuItem_Click);
            // 
            // магазиныToolStripMenuItem
            // 
            this.магазиныToolStripMenuItem.Name = "магазиныToolStripMenuItem";
            this.магазиныToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.магазиныToolStripMenuItem.Text = "Магазины";
            this.магазиныToolStripMenuItem.Click += new System.EventHandler(this.ShopsToolStripMenuItem_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dishesToolStripMenuItem,
            this.componentDishesToolStripMenuItem,
            this.ordersToolStripMenuItem,
            this.списокМагазиновToolStripMenuItem,
            this.магазинСБлюдамиToolStripMenuItem,
            this.списокЗаказовСгрупированныхПоДатамToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // dishesToolStripMenuItem
            // 
            this.dishesToolStripMenuItem.Name = "dishesToolStripMenuItem";
            this.dishesToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.dishesToolStripMenuItem.Text = "Список Блюд";
            this.dishesToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // componentDishesToolStripMenuItem
            // 
            this.componentDishesToolStripMenuItem.Name = "componentDishesToolStripMenuItem";
            this.componentDishesToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.componentDishesToolStripMenuItem.Text = "Компоненты по изделиям";
            this.componentDishesToolStripMenuItem.Click += new System.EventHandler(this.ComponentDishesToolStripMenuItem_Click);
            // 
            // ordersToolStripMenuItem
            // 
            this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            this.ordersToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.ordersToolStripMenuItem.Text = "Список заказов";
            this.ordersToolStripMenuItem.Click += new System.EventHandler(this.OrdersToolStripMenuItem_Click);
            // 
            // списокМагазиновToolStripMenuItem
            // 
            this.списокМагазиновToolStripMenuItem.Name = "списокМагазиновToolStripMenuItem";
            this.списокМагазиновToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.списокМагазиновToolStripMenuItem.Text = "Список магазинов";
            this.списокМагазиновToolStripMenuItem.Click += new System.EventHandler(this.ShopsReportToolStripMenuItem_Click);
            // 
            // магазинСБлюдамиToolStripMenuItem
            // 
            this.магазинСБлюдамиToolStripMenuItem.Name = "магазинСБлюдамиToolStripMenuItem";
            this.магазинСБлюдамиToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.магазинСБлюдамиToolStripMenuItem.Text = "Магазин с блюдами";
            this.магазинСБлюдамиToolStripMenuItem.Click += new System.EventHandler(this.ShopDishToolStripMenuItem_Click);
            // 
            // списокЗаказовСгрупированныхПоДатамToolStripMenuItem
            // 
            this.списокЗаказовСгрупированныхПоДатамToolStripMenuItem.Name = "списокЗаказовСгрупированныхПоДатамToolStripMenuItem";
            this.списокЗаказовСгрупированныхПоДатамToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.списокЗаказовСгрупированныхПоДатамToolStripMenuItem.Text = "Список заказов, сгрупированных по датам";
            this.списокЗаказовСгрупированныхПоДатамToolStripMenuItem.Click += new System.EventHandler(this.OrdersGroupedByDateToolStripMenuItem_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(780, 314);
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
            this.buttonSetToFinish.Location = new System.Drawing.Point(780, 252);
            this.buttonSetToFinish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSetToFinish.Name = "buttonSetToFinish";
            this.buttonSetToFinish.Size = new System.Drawing.Size(170, 58);
            this.buttonSetToFinish.TabIndex = 11;
            this.buttonSetToFinish.Text = "Заказ выдан";
            this.buttonSetToFinish.UseVisualStyleBackColor = true;
            this.buttonSetToFinish.Click += new System.EventHandler(this.ButtonIssuedOrder_Click);
            // 
            // buttonSetToDone
            // 
            this.buttonSetToDone.Location = new System.Drawing.Point(780, 190);
            this.buttonSetToDone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSetToDone.Name = "buttonSetToDone";
            this.buttonSetToDone.Size = new System.Drawing.Size(170, 58);
            this.buttonSetToDone.TabIndex = 10;
            this.buttonSetToDone.Text = "Заказ готов";
            this.buttonSetToDone.UseVisualStyleBackColor = true;
            this.buttonSetToDone.Click += new System.EventHandler(this.ButtonOrderReady_Click);
            // 
            // buttonSetToWork
            // 
            this.buttonSetToWork.Location = new System.Drawing.Point(780, 128);
            this.buttonSetToWork.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSetToWork.Name = "buttonSetToWork";
            this.buttonSetToWork.Size = new System.Drawing.Size(170, 58);
            this.buttonSetToWork.TabIndex = 9;
            this.buttonSetToWork.Text = "Отдать на выполнение";
            this.buttonSetToWork.UseVisualStyleBackColor = true;
            this.buttonSetToWork.Click += new System.EventHandler(this.ButtonTakeOrderInWork_Click);
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(780, 66);
            this.buttonCreateOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(170, 58);
            this.buttonCreateOrder.TabIndex = 8;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView.Location = new System.Drawing.Point(0, 24);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(755, 426);
            this.dataGridView.TabIndex = 7;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonSetToFinish);
            this.Controls.Add(this.buttonSetToDone);
            this.Controls.Add(this.buttonSetToWork);
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
        private ToolStripMenuItem справочникиToolStripMenuItem;
        private ToolStripMenuItem БлюдаToolStripMenuItem;
        private ToolStripMenuItem наборблюдToolStripMenuItem;
        private Button buttonUpdate;
        private Button buttonSetToFinish;
        private Button buttonSetToDone;
        private Button buttonSetToWork;
        private Button buttonCreateOrder;
        private DataGridView dataGridView;
        private ToolStripMenuItem отчётыToolStripMenuItem;
        private ToolStripMenuItem dishesToolStripMenuItem;
        private ToolStripMenuItem componentDishesToolStripMenuItem;
        private ToolStripMenuItem ordersToolStripMenuItem;
    }
}