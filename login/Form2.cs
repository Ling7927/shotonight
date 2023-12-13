using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Access.Dao;

namespace login
{

    public partial class Report : Form
    {
        int index = 1;

        public class DBConfig
        {
            //log.db要放在【bin\Debug底下】      
            public static string dbFile = Application.StartupPath + @"\log.db";

            public static string dbPath = "Data source=" + dbFile;

            public static SQLiteConnection sqlite_connect;
            public static SQLiteCommand sqlite_cmd;
            public static SQLiteDataReader sqlite_datareader;
        }

        private void Load_DB()
        {
            DBConfig.sqlite_connect = new SQLiteConnection(DBConfig.dbPath);
            DBConfig.sqlite_connect.Open();// Open

        }
        //訂單明細
        public class DataItem
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public int Amount { get; set; }
            public int TotalPrice { get; set; }
            public string Remark { get; set; }
            public string Oid { get; set; }
        }

        public void showTransForm(String Oid)
        {
            string sql = @"SELECT * FROM transform WHERE Oid = '" + Oid + "'";
            DBConfig.sqlite_cmd = new SQLiteCommand(sql, DBConfig.sqlite_connect);
            DBConfig.sqlite_datareader = DBConfig.sqlite_cmd.ExecuteReader();

            List<DataItem> dataList = new List<DataItem>();

            if (DBConfig.sqlite_datareader.HasRows)
            {
                while (DBConfig.sqlite_datareader.Read()) //read every data
                {
                    String id = DBConfig.sqlite_datareader["id"].ToString();
                    String name = DBConfig.sqlite_datareader["name"].ToString();
                    int price = Convert.ToInt32(DBConfig.sqlite_datareader["price"]);
                    int amount = Convert.ToInt32(DBConfig.sqlite_datareader["amount"]);
                    int total_price = price * amount;
                    String remark = DBConfig.sqlite_datareader["remark"].ToString();
                    String _Oid = DBConfig.sqlite_datareader["Oid"].ToString();

                    DataItem item = new DataItem
                    {
                        Id = id,
                        Name = name,
                        Price = price,
                        Amount = amount,
                        TotalPrice = total_price,
                        Remark = remark,
                        Oid = _Oid
                    };

                        dataList.Add(item);
                }
                DBConfig.sqlite_datareader.Close();
            }

            Form3 form3 = new Form3();
            form3.DisplayData(dataList);
            form3.Show();
        }

        //訂單資料庫
        public void showTransOrder()
        {
            this.transOrderTable.Rows.Clear();

            string sql = @"SELECT * from transOrder;";
            DBConfig.sqlite_cmd = new SQLiteCommand(sql, DBConfig.sqlite_connect);
            DBConfig.sqlite_datareader = DBConfig.sqlite_cmd.ExecuteReader();

            if (DBConfig.sqlite_datareader.HasRows)
            {
                while (DBConfig.sqlite_datareader.Read()) //read every data
                {
                    String id = DBConfig.sqlite_datareader["id"].ToString();
                    int total_price = Convert.ToInt32(DBConfig.sqlite_datareader["total_price"]);
                    String _date_str = DBConfig.sqlite_datareader["trans_time"].ToString();
                    //button
                    DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();
                    buttonCell.Value = "交易明細";
                    buttonCell.Tag = "btnDetails"; // 按鈕列的名稱，可用於識別該列
                    buttonCell.UseColumnTextForButtonValue = true; //shape

                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = id });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = total_price });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = _date_str });
                    row.Cells.Add(buttonCell);
                    transOrderTable.Rows.Add(row);
                }
                DBConfig.sqlite_datareader.Close();
            }
        }

        //交易訂單(按鈕事件)
        private void transOrderTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = transOrderTable.Rows[e.RowIndex].Cells["oid"].Value.ToString();
            int total_price = Convert.ToInt32(transOrderTable.Rows[e.RowIndex].Cells["total_price"].Value);
            string trans_time = transOrderTable.Rows[e.RowIndex].Cells["transTime"].Value.ToString();
            showTransForm(id);
        }

        //選擇餐點
        void inputtextBoxOrderData(String foodId, String foodName, int price,String type)
        {
            idBox.Text = foodId;
            nameBox.Text = foodName;
            priceBox.Text = price.ToString();
            productType.Text = type;
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
        void inputOrderData(String foodId,String type, String foodName, String price, String quantity, String totalPrice, String remarks)
        {

            DataGridViewRowCollection rows = dataGridView1.Rows;
            rows.Add(new Object[] { foodId, type, foodName, price, quantity, totalPrice, remarks});

        }

        //結帳
        void checkOut()
        {
            if (dataGridView1.Rows.Count != 1)
            {

                Random random = new Random();
                int randomNumber = random.Next(); // 訂單編號
                int totalMoney = 0; //交易總金額
                DateTime date = DateTime.Now; // 訂單時間

                for (int i=0;i< dataGridView1.Rows.Count-1; i++)
                {

                    DataGridViewRow row = dataGridView1.Rows[i];
                    string foodId = row.Cells["id"].Value.ToString();
                    string type = row.Cells["type"].Value.ToString();
                    string foodName = row.Cells["productName"].Value.ToString();
                    int price = Convert.ToInt32(row.Cells["price"].Value);
                    int quantity = Convert.ToInt32(row.Cells["quantity"].Value);
                    int totalPrice = Convert.ToInt32(row.Cells["totalPrice"].Value);
                    string remarks = row.Cells["Remark"].Value.ToString();

                    totalMoney += totalPrice;

                    //INSERT TransForm(OID:randomNumber)
                    string sqlOrder = @"INSERT INTO transform(id, type,name,price,amount,total_price,remark,Oid)
                    VALUES( "
                     + " '" + foodId.ToString() + "' , "
                     + " '" + type.ToString() + "' , "
                     + " '" + foodName.ToString() + "' , "
                     + " '" + price.ToString() + "' , "
                     + " '" + quantity.ToString() + "' , "
                     + " '" + totalPrice.ToString() + "' ,  "
                     + " '" + remarks.ToString() + "' ,  "
                     + " '" + randomNumber.ToString() + "'   "
                    + ");";
                    DBConfig.sqlite_cmd = new SQLiteCommand(sqlOrder, DBConfig.sqlite_connect);
                    DBConfig.sqlite_cmd.ExecuteNonQuery();

                    //MessageBox.Show("點餐成功");
                    //MessageBox.Show("編號 : " + foodId + " 產品名稱 : " + foodName + " 單價 : " + price + " 數量 : " + quantity
                    //    + " 金額 : " + totalPrice + " 備註" + remarks);

                    //MessageBox.Show("編號 : " + foodId + " 產品名稱 : " + foodName + " 單價 : " + price + " 數量 : " + quantity
                    //    + " 金額 : " + totalPrice + " 備註" + remarks);
                }

                MessageBox.Show("訂單編號 : " + randomNumber + " 交易總金額 : " + totalMoney + " 訂單時間 : " + date);
                //INSERT TransOrder
                string sql = @"INSERT INTO transOrder(id,total_price,trans_time)
                    VALUES( "
                     + " '" + randomNumber.ToString() + "' , "
                     + " '" + totalMoney.ToString() + "' , "
                     + " '" + date.ToString("yyyy-MM-dd") + "'  "
                    + ");";
                    DBConfig.sqlite_cmd = new SQLiteCommand(sql, DBConfig.sqlite_connect);
                    DBConfig.sqlite_cmd.ExecuteNonQuery();

                //清空資料
                dataGridView1.Rows.Clear();

            }
            else
            {
                MessageBox.Show("您尚未點餐");
            }
        }

        public Report()
        {
            InitializeComponent();
            Load_DB();
            showTransOrder();

        }

        //---------------------------------------------------------------------
        //order

        //酒類
        //不醉不歸
        private void button37_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("001", "不醉不歸",280, "Alcohol");
        }

        //三天三夜
        private void button36_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("002", "三天三夜", 380, "Alcohol");
        }

        //我梅了
        private void button35_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("003", "我梅了", 350, "Alcohol");
        }

        //梅焦慮
        private void button18_Click_1(object sender, EventArgs e)
        {
            inputtextBoxOrderData("004", "梅焦慮", 170, "Alcohol");
        }

        //芒碌的一天
        private void button41_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("005", "芒碌的一天", 330, "Alcohol");
        }

        //手下柳琴
        private void button40_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("006", "手下柳琴", 300, "Alcohol");
        }

        //紅心芭樂多
        private void button39_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("007", "紅心芭樂多", 630, "Alcohol");
        }

        //口以麻
        private void button38_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("008", "口以麻", 120, "Alcohol");
        }

        //黑色漂流瓶
        private void button45_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("009", "黑色漂流瓶", 530, "Alcohol");
        }

        //白色的大海
        private void button44_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("010", "白色的大海", 170, "Alcohol");
        }

        //黃色的大樹
        private void button43_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("011", "黃色的大樹", 320, "Alcohol");
        }

        //綠色的天空
        private void button42_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("012", "綠色的天空", 450, "Alcohol");
        }

        //粉紅泡泡
        private void button53_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("013", "粉紅泡泡", 1000, "Alcohol");
        }

        //紅色炸彈
        private void button52_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("014", "紅色炸彈", 888, "Alcohol");
        }

        //彩虹軟糖
        private void button51_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("015", "彩虹軟糖", 777, "Alcohol");
        }

        //史藍姆
        private void button50_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("016", "史藍姆", 430, "Alcohol");
        }

        //MIX夏威夷
        private void button55_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("017", "MIX夏威夷", 220, "Alcohol");
        }

        //碧落大地
        private void button48_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("018", "碧落大地", 190, "Alcohol");
        }

        //莫吉托
        private void button47_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("019", "莫吉托", 350, "Alcohol");
        }

        //月光寶盒
        private void button46_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("020", "月光寶盒", 100000, "Alcohol");
        }

        //主餐
        //白酒蛤蜊義大利麵
        private void button34_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("021", "白酒蛤蜊義大利麵", 5500, "Meal");
        }

        //奶油起司寬麵
        private void button33_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("022", "奶油起司寬麵", 650, "Meal");
        }

        //經典肉醬義大利麵
        private void button32_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("023", "經典肉醬義大利麵", 650, "Meal");
        }

        //羅勒雞肉青醬義大利麵
        private void button31_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("024", "羅勒雞肉青醬義大利麵", 750, "Meal");
        }

        //白酒蛤蜊義大利麵
        private void button61_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("025", "白酒蛤蜊義大利麵", 1000, "Meal");
        }

        //奶油起司寬麵
        private void button60_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("026", "奶油起司寬麵", 580, "Meal");
        }

        //經典肉醬寬麵
        private void button59_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("027", "經典肉醬寬麵", 780, "Meal");
        }

        //羅勒雞肉青醬寬麵
        private void button58_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("028", "羅勒雞肉青醬寬麵", 370, "Meal");
        }

        //椒麻乾麵
        private void button77_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("029", "椒麻乾麵", 250, "Meal");
        }

        //微粒炸醬麵
        private void button76_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("030", "微粒炸醬麵", 100, "Meal");
        }

        //黑金滷肉飯
        private void button75_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("031", "黑金滷肉飯", 270, "Meal");
        }

        //什錦炒麵
        private void button74_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("032", "什錦炒麵", 250, "Meal");
        }

        //炒海瓜子直麵
        private void button73_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("033", "炒海瓜子直麵", 350, "Meal");
        }

        //阿罵的炒飯
        private void button72_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("034", "阿罵的炒飯", 100, "Meal");
        }

        //下酒菜
        //松露薯條
        private void button19_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("035", "松露薯條", 300, "Appetizers");
        }

        //美式肉醬薯條
        private void button20_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("036", "美式肉醬薯條", 300, "Appetizers");
        }

        //左宗棠炸雞
        private void button21_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("037", "左宗棠炸雞", 450, "Appetizers");
        }

        //韓式炸雞
        private void button22_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("038", "韓式炸雞", 450, "Appetizers");
        }

        //四拉差雞軟骨
        private void button69_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("039", "四拉差雞軟骨", 450, "Appetizers");
        }

        //避風塘牛肉塊
        private void button68_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("040", "避風塘牛肉塊", 650, "Appetizers");
        }

        //南方一級棒棒腿
        private void button67_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("041", "南方一級棒棒腿", 380, "Appetizers");
        }

        //炸物拼盤
        private void button66_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("042", "炸物拼盤", 800, "Appetizers");
        }

        //奈奈桂心豬
        private void button79_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("043", "奈奈桂心豬", 600, "Appetizers");
        }

        //油醋大蔥鴨
        private void button78_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("044", "油醋大蔥鴨", 850, "Appetizers");
        }

        //日本廣島生蠔
        private void button71_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("045", "日本廣島生蠔", 1500, "Appetizers");
        }

        //涼拌檸檬蝦
        private void button70_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("046", "涼拌檸檬蝦", 1200, "Appetizers");
        }

        //阿罵的滷味拼盤
        private void button65_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("047", "阿罵的滷味拼盤", 250, "Appetizers");
        }

        //Shot\
        //伏特加
        private void button30_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("048", "伏特加", 120, "Appetizers");
        }

        //香醇威士忌
        private void button29_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("049", "香醇威士忌", 120, "Shot");
        }

        //蘭姆酒
        private void button28_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("050", "蘭姆酒", 120, "Shot");
        }

        //琴酒
        private void button27_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("051", "琴酒", 120, "Shot");
        }

        //等級I
        private void button84_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("052", "等級I", 200, "Shot");
        }

        //等級II
        private void button83_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("053", "等級II", 500, "Shot");
        }

        //等級III
        private void button82_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("054", "等級III", 700, "Shot");
        }

        //一杯倒
        private void button81_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("055", "一杯倒", 1000, "Shot");
        }

        //套餐
        //A套餐
        private void button26_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("056", "A套餐", 1599,"set");
        }

        //B套餐
        private void button25_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("057", "B套餐", 2599, "set");
        }

        //C套餐
        private void button24_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("058", "C套餐", 3599, "set");
        }

        //D套餐
        private void button23_Click(object sender, EventArgs e)
        {
            inputtextBoxOrderData("059", "D套餐", 4599, "set");
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
                !string.IsNullOrEmpty(totalPriceBox.Text) &&
                !string.IsNullOrEmpty(productType.Text))
            {
                inputOrderData(idBox.Text, productType.Text, nameBox.Text, priceBox.Text, quantityBox.Text, totalPriceBox.Text, remarkBox.Text);
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
            showTransOrder();
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

        //productType
        private void productType_TextChanged(object sender, EventArgs e)
        {

        }
        //繪圖
        private void Draw_Click(object sender, EventArgs e)
        {
            // 1. 從資料庫獲取數據
            string sql = @"SELECT type, SUM(total_price) AS total_amount
                           FROM transform
                           WHERE type IN ('Alcohol', 'Meal', 'Appetizers', 'Shot')
                           GROUP BY type";

            SQLiteCommand command = new SQLiteCommand(sql, DBConfig.sqlite_connect);
            SQLiteDataReader reader = command.ExecuteReader();

            var data = new Dictionary<string, double>();
            double totalSum = 0;

            while (reader.Read())
            {
                string type = reader["type"].ToString();
                double totalAmount = Convert.ToDouble(reader["total_amount"]);
                data[type] = totalAmount;
                totalSum += totalAmount;
            }

            // 關閉資料庫讀取器
            reader.Close();

            // 清空圖表現有的數據點
            this.chart1.Series["stocks"].Points.Clear();

            // 2. 將數據轉換為百分比並添加到圖表
            foreach (var item in data)
            {
                double percentage = (item.Value / totalSum) * 100;
                // 添加數據點和標籤
                DataPoint dp = new DataPoint();
                dp.SetValueXY(item.Key, percentage);
                dp.Label = $"{item.Key} {percentage:#.##}%";
                this.chart1.Series["stocks"].Points.Add(dp);
            }

            // 設置圖表顯示數據的格式為百分比
            this.chart1.Series["stocks"].Label = "#PERCENT";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            save.FileName = "Export_Chart1_JPG";
            save.Filter = "*.jpg|*.jpg";
            if (save.ShowDialog() != DialogResult.OK) return;

            chart1.SaveImage(save.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void Export_draw_excel_Click(object sender, EventArgs e)
        {

            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            save.FileName = "Export_Chart_Data";
            save.Filter = "*.xlsx|*.xlsx";
            if (save.ShowDialog() != DialogResult.OK) return;

            // Excel 物件

            Microsoft.Office.Interop.Excel.Application xls = null;
            try
            {
                xls = new Microsoft.Office.Interop.Excel.Application();
                // Excel WorkBook
                Microsoft.Office.Interop.Excel.Workbook book = xls.Workbooks.Add();
                //Excel.Worksheet Sheet = (Excel.Worksheet)book.Worksheets[1];
                Microsoft.Office.Interop.Excel.Worksheet Sheet = xls.ActiveSheet;

                // 把資料塞進 Excel 內
                // 標題
                Sheet.Cells[1, 1] = "分類";
                Sheet.Cells[1, 2] = "佔比";

                // 內容
                for (int k = 0; k < this.chart1.Series["stocks"].Points.Count; k++)
                {
                    Sheet.Cells[k + 2, 1] = this.chart1.Series["stocks"].Points[k].AxisLabel.ToString();
                    Sheet.Cells[k + 2, 2] = this.chart1.Series["stocks"].Points[k].YValues[0].ToString();
                }

                // 儲存檔案
                book.SaveAs(save.FileName);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                xls.Quit();
            }
        }
        //繪出報表
        private void button8_Click(object sender, EventArgs e)
        {
            Excel.Application xls = null; // 新增一個excel應用程式
            try
            {
                // 打開excel應用程式
                xls = new Excel.Application();

                // 新增 Workbook
                Excel.Workbook book = xls.Workbooks.Add();

                // 活動工作表
                Excel.Worksheet Sheet = xls.ActiveSheet;

                // 從資料庫獲取數據
                DateTime now = DateTime.Now;
                string monthStart = new DateTime(now.Year, now.Month, 1).ToString("yyyy-MM-dd");
                string monthEnd = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).ToString("yyyy-MM-dd");

                string sql = $@"SELECT name, SUM(amount) AS monthly_total
                                FROM transform,transOrder
                                WHERE transOrder.trans_time >= '{monthStart}' AND transOrder.trans_time <= '{monthEnd}' AND transform.Oid == transOrder.id
                                GROUP BY name";

                SQLiteCommand command = new SQLiteCommand(sql, DBConfig.sqlite_connect);
                SQLiteDataReader reader = command.ExecuteReader();

                // 標題
                Sheet.Cells[1, 1] = "商品名稱";
                Sheet.Cells[1, 2] = "當月數總和";

                int row = 2;
                while (reader.Read())
                {
                    string name = reader["name"].ToString();
                    int monthlyTotal = Convert.ToInt32(reader["monthly_total"]);
                    Sheet.Cells[row, 1] = name;
                    Sheet.Cells[row, 2] = monthlyTotal;
                    row++;
                }

                // 關閉資料庫讀取器
                reader.Close();

                // 儲存檔案
                SaveFileDialog save = new SaveFileDialog(); //新增存檔的視窗
                save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // 檔案優先存在桌面
                save.FileName = $"Export_Chart_Data_{now.Month}月"; // 檔案名稱
                save.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"; // 檔案格式
                if (save.ShowDialog() != DialogResult.OK) return;
                book.SaveAs(save.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤: " + ex.Message);
            }
            finally
            {
                if (xls != null)
                {
                    xls.Quit();
                }
            }
        }
    }
}

