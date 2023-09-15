namespace Exam
{
    public partial class Form1 : Form
    {
        Random random = new();
        int num1;
        int num2;
        int answer;
        int time = 10;
        int progress = 1;
        int correct = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            startBtn.Visible = false;

            num1 = random.Next(100);
            num2 = random.Next(100);
            char sign = '+';
            switch (random.Next(3))
            {
                case 0:
                    sign = '+';
                    answer = num1 + num2;
                    break;
                case 1:
                    sign = '-';
                    answer = num1 - num2;
                    break;
                case 2:
                    sign = '¡Á';
                    answer = num1 * num2;
                    break;
            }
            questionLabel.Text = num1 + sign.ToString() + num2 + "=?";

            answerBox.Visible = true;
            answerLabel.Visible = true;
            answerBtn.Visible = true;
            timeLabel.Visible = true;
            progressLabel.Visible = true;

            timer.Start();
        }

        private void answerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int input = int.Parse(answerBox.Text);
                if (input != answer)
                    throw new Exception();

                judgeLabel.Text = "Right!";
                this.BackColor = Color.Green;
                correct++;
            }
            catch (Exception)
            {
                judgeLabel.Text = "Wrong!";
                this.BackColor = Color.Red;
            }
            finally
            {
                if (progress == 10)
                {
                    this.BackColor = Color.White;
                    timer.Stop();
                    answerBtn.Visible = false;
                    answerLabel.Visible = false;
                    answerBox.Visible = false;
                    progressLabel.Visible= false;
                    timeLabel.Visible= false;

                    questionLabel.Text = "Game Over!";
                    judgeLabel.Text = "Your score: " + correct;
                    quitBtn.Visible = true;
                }
                else
                {
                    answerBox.Clear();
                    time = 10;
                    timeLabel.Text = "Time:10";

                    progressLabel.Text = $"Progress:{++progress}/10";

                    num1 = random.Next(100);
                    num2 = random.Next(100);
                    char sign = '+';
                    switch (random.Next(3))
                    {
                        case 0:
                            sign = '+';
                            answer = num1 + num2;
                            break;
                        case 1:
                            sign = '-';
                            answer = num1 - num2;
                            break;
                        case 2:
                            sign = '¡Á';
                            answer = num1 * num2;
                            break;
                    }
                    questionLabel.Text = num1 + sign.ToString() + num2 + "=?";
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = "Time:" + (--time).ToString();
            if (time == 0)
            {
                answerBtn_Click(sender, e);
            }
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}