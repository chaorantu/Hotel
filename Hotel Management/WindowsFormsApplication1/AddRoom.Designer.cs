namespace WindowsFormsApplication1
{
    partial class AddRoom
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
            this.TxtRoomNum = new System.Windows.Forms.TextBox();
            this.CbbFloor = new System.Windows.Forms.ComboBox();
            this.CbbRoomType = new System.Windows.Forms.ComboBox();
            this.TxtRoomPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TxtRoomName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtRoomNum
            // 
            this.TxtRoomNum.Location = new System.Drawing.Point(183, 62);
            this.TxtRoomNum.Name = "TxtRoomNum";
            this.TxtRoomNum.Size = new System.Drawing.Size(100, 21);
            this.TxtRoomNum.TabIndex = 0;
            // 
            // CbbFloor
            // 
            this.CbbFloor.FormattingEnabled = true;
            this.CbbFloor.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.CbbFloor.Location = new System.Drawing.Point(41, 61);
            this.CbbFloor.Name = "CbbFloor";
            this.CbbFloor.Size = new System.Drawing.Size(75, 20);
            this.CbbFloor.TabIndex = 1;
            this.CbbFloor.SelectedIndexChanged += new System.EventHandler(this.CbbFloor_SelectedIndexChanged);
            // 
            // CbbRoomType
            // 
            this.CbbRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbRoomType.FormattingEnabled = true;
            this.CbbRoomType.Location = new System.Drawing.Point(340, 61);
            this.CbbRoomType.Name = "CbbRoomType";
            this.CbbRoomType.Size = new System.Drawing.Size(104, 20);
            this.CbbRoomType.TabIndex = 2;
            // 
            // TxtRoomPrice
            // 
            this.TxtRoomPrice.Location = new System.Drawing.Point(485, 60);
            this.TxtRoomPrice.Name = "TxtRoomPrice";
            this.TxtRoomPrice.ReadOnly = true;
            this.TxtRoomPrice.Size = new System.Drawing.Size(100, 21);
            this.TxtRoomPrice.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "楼层";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "房间号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "房间类型";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(450, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "价格";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(390, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(510, 126);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TxtRoomName
            // 
            this.TxtRoomName.Location = new System.Drawing.Point(344, 99);
            this.TxtRoomName.Name = "TxtRoomName";
            this.TxtRoomName.Size = new System.Drawing.Size(100, 21);
            this.TxtRoomName.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(305, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "房名";
            // 
            // AddRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 197);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtRoomName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtRoomPrice);
            this.Controls.Add(this.CbbRoomType);
            this.Controls.Add(this.CbbFloor);
            this.Controls.Add(this.TxtRoomNum);
            this.Name = "AddRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddRoom";
            this.Load += new System.EventHandler(this.AddRoom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtRoomNum;
        private System.Windows.Forms.ComboBox CbbFloor;
        private System.Windows.Forms.ComboBox CbbRoomType;
        private System.Windows.Forms.TextBox TxtRoomPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TxtRoomName;
        private System.Windows.Forms.Label label5;
    }
}