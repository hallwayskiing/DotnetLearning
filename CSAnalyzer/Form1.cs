using System.Data;
using System.Text.RegularExpressions;

namespace CSAnalyzer
{
    public partial class Form1 : Form
    {
        string cleanedContent = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "C# Files (*.cs)|*.cs";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileContent = File.ReadAllText(filePath);

                // ����ԭʼ�����͵�����
                int originalLineCount = fileContent.Split('\n').Length;
                int originalWordCount = Regex.Matches(fileContent, @"\b\w+\b").Count;

                // ɾ�����к�ע����
                cleanedContent = RemoveEmptyAndCommentLines(fileContent);

                // ����ɾ����������͵�����
                int cleanedLineCount = cleanedContent.Split('\n').Length;
                int cleanedWordCount = Regex.Matches(cleanedContent, @"\b\w+\b").Count;

                // ��ʾ���
                fileLabel.Text = filePath;
                resLabel.Text = $"Original Lines: {originalLineCount}    Original Words: {originalWordCount}\n" +
                                   $"Cleaned Lines: {cleanedLineCount}    Cleaned Words: {cleanedWordCount}";

                freqBtn.Enabled = true;
            }
        }

        private string RemoveEmptyAndCommentLines(string input)
        {
            // ʹ��������ʽɾ�����к�ע����
            string cleanedContent = Regex.Replace(input, @"^\s*//.*$", "", RegexOptions.Multiline);
            cleanedContent = Regex.Replace(cleanedContent, @"^\s*/\*.*?\*/\s*$", "", RegexOptions.Singleline | RegexOptions.Multiline);
            cleanedContent = Regex.Replace(cleanedContent, @"^\s*$[\r\n]*", "", RegexOptions.Multiline);
            return cleanedContent;
        }

        private void freqBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
            MatchCollection matches = Regex.Matches(cleanedContent, @"\b\w+\b");
            foreach (Match match in matches)
            {
                string word = match.Value.ToLower();
                if (wordFrequency.ContainsKey(word))
                {
                    wordFrequency[word]++;
                }
                else
                {
                    wordFrequency[word] = 1;
                }
            }

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Word");
            dataTable.Columns.Add("Frequency");

            foreach (var kvp in wordFrequency)
            {
                dataTable.Rows.Add(kvp.Key, kvp.Value);
            }
            new FrequencyForm(dataTable).ShowDialog();
        }
    }
}