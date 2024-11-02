using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordsFinder.BI;

namespace WordsFinder.UI
{
    public partial class MainForm : Form
    {

        HashSet<String> wordsCombinations = new HashSet<String>();
        HashSet<String> wordsFiltered = new HashSet<String>();
        HashSet<String> referenceDictionary = new HashSet<String>();
        
        public MainForm()
        {
            InitializeComponent();
            toolTip1.SetToolTip(this.cbxAdvance, "Required full Regex pattern when checked");
            if (cbxAdvance.Checked == false) 
            { toolTip1.SetToolTip(this.txtPattern, "Put ? for one any character or * for many any characters"); }
            else
            { toolTip1.SetToolTip(this.txtPattern, "Put full Regex pattern to filter"); }
        }

        private void dataGridViewRefresh(HashSet<string> wordsCollcetion)
        {
            dataGridView.Rows.Clear();
            int i = 1;
            foreach (var word in wordsCollcetion)
            {
                int length = word.Length;
                dataGridView.Rows.Add(i, word, length);
                i++;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            referenceDictionary = ReferenceDictionary.UploadDictionary("C:\\Users\\brygo\\source\\repos\\WordsFinder\\Files\\dictionaryPL.txt");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            wordsCombinations = WordsCombinations.GetCombinations(txtInput.Text);
            wordsCombinations = WordsCombinations.CheckCollection(wordsCombinations, referenceDictionary);
            dataGridViewRefresh(wordsCombinations);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Text = string.Empty;
            wordsCombinations.Clear();
            wordsFiltered.Clear();
            dataGridView.Rows.Clear();
            txtPattern.Text = string.Empty;

        }


        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView.Rows )
            {
                row.Cells[0].Value = i;
                i++;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cbxAdvance.Checked == true)
                { wordsFiltered = Filtering.FilterAdvanceWords(wordsCombinations, txtPattern.Text); }
            else
                { wordsFiltered = Filtering.FilterWords(wordsCombinations, txtPattern.Text); }
            dataGridViewRefresh(wordsFiltered);
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtPattern.Text = string.Empty;
            dataGridViewRefresh(wordsCombinations);
        }

        private void cbxAdvance_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAdvance.Checked == true)
                { wordsFiltered = Filtering.FilterAdvanceWords(wordsCombinations, txtPattern.Text); }
            else
                { wordsFiltered = Filtering.FilterWords(wordsCombinations, txtPattern.Text); }

            if (wordsFiltered.Count != 0 )
                { dataGridViewRefresh(wordsFiltered); }
            else 
                { dataGridViewRefresh(wordsCombinations); }

            if (cbxAdvance.Checked == false)
                { toolTip1.SetToolTip(this.txtPattern, "Put ? for one any character or * for many any characters"); }
            else
                { toolTip1.SetToolTip(this.txtPattern, "Put full Regex pattern to filter"); }
        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            toolStripStatusCount.Text = "Found words: " + dataGridView.RowCount + " from total " + wordsCombinations.Count;

        }

        private void dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            toolStripStatusCount.Text = "Found words: " + dataGridView.RowCount + " from total " + wordsCombinations.Count;

        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program version: 1.0.3");
        }
    }
}
