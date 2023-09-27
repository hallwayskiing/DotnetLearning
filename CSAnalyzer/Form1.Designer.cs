namespace CSAnalyzer
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
            browseBtn = new Button();
            resLabel = new Label();
            fileLabel = new Label();
            freqBtn = new Button();
            SuspendLayout();
            // 
            // browseBtn
            // 
            browseBtn.Location = new Point(312, 282);
            browseBtn.Name = "browseBtn";
            browseBtn.Size = new Size(150, 46);
            browseBtn.TabIndex = 0;
            browseBtn.Text = "Upload";
            browseBtn.UseVisualStyleBackColor = true;
            browseBtn.Click += browseBtn_Click;
            // 
            // resLabel
            // 
            resLabel.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            resLabel.Location = new Point(12, 140);
            resLabel.Name = "resLabel";
            resLabel.Size = new Size(776, 82);
            resLabel.TabIndex = 1;
            resLabel.Text = "Please upload a first .cs file";
            resLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fileLabel
            // 
            fileLabel.Location = new Point(12, 52);
            fileLabel.Name = "fileLabel";
            fileLabel.Size = new Size(776, 62);
            fileLabel.TabIndex = 2;
            fileLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // freqBtn
            // 
            freqBtn.Enabled = false;
            freqBtn.Location = new Point(312, 359);
            freqBtn.Name = "freqBtn";
            freqBtn.Size = new Size(150, 46);
            freqBtn.TabIndex = 3;
            freqBtn.Text = "Frequency";
            freqBtn.UseVisualStyleBackColor = true;
            freqBtn.Click += freqBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(freqBtn);
            Controls.Add(fileLabel);
            Controls.Add(resLabel);
            Controls.Add(browseBtn);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "C# Analyzer";
            ResumeLayout(false);
        }

        #endregion

        private Button browseBtn;
        private Label resLabel;
        private Label fileLabel;
        private Button freqBtn;
    }
}