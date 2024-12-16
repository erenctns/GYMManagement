using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GYMProject
{
    public partial class Class : Form
    {
        private TextBox textBoxName;
        private ComboBox comboBoxTrainer;
        private ComboBox comboBoxClassType;
        private DateTimePicker datePicker;
        private DateTimePicker timePicker;
        private Button buttonAddClass;
        private DataGridView dataGridClasses;
        private Button buttonViewMembers;

        public Class()
        {
            InitializeComponent();
            InitializeClassForm();
        }

        private void InitializeClassForm()
        {
            this.Text = "Add New Class";
            this.Size = new System.Drawing.Size(1200, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Panel for Class Form (to center align controls)
            Panel panelForm = new Panel
            {
                Size = new Size(500, 250), // Fixed size
                Location = new Point((this.ClientSize.Width - 500) / 2, 20), // Center align
                Anchor = AnchorStyles.Top,
            };

            // Class Name
            Label labelName = new Label { Text = "Class Name:", Location = new Point(10, 10), AutoSize = true };
            textBoxName = new TextBox { Location = new Point(150, 10), Width = 300 };

            // Date and Time Section
            Label labelDate = new Label { Text = "Date:", Location = new Point(10, 50), AutoSize = true };
            datePicker = new DateTimePicker
            {
                Location = new Point(150, 50),
                Width = 140,
                Format = DateTimePickerFormat.Short,  // Short format (only Date)
                ShowUpDown = false,
                CustomFormat = "yyyy-MM-dd",  // Custom format for date
            };

            Label labelTime = new Label { Text = "Time:", Location = new Point(300, 50), AutoSize = true };
            timePicker = new DateTimePicker
            {
                Location = new Point(350, 50),
                Width = 140,
                Format = DateTimePickerFormat.Custom,  // Time format
                CustomFormat = "HH:mm",  // 24-hour time format
                ShowUpDown = true  // Use up/down buttons for time
            };

            // Trainer Selection
            Label labelTrainer = new Label { Text = "Trainer:", Location = new Point(10, 90), AutoSize = true };
            comboBoxTrainer = new ComboBox { Location = new Point(150, 90), Width = 300, DropDownStyle = ComboBoxStyle.DropDownList };

            // Class Type
            Label labelClassType = new Label { Text = "Class Type:", Location = new Point(10, 130), AutoSize = true };
            comboBoxClassType = new ComboBox
            {
                Location = new Point(150, 130),
                Width = 300,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboBoxClassType.Items.AddRange(new[] { "Fitness", "Yoga", "Kick Box" });

            // Add Button
            buttonAddClass = new Button { Text = "Add Class", Location = new Point(200, 180), Width = 100 };
            buttonAddClass.Click += ButtonAddClass_Click;

            // View Members Button
            buttonViewMembers = new Button { Text = "View Members", Location = new Point(320, 180), Width = 100 };
            buttonViewMembers.Click += ButtonViewMembers_Click;

            // Add controls to the form panel
            panelForm.Controls.Add(labelName);
            panelForm.Controls.Add(textBoxName);
            panelForm.Controls.Add(labelDate);
            panelForm.Controls.Add(datePicker);
            panelForm.Controls.Add(labelTime);
            panelForm.Controls.Add(timePicker);
            panelForm.Controls.Add(labelTrainer);
            panelForm.Controls.Add(comboBoxTrainer);
            panelForm.Controls.Add(labelClassType);
            panelForm.Controls.Add(comboBoxClassType);
            panelForm.Controls.Add(buttonAddClass);
            panelForm.Controls.Add(buttonViewMembers);

            // DataGridView
            dataGridClasses = new DataGridView
            {
                Location = new Point(0, panelForm.Bottom + 20),
                Size = new Size(this.ClientSize.Width, 250), // Fill the screen width
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, // Adjust columns to fill space
            };

            // Add Columns
            if (dataGridClasses.Columns["ClassID"] == null)
            {
                dataGridClasses.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ClassID",  // Name is ClassID for accessing
                    HeaderText = "Class ID",
                    DataPropertyName = "ClassID",
                    Visible = false // ClassID hidden in DataGridView
                });
            }

            dataGridClasses.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Class Name", DataPropertyName = "Name" });
            dataGridClasses.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Date and Time", DataPropertyName = "Schedule" });
            dataGridClasses.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Class Type", DataPropertyName = "ClassType" });
            dataGridClasses.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trainer Name", DataPropertyName = "TrainerName" });

            // Delete Button
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            dataGridClasses.Columns.Add(deleteButtonColumn);

            // View Members Button
            DataGridViewButtonColumn viewMembersButtonColumn = new DataGridViewButtonColumn
            {
                Name = "ViewMembers",
                HeaderText = "View Members",
                Text = "View Members",
                UseColumnTextForButtonValue = true
            };
            dataGridClasses.Columns.Add(viewMembersButtonColumn);

            // Add to the Form
            this.Controls.Add(panelForm);
            this.Controls.Add(dataGridClasses);
            this.Load += ClassForm_Load;
            dataGridClasses.CellClick += DataGridClasses_CellClick;
        }

        private void ClassForm_Load(object sender, EventArgs e)
        {
            LoadTrainerData();
            LoadClassData();
            comboBoxClassType.SelectedIndex = 0; // Default selection
        }

        private void LoadTrainerData()
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-FAT5F5N\\SQLEXPRESS01;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";
                string query = "SELECT TrainerID, FirstName + ' ' + LastName AS FullName, Specialization FROM Trainer";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    comboBoxTrainer.DataSource = dataTable;
                    comboBoxTrainer.DisplayMember = "FullName";
                    comboBoxTrainer.ValueMember = "TrainerID";
                    comboBoxTrainer.Tag = dataTable; // Store trainer specialization for validation
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void LoadClassData()
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-FAT5F5N\\SQLEXPRESS01;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";
                string query = "SELECT ClassID, Name, Schedule, ClassType, FirstName + ' ' + LastName AS TrainerName FROM Class INNER JOIN Trainer ON Class.TrainerID = Trainer.TrainerID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Veriyi DataGridView'e yükle
                    dataGridClasses.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ButtonAddClass_Click(object sender, EventArgs e)
        {
            string className = textBoxName.Text.Trim();
            DateTime scheduleDate = datePicker.Value;  // Get selected date
            DateTime scheduleTime = timePicker.Value;  // Get selected time

            // Combine Date and Time
            DateTime fullSchedule = new DateTime(
                scheduleDate.Year, scheduleDate.Month, scheduleDate.Day,
                scheduleTime.Hour, scheduleTime.Minute, 0);  // Combine date and time

            int trainerId = (int)comboBoxTrainer.SelectedValue;
            string classType = comboBoxClassType.SelectedItem.ToString();

            // Trainer specialization validation
            DataTable trainerData = (DataTable)comboBoxTrainer.Tag;
            DataRow selectedTrainer = trainerData.AsEnumerable()
                .FirstOrDefault(row => (int)row["TrainerID"] == trainerId);

            if (selectedTrainer == null || selectedTrainer["Specialization"].ToString() != classType)
            {
                MessageBox.Show("The selected trainer is not suitable for the class type.");
                return;
            }

            try
            {
                string connectionString = "Data Source=DESKTOP-FAT5F5N\\SQLEXPRESS01;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";
                string query = "INSERT INTO Class (Name, Schedule, TrainerID, ClassType) VALUES (@Name, @Schedule, @TrainerID, @ClassType)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", className);
                        command.Parameters.AddWithValue("@Schedule", fullSchedule);  // Use combined DateTime
                        command.Parameters.AddWithValue("@TrainerID", trainerId);
                        command.Parameters.AddWithValue("@ClassType", classType);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Class successfully added.");
                        ClearFormFields();
                        LoadClassData(); // Update the list
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ClearFormFields()
        {
            textBoxName.Clear();
            comboBoxTrainer.SelectedIndex = -1;
            comboBoxClassType.SelectedIndex = -1;
            datePicker.Value = DateTime.Now;
            timePicker.Value = DateTime.Now;
        }

        private void DataGridClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridClasses.Columns["Delete"].Index)
            {
                // "Delete" butonuna tıklanmışsa işlemler burada
                var classID = dataGridClasses.Rows[e.RowIndex].Cells["ClassID"].Value;

                DialogResult result = MessageBox.Show("Are you sure you want to delete this class?", "Delete Class", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string connectionString = "Data Source=DESKTOP-FAT5F5N\\SQLEXPRESS01;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";
                        string query = "DELETE FROM Class WHERE ClassID = @ClassID";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@ClassID", classID);
                                command.ExecuteNonQuery();
                                MessageBox.Show("Class successfully deleted.");
                                LoadClassData(); // Reload the data after deletion
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
            else if (e.ColumnIndex == dataGridClasses.Columns["ViewMembers"].Index)
            {
                // "View Members" butonuna tıklanmışsa işlemler burada
                int classID = (int)dataGridClasses.Rows[e.RowIndex].Cells["ClassID"].Value;
                ClassMembers classMembersForm = new ClassMembers(classID);
                classMembersForm.Show();
            }
        }

        // View Members Button Click event handler
        private void ButtonViewMembers_Click(object sender, EventArgs e)
        {
            // View members related to the selected class
            if (dataGridClasses.SelectedRows.Count > 0)
            {
                int selectedClassID = (int)dataGridClasses.SelectedRows[0].Cells["ClassID"].Value;
                ClassMembers classMembersForm = new ClassMembers(selectedClassID);
                classMembersForm.Show();
            }
        }
    }
}
