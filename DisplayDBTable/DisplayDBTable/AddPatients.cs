using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DisplayDBTable
{
    public partial class AddPatients : Form
    {
        private readonly SqlConnection connection;
        private readonly Form1 parentForm;

        public AddPatients(SqlConnection conn, Form1 parent)
        {
            InitializeComponent();
            connection = conn;
            parentForm = parent;
        }
        string connectionString;
        private int selectedGenderID;

        private void addBtn_Click(object sender, EventArgs e)

        {
            connectionString = "Data Source=DESKTOP-9CHL98U\\SQLEXPRESS;Database=PatientsDemo;Integrated Security=true";
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                // Open the database connection
                sqlCon.Open();

                // INSERT INTO Patients
                string insertQuery = "INSERT INTO Patients (FullName, Dob, GenderID, Phone, Address, Email,certificateID) VALUES (@FullName, @Dob, @GenderID, @Phone, @Address, @Email, @certificateID)";

                using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlCon))
                {

                    if (string.IsNullOrWhiteSpace(fullNameField.Text) || string.IsNullOrWhiteSpace(dateOfBirthField.Text) || selectedGenderID == -1)
                    {
                        MessageBox.Show("Please fill in all mandatory fields: Full Name, Date of Birth, and Gender.");
                        return;
                    }

                    // Validate Date of Birth
                    if (!DateTime.TryParse(dateOfBirthField.Text, out DateTime dob))
                    {
                        MessageBox.Show("Invalid Date of Birth. Please enter a valid date in the format YYYY-MM-DD.");
                        return;
                    }

                    // Validate phone number (if provided)
                    string phone = phoneField.Text.Trim();
                    if (!string.IsNullOrEmpty(phone))
                    {
                        if (!phone.StartsWith("5") || phone.Length != 9 || !IsNumeric(phone))
                        {
                            MessageBox.Show("Invalid phone number. It should start with '5' and be 9 digits long.");
                            return;
                        }
                    }
                    string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

                    Regex regex = new Regex(pattern);

                    bool isValid = regex.IsMatch(emailFieldValue.Text);

                    if (isValid)
                    {
                        MessageBox.Show("Valid email address!");
                        MessageBox.Show(emailFieldValue.Text);
                        sqlCommand.Parameters.AddWithValue("@Email", emailFieldValue.Text);
                    }
                    else
                    {
                        MessageBox.Show("Invalid email address!");
                        MessageBox.Show(emailFieldValue.Text);
                        this.Close();
                    }





                    // Create parameters for the INSERT query
                    sqlCommand.Parameters.AddWithValue("@FullName", fullNameField.Text);
                    sqlCommand.Parameters.AddWithValue("@Dob", dateOfBirthField.Text);
                    sqlCommand.Parameters.AddWithValue("@Phone", phoneField.Text);
                    sqlCommand.Parameters.AddWithValue("@Address", addressField.Text);
                    sqlCommand.Parameters.AddWithValue("@ID", idField.Text);



                    // Execute the INSERT query
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record inserted successfully.");
                        // Reload data after inserting
                        parentForm.LoadData();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Error inserting record.");
                    }
                }

            }

        }

        private void maleBtn_CheckedChanged(object sender, EventArgs e)
        {

            connectionString = "Data Source=DESKTOP-9CHL98U\\SQLEXPRESS;Database=PatientsDemo;Integrated Security=true";
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                // Open the database connection
                sqlCon.Open();

                // INSERT INTO Patients
                string insertQuery = "INSERT INTO Patients (FullName, Dob, GenderID, Phone, Address, Email,certificateID) VALUES (@FullName, @Dob, @GenderID, @Phone, @Address, @Email, @certificateID)";

                using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlCon))
                {


                    if (string.IsNullOrWhiteSpace(fullNameField.Text) || string.IsNullOrWhiteSpace(dateOfBirthField.Text) || selectedGenderID == -1)
                    {
                        MessageBox.Show("Please fill in all mandatory fields: Full Name, Date of Birth, and Gender.");
                        return;
                    }

                    // Validate Date of Birth
                    if (!DateTime.TryParse(dateOfBirthField.Text, out DateTime dob))
                    {
                        MessageBox.Show("Invalid Date of Birth. Please enter a valid date in the format YYYY-MM-DD.");
                        return;
                    }
                    // Validate phone number (if provided)
                    string phone = phoneField.Text.Trim();
                    if (!string.IsNullOrEmpty(phone))
                    {
                        if (!phone.StartsWith("5") || phone.Length != 9 || !IsNumeric(phone))
                        {
                            MessageBox.Show("Invalid phone number. It should start with '5' and be 9 digits long.");
                            return;
                        }
                    }
                    string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

                    Regex regex = new Regex(pattern);

                    bool isValid = regex.IsMatch(emailFieldValue.Text);

                    if (isValid)
                    {
                        MessageBox.Show("Valid email address!");
                        MessageBox.Show(emailFieldValue.Text);
                        sqlCommand.Parameters.AddWithValue("@Email", emailFieldValue.Text);
                    }
                    else
                    {
                        MessageBox.Show("Invalid email address!");
                        MessageBox.Show(emailFieldValue.Text);
                        this.Close();
                    }



                    // Create parameters for the INSERT query
                    sqlCommand.Parameters.AddWithValue("@FullName", fullNameField.Text);
                    sqlCommand.Parameters.AddWithValue("@Dob", dateOfBirthField.Text);
                    sqlCommand.Parameters.AddWithValue("@GenderID", 1);
                    sqlCommand.Parameters.AddWithValue("@Phone", phoneField.Text);
                    sqlCommand.Parameters.AddWithValue("@Address", addressField.Text);
                    sqlCommand.Parameters.AddWithValue("@certificateID", idField.Text);


                    // Execute the INSERT query
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record inserted successfully.");
                        // Reload data after inserting
                        parentForm.LoadData();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Error inserting record.");
                    }
                }

            }

        }

        private void femaleBtn_CheckedChanged(object sender, EventArgs e)
        {
            connectionString = "Data Source=DESKTOP-9CHL98U\\SQLEXPRESS;Database=PatientsDemo;Integrated Security=true";
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                // Open the database connection
                sqlCon.Open();

                // INSERT INTO Patients
                string insertQuery = "INSERT INTO Patients (FullName, Dob, GenderID, Phone, Address, Email,certificateID) VALUES (@FullName, @Dob, @GenderID, @Phone, @Address, @Email, @certificateID)";

                using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlCon))
                {

                    if (string.IsNullOrWhiteSpace(fullNameField.Text) || string.IsNullOrWhiteSpace(dateOfBirthField.Text) || selectedGenderID == -1)
                    {
                        MessageBox.Show("Please fill in all mandatory fields: Full Name, Date of Birth, and Gender.");
                        return;

                    }

                    // Validate Date of Birth
                    if (!DateTime.TryParse(dateOfBirthField.Text, out DateTime dob))
                    {
                        MessageBox.Show("Invalid Date of Birth. Please enter a valid date in the format YYYY-MM-DD.");
                        return;
                    }

                    // Validate phone number (if provided)
                    string phone = phoneField.Text.Trim();
                    if (!string.IsNullOrEmpty(phone))
                    {
                        if (!phone.StartsWith("5") || phone.Length != 9 || !IsNumeric(phone))
                        {
                            MessageBox.Show("Invalid phone number. It should start with '5' and be 9 digits long.");
                            return;
                        }
                    }

                    string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

                    Regex regex = new Regex(pattern);

                    bool isValid = regex.IsMatch(emailFieldValue.Text);

                    if (isValid)
                    {
                        MessageBox.Show("Valid email address!");
                        MessageBox.Show(emailFieldValue.Text);
                        sqlCommand.Parameters.AddWithValue("@Email", emailFieldValue.Text);
                    }
                    else
                    {
                        MessageBox.Show("Invalid email address!");
                        MessageBox.Show(emailFieldValue.Text);
                        this.Close();
                    }



                    // Create parameters for the INSERT query

                    sqlCommand.Parameters.AddWithValue("@FullName", fullNameField.Text);
                    sqlCommand.Parameters.AddWithValue("@Dob", dateOfBirthField.Text);
                    sqlCommand.Parameters.AddWithValue("@GenderID", 2);
                    sqlCommand.Parameters.AddWithValue("@Phone", phoneField.Text);
                    sqlCommand.Parameters.AddWithValue("@Address", addressField.Text);
                    sqlCommand.Parameters.AddWithValue("@Email", emailField.Text);
                    sqlCommand.Parameters.AddWithValue("@certificateID", idField.Text);



                    // Execute the INSERT query
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record inserted successfully.");
                        // Reload data after inserting
                        parentForm.LoadData();
                        this.Close();


                    }
                    else
                    {
                        MessageBox.Show("Error inserting record.");
                    }
                }

            }
        }





        private bool IsNumeric(string str)
        {
            return int.TryParse(str, out _);
        }
    }

}
