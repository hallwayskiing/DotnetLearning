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
            moneyLabel.Text = "�˻���" + account.Money.ToString();
            creditLabel.Text = "���ö�ȣ�" + account.Credit.ToString();
            returnLabel.Text = "������ȣ�" + (account.OriginCredit - account.Credit);
        }
        private void Account_BigMoneyFetched(BigMoneyArgs e)
        {
            var res = MessageBox.Show("�����ڽ��д��ȡ��...\n��ע���ʽ�ȫ��", "���ȡ��", MessageBoxButtons.OK);
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
                MessageBox.Show("��������ȷ��");
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
                MessageBox.Show("��������ȷ��");
            }
            catch(MoneyNotEnoughException)
            {
                MessageBox.Show("���㣡");
            }
        }
    }
}