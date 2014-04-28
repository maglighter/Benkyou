using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSystem
{
    public partial class TeacherLogin : Form
    {
        public TeacherLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0)
                if (is_validated(textBox1.Text))
                {
                    this.Visible = false;
                    ViewDB vdbform = new ViewDB();
                    vdbform.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неправильный ввод пароля. Доступ закрыт.", "Неверный пароль", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            else
                MessageBox.Show("Введите пароль. Пустой пароль.", "Неверный пароль", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool is_validated(string pass)
        {
            if (pass == "password")
                return true;
            return false;
        }
    }
}
