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

                // 计算原始行数和单词数
                int originalLineCount = fileContent.Split('\n').Length;
                int originalWordCount = Regex.Matches(fileContent, @"\b\w+\b").Count;

                // 删除空行和注释行
                cleanedContent = RemoveEmptyAndCommentLines(fileContent);

                // 计算删除后的行数和单词数
                int cleanedLineCount = cleanedContent.Split('\n').Length;
                int cleanedWordCount = Regex.Matches(cleanedContent, @"\b\w+\b").Count;

                // 显示结果
                fileLabel.Text = filePath;
                resLabel.Text = $"Original Lines: {originalLineCount}    Original Words: {originalWordCount}\n" +
                                   $"Cleaned Lines: {cleanedLineCount}    Cleaned Words: {cleanedWordCount}";

                freqBtn.Enabled = true;
            }
        }

        private string RemoveEmptyAndCommentLines(string input)
        {
            // 使用正则表达式删除空行和注释行
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