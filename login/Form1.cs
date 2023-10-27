using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 打開程式後，跳出Form2，確認帳號密碼
            Form2 form2;
            form2 = new Form2();
            form2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2;
            form2 = new Form2();
            // 打開Form 2，不會鎖定Form 1
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2;
            form2 = new Form2();
            // 打開Form 2，會鎖定Form 1
            form2.ShowDialog();
        }
    }
}
