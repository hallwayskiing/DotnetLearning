using AccountApp.entity;

namespace AccountApp
{
    public partial class Form1 : Form
    {
        CreditAccount account;
        public Form1()
        {
            InitializeComponent();
            account = new CreditAccount(0, 5000);
            account.BigMoneyFetched += Account_BigMoneyFetched;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            moneyLabel.Text = "账户余额：" + account.Money.ToString();
            creditLabel.Text = "信用额度：" + account.Credit.ToString();
            returnLabel.Text = "待还额度：" + (account.OriginCredit - account.Credit);
        }
        private void Account_BigMoneyFetched(BigMoneyArgs e)
        {
            var res = MessageBox.Show("你正在进行大额取款...\n请注意资金安全！", "大额取款", MessageBoxButtons.OK);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var money = double.Parse(inputBox.Text);
                account.SaveMoney(money);
                Form1_Load(sender, e);
            }
            catch (FormatException)
            {
                MessageBox.Show("请输入正确金额！");
            }
        }

        private void fetchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var money = double.Parse(inputBox.Text);
                account.FetchMoney(money);
                Form1_Load(sender, e);
            }
            catch(FormatException)
            {
                MessageBox.Show("请输入正确金额！");
            }
            catch(MoneyNotEnoughException)
            {
                MessageBox.Show("金额不足！");
            }
        }
    }
}