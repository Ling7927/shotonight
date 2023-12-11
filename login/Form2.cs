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

    public partial class Report : Form
    {

        //選擇餐點
        void inputtextBoxOrderData(String foodId, String foodName, int price)
        {
            idBox.Text = foodId;
            nameBox.Text = foodName;
            priceBox.Text = price.ToString();
        }

        //選擇數量
        void inputNumberBoxOrderData(int number, String price)
        {

            if(number == 00)
            {
                quantityBox.Text = quantityBox.Text.Substring(0, quantityBox.Text.Length - 1);
            }
            else
            {
                quantityBox.Text += number.ToString();
            }

            if (int.TryParse(price, out int priceValue) && int.TryParse(quantityBox.Text, out int numberValue))
            {
                //計算
                int totalPrice = numberValue * priceValue;
                totalPriceBox.Text = totalPrice.ToString();
            }
            else
            {
                if(number == 00 )
                {
                    if(quantityBox.Text == "")
                    {
                        totalPriceBox.Text = "";
                    }
                }
                else
                {
                        MessageBox.Show("請先選擇餐點再選擇數量");
                }
            }
        }

        //order Enter 
        void inputOrderData(String foodId, String foodName, String price, String quantity, String totalPrice, String remarks)
        {

            DataGridViewRowCollection rows = dataGridView1.Rows;
            rows.Add(new Object[] { foodId, foodName, price, quantity, totalPrice, remarks});

        }
        public Report()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------------
        //order

        //不醉不歸
        private void button37_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("001", "不醉不歸",280);
        }

        //三天三夜
        private void button36_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("002", "三天三夜", 380);
        }

        //我梅了
        private void button35_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("003", "我梅了", 350);
        }

        //梅焦慮
        private void button18_Click_1(object sender, EventArgs e)
        {
            inputtextBoxOrderData("004", "梅焦慮", 170);
        }

        //芒碌的一天
        private void button41_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("005", "芒碌的一天", 330);
        }

        //手下柳琴
        private void button40_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("006", "手下柳琴", 300);
        }

        //紅心芭樂多
        private void button39_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("007", "紅心芭樂多", 630);
        }

        private void button65_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void orderTable_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }


        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        //orderTable
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //---------------------------
        //計算機

        // 1
        private void button3_Click(object sender, EventArgs e)
        {
            inputNumberBoxOrderData(1, priceBox.Text);
        }

        // 2
        private void button4_Click(object sender, EventArgs e)
        {
            inputNumberBoxOrderData(2, priceBox.Text);
        }

        // 3
        private void button5_Click(object sender, EventArgs e)
        {
            inputNumberBoxOrderData(3, priceBox.Text);
        }

        //4
        private void Four_Click(object sender, EventArgs e)
        {
            inputNumberBoxOrderData(4, priceBox.Text);
        }

        //5
        private void Five_Click(object sender, EventArgs e)
        {
            inputNumberBoxOrderData(5, priceBox.Text);
        }

        //6
        private void Six_Click(object sender, EventArgs e)
        {
            inputNumberBoxOrderData(6, priceBox.Text);
        }

        //7
        private void button9_Click(object sender, EventArgs e)
        {
            inputNumberBoxOrderData(7, priceBox.Text);
        }

        //8
        private void button10_Click(object sender, EventArgs e)
        {
            inputNumberBoxOrderData(8, priceBox.Text);
        }

        // 9
        private void nine_Click(object sender, EventArgs e)
        {
            inputNumberBoxOrderData(9, priceBox.Text);
        }

        // 0
        private void Zero_Click(object sender, EventArgs e)
        {
            inputNumberBoxOrderData(0, priceBox.Text);
        }

        // 00
        private void doubleZero_Click(object sender, EventArgs e)
        {
            inputNumberBoxOrderData(00, priceBox.Text);
        }

        // sure
        private void button14_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idBox.Text) &&
                !string.IsNullOrEmpty(nameBox.Text) &&
                !string.IsNullOrEmpty(priceBox.Text) &&
                !string.IsNullOrEmpty(quantityBox.Text) &&
                !string.IsNullOrEmpty(totalPriceBox.Text))
            {
                inputOrderData(idBox.Text, nameBox.Text, priceBox.Text, quantityBox.Text, totalPriceBox.Text, remarkBox.Text);
                idBox.Text = nameBox.Text = priceBox.Text = quantityBox.Text = totalPriceBox.Text = remarkBox.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("請填寫所有餐點欄位");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Report_Load(object sender, EventArgs e)
        {

        }

    }
}
