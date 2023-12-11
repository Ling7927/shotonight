using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void powdText_TextChanged(object sender, EventArgs e)
        {

        }

        private void passText_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("登入");
            String powd = "1";
            String password = "1";

            if(String.Equals(powd, powdText.Text))
            {
                if (String.Equals(password, passText.Text))
                {
                    this.Hide();
                    Report form2 = new Report();
                    form2.Show();

                }
                else
                {
                    MessageBox.Show("密碼錯誤");
                }
            }
            else
            {
                MessageBox.Show("帳號不存在");
            }

        }

        private void register_Click(object sender, EventArgs e)
        {

        }
    }
}
