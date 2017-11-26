namespace WinFormLabChislMeth
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButtonWriteMatrix = new System.Windows.Forms.RadioButton();
            this.radioButtonRandomMatrix = new System.Windows.Forms.RadioButton();
            this.radioButtonCustomMatrix = new System.Windows.Forms.RadioButton();
            this.buttonWork = new System.Windows.Forms.Button();
            this.textBoxEntrMatrix = new System.Windows.Forms.TextBox();
            this.comboBoxCustomMatrix = new System.Windows.Forms.ComboBox();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonGraph = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // radioButtonWriteMatrix
            // 
            this.radioButtonWriteMatrix.AutoSize = true;
            this.radioButtonWriteMatrix.Checked = true;
            this.radioButtonWriteMatrix.Location = new System.Drawing.Point(24, 24);
            this.radioButtonWriteMatrix.Name = "radioButtonWriteMatrix";
            this.radioButtonWriteMatrix.Size = new System.Drawing.Size(106, 17);
            this.radioButtonWriteMatrix.TabIndex = 1;
            this.radioButtonWriteMatrix.TabStop = true;
            this.radioButtonWriteMatrix.Text = "Ввести матрицу";
            this.radioButtonWriteMatrix.UseVisualStyleBackColor = true;
            this.radioButtonWriteMatrix.CheckedChanged += new System.EventHandler(this.radioButtonWriteMatrix_CheckedChanged);
            // 
            // radioButtonRandomMatrix
            // 
            this.radioButtonRandomMatrix.AutoSize = true;
            this.radioButtonRandomMatrix.Location = new System.Drawing.Point(24, 84);
            this.radioButtonRandomMatrix.Name = "radioButtonRandomMatrix";
            this.radioButtonRandomMatrix.Size = new System.Drawing.Size(124, 17);
            this.radioButtonRandomMatrix.TabIndex = 2;
            this.radioButtonRandomMatrix.TabStop = true;
            this.radioButtonRandomMatrix.Text = "Случайная матрица";
            this.radioButtonRandomMatrix.UseVisualStyleBackColor = true;
            // 
            // radioButtonCustomMatrix
            // 
            this.radioButtonCustomMatrix.AutoSize = true;
            this.radioButtonCustomMatrix.Location = new System.Drawing.Point(24, 143);
            this.radioButtonCustomMatrix.Name = "radioButtonCustomMatrix";
            this.radioButtonCustomMatrix.Size = new System.Drawing.Size(114, 17);
            this.radioButtonCustomMatrix.TabIndex = 3;
            this.radioButtonCustomMatrix.TabStop = true;
            this.radioButtonCustomMatrix.Text = "Выбрать матрицу";
            this.radioButtonCustomMatrix.UseVisualStyleBackColor = true;
            this.radioButtonCustomMatrix.CheckedChanged += new System.EventHandler(this.radioButtonCustomMatrix_CheckedChanged);
            // 
            // buttonWork
            // 
            this.buttonWork.Location = new System.Drawing.Point(243, 168);
            this.buttonWork.Name = "buttonWork";
            this.buttonWork.Size = new System.Drawing.Size(124, 25);
            this.buttonWork.TabIndex = 4;
            this.buttonWork.Text = "Рассчитать";
            this.buttonWork.UseVisualStyleBackColor = true;
            this.buttonWork.Click += new System.EventHandler(this.buttonWork_Click);
            // 
            // textBoxEntrMatrix
            // 
            this.textBoxEntrMatrix.Location = new System.Drawing.Point(178, 12);
            this.textBoxEntrMatrix.Multiline = true;
            this.textBoxEntrMatrix.Name = "textBoxEntrMatrix";
            this.textBoxEntrMatrix.Size = new System.Drawing.Size(189, 136);
            this.textBoxEntrMatrix.TabIndex = 5;
            // 
            // comboBoxCustomMatrix
            // 
            this.comboBoxCustomMatrix.Enabled = false;
            this.comboBoxCustomMatrix.FormattingEnabled = true;
            this.comboBoxCustomMatrix.Location = new System.Drawing.Point(24, 182);
            this.comboBoxCustomMatrix.Name = "comboBoxCustomMatrix";
            this.comboBoxCustomMatrix.Size = new System.Drawing.Size(124, 21);
            this.comboBoxCustomMatrix.TabIndex = 6;
            this.comboBoxCustomMatrix.SelectedIndexChanged += new System.EventHandler(this.comboBoxCustomMatrix_SelectedIndexChanged);
            // 
            // listBoxResults
            // 
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.Location = new System.Drawing.Point(391, 12);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(256, 264);
            this.listBoxResults.TabIndex = 7;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 293);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(624, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(243, 210);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(124, 25);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonGraph
            // 
            this.buttonGraph.Location = new System.Drawing.Point(243, 251);
            this.buttonGraph.Name = "buttonGraph";
            this.buttonGraph.Size = new System.Drawing.Size(124, 25);
            this.buttonGraph.TabIndex = 10;
            this.buttonGraph.Text = "График";
            this.buttonGraph.UseVisualStyleBackColor = true;
            this.buttonGraph.Click += new System.EventHandler(this.buttonGraph_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "Текстовые файлы|*.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 336);
            this.Controls.Add(this.buttonGraph);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.listBoxResults);
            this.Controls.Add(this.comboBoxCustomMatrix);
            this.Controls.Add(this.textBoxEntrMatrix);
            this.Controls.Add(this.buttonWork);
            this.Controls.Add(this.radioButtonCustomMatrix);
            this.Controls.Add(this.radioButtonRandomMatrix);
            this.Controls.Add(this.radioButtonWriteMatrix);
            this.Name = "Form1";
            this.Text = "Решение СЛАУ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton radioButtonWriteMatrix;
        private System.Windows.Forms.RadioButton radioButtonRandomMatrix;
        private System.Windows.Forms.RadioButton radioButtonCustomMatrix;
        private System.Windows.Forms.Button buttonWork;
        private System.Windows.Forms.TextBox textBoxEntrMatrix;
        private System.Windows.Forms.ComboBox comboBoxCustomMatrix;
        private System.Windows.Forms.ListBox listBoxResults;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonGraph;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}