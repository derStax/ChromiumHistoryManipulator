using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace ChromiumHistoryManipulator {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }
        const string SAVE_PATH = "local.txt";
        private void MainForm_Load(object sender, EventArgs e) {
            minuteText.Text = DateTime.Now.Minute.ToString();
            hourText.Text = DateTime.Now.Hour.ToString();
            SetTimeWith00();

            actionSelect.SelectedIndex = 0;

            if(File.Exists(SAVE_PATH)) {
                string[] content = File.ReadAllLines(SAVE_PATH);
                if(content.Length <= 0)
                    return;

                if(!File.Exists(content[0]))
                    return;

                pathText.Text = content[0];
                _dbPath = content[0];
                InitializeDatabase();
            } else {
                File.Create(SAVE_PATH).Close();
            }
        }

        private void SetTimeWith00() {
            if(minuteText.Text.Length == 1) {
                minuteText.Text = "0" + minuteText.Text;
            } else if(minuteText.Text.Length == 0) {
                minuteText.Text = "00";
            }
            
            if(hourText.Text.Length == 1) {
                hourText.Text = "0" + hourText.Text;
            } else if(hourText.Text.Length == 0) {
                hourText.Text = "00";
            }
        }


        private void OverrideLineSaveFile(int line, string newContent) {
            List<string> content = File.ReadAllLines(SAVE_PATH).ToList();
            if(content.Count > line) {
                content[line] = newContent;
            } else {
                while(content.Count < line) {
                    content.Add("EMPTY LINE : " + line + " FOR: " + newContent);
                }
                content.Add(newContent);
            }

            File.WriteAllLines(SAVE_PATH, content);
        }

        string _dbPath = string.Empty;
        private void OpenFileBtn_Click(object sender, EventArgs e) {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Select the \"History\" file from your Chromium Browser";

            file.ShowDialog();

            pathText.Text = file.FileName;
            _dbPath = file.FileName;

            if(!File.Exists(_dbPath)) {
                OpenFileBtn_Click(null, null);
                return;
            }

            OverrideLineSaveFile(0, _dbPath);

            InitializeDatabase();
        }

        private DataTable _dT = new();
        public void InitializeDatabase() {
            using(var connection = new SQLiteConnection("data source=" + _dbPath)) {
                connection.Open();
                /*
                int x = 0;
                if(x == 0) {
                    SQLiteDataAdapter data = new("SELECT id as ID, title as Title, url as URL, last_visit_time FROM urls", connection);
                    data.Fill(_dT);
                    dataGrid.DataSource = _dT;
                } else if(x == 1) {
                    SQLiteDataAdapter data = new("SELECT id as ID, url as URL, visit_time FROM visits", connection);
                    data.Fill(_dT);
                    dataGrid.DataSource = _dT;
                }
                */
                SQLiteDataAdapter data = new("SELECT * FROM visits", connection);
                data.Fill(_dT);
                dataGrid.DataSource = _dT;
                connection.Close();
            }
        }
        private void StartBtn_Click(object sender, EventArgs e) {
            switch(actionSelect.SelectedIndex) {
                case 0: // insert
                    InsertHistory();
                    break;

                case 1: // update
                    UpdateHistory();
                    break;

                case 2: // delete

                    break;

                default:
                    MessageBox.Show("Wrong Acion Index!");
                    break;
            }
        }

        private long GetTimeFromInput(DateTimePicker calen, TextBox minuteT, TextBox hourT) {
            DateTime dt = calen.Value;
            if(!int.TryParse(minuteT.Text, out int min)) {
                return -1;
            }
            if(!int.TryParse(hourT.Text, out int hour)) {
                return -1;
            }
            dt = dt.Add(new TimeSpan(hour, min, 0));
            return dt.ToFileTime() / 10;
        }

        long insertNewID = 0;


        /// <summary>
        /// REWORK NEEDED: 
        /// search for url of website in "urls", if existent use that key inside "URL" of "visits",
        /// otherwise, create new "urls" entry.
        /// </summary>
        private void InsertHistory() {
            List<long> urlIDs = new();
            List<long> visitIDs = new();
            using(var connection = new SQLiteConnection("data source=" + _dbPath)) {
                connection.Open();
                using(SQLiteCommand cmd = new SQLiteCommand(connection)) {
                    cmd.CommandText = "SELECT * FROM urls";
                    using(SQLiteDataReader reader = cmd.ExecuteReader()) {
                        while(reader.Read()) {
                            urlIDs.Add((long) reader["id"]);
                        }
                    }
                }
                using(SQLiteCommand cmd = new SQLiteCommand(connection)) {
                    cmd.CommandText = "SELECT * FROM visits";
                    using(SQLiteDataReader reader = cmd.ExecuteReader()) {
                        while(reader.Read()) {
                            visitIDs.Add((long) reader["id"]);
                        }
                    }
                }
                bool reCheck;
                insertNewID = GetNewID();
                long GetNewID() {
                    reCheck = false;
                    for(int i = 0; i < urlIDs.Count; i++) {
                        if(insertNewID == urlIDs[i]) {
                            insertNewID++;
                            reCheck = true;
                        }
                    }
                    for(int i = 0; i < visitIDs.Count; i++) {
                        if(insertNewID == visitIDs[i]) {
                            insertNewID++;
                            reCheck = true;
                        }
                    }
                    if(reCheck) {
                        return GetNewID();
                    }
                    return insertNewID;
                }

                long time = GetTimeFromInput(dateValue, minuteText, hourText);
                if(ValidInput(time)) {

                    List<string> entries = new List<string>();
                    using(SQLiteCommand cmd = new SQLiteCommand(connection)) {
                        cmd.CommandText = $"SELECT * FROM urls WHERE urls.last_visit_time = {time}";
                        using(SQLiteDataReader reader = cmd.ExecuteReader()) {
                            while(reader.Read()) {
                                entries.Add((string) reader["url"]);
                            }
                        }
                    }
                    foreach(string entry in entries) {
                        if(entry == urlText.Text) {
                            DialogResult x = MessageBox.Show("There is already an entry with this URL at that time. ", "Double entry?", MessageBoxButtons.OKCancel);
                            if(x == DialogResult.Cancel) {
                                MessageBox.Show("INSERT Command canceled.");
                                connection.Close();
                                return;
                            } else {
                                break;
                            }
                        }
                    }

                    string query = $"INSERT INTO urls VALUES ({insertNewID}, \"{urlText.Text}\", \"{titleText.Text}\", 1, 0, {time}, 0);";
                    string quer2 = $"INSERT INTO visits VALUES ({insertNewID}, {insertNewID}, {time}, 0, 805306376, 0, 10000, 0, 0, \"\", 0, 0, 0, 0, 1, \"\", 0);";
                    using(SQLiteCommand cmd = new(connection)) {
                        cmd.CommandText = query + quer2;
                        cmd.ExecuteReader();
                    }

                }
                connection.Close();
            }
            InitializeDatabase();
        }
        private bool ValidInput(long time) {
            if(!urlText.Text.Contains("http")) {
                MessageBox.Show("Please insert a valid URL.");
                return false;
            }
            if(titleText.Text.Length <= 0) {
                MessageBox.Show("Please insert a title.");
                return false;
            }
            if(time <= 0) {
                MessageBox.Show("Please insert valid time values.");
                return false;
            }
            return true;
        }

        private void SetupUpdateHistory(DataRow r) {
            urlText.Text = r["url"].ToString();
            titleText.Text = r["title"].ToString();
            long x = (long)r["visit_time"] * 10;
            DateTime dt = DateTime.FromFileTime(x);
            int m = dt.Minute;
            int h = dt.Hour;
            dt.AddMinutes(-m);
            dt.AddSeconds(-dt.Second);
            dt.AddHours(-h);
            dateValue.Value = dt;
            minuteText.Text = m.ToString();
            hourText.Text = h.ToString();
            SetTimeWith00();
        }
        private void UpdateHistory() {
            using(var connection = new SQLiteConnection("data source=" + _dbPath)) {
                connection.Open();

                /**
                 * Search for input URL in URL Table, if non existent, create and use key, else copy key and use.
                 * 
                 * 
                 */

                long time = GetTimeFromInput(dateValue, minuteText, hourText);
                if(ValidInput(time)) {
                    string quer2 = $"UPDATE visits " +
                    $"SET title = '{titleText.Text}', " +
                    $"    visit_time = {time}," +
                    $"    "; /// URL CHANGE
                    using(SQLiteCommand cmd = new(connection)) {
                        cmd.CommandText = quer2;
                        cmd.ExecuteReader();
                    }
                }
                connection.Close();
            }
        }

        private void DeleteHistory() {

        }


        private bool _showsHelp = false;
        private void HelpBtn_Click(object sender, EventArgs e) {
            _showsHelp = !_showsHelp;

            if(_showsHelp) {
                helpFilePanel.Show();
                dataGrid.Hide();
            } else {
                helpFilePanel.Hide();
                dataGrid.Show();
            }
        }
        private void actionSelect_SelectedIndexChanged(object sender, EventArgs e) {
            IDInfo.Hide();

            switch(actionSelect.SelectedIndex) {
                case 0: // insert
                    idText.Hide();
                    searchIDBtn.Hide();
                    filterPanel.Hide();
                    startPanel.Show();
                    break;

                case 1: // update
                    idText.Show();
                    searchIDBtn.Show();
                    filterPanel.Show();
                    startPanel.Hide();
                    break;

                case 2: // delete
                    idText.Show();
                    searchIDBtn.Show();
                    filterPanel.Show();
                    startPanel.Hide();
                    break;

                default:
                    MessageBox.Show("Wrong Acion Index!");
                    break;
            }
        }

        private void FilterBtn_Click(object sender, EventArgs e) {
            using(var connection = new SQLiteConnection("data source=" + _dbPath)) {
                connection.Open();

                string whereQuery = "WHERE";
                bool addAnd = false;
                long time = GetTimeFromInput(filterDate, minFilterText, hourFilterText);
                if(time > 0) {
                    whereQuery += addAnd ? " AND " : "";
                    whereQuery += $" v.visit_time BETWEEN {time - 180000000} AND {time + 180000000}";
                    addAnd = true;
                }
                if(filterTitleText.Text.Length >= 1) {
                    whereQuery += addAnd ? " AND " : "";
                    whereQuery += $"(u.title LIKE '%{filterTitleText.Text}%')";
                    addAnd = true;
                }
                if(filterURLText.Text.Length >= 1) {
                    whereQuery += addAnd ? " AND " : "";
                    whereQuery += $"(u.url LIKE '%{filterURLText.Text}%')";
                    addAnd = true;
                }
                whereQuery = whereQuery.Length == 5 ? "" : whereQuery + ";";

                SQLiteDataAdapter data =
                    new("SELECT u.id as URLID, v.id as VID, u.title, v.visit_time, u.url, " +
                    "datetime(v.visit_time / 1000000 + (strftime('%s', '1601-01-01')), 'unixepoch', 'localtime')" +
                    "FROM visits AS v JOIN urls AS u ON v.url == u.id " + whereQuery, connection);

                _dT = new();
                data.Fill(_dT);
                dataGrid.DataSource = _dT;
                connection.Close();
            }
        }

        private void SearchIDBtn_Click(object sender, EventArgs e) {
            if(!int.TryParse(idText.Text, out int id)) {
                MessageBox.Show("Insert a valid ID first.");
                return;
            }

            using(var connection = new SQLiteConnection("data source=" + _dbPath)) {
                connection.Open();

                SQLiteDataAdapter data =
                    new("SELECT u.id as URLID, v.id as VID, u.title, v.visit_time, u.url, " +
                    "datetime(v.visit_time / 1000000 + (strftime('%s', '1601-01-01')), 'unixepoch', 'localtime')" +
                    $"FROM visits AS v JOIN urls AS u ON v.url == u.id WHERE v.id == {id}", connection);
                _dT = new();
                data.Fill(_dT);
                dataGrid.DataSource = _dT;
                if(_dT.Rows.Count <= 0) {
                    MessageBox.Show("No entry found with that ID.");
                    return;
                }
                IDInfo.Show();
                IDInfo.Text = $"Success. {id} is selected.";
                switch(actionSelect.SelectedIndex) {
                    case 1: // update
                        idText.Hide();
                        searchIDBtn.Hide();
                        filterPanel.Hide();
                        startPanel.Show();
                        SetupUpdateHistory(_dT.Select()[0]);
                        break;

                    case 2: // delete
                        
                        break;

                    default:
                        MessageBox.Show("Wrong Acion Index!");
                        break;
                }


                connection.Close();
            }
        }
    }
}