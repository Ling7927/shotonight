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

        //確認點餐
        void inputOrderData(String foodId, String foodName, String price, String quantity, String totalPrice, String remarks)
        {

            DataGridViewRowCollection rows = dataGridView1.Rows;
            rows.Add(new Object[] { foodId, foodName, price, quantity, totalPrice, remarks});

        }

        //結帳
        void checkOut()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DateTime date = DateTime.Now; // 現在時間
                for (int i=0;i< dataGridView1.Rows.Count-1; i++)
                {

                    DataGridViewRow row = dataGridView1.Rows[i];
                    string foodId = row.Cells["id"].Value.ToString();
                    string foodName = row.Cells["productName"].Value.ToString();
                    int price = Convert.ToInt32(row.Cells["price"].Value);
                    int quantity = Convert.ToInt32(row.Cells["quantity"].Value);
                    int totalPrice = Convert.ToInt32(row.Cells["totalPrice"].Value);
                    string remarks = row.Cells["Remark"].Value.ToString();

                    //MessageBox.Show("點餐成功");
                    //MessageBox.Show("編號 : " + foodId + " 產品名稱 : " + foodName + " 單價 : " + price + " 數量 : " + quantity
                    //    + " 金額 : " + totalPrice + " 備註" + remarks);

                }
            }
            else
            {
                MessageBox.Show("您尚未點餐");
            }
        }

        public Report()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------------
        //order
        
        //酒類
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

        //口以麻
        private void button38_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("008", "口以麻", 120);
        }

        //黑色漂流瓶
        private void button45_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("009", "黑色漂流瓶", 530);
        }

        //白色的大海
        private void button44_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("010", "白色的大海", 170);
        }

        //黃色的大樹
        private void button43_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("011", "黃色的大樹", 320);
        }

        //綠色的天空
        private void button42_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("012", "綠色的天空", 450);
        }

        //粉紅泡泡
        private void button53_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("013", "粉紅泡泡", 1000);
        }

        //紅色炸彈
        private void button52_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("014", "紅色炸彈", 888);
        }

        //彩虹軟糖
        private void button51_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("015", "彩虹軟糖", 777);
        }

        //史藍姆
        private void button50_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("016", "史藍姆", 430);
        }

        //MIX夏威夷
        private void button55_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("017", "MIX夏威夷", 220);
        }

        //碧落大地
        private void button48_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("018", "碧落大地", 190);
        }

        //莫吉托
        private void button47_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("019", "莫吉托", 350);
        }

        //月光寶盒
        private void button46_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("020", "月光寶盒", 10000);
        }

        //主餐
        //白酒蛤蜊義大利麵
        private void button34_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("021", "白酒蛤蜊義大利麵", 550);
        }

        //奶油起司寬麵
        private void button33_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("022", "奶油起司寬麵", 650);
        }

        //經典肉醬義大利麵
        private void button32_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("023", "經典肉醬義大利麵", 650);
        }

        //羅勒雞肉青醬義大利麵
        private void button31_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("024", "羅勒雞肉青醬義大利麵", 750);
        }

        //白酒蛤蜊義大利麵
        private void button61_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("025", "白酒蛤蜊義大利麵", 1000);
        }

        //奶油起司寬麵
        private void button60_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("026", "奶油起司寬麵", 580);
        }

        //經典肉醬寬麵
        private void button59_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("027", "經典肉醬寬麵", 780);
        }

        //羅勒雞肉青醬寬麵
        private void button58_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("028", "羅勒雞肉青醬寬麵", 370);
        }

        //椒麻乾麵
        private void button77_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("029", "椒麻乾麵", 250);
        }

        //微粒炸醬麵
        private void button76_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("030", "微粒炸醬麵", 100);
        }

        //黑金滷肉飯
        private void button75_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("031", "黑金滷肉飯", 270);
        }

        //什錦炒麵
        private void button74_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("032", "什錦炒麵", 250);
        }

        //炒海瓜子直麵
        private void button73_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("033", "炒海瓜子直麵", 350);
        }

        //阿罵的炒飯
        private void button72_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("034", "阿罵的炒飯", 100);
        }

        //下酒菜
        //松露薯條
        private void button19_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("035", "松露薯條", 300);
        }

        //美式肉醬薯條
        private void button20_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("036", "美式肉醬薯條", 300);
        }

        //左宗棠炸雞
        private void button21_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("037", "左宗棠炸雞", 450);
        }

        //韓式炸雞
        private void button22_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("038", "韓式炸雞", 450);
        }

        //四拉差雞軟骨
        private void button69_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("039", "四拉差雞軟骨", 450);
        }

        //避風塘牛肉塊
        private void button68_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("040", "避風塘牛肉塊", 650);
        }

        //南方一級棒棒腿
        private void button67_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("041", "南方一級棒棒腿", 380);
        }

        //炸物拼盤
        private void button66_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("042", "炸物拼盤", 800);
        }

        //奈奈桂心豬
        private void button79_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("043", "奈奈桂心豬", 600);
        }

        //油醋大蔥鴨
        private void button78_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("044", "油醋大蔥鴨", 850);
        }

        //日本廣島生蠔
        private void button71_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("045", "日本廣島生蠔", 1500);
        }

        //涼拌檸檬蝦
        private void button70_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("046", "涼拌檸檬蝦", 1200);
        }

        //阿罵的滷味拼盤
        private void button65_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("047", "阿罵的滷味拼盤", 250);
        }

        //SHOT
        //伏特加
        private void button30_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("048", "伏特加", 120);
        }

        //香醇威士忌
        private void button29_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("049", "香醇威士忌", 120);
        }

        //蘭姆酒
        private void button28_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("050", "蘭姆酒", 120);
        }

        //琴酒
        private void button27_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("051", "琴酒", 120);
        }

        //等級I
        private void button84_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("052", "等級I", 200);
        }

        //等級II
        private void button83_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("053", "等級II", 500);
        }

        //等級III
        private void button82_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("054", "等級III", 700);
        }

        //一杯倒
        private void button81_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("055", "一杯倒", 1000);
        }

        //套餐
        //A套餐
        private void button26_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("056", "A套餐", 1599);
        }

        //B套餐
        private void button25_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("057", "B套餐", 2599);
        }

        //C套餐
        private void button24_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("058", "C套餐", 3599);
        }

        //D套餐
        private void button23_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("059", "D套餐", 4599);
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

        // 確認(Enter)
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

        //-------------------------------------------
        //功能性按鈕
        //結帳
        private void Checkout_Click(object sender, EventArgs e)
        {
            checkOut();
        }

        //-------------------------------------------
        //暫時用不到
        private void Report_Load(object sender, EventArgs e)
        {

        }
        private void orderTable_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //orderTable
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
