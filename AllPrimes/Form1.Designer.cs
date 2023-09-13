namespace AllPrimes
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
            label1 = new Label();
            textBox1 = new TextBox();
            resLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(62, 44);
            label1.Name = "label1";
            label1.Size = new Size(303, 48);
            label1.TabIndex = 0;
            label1.Text = "Enter a number:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(422, 51);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(267, 38);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // resLabel
            // 
            resLabel.AutoSize = true;
            resLabel.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            resLabel.Location = new Point(94, 154);
            resLabel.Name = "resLabel";
            resLabel.Size = new Size(0, 41);
            resLabel.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 451);
            Controls.Add(resLabel);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "All Primes";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label resLabel;
    }
}