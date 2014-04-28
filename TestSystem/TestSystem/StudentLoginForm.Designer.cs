namespace TestSystem
{
    partial class StudentLoginForm
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
            this.secondNameTB = new System.Windows.Forms.TextBox();
            this.firstNameTB = new System.Windows.Forms.TextBox();
            this.groupTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userLoginButton = new System.Windows.Forms.Button();
            this.prepodLoginLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // secondNameTB
            // 
            this.secondNameTB.Location = new System.Drawing.Point(12, 45);
            this.secondNameTB.Name = "secondNameTB";
            this.secondNameTB.Size = new System.Drawing.Size(139, 20);
            this.secondNameTB.TabIndex = 0;
            // 
            // firstNameTB
            // 
            this.firstNameTB.Location = new System.Drawing.Point(157, 45);
            this.firstNameTB.Name = "firstNameTB";
            this.firstNameTB.Size = new System.Drawing.Size(140, 20);
            this.firstNameTB.TabIndex = 1;
            // 
            // groupTB
            // 
            this.groupTB.Location = new System.Drawing.Point(314, 45);
            this.groupTB.Name = "groupTB";
            this.groupTB.Size = new System.Drawing.Size(72, 20);
            this.groupTB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(314, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Группа";
            // 
            // userLoginButton
            // 
            this.userLoginButton.Location = new System.Drawing.Point(15, 100);
            this.userLoginButton.Name = "userLoginButton";
            this.userLoginButton.Size = new System.Drawing.Size(136, 23);
            this.userLoginButton.TabIndex = 6;
            this.userLoginButton.Text = "Вход";
            this.userLoginButton.UseVisualStyleBackColor = true;
            this.userLoginButton.Click += new System.EventHandler(this.userLoginButton_Click);
            // 
            // prepodLoginLink
            // 
            this.prepodLoginLink.AutoSize = true;
            this.prepodLoginLink.Location = new System.Drawing.Point(251, 105);
            this.prepodLoginLink.Name = "prepodLoginLink";
            this.prepodLoginLink.Size = new System.Drawing.Size(135, 13);
            this.prepodLoginLink.TabIndex = 7;
            this.prepodLoginLink.TabStop = true;
            this.prepodLoginLink.Text = "Вход  для преподавателя";
            this.prepodLoginLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // StudentLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 144);
            this.Controls.Add(this.prepodLoginLink);
            this.Controls.Add(this.userLoginButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupTB);
            this.Controls.Add(this.firstNameTB);
            this.Controls.Add(this.secondNameTB);
            this.Name = "StudentLoginForm";
            this.Text = "Cистемя тестирования";
            this.Load += new System.EventHandler(this.StudentLoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox secondNameTB;
        private System.Windows.Forms.TextBox firstNameTB;
        private System.Windows.Forms.TextBox groupTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button userLoginButton;
        private System.Windows.Forms.LinkLabel prepodLoginLink;
    }
}

