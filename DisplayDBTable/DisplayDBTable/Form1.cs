using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DisplayDBTable
{
    public partial class Form1 : Form
    {
        readonly string connectionString = "Data Source=DESKTOP-9CHL98U\\SQLEXPRESS;Database=PatientsDemo; Integrated Security=true";
        private SqlDataAdapter sqlDa;
        private DataTable dtbl;
        private SqlConnection sqlConnection;


        public Form1()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            LoadData();
            dgv1.CellEndEdit += dgv1_CellEndEdit;
        }

        public void LoadData()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlDa = new SqlDataAdapter("SELECT ID, FullName, Dob, GenderID, Phone, Address , Email, certificateId FROM Patients", sqlConnection);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                // Add a new DataColumn to the DataTable for displaying gender
                DataColumn genderColumn = new DataColumn("Gender", typeof(string));
                dtbl.Columns.Add(genderColumn);

                foreach (DataRow row in dtbl.Rows)
                {
                    int genderId = Convert.ToInt32(row["GenderID"]);
                    row["Gender"] = (genderId == 1) ? "Male" : "Female";
                }

                dgv1.DataSource = dtbl;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddPatients addPatients = new AddPatients(sqlConnection, this);
            addPatients.Show();


        }

        private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow modifiedRow = dgv1.Rows[e.RowIndex];
                modifiedRow.Tag = "Modified"; // Mark the row as modified

                // Get the ID of the modified record
                int recordID = Convert.ToInt32(modifiedRow.Cells["ID"].Value);

                // Determine which column was edited and get the new value
                string columnName = dgv1.Columns[e.ColumnIndex].Name;
                object newValue = modifiedRow.Cells[e.ColumnIndex].Value;

                // Update the corresponding record in the database
                string updateQuery = $"UPDATE Patients SET {columnName} = @Value WHERE ID = @ID";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                using (SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlCon))
                {
                    sqlCommand.Parameters.AddWithValue("@Value", newValue);
                    sqlCommand.Parameters.AddWithValue("@ID", recordID);

                    sqlCon.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Clear the "Modified" tag for this row
                        modifiedRow.Tag = null;
                        MessageBox.Show("Record updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Error updating record.");
                    }
                }
            }
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                // Loop through the DataGridView and update modified rows
                foreach (DataGridViewRow row in dgv1.Rows)
                {
                    if (row.Tag != null && row.Tag.ToString() == "Modified")
                    {

                        string fullName = row.Cells["FullName"].Value.ToString();
                        DateTime dob = Convert.ToDateTime(row.Cells["Dob"].Value);
                        int genderId = Convert.ToInt32(row.Cells["GenderID"].Value);
                        string phone = row.Cells["Phone"].Value.ToString();
                        string address = row.Cells["Address"].Value.ToString();

                        // Update the corresponding record in the database
                        string updateQuery = "UPDATE Patients SET FullName = @FullName, Dob = @Dob, GenderID = @GenderID, Phone = @Phone, Address = @Address, Email = @Email, certificateId = @certificateId WHERE ID = @ID";

                        using (SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlCon))
                        {

                            sqlCommand.Parameters.AddWithValue("@FullName", fullName);
                            sqlCommand.Parameters.AddWithValue("@Dob", dob);
                            sqlCommand.Parameters.AddWithValue("@GenderID", genderId);
                            sqlCommand.Parameters.AddWithValue("@Phone", phone);
                            sqlCommand.Parameters.AddWithValue("@Address", address);

                            int rowsAffected = sqlCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                // Clear the "modified" tag for this row
                                row.Tag = null;
                            }
                        }
                    }
                }

                MessageBox.Show("Records updated successfully.");
            }
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dgv1.CurrentCell.RowIndex;

            if (selectedRowIndex >= 0)
            {
                // Get the ID of the selected patient record
                int selectedPatientID = Convert.ToInt32(dtbl.Rows[selectedRowIndex]["ID"]);

                // Ask for confirmation before deleting
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        // Open the database connection
                        sqlCon.Open();

                        // DELETE the selected patient record
                        string deleteQuery = "DELETE FROM Patients WHERE ID = @ID";

                        using (SqlCommand sqlCommand = new SqlCommand(deleteQuery, sqlCon))
                        {
                            sqlCommand.Parameters.AddWithValue("@ID", selectedPatientID);

                            // Execute the DELETE query
                            int rowsAffected = sqlCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record deleted successfully.");
                                LoadData(); // Reload data after deleting
                            }
                            else
                            {
                                MessageBox.Show("Error deleting record.");
                            }
                        }
                    }
                }
            }
        }


    }
}
