namespace ChromiumHistoryManipulator {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            pathText = new TextBox();
            openFileBtn = new Button();
            helpBtn = new Button();
            helpFilePanel = new Panel();
            des2 = new TextBox();
            des1 = new Label();
            dataGrid = new DataGridView();
            panel1 = new Panel();
            IDInfo = new Label();
            searchIDBtn = new Button();
            startPanel = new Panel();
            urlText = new TextBox();
            startBtn = new Button();
            titleText = new TextBox();
            dateValue = new DateTimePicker();
            des3 = new Label();
            minuteText = new TextBox();
            hourText = new TextBox();
            filterPanel = new Panel();
            filterBtn = new Button();
            label1 = new Label();
            filterURLText = new TextBox();
            hourFilterText = new TextBox();
            filterTitleText = new TextBox();
            minFilterText = new TextBox();
            filterDate = new DateTimePicker();
            idText = new TextBox();
            actionSelect = new ComboBox();
            helpFilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) dataGrid).BeginInit();
            panel1.SuspendLayout();
            startPanel.SuspendLayout();
            filterPanel.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // pathText
            // 
            pathText.Location = new Point(15, 12);
            pathText.Margin = new Padding(3, 4, 3, 4);
            pathText.Name = "pathText";
            pathText.PlaceholderText = "Add file";
            pathText.Size = new Size(484, 27);
            pathText.TabIndex = 0;
            // 
            // openFileBtn
            // 
            openFileBtn.Location = new Point(506, 12);
            openFileBtn.Margin = new Padding(3, 4, 3, 4);
            openFileBtn.Name = "openFileBtn";
            openFileBtn.Size = new Size(136, 31);
            openFileBtn.TabIndex = 1;
            openFileBtn.Text = "Open File";
            openFileBtn.UseVisualStyleBackColor = true;
            openFileBtn.Click += OpenFileBtn_Click;
            // 
            // helpBtn
            // 
            helpBtn.Location = new Point(649, 12);
            helpBtn.Margin = new Padding(3, 4, 3, 4);
            helpBtn.Name = "helpBtn";
            helpBtn.Size = new Size(29, 31);
            helpBtn.TabIndex = 2;
            helpBtn.Text = "?";
            helpBtn.UseVisualStyleBackColor = true;
            helpBtn.Click += HelpBtn_Click;
            // 
            // helpFilePanel
            // 
            helpFilePanel.Controls.Add(des2);
            helpFilePanel.Controls.Add(des1);
            helpFilePanel.Location = new Point(405, 49);
            helpFilePanel.Margin = new Padding(3, 4, 3, 4);
            helpFilePanel.Name = "helpFilePanel";
            helpFilePanel.Size = new Size(496, 144);
            helpFilePanel.TabIndex = 3;
            helpFilePanel.Visible = false;
            // 
            // des2
            // 
            des2.Location = new Point(6, 51);
            des2.Margin = new Padding(3, 4, 3, 4);
            des2.Name = "des2";
            des2.ReadOnly = true;
            des2.Size = new Size(486, 27);
            des2.TabIndex = 1;
            des2.Text = "C:\\Users\\<username>\\AppData\\Local\\Google\\Chrome\\User Data\\Default";
            // 
            // des1
            // 
            des1.Location = new Point(6, 7);
            des1.Name = "des1";
            des1.Size = new Size(427, 139);
            des1.TabIndex = 3;
            des1.Text = "Select the \"History\" file of your Chromium Based Browser.\r\nGoogle Chromes history can be found here: \r\n\r\n\r\nFor other Browsers, please check the internet to find the savepaths of given browsers.\r\n\r\n\r\n";
            // 
            // dataGrid
            // 
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGrid.ColumnHeadersHeight = 29;
            dataGrid.Location = new Point(14, 183);
            dataGrid.Margin = new Padding(3, 4, 3, 4);
            dataGrid.Name = "dataGrid";
            dataGrid.ReadOnly = true;
            dataGrid.RowHeadersWidth = 51;
            dataGrid.RowTemplate.Height = 25;
            dataGrid.Size = new Size(1981, 433);
            dataGrid.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(IDInfo);
            panel1.Controls.Add(searchIDBtn);
            panel1.Controls.Add(startPanel);
            panel1.Controls.Add(filterPanel);
            panel1.Controls.Add(idText);
            panel1.Controls.Add(actionSelect);
            panel1.Location = new Point(15, 624);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1198, 213);
            panel1.TabIndex = 5;
            // 
            // IDInfo
            // 
            IDInfo.AutoSize = true;
            IDInfo.Location = new Point(422, 9);
            IDInfo.Name = "IDInfo";
            IDInfo.Size = new Size(50, 20);
            IDInfo.TabIndex = 11;
            IDInfo.Text = "label2";
            // 
            // searchIDBtn
            // 
            searchIDBtn.Location = new Point(329, 4);
            searchIDBtn.Margin = new Padding(3, 4, 3, 4);
            searchIDBtn.Name = "searchIDBtn";
            searchIDBtn.Size = new Size(86, 31);
            searchIDBtn.TabIndex = 10;
            searchIDBtn.Text = "Search";
            searchIDBtn.UseVisualStyleBackColor = true;
            searchIDBtn.Click += SearchIDBtn_Click;
            // 
            // startPanel
            // 
            startPanel.Controls.Add(urlText);
            startPanel.Controls.Add(startBtn);
            startPanel.Controls.Add(titleText);
            startPanel.Controls.Add(dateValue);
            startPanel.Controls.Add(des3);
            startPanel.Controls.Add(minuteText);
            startPanel.Controls.Add(hourText);
            startPanel.Location = new Point(0, 35);
            startPanel.Margin = new Padding(3, 4, 3, 4);
            startPanel.Name = "startPanel";
            startPanel.Size = new Size(1194, 89);
            startPanel.TabIndex = 6;
            // 
            // urlText
            // 
            urlText.Location = new Point(3, 47);
            urlText.Margin = new Padding(3, 4, 3, 4);
            urlText.Name = "urlText";
            urlText.PlaceholderText = "Insert New URL";
            urlText.Size = new Size(919, 27);
            urlText.TabIndex = 1;
            // 
            // startBtn
            // 
            startBtn.Location = new Point(930, 8);
            startBtn.Margin = new Padding(3, 4, 3, 4);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(261, 69);
            startBtn.TabIndex = 7;
            startBtn.Text = "Start";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += StartBtn_Click;
            // 
            // titleText
            // 
            titleText.Location = new Point(3, 8);
            titleText.Margin = new Padding(3, 4, 3, 4);
            titleText.Name = "titleText";
            titleText.PlaceholderText = "Insert New Website title";
            titleText.Size = new Size(485, 27);
            titleText.TabIndex = 2;
            // 
            // dateValue
            // 
            dateValue.Location = new Point(496, 8);
            dateValue.Margin = new Padding(3, 4, 3, 4);
            dateValue.Name = "dateValue";
            dateValue.Size = new Size(239, 27);
            dateValue.TabIndex = 3;
            dateValue.Value = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // des3
            // 
            des3.AutoSize = true;
            des3.Location = new Point(765, 12);
            des3.Name = "des3";
            des3.Size = new Size(12, 20);
            des3.TabIndex = 6;
            des3.Text = ":";
            // 
            // minuteText
            // 
            minuteText.Location = new Point(774, 8);
            minuteText.Margin = new Padding(3, 4, 3, 4);
            minuteText.MaxLength = 2;
            minuteText.Name = "minuteText";
            minuteText.PlaceholderText = "59";
            minuteText.Size = new Size(36, 27);
            minuteText.TabIndex = 4;
            // 
            // hourText
            // 
            hourText.Location = new Point(743, 8);
            hourText.Margin = new Padding(3, 4, 3, 4);
            hourText.MaxLength = 2;
            hourText.Name = "hourText";
            hourText.PlaceholderText = "24";
            hourText.Size = new Size(33, 27);
            hourText.TabIndex = 5;
            // 
            // filterPanel
            // 
            filterPanel.Controls.Add(filterBtn);
            filterPanel.Controls.Add(label1);
            filterPanel.Controls.Add(filterURLText);
            filterPanel.Controls.Add(hourFilterText);
            filterPanel.Controls.Add(filterTitleText);
            filterPanel.Controls.Add(minFilterText);
            filterPanel.Controls.Add(filterDate);
            filterPanel.Location = new Point(0, 120);
            filterPanel.Margin = new Padding(3, 4, 3, 4);
            filterPanel.Name = "filterPanel";
            filterPanel.Size = new Size(1194, 89);
            filterPanel.TabIndex = 9;
            // 
            // filterBtn
            // 
            filterBtn.Location = new Point(934, 8);
            filterBtn.Margin = new Padding(3, 4, 3, 4);
            filterBtn.Name = "filterBtn";
            filterBtn.Size = new Size(261, 69);
            filterBtn.TabIndex = 10;
            filterBtn.Text = "Filter";
            filterBtn.UseVisualStyleBackColor = true;
            filterBtn.Click += FilterBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(768, 8);
            label1.Name = "label1";
            label1.Size = new Size(12, 20);
            label1.TabIndex = 13;
            label1.Text = ":";
            // 
            // filterURLText
            // 
            filterURLText.Location = new Point(3, 43);
            filterURLText.Margin = new Padding(3, 4, 3, 4);
            filterURLText.Name = "filterURLText";
            filterURLText.PlaceholderText = "Filter URL";
            filterURLText.Size = new Size(923, 27);
            filterURLText.TabIndex = 1;
            // 
            // hourFilterText
            // 
            hourFilterText.Location = new Point(746, 4);
            hourFilterText.Margin = new Padding(3, 4, 3, 4);
            hourFilterText.MaxLength = 2;
            hourFilterText.Name = "hourFilterText";
            hourFilterText.PlaceholderText = "24";
            hourFilterText.Size = new Size(33, 27);
            hourFilterText.TabIndex = 12;
            // 
            // filterTitleText
            // 
            filterTitleText.Location = new Point(3, 4);
            filterTitleText.Margin = new Padding(3, 4, 3, 4);
            filterTitleText.Name = "filterTitleText";
            filterTitleText.PlaceholderText = "Filter Title";
            filterTitleText.Size = new Size(489, 27);
            filterTitleText.TabIndex = 0;
            // 
            // minFilterText
            // 
            minFilterText.Location = new Point(777, 4);
            minFilterText.Margin = new Padding(3, 4, 3, 4);
            minFilterText.MaxLength = 2;
            minFilterText.Name = "minFilterText";
            minFilterText.PlaceholderText = "59";
            minFilterText.Size = new Size(36, 27);
            minFilterText.TabIndex = 11;
            // 
            // filterDate
            // 
            filterDate.Location = new Point(499, 4);
            filterDate.Margin = new Padding(3, 4, 3, 4);
            filterDate.Name = "filterDate";
            filterDate.Size = new Size(239, 27);
            filterDate.TabIndex = 10;
            filterDate.Value = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // idText
            // 
            idText.Location = new Point(221, 4);
            idText.Margin = new Padding(3, 4, 3, 4);
            idText.MaxLength = 8;
            idText.Name = "idText";
            idText.PlaceholderText = "Change this ID";
            idText.Size = new Size(111, 27);
            idText.TabIndex = 8;
            // 
            // actionSelect
            // 
            actionSelect.DisplayMember = "Insert";
            actionSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            actionSelect.FormattingEnabled = true;
            actionSelect.Items.AddRange(new object[] { "Insert", "Update", "Delete" });
            actionSelect.Location = new Point(3, 4);
            actionSelect.Margin = new Padding(3, 4, 3, 4);
            actionSelect.Name = "actionSelect";
            actionSelect.Size = new Size(210, 28);
            actionSelect.TabIndex = 0;
            actionSelect.SelectedIndexChanged += actionSelect_SelectedIndexChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 853);
            Controls.Add(panel1);
            Controls.Add(dataGrid);
            Controls.Add(helpFilePanel);
            Controls.Add(helpBtn);
            Controls.Add(openFileBtn);
            Controls.Add(pathText);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "History Manipulator";
            Load += MainForm_Load;
            helpFilePanel.ResumeLayout(false);
            helpFilePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) dataGrid).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            startPanel.ResumeLayout(false);
            startPanel.PerformLayout();
            filterPanel.ResumeLayout(false);
            filterPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private TextBox pathText;
        private Button openFileBtn;
        private Button helpBtn;
        private Panel helpFilePanel;
        private Label des1;
        private TextBox des2;
        private DataGridView dataGrid;
        private Panel panel1;
        private ComboBox actionSelect;
        private TextBox titleText;
        private TextBox urlText;
        private DateTimePicker dateValue;
        private Label des3;
        private TextBox hourText;
        private TextBox minuteText;
        private Button startBtn;
        private TextBox idText;
        private Panel filterPanel;
        private TextBox filterTitleText;
        private Button filterBtn;
        private Label label1;
        private TextBox filterURLText;
        private TextBox hourFilterText;
        private TextBox minFilterText;
        private DateTimePicker filterDate;
        private Panel startPanel;
        private Button searchIDBtn;
        private Label IDInfo;
    }
}