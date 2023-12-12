namespace login
{
    partial class Form3
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
            this.orderDataTable = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.orderDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // orderDataTable
            // 
            this.orderDataTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.orderDataTable.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.orderDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderDataTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.type,
            this.productName,
            this.price,
            this.quantity,
            this.totalPrice,
            this.Remark});
            this.orderDataTable.Location = new System.Drawing.Point(12, 12);
            this.orderDataTable.Name = "orderDataTable";
            this.orderDataTable.RowHeadersWidth = 51;
            this.orderDataTable.RowTemplate.Height = 27;
            this.orderDataTable.Size = new System.Drawing.Size(776, 426);
            this.orderDataTable.TabIndex = 1;
            this.orderDataTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderDataTable_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "編號";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            // 
            // type
            // 
            this.type.HeaderText = "類型";
            this.type.MinimumWidth = 8;
            this.type.Name = "type";
            // 
            // productName
            // 
            this.productName.HeaderText = "名稱";
            this.productName.MinimumWidth = 6;
            this.productName.Name = "productName";
            // 
            // price
            // 
            this.price.HeaderText = "單價";
            this.price.MinimumWidth = 6;
            this.price.Name = "price";
            // 
            // quantity
            // 
            this.quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.quantity.HeaderText = "數量";
            this.quantity.MinimumWidth = 6;
            this.quantity.Name = "quantity";
            this.quantity.Width = 125;
            // 
            // totalPrice
            // 
            this.totalPrice.HeaderText = "金額";
            this.totalPrice.MinimumWidth = 6;
            this.totalPrice.Name = "totalPrice";
            // 
            // Remark
            // 
            this.Remark.HeaderText = "備註";
            this.Remark.MinimumWidth = 6;
            this.Remark.Name = "Remark";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.orderDataTable);
            this.Name = "Form3";
            this.Text = "訂單明細";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.orderDataTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView orderDataTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn productName;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}