using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleLabChislMeth;
using System.Threading;
using System.IO;

namespace WinFormLabChislMeth
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 1; i < 10; i++)
            {
                this.comboBoxCustomMatrix.Items.Add(i);
            }
            this.comboBoxCustomMatrix.SelectedIndex = 0;
            this.numCustomMatrix = 0;
        }

        private CreateMatrix cm = new CreateMatrix();
        private int size;
        Result r;
        int numCustomMatrix;

        private void buttonWork_Click(object sender, EventArgs e)
        {

            Work();
        }

        private void Work()
        {

            if (radioButtonWriteMatrix.Checked)
            {
                if (CreateMatrix())
                {
                    listBoxResults.Items.Clear();

                    size = cm.getSize;

                    listBoxResults.Items.Add(cm.Work(size));
                }
                else
                {
                    MessageBox.Show("Матрица не созданана");
                    return;
                }
            }
            else
            {
                if (!backgroundWorker1.IsBusy)
                {
                    listBoxResults.Items.Clear();

                    backgroundWorker1.RunWorkerAsync();

                }
                
            }
        }

        private bool CreateMatrix()
        {
            if (radioButtonRandomMatrix.Checked)
            {
                cm.CreateRandomMatrix(size);
            }
            else if (radioButtonCustomMatrix.Checked)
            {
                switch (numCustomMatrix)
                {
                    case 0:
                        cm.CreateCustomMatrix1(size);
                        break;
                        //case 1:
                        //    cm.CreateCustomMatrix2(size);
                        //    break;
                        //case 2:
                        //    cm.CreateCustomMatrix3(size);
                        //    break;
                        //case 3:
                        //    cm.CreateCustomMatrix4(size);
                        //    break;
                        //case 4:
                        //    cm.CreateCustomMatrix5(size);
                        //    break;
                        //case 5:
                        //    cm.CreateCustomMatrix6(size);
                        //    break;
                        //case 6:
                        //    cm.CreateCustomMatrix7(size);
                        //    break;
                        //case 7:
                        //    cm.CreateCustomMatrix8(size);
                        //    break;
                        //case 8:
                        //    cm.CreateCustomMatrix9(size);
                        //    break;
                }
            }
            else if (radioButtonWriteMatrix.Checked)
            {
                string mes = cm.readMatrixElements(textBoxEntrMatrix.Text);
                if (!mes.Equals("Матрица составлена"))
                {
                    MessageBox.Show(mes);
                    return false;
                }

            }
            return true;
        }

        private void startWork()
        {
            radioButtonCustomMatrix.Enabled = false;
            radioButtonRandomMatrix.Enabled = false;
            radioButtonWriteMatrix.Enabled = false;
        }

        private void endWork()
        {
            radioButtonCustomMatrix.Enabled = true;
            radioButtonRandomMatrix.Enabled = true;
            radioButtonWriteMatrix.Enabled = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            size = 5;
            while (size <= 100)
            {
                if (CreateMatrix())
                {
                    
                    r = cm.Work(size);
                    backgroundWorker1.ReportProgress(size);

                    size += 5;

                    Invalidate();

                }
                else
                {
                    MessageBox.Show("Матрица не созданана");
                    return;
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            listBoxResults.Items.Add(r);
            progressBar1.Value = e.ProgressPercentage;

        }

        private void radioButtonWriteMatrix_CheckedChanged(object sender, EventArgs e)
        {
            if (textBoxEntrMatrix.Enabled)
            {
                textBoxEntrMatrix.Enabled = false;
            }
            else
            {
                textBoxEntrMatrix.Enabled = true;
            }
        }

        private void radioButtonCustomMatrix_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBoxCustomMatrix.Enabled)
            {
                comboBoxCustomMatrix.Enabled = false;
            }
            else
            {
                comboBoxCustomMatrix.Enabled = true;
            }
        }

        private void comboBoxCustomMatrix_SelectedIndexChanged(object sender, EventArgs e)
        {
            numCustomMatrix = comboBoxCustomMatrix.SelectedIndex;
        }

        private void buttonGraph_Click(object sender, EventArgs e)
        {
            FormGraph fg = new FormGraph();
            fg.ShowDialog();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Stream stream;
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if((stream = saveFileDialog1.OpenFile()) != null)
                {

                    using (StreamWriter sw = new StreamWriter(stream))
                    {
                        for (int i = 0; i < listBoxResults.Items.Count; i++)
                        {
                            sw.WriteLine(listBoxResults.Items[i].ToString());
                        }
                    }
                    stream.Close();
                    MessageBox.Show("Сохранено");
                }
            }
        }
    }
}
