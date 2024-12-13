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
        private DateTimePicker dateTimePickerSchedule;
        private Button buttonAddClass;
        private DataGridView dataGridClasses;

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

            // Class Name
            Label labelName = new Label
            {
                Text = "Class Name:",
                Location = new Point(20, 20),
                AutoSize = true
            };
            textBoxName = new TextBox
            {
                Location = new Point(150, 20),
                Width = 300
            };

            // Date and Time
            Label labelSchedule = new Label
            {
                Text = "Date and Time:",
                Location = new Point(20, 60),
                AutoSize = true
            };
            dateTimePickerSchedule = new DateTimePicker
            {
                Location = new Point(150, 60),
                Width = 300,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "yyyy-MM-dd HH:mm",
                ShowUpDown = true,
                Font = new Font("Arial", 12, FontStyle.Bold), // Larger and bolder font style
                CalendarFont = new Font("Arial", 10, FontStyle.Regular),
                BackColor = Color.White,
                ForeColor = Color.Black,
                Margin = new Padding(10)
            };

            // Trainer Selection
            Label labelTrainer = new Label
            {
                Text = "Trainer:",
                Location = new Point(20, 100),
                AutoSize = true
            };
            comboBoxTrainer = new ComboBox
            {
                Location = new Point(150, 100),
                Width = 300,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Class Type
            Label labelClassType = new Label
            {
                Text = "Class Type:",
                Location = new Point(20, 140),
                AutoSize = true
            };
            comboBoxClassType = new ComboBox
            {
                Location = new Point(150, 140),
                Width = 300,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboBoxClassType.Items.AddRange(new[] { "Fitness", "Yoga", "Kick Box" });

            // Add Button
            buttonAddClass = new Button
            {
                Text = "Add Class",
                Location = new Point(150, 200),
                Width = 100
            };
            buttonAddClass.Click += ButtonAddClass_Click;

            // DataGridView
            dataGridClasses = new DataGridView
            {
                Location = new Point(20, 250),
                Size = new Size(740, 250),
                AutoGenerateColumns = false,
                AllowUserToAddRows = false
            };

            dataGridClasses.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Class Name",
                DataPropertyName = "Name",
                Width = 150
            });
            dataGridClasses.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Date and Time",
                DataPropertyName = "Schedule",
                Width = 150
            });
            dataGridClasses.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Class Type",
                DataPropertyName = "ClassType",
                Width = 150
            });
            dataGridClasses.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Trainer Name",
                DataPropertyName = "TrainerName",
                Width = 150
            });

            // Delete button
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Width = 100,
                Name = "Delete" // Explicitly set the 'Name' property
            };

            dataGridClasses.Columns.Add(deleteButtonColumn);

            // Add event for clicking the DataGridView
            dataGridClasses.CellClick += DataGridClasses_CellClick;

            // Add controls to the form
            this.Controls.Add(labelName);
            this.Controls.Add(textBoxName);
            this.Controls.Add(labelSchedule);
            this.Controls.Add(dateTimePickerSchedule);
            this.Controls.Add(labelTrainer);
            this.Controls.Add(comboBoxTrainer);
            this.Controls.Add(labelClassType);
            this.Controls.Add(comboBoxClassType);
            this.Controls.Add(buttonAddClass);
            this.Controls.Add(dataGridClasses);

            this.Load += ClassForm_Load;
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
                string connectionString = "Data Source=DESKTOP-M4M4Q6P;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";
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
                string connectionString = "Data Source=DESKTOP-M4M4Q6P;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";
                string query = "SELECT ClassID, Name, Schedule, ClassType, FirstName + ' ' + LastName AS TrainerName FROM Class INNER JOIN Trainer ON Class.TrainerID = Trainer.TrainerID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Add the ClassID column explicitly if it's not present
                    if (!dataGridClasses.Columns.Contains("ClassID"))
                    {
                        dataGridClasses.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            HeaderText = "ClassID",
                            DataPropertyName = "ClassID",
                            Visible = false // You can hide this column since it's just for reference
                        });
                    }

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
            DateTime schedule = dateTimePickerSchedule.Value;
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
                string connectionString = "Data Source=DESKTOP-M4M4Q6P;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";
                string query = "INSERT INTO Class (Name, Schedule, TrainerID, ClassType) VALUES (@Name, @Schedule, @TrainerID, @ClassType)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", className);
                        command.Parameters.AddWithValue("@Schedule", schedule);
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
            comboBoxTrainer.SelectedIndex = 0;
            comboBoxClassType.SelectedIndex = 0;
            dateTimePickerSchedule.Value = DateTime.Now;
        }

        private void DataGridClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If the "Delete" button is clicked
            if (e.ColumnIndex == dataGridClasses.Columns["Delete"].Index)
            {
                var classID = dataGridClasses.Rows[e.RowIndex].Cells["ClassID"].Value;
                if (classID != null)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this class?", "Delete", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            string connectionString = "Data Source=DESKTOP-M4M4Q6P;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";
                            string query = "DELETE FROM Class WHERE ClassID = @ClassID";

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@ClassID", classID);
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("Class successfully deleted.");
                                    LoadClassData(); // Update the class list
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}");
                        }
                    }
                }
            }
        }
    }
}
