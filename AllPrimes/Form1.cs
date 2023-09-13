namespace AllPrimes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var num = int.Parse(textBox1.Text);
                if (num <= 2)
                {
                    throw new ArgumentException();
                }
                var primes = new List<int>();
                for (int i = 2; i < num; i++)
                {
                    bool isPrime = true;
                    foreach (int prime in primes)
                    {
                        if (i % prime == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        primes.Add(i);
                    }
                }
                resLabel.Text = "Primes between:\n";
                for (int i = 0; i < primes.Count; i++)
                {
                    resLabel.Text += primes.ElementAt(i).ToString() + ", " + ((i + 1) % 8 == 0 ? "\n" : "");
                }
            }
            catch (FormatException)
            {
                resLabel.Text = "Must be an integer!";
            }
            catch (ArgumentException)
            {
                resLabel.Text = "Must be larger than 2!";
            }
            catch (Exception ex)
            {
                resLabel.Text = ex.Message;
            }
        }
    }
}