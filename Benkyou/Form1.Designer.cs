namespace Benkyou
{
    partial class Form1
    {
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcWorkSpace = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // tcWorkSpace
            // 
            this.tcWorkSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcWorkSpace.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tcWorkSpace.ItemSize = new System.Drawing.Size(100, 22);
            this.tcWorkSpace.Location = new System.Drawing.Point(0, 0);
            this.tcWorkSpace.Margin = new System.Windows.Forms.Padding(0);
            this.tcWorkSpace.Name = "tcWorkSpace";
            this.tcWorkSpace.SelectedIndex = 0;
            this.tcWorkSpace.Size = new System.Drawing.Size(984, 562);
            this.tcWorkSpace.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.tcWorkSpace);
            this.Name = "Form1";
            this.Text = "Benkyou";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcWorkSpace;

    }
}

