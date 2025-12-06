namespace form1
{
    partial class Form1
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
            allBible = new RichTextBox();
            results = new ListBox();
            inputTextToSearch = new TextBox();
            searchBtn = new Button();
            resultsLbl = new Label();
            labelMss = new Label();
            searchInSpecBookLbl = new Label();
            selectSpecBookComboBox = new ComboBox();
            selectedSpecChapterComboBox = new ComboBox();
            searchInChapterLbl = new Label();
            sumOfResults = new Label();
            searchByAcronymsBtn = new Button();
            searchStartEnd = new Button();
            inputStart = new TextBox();
            inputEnd = new TextBox();
            StartLbl = new Label();
            endLbl = new Label();
            SuspendLayout();
            // 
            // allBible
            // 
            allBible.BackColor = Color.White;
            allBible.Location = new Point(12, 194);
            allBible.Margin = new Padding(3, 4, 3, 4);
            allBible.Name = "allBible";
            allBible.ReadOnly = true;
            allBible.RightToLeft = RightToLeft.Yes;
            allBible.Size = new Size(919, 413);
            allBible.TabIndex = 0;
            allBible.Text = "";
            // 
            // results
            // 
            results.FormattingEnabled = true;
            results.Location = new Point(980, 194);
            results.Name = "results";
            results.Size = new Size(241, 384);
            results.TabIndex = 1;
            results.SelectedIndexChanged += results_SelectedIndexChanged;
            // 
            // inputTextToSearch
            // 
            inputTextToSearch.Location = new Point(512, 43);
            inputTextToSearch.Name = "inputTextToSearch";
            inputTextToSearch.Size = new Size(551, 27);
            inputTextToSearch.TabIndex = 2;
            inputTextToSearch.TextChanged += inputTextToSearch_TextChanged;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(389, 41);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(117, 31);
            searchBtn.TabIndex = 3;
            searchBtn.Text = "חפש";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // resultsLbl
            // 
            resultsLbl.AutoSize = true;
            resultsLbl.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            resultsLbl.Location = new Point(1058, 153);
            resultsLbl.Name = "resultsLbl";
            resultsLbl.Size = new Size(53, 18);
            resultsLbl.TabIndex = 4;
            resultsLbl.Text = "תוצאות";
            // 
            // labelMss
            // 
            labelMss.AutoSize = true;
            labelMss.Location = new Point(1078, 43);
            labelMss.Name = "labelMss";
            labelMss.Size = new Size(129, 20);
            labelMss.TabIndex = 5;
            labelMss.Text = "הכנס ביטוי לחיפוש";
            // 
            // searchInSpecBookLbl
            // 
            searchInSpecBookLbl.AutoSize = true;
            searchInSpecBookLbl.Location = new Point(1078, 96);
            searchInSpecBookLbl.Name = "searchInSpecBookLbl";
            searchInSpecBookLbl.Size = new Size(80, 20);
            searchInSpecBookLbl.TabIndex = 6;
            searchInSpecBookLbl.Text = "חפש בספר";
            // 
            // selectSpecBookComboBox
            // 
            selectSpecBookComboBox.FormattingEnabled = true;
            selectSpecBookComboBox.Location = new Point(919, 88);
            selectSpecBookComboBox.Name = "selectSpecBookComboBox";
            selectSpecBookComboBox.Size = new Size(144, 28);
            selectSpecBookComboBox.TabIndex = 7;
            selectSpecBookComboBox.SelectedIndexChanged += selectSpecBookComboBox_SelectedIndexChanged;
            // 
            // selectedSpecChapterComboBox
            // 
            selectedSpecChapterComboBox.FormattingEnabled = true;
            selectedSpecChapterComboBox.Location = new Point(632, 88);
            selectedSpecChapterComboBox.Name = "selectedSpecChapterComboBox";
            selectedSpecChapterComboBox.Size = new Size(144, 28);
            selectedSpecChapterComboBox.TabIndex = 9;
            selectedSpecChapterComboBox.Visible = false;
            selectedSpecChapterComboBox.SelectedIndexChanged += serchInSpecChapterComboBox_SelectedIndexChanged;
            // 
            // searchInChapterLbl
            // 
            searchInChapterLbl.AutoSize = true;
            searchInChapterLbl.Location = new Point(791, 96);
            searchInChapterLbl.Name = "searchInChapterLbl";
            searchInChapterLbl.Size = new Size(80, 20);
            searchInChapterLbl.TabIndex = 8;
            searchInChapterLbl.Text = "חפש בפרק";
            searchInChapterLbl.Visible = false;
            // 
            // sumOfResults
            // 
            sumOfResults.AutoSize = true;
            sumOfResults.Location = new Point(1003, 587);
            sumOfResults.Name = "sumOfResults";
            sumOfResults.Size = new Size(0, 20);
            sumOfResults.TabIndex = 10;
            // 
            // searchByAcronymsBtn
            // 
            searchByAcronymsBtn.Location = new Point(389, 78);
            searchByAcronymsBtn.Name = "searchByAcronymsBtn";
            searchByAcronymsBtn.Size = new Size(117, 56);
            searchByAcronymsBtn.TabIndex = 11;
            searchByAcronymsBtn.Text = "חפש ראשי תיבות";
            searchByAcronymsBtn.UseVisualStyleBackColor = true;
            searchByAcronymsBtn.Click += searchByAcronymsBtn_Click;
            // 
            // searchStartEnd
            // 
            searchStartEnd.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchStartEnd.Location = new Point(85, 41);
            searchStartEnd.Name = "searchStartEnd";
            searchStartEnd.Size = new Size(155, 43);
            searchStartEnd.TabIndex = 12;
            searchStartEnd.Text = "חיפוש לפי אותיות תחילת וסוף פסוק";
            searchStartEnd.UseVisualStyleBackColor = true;
            searchStartEnd.Click += openSearchStartEnd_Click;
            // 
            // inputStart
            // 
            inputStart.Location = new Point(176, 107);
            inputStart.Name = "inputStart";
            inputStart.Size = new Size(64, 27);
            inputStart.TabIndex = 13;
            // 
            // inputEnd
            // 
            inputEnd.Location = new Point(85, 107);
            inputEnd.Name = "inputEnd";
            inputEnd.Size = new Size(64, 27);
            inputEnd.TabIndex = 14;
            // 
            // StartLbl
            // 
            StartLbl.AutoSize = true;
            StartLbl.Location = new Point(178, 86);
            StartLbl.Name = "StartLbl";
            StartLbl.Size = new Size(58, 20);
            StartLbl.TabIndex = 15;
            StartLbl.Text = "התחלה";
            // 
            // endLbl
            // 
            endLbl.AutoSize = true;
            endLbl.Location = new Point(99, 84);
            endLbl.Name = "endLbl";
            endLbl.Size = new Size(32, 20);
            endLbl.TabIndex = 16;
            endLbl.Text = "סוף";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1233, 659);
            Controls.Add(endLbl);
            Controls.Add(StartLbl);
            Controls.Add(inputEnd);
            Controls.Add(inputStart);
            Controls.Add(searchStartEnd);
            Controls.Add(searchByAcronymsBtn);
            Controls.Add(sumOfResults);
            Controls.Add(selectedSpecChapterComboBox);
            Controls.Add(searchInChapterLbl);
            Controls.Add(selectSpecBookComboBox);
            Controls.Add(searchInSpecBookLbl);
            Controls.Add(labelMss);
            Controls.Add(resultsLbl);
            Controls.Add(searchBtn);
            Controls.Add(inputTextToSearch);
            Controls.Add(results);
            Controls.Add(allBible);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            RightToLeft = RightToLeft.Yes;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox allBible;
        private ListBox results;
        private TextBox inputTextToSearch;
        private Button searchBtn;
        private Label resultsLbl;
        private Label labelMss;
        private Label searchInSpecBookLbl;
        private ComboBox selectSpecBookComboBox;
        private ComboBox selectedSpecChapterComboBox;
        private Label searchInChapterLbl;
        private Label sumOfResults;
        private Button searchByAcronymsBtn;
        private Button searchStartEnd;
        private TextBox inputStart;
        private TextBox inputEnd;
        private Label StartLbl;
        private Label endLbl;
    }
}
