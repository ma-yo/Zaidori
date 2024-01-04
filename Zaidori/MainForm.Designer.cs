namespace Zaidori
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            InputGrid = new DataGridView();
            COL_SIZE = new DataGridViewTextBoxColumn();
            COL_QUANT = new DataGridViewTextBoxColumn();
            MaterialGrid = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            Label01 = new Label();
            Label05 = new Label();
            ClearButton = new Button();
            CalcButton = new Button();
            Label04 = new Label();
            AsariText = new TextBox();
            Label03 = new Label();
            MemoText = new TextBox();
            ((System.ComponentModel.ISupportInitialize)InputGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaterialGrid).BeginInit();
            SuspendLayout();
            // 
            // InputGrid
            // 
            InputGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.Honeydew;
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.Honeydew;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            InputGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            InputGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            InputGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            InputGrid.Columns.AddRange(new DataGridViewColumn[] { COL_SIZE, COL_QUANT });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            InputGrid.DefaultCellStyle = dataGridViewCellStyle4;
            InputGrid.EditMode = DataGridViewEditMode.EditOnEnter;
            InputGrid.Location = new Point(138, 86);
            InputGrid.Name = "InputGrid";
            InputGrid.RowHeadersVisible = false;
            InputGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            InputGrid.Size = new Size(200, 283);
            InputGrid.TabIndex = 0;
            // 
            // COL_SIZE
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            COL_SIZE.DefaultCellStyle = dataGridViewCellStyle2;
            COL_SIZE.HeaderText = "サイズ";
            COL_SIZE.MinimumWidth = 100;
            COL_SIZE.Name = "COL_SIZE";
            COL_SIZE.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // COL_QUANT
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            COL_QUANT.DefaultCellStyle = dataGridViewCellStyle3;
            COL_QUANT.HeaderText = "数量";
            COL_QUANT.MinimumWidth = 80;
            COL_QUANT.Name = "COL_QUANT";
            COL_QUANT.Width = 80;
            // 
            // MaterialGrid
            // 
            MaterialGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = Color.Honeydew;
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.Honeydew;
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            MaterialGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            MaterialGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            MaterialGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MaterialGrid.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1 });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = Color.White;
            dataGridViewCellStyle7.SelectionForeColor = Color.Black;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            MaterialGrid.DefaultCellStyle = dataGridViewCellStyle7;
            MaterialGrid.EditMode = DataGridViewEditMode.EditOnEnter;
            MaterialGrid.Location = new Point(12, 86);
            MaterialGrid.Name = "MaterialGrid";
            MaterialGrid.RowHeadersVisible = false;
            MaterialGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            MaterialGrid.Size = new Size(120, 283);
            MaterialGrid.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewTextBoxColumn1.HeaderText = "サイズ";
            dataGridViewTextBoxColumn1.MinimumWidth = 100;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Label01
            // 
            Label01.AutoSize = true;
            Label01.Location = new Point(12, 68);
            Label01.Name = "Label01";
            Label01.Size = new Size(43, 15);
            Label01.TabIndex = 3;
            Label01.Text = "原材料";
            // 
            // Label05
            // 
            Label05.AutoSize = true;
            Label05.Location = new Point(138, 68);
            Label05.Name = "Label05";
            Label05.Size = new Size(55, 15);
            Label05.TabIndex = 4;
            Label05.Text = "入力材料";
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(12, 12);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(75, 23);
            ClearButton.TabIndex = 6;
            ClearButton.Text = "クリア";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // CalcButton
            // 
            CalcButton.Location = new Point(93, 12);
            CalcButton.Name = "CalcButton";
            CalcButton.Size = new Size(75, 23);
            CalcButton.TabIndex = 7;
            CalcButton.Text = "計算";
            CalcButton.UseVisualStyleBackColor = true;
            CalcButton.Click += CalcButton_Click;
            // 
            // Label04
            // 
            Label04.AutoSize = true;
            Label04.Location = new Point(174, 16);
            Label04.Name = "Label04";
            Label04.Size = new Size(57, 15);
            Label04.TabIndex = 8;
            Label04.Text = "あさり寸法";
            // 
            // AsariText
            // 
            AsariText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AsariText.Location = new Point(237, 12);
            AsariText.Name = "AsariText";
            AsariText.Size = new Size(101, 23);
            AsariText.TabIndex = 9;
            // 
            // Label03
            // 
            Label03.AutoSize = true;
            Label03.Location = new Point(12, 44);
            Label03.Name = "Label03";
            Label03.Size = new Size(24, 15);
            Label03.TabIndex = 10;
            Label03.Text = "メモ";
            // 
            // MemoText
            // 
            MemoText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            MemoText.Location = new Point(75, 41);
            MemoText.Name = "MemoText";
            MemoText.Size = new Size(263, 23);
            MemoText.TabIndex = 11;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 381);
            Controls.Add(MemoText);
            Controls.Add(Label03);
            Controls.Add(AsariText);
            Controls.Add(Label04);
            Controls.Add(CalcButton);
            Controls.Add(ClearButton);
            Controls.Add(Label05);
            Controls.Add(Label01);
            Controls.Add(MaterialGrid);
            Controls.Add(InputGrid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "1次元材取り";
            Shown += MainForm_Shown;
            ((System.ComponentModel.ISupportInitialize)InputGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)MaterialGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView InputGrid;
        private DataGridView MaterialGrid;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Label Label01;
        private Label Label05;
        private Button ClearButton;
        private Button CalcButton;
        private Label Label04;
        private Label Label03;
        private TextBox AsariText;
        private TextBox MemoText;
        private DataGridViewTextBoxColumn COL_SIZE;
        private DataGridViewTextBoxColumn COL_QUANT;
    }
}
