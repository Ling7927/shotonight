namespace login
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.passText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Login = new System.Windows.Forms.Button();
            this.register = new System.Windows.Forms.Button();
            this.powd = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.Label();
            this.powdText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // passText
            // 
            this.passText.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.passText.Location = new System.Drawing.Point(120, 209);
            this.passText.Name = "passText";
            this.passText.Size = new System.Drawing.Size(390, 27);
            this.passText.TabIndex = 3;
            this.passText.TextChanged += new System.EventHandler(this.passText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(225, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 43);
            this.label1.TabIndex = 4;
            this.label1.Text = "Shotonight";
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(148, 273);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(143, 52);
            this.Login.TabIndex = 5;
            this.Login.Text = "登入";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // register
            // 
            this.register.Location = new System.Drawing.Point(337, 273);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(143, 52);
            this.register.TabIndex = 6;
            this.register.Text = "註冊";
            this.register.UseVisualStyleBackColor = true;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // powd
            // 
            this.powd.AutoSize = true;
            this.powd.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.powd.Location = new System.Drawing.Point(47, 138);
            this.powd.Name = "powd";
            this.powd.Size = new System.Drawing.Size(67, 25);
            this.powd.TabIndex = 7;
            this.powd.Text = "帳號 : ";
            // 
            // pass
            // 
            this.pass.AutoSize = true;
            this.pass.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.pass.Location = new System.Drawing.Point(47, 209);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(67, 25);
            this.pass.TabIndex = 8;
            this.pass.Text = "密碼 : ";
            // 
            // powdText
            // 
            this.powdText.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.powdText.Location = new System.Drawing.Point(120, 140);
            this.powdText.Name = "powdText";
            this.powdText.Size = new System.Drawing.Size(390, 27);
            this.powdText.TabIndex = 9;
            this.powdText.TextChanged += new System.EventHandler(this.powdText_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 404);
            this.Controls.Add(this.powdText);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.powd);
            this.Controls.Add(this.register);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox passText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button register;
        private System.Windows.Forms.Label powd;
        private System.Windows.Forms.Label pass;
        private System.Windows.Forms.TextBox powdText;
    }
}

