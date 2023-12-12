using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static login.Report;

namespace login
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public void DisplayData(List<DataItem> data)
        {
            // 假設您的 DataGridView 控制項名稱為 dataGridView1
            orderDataTable.Rows.Clear();

            foreach (var item in data)
            {
                orderDataTable.Rows.Add(item.Id, item.Name, item.Price, item.Amount, item.TotalPrice, item.Remark, item.Oid);
            }
        }

        private void orderDataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
