namespace Exam
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
            components = new System.ComponentModel.Container();
            timer = new System.Windows.Forms.Timer(components);
            startBtn = new Button();
            questionLabel = new Label();
            answerLabel = new Label();
            answerBox = new TextBox();
            answerBtn = new Button();
            timeLabel = new Label();
            judgeLabel = new Label();
            progressLabel = new Label();
            quitBtn = new Button();
            SuspendLayout();
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // startBtn
            // 
            startBtn.Location = new Point(230, 299);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(150, 46);
            startBtn.TabIndex = 1;
            startBtn.Text = "GO";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // questionLabel
            // 
            questionLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            questionLabel.Font = new Font("Microsoft YaHei UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point);
            questionLabel.Location = new Point(12, 65);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new Size(590, 57);
            questionLabel.TabIndex = 2;
            questionLabel.Text = "Start your test";
            questionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // answerLabel
            // 
            answerLabel.AutoSize = true;
            answerLabel.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            answerLabel.Location = new Point(140, 231);
            answerLabel.Name = "answerLabel";
            answerLabel.Size = new Size(139, 41);
            answerLabel.TabIndex = 3;
            answerLabel.Text = "Answer:";
            answerLabel.Visible = false;
            // 
            // answerBox
            // 
            answerBox.Location = new Point(285, 234);
            answerBox.Name = "answerBox";
            answerBox.Size = new Size(163, 38);
            answerBox.TabIndex = 4;
            answerBox.Visible = false;
            // 
            // answerBtn
            // 
            answerBtn.Location = new Point(229, 300);
            answerBtn.Name = "answerBtn";
            answerBtn.Size = new Size(150, 46);
            answerBtn.TabIndex = 5;
            answerBtn.Text = "Confirm";
            answerBtn.UseVisualStyleBackColor = true;
            answerBtn.Visible = false;
            answerBtn.Click += answerBtn_Click;
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(489, 34);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(104, 31);
            timeLabel.TabIndex = 6;
            timeLabel.Text = "Time:10";
            timeLabel.Visible = false;
            // 
            // judgeLabel
            // 
            judgeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            judgeLabel.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            judgeLabel.Location = new Point(12, 143);
            judgeLabel.Name = "judgeLabel";
            judgeLabel.Size = new Size(590, 41);
            judgeLabel.TabIndex = 7;
            judgeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressLabel
            // 
            progressLabel.AutoSize = true;
            progressLabel.Location = new Point(310, 34);
            progressLabel.Name = "progressLabel";
            progressLabel.Size = new Size(171, 31);
            progressLabel.TabIndex = 8;
            progressLabel.Text = "Progress:1/10";
            progressLabel.Visible = false;
            // 
            // quitBtn
            // 
            quitBtn.Location = new Point(230, 300);
            quitBtn.Name = "quitBtn";
            quitBtn.Size = new Size(150, 46);
            quitBtn.TabIndex = 9;
            quitBtn.Text = "Quit";
            quitBtn.UseVisualStyleBackColor = true;
            quitBtn.Visible = false;
            quitBtn.Click += quitBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 372);
            Controls.Add(quitBtn);
            Controls.Add(progressLabel);
            Controls.Add(judgeLabel);
            Controls.Add(timeLabel);
            Controls.Add(answerBtn);
            Controls.Add(answerBox);
            Controls.Add(answerLabel);
            Controls.Add(questionLabel);
            Controls.Add(startBtn);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Exam";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private Button startBtn;
        private Label questionLabel;
        private Label answerLabel;
        private TextBox answerBox;
        private Button answerBtn;
        private Label timeLabel;
        private Label judgeLabel;
        private Label progressLabel;
        private Button quitBtn;
    }
}