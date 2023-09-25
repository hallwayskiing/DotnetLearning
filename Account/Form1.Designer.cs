namespace AccountApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            saveBtn = new Button();
            moneyLabel = new Label();
            creditLabel = new Label();
            fetchBtn = new Button();
            returnLabel = new Label();
            inputBox = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(147, 304);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(150, 46);
            saveBtn.TabIndex = 0;
            saveBtn.Text = "存款";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // moneyLabel
            // 
            moneyLabel.AutoSize = true;
            moneyLabel.Location = new Point(79, 69);
            moneyLabel.Name = "moneyLabel";
            moneyLabel.Size = new Size(148, 31);
            moneyLabel.TabIndex = 1;
            moneyLabel.Text = "账户余额：0";
            // 
            // creditLabel
            // 
            creditLabel.AutoSize = true;
            creditLabel.Location = new Point(284, 69);
            creditLabel.Name = "creditLabel";
            creditLabel.Size = new Size(148, 31);
            creditLabel.TabIndex = 2;
            creditLabel.Text = "信用额度：0";
            // 
            // fetchBtn
            // 
            fetchBtn.Location = new Point(419, 304);
            fetchBtn.Name = "fetchBtn";
            fetchBtn.Size = new Size(150, 46);
            fetchBtn.TabIndex = 3;
            fetchBtn.Text = "取款";
            fetchBtn.UseVisualStyleBackColor = true;
            fetchBtn.Click += fetchBtn_Click;
            // 
            // returnLabel
            // 
            returnLabel.AutoSize = true;
            returnLabel.Location = new Point(502, 69);
            returnLabel.Name = "returnLabel";
            returnLabel.Size = new Size(148, 31);
            returnLabel.TabIndex = 4;
            returnLabel.Text = "待还额度：0";
            // 
            // inputBox
            // 
            inputBox.Location = new Point(239, 204);
            inputBox.Name = "inputBox";
            inputBox.Size = new Size(330, 38);
            inputBox.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(147, 210);
            label1.Name = "label1";
            label1.Size = new Size(86, 31);
            label1.TabIndex = 6;
            label1.Text = "金额：";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 425);
            Controls.Add(label1);
            Controls.Add(inputBox);
            Controls.Add(returnLabel);
            Controls.Add(fetchBtn);
            Controls.Add(creditLabel);
            Controls.Add(moneyLabel);
            Controls.Add(saveBtn);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ATM";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button saveBtn;
        private Label moneyLabel;
        private Label creditLabel;
        private Button fetchBtn;
        private Label returnLabel;
        private TextBox inputBox;
        private Label label1;
    }
}