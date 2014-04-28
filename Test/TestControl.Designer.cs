using System.Drawing;

namespace Test
{
    partial class TestControl
    {
        Color activeFontColor = Color.Black;
        Color activeBackColor = Color.LightGray;
        Color activeBorderColor = Color.Black;
        Color selectedFontColor = Color.Black;
        Color selectedBackColor = Color.LightBlue;
        Color fontColor = Color.Black;
        Color backColor = Color.White;
        Color doneColor = Color.LightGreen;
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle1 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle2 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle3 = new BrightIdeasSoftware.HeaderStateStyle();
            this.lbTests = new System.Windows.Forms.ListBox();
            this.tableWorkplace = new System.Windows.Forms.TableLayoutPanel();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.columnTaskNum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.headerFormatStyle1 = new BrightIdeasSoftware.HeaderFormatStyle();
            this.hotItemStyle1 = new BrightIdeasSoftware.HotItemStyle();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.rlbAnswers = new System.Windows.Forms.RadioListBox();
            this.tableTests = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.tableWorkplace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableTests.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTests
            // 
            this.lbTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTests.FormattingEnabled = true;
            this.lbTests.Location = new System.Drawing.Point(3, 23);
            this.lbTests.Name = "lbTests";
            this.lbTests.Size = new System.Drawing.Size(604, 161);
            this.lbTests.TabIndex = 0;
            this.lbTests.SelectedIndexChanged += new System.EventHandler(this.lbTests_SelectedIndexChanged);
            // 
            // tableWorkplace
            // 
            this.tableWorkplace.ColumnCount = 3;
            this.tableWorkplace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableWorkplace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableWorkplace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableWorkplace.Controls.Add(this.objectListView1, 0, 1);
            this.tableWorkplace.Controls.Add(this.webBrowser1, 1, 1);
            this.tableWorkplace.Controls.Add(this.label1, 0, 0);
            this.tableWorkplace.Controls.Add(this.label2, 1, 0);
            this.tableWorkplace.Controls.Add(this.label3, 2, 0);
            this.tableWorkplace.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableWorkplace.Controls.Add(this.rlbAnswers, 2, 1);
            this.tableWorkplace.Location = new System.Drawing.Point(0, 200);
            this.tableWorkplace.Margin = new System.Windows.Forms.Padding(0);
            this.tableWorkplace.Name = "tableWorkplace";
            this.tableWorkplace.RowCount = 3;
            this.tableWorkplace.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableWorkplace.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableWorkplace.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableWorkplace.Size = new System.Drawing.Size(610, 314);
            this.tableWorkplace.TabIndex = 1;
            this.tableWorkplace.Visible = false;
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.columnTaskNum);
            this.objectListView1.AlternateRowBackColor = System.Drawing.Color.White;
            this.objectListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnTaskNum});
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.HeaderFormatStyle = this.headerFormatStyle1;
            this.objectListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.objectListView1.HeaderUsesThemes = false;
            this.objectListView1.HighlightBackgroundColor = System.Drawing.Color.White;
            this.objectListView1.HotItemStyle = this.hotItemStyle1;
            this.objectListView1.Location = new System.Drawing.Point(3, 23);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.OwnerDraw = true;
            this.objectListView1.RowHeight = 16;
            this.objectListView1.SelectColumnsOnRightClick = false;
            this.objectListView1.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.objectListView1.ShowGroups = false;
            this.objectListView1.ShowImagesOnSubItems = true;
            this.objectListView1.Size = new System.Drawing.Size(53, 248);
            this.objectListView1.TabIndex = 0;
            this.objectListView1.UseCellFormatEvents = true;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.UseCustomSelectionColors = true;
            this.objectListView1.UseHotItem = true;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.SelectedIndexChanged += objectListView1_SelectedIndexChanged;
            this.objectListView1.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.objectListView1_FormatCell);
            // 
            // columnTaskNum
            // 
            this.columnTaskNum.AspectName = "TaskNumber";
            this.columnTaskNum.AspectToStringFormat = "{0:00}";
            this.columnTaskNum.CellPadding = null;
            this.columnTaskNum.FillsFreeSpace = true;
            this.columnTaskNum.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnTaskNum.Text = "";
            this.columnTaskNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnTaskNum.ImageGetter = this.GetImageKey;
            // 
            // headerFormatStyle1
            // 
            headerStateStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            headerStateStyle1.ForeColor = System.Drawing.Color.White;
            this.headerFormatStyle1.Hot = headerStateStyle1;
            headerStateStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            headerStateStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.headerFormatStyle1.Normal = headerStateStyle2;
            headerStateStyle3.BackColor = System.Drawing.Color.Gray;
            headerStateStyle3.ForeColor = System.Drawing.Color.White;
            this.headerFormatStyle1.Pressed = headerStateStyle3;
            // 
            // hotItemStyle1
            // 
            this.hotItemStyle1.ForeColor = System.Drawing.Color.White;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(62, 23);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(467, 248);
            this.webBrowser1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Вопросы";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(62, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(467, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Текущее задание";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(535, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ответ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableWorkplace.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(59, 274);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(551, 40);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(454, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ответить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(354, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Завершить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rlbAnswers
            // 
            this.rlbAnswers.BackColor = System.Drawing.SystemColors.Window;
            this.rlbAnswers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rlbAnswers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.rlbAnswers.Font = this.Font;
            this.rlbAnswers.FormattingEnabled = true;
            this.rlbAnswers.Location = new System.Drawing.Point(535, 23);
            this.rlbAnswers.Name = "rlbAnswers";
            this.rlbAnswers.Size = new System.Drawing.Size(72, 248);
            this.rlbAnswers.TabIndex = 7;
            // 
            // tableTests
            // 
            this.tableTests.ColumnCount = 1;
            this.tableTests.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableTests.Controls.Add(this.lbTests, 0, 1);
            this.tableTests.Controls.Add(this.label4, 0, 0);
            this.tableTests.Location = new System.Drawing.Point(0, 0);
            this.tableTests.Margin = new System.Windows.Forms.Padding(0);
            this.tableTests.Name = "tableTests";
            this.tableTests.RowCount = 2;
            this.tableTests.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableTests.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableTests.Size = new System.Drawing.Size(610, 187);
            this.tableTests.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(604, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Выберите тест";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableTests);
            this.Controls.Add(this.tableWorkplace);
            this.Name = "TestControl";
            this.Size = new System.Drawing.Size(718, 514);
            this.FontChanged += new System.EventHandler(this.TestControl_FontChanged);
            this.tableWorkplace.ResumeLayout(false);
            this.tableWorkplace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableTests.ResumeLayout(false);
            this.tableTests.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbTests;
        private System.Windows.Forms.TableLayoutPanel tableWorkplace;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel tableTests;
        private System.Windows.Forms.Label label4;
        private BrightIdeasSoftware.OLVColumn columnTaskNum;
        private System.Windows.Forms.RadioListBox rlbAnswers;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.HotItemStyle hotItemStyle1;
        private BrightIdeasSoftware.HeaderFormatStyle headerFormatStyle1;
    }
}
