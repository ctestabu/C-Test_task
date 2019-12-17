using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace testTask_Kolpakov
{
    public struct ForSearch
    {
        public int flag;
        public string TextToSearch;

    }
    public partial class Form1 : Form
    {
        public ForSearch first;
        public ForSearch second;
        public ForSearch third;
        public ForSearch fourth;

        public Form1()
        {
            InitializeComponent();
            richTextBox1.AllowDrop = true;
            richTextBox1.DragDrop += RichTextBox1_DragEnter;
            richTextBox1.DragDrop += RichTextBox1_DragDrop;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SortFunction();
        }
        private void RichTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void RichTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var fileNames = data as string[];
                if (fileNames.Length > 0)
                {
                    richTextBox1.Clear();
                    richTextBox1.LoadFile(fileNames[0], RichTextBoxStreamType.PlainText);
                }
            }
        }


        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files | *.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(dialog.FileName);
                richTextBox1.Text = reader.ReadToEnd();
                reader.Close();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Text files | *.txt";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(sv.FileName);
                sw.Write(richTextBox1.Text);
                sw.Close();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void отменадействияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void отменадействияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void вставкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void выделитьвсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void SortFunction()
        {
            first.TextToSearch = textBox1.Text;
            second.TextToSearch = textBox2.Text;
            third.TextToSearch = textBox3.Text;
            fourth.TextToSearch = textBox4.Text;
            string helper = richTextBox1.Text;
            string [] tmp = helper.Split('\n');

            if (helper.IndexOf(first.TextToSearch) > -1)
            {
                richTextBox1.Clear();
                foreach (string line in tmp)
                {
                    if (second.flag == 1 && line.Contains(textBox1.Text) && line.Contains(textBox2.Text))
                    {
                        if (third.flag == 1 && line.Contains(textBox3.Text))
                        {
                            if (fourth.flag == 1 && line.Contains(textBox4.Text) && line.Contains(textBox3.Text))
                                richTextBox1.AppendText(line + '\n');
                            else if (fourth.flag == 0 && line.Contains(textBox3.Text) || line.Contains(textBox4.Text))
                                richTextBox1.AppendText(line + '\n');
                        }
                        else if (line.Contains(textBox2.Text) || line.Contains(textBox3.Text))
                        {
                            if (fourth.flag == 1 && line.Contains(textBox4.Text))
                                richTextBox1.AppendText(line + '\n');
                            else if (third.flag == 0 || line.Contains(textBox3.Text) || line.Contains(textBox4.Text))
                                richTextBox1.AppendText(line + '\n');
                        }
                    }
                    else if (second.flag == 0 && line.Contains(textBox1.Text) || line.Contains(textBox2.Text))
                    {
                        if (third.flag == 1 && line.Contains(textBox3.Text))
                        {
                            if (fourth.flag == 1 && line.Contains(textBox4.Text) && line.Contains(textBox3.Text))
                                richTextBox1.AppendText(line + '\n');
                            else if (fourth.flag == 0 && line.Contains(textBox3.Text) || line.Contains(textBox4.Text))
                                richTextBox1.AppendText(line + '\n');
                        }
                        else if (line.Contains(textBox2.Text) || line.Contains(textBox3.Text))
                        {
                            if (fourth.flag == 1 && line.Contains(textBox4.Text))
                                richTextBox1.AppendText(line + '\n');
                            else if (fourth.flag == 0 && line.Contains(textBox3.Text) || line.Contains(textBox4.Text))
                                richTextBox1.AppendText(line + '\n');
                        }
                        else if (line.Contains(textBox1.Text))
                            richTextBox1.AppendText(line + '\n');
                    }
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string comboText = comboBox1.Text;
            if (comboText == "И")
                first.flag = 1;
            else
                first.flag = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string comboText = comboBox2.Text;
            if (comboText == "И")
                second.flag = 1;
            else
                second.flag = 0;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string comboText = comboBox3.Text;
            if (comboText == "И")
                third.flag = 1;
            else
                third.flag = 0;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string comboText = comboBox4.Text;
            if (comboText == "И")
                fourth.flag = 1;
            else
                fourth.flag = 0;
        }

    }
}
