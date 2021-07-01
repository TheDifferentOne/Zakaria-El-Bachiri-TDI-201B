using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Drawing;

namespace ProjectFinEtude
{
    public partial class usersUC : UserControl
    {

        public usersUC()
        {
            InitializeComponent();
        }
        //On load event
        private void usersUC_Load(object sender, EventArgs e)
        {
            searchTxtBx.KeyPress += TxtBx_KeyPress;
            lastNameTxtBx.KeyPress += TxtBx_KeyPress;
            firstNameTxtBx.KeyPress += TxtBx_KeyPress;

            userTypeCmbBx.SelectedIndex = 0;

            usersDgv.DefaultCellStyle.Font = new Font(usersDgv.Font, FontStyle.Bold);
            getAllData();

        }

        #region KeyPress Events
        //KeyPress event for normal inputs    
        private void TxtBx_KeyPress(object sender, KeyPressEventArgs keyPress)
        {
            handlingInputs(keyPress);
        }
        //Email textbox keyPress event
        private void emailTxtBx_KeyPress(object sender, KeyPressEventArgs keyPress)
        {
            if (keyPress.KeyChar == (Char)Keys.Space)
            {
                keyPress.Handled = true;
                emailErrorLbl.ForeColor = Color.OrangeRed;
                emailErrorLbl.Text = "Spaces are not allowed ❌";
            }
            else if (keyPress.KeyChar == (Char)Keys.Enter) keyPress.Handled = true;
            else
                emailErrorLbl.Text = String.Empty;

        }

        //Email text change event
        private void emailTxtBx_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(emailTxtBx.Text))
            {
                if (isEmailValid())
                {
                    emailErrorLbl.ForeColor = Color.LimeGreen;
                    emailErrorLbl.Text = "Valid email ✔";
                }
                else
                {
                    emailErrorLbl.ForeColor = Color.OrangeRed;
                    emailErrorLbl.Text = "Invalid email ❌";
                }
            }
            else emailErrorLbl.Text = string.Empty;
        }

        //Email textbox leave event
        private void emailTxtBx_Leave(object sender, EventArgs e)
        {
            if (isEmailValid())
            {
                emailErrorLbl.ForeColor = Color.LimeGreen;
                emailErrorLbl.Text = "Valid email ✔";
            }
        }

        //Password textbox text change event
        private void passwordTxtBx_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordTxtBx.Text))
            {
                if (passwordTxtBx.Text.Length >= 6)
                {
                    passwordErrorLbl.ForeColor = Color.LimeGreen;
                    passwordErrorLbl.Text = "Valid password ✔";
                }
                else
                {
                    passwordErrorLbl.ForeColor = Color.OrangeRed;
                    passwordErrorLbl.Text = "Password is too short ❌";
                }
            }
            else passwordErrorLbl.Text = string.Empty;
        }

        #endregion


        //Search btn click event
        private void searchBtn_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            string getBynameQuery = "SELECT * FROM Accounts WHERE firstName = @firstName";
            SqlCommand command = new SqlCommand(getBynameQuery);
            if (string.IsNullOrEmpty(searchTxtBx.Text))
            {
                MessageBox.Show("Enter the user name", "Required field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            command.Parameters.AddWithValue("@firstName", searchTxtBx.Text);
            table = DataAccess.getData(command);
            if (table.Rows.Count == 0)
                MessageBox.Show("Non of the users has this name", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                fillCounters(table);
                usersDgv.DataSource = table;
                usersDgv.Columns["id"].Visible = false;

            }
        }

        #region Data Manupilation
        //Add user btn event
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (!isDataValid())
                MessageBox.Show("Empty fields or invlid input", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DataTable table = new DataTable();
                string query = "INSERT INTO Accounts VALUES (@userType,@firstName,@lastName,@email,@password)";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddRange(new SqlParameter[] {
                    new SqlParameter("@userType",userTypeCmbBx.Text),
                    new SqlParameter("@firstName",firstNameTxtBx.Text),
                    new SqlParameter("@lastName",lastNameTxtBx.Text),
                    new SqlParameter("@email",emailTxtBx.Text),
                    new SqlParameter("@password",passwordTxtBx.Text),
                });
                if (DataAccess.setData(command))
                {
                    MessageBox.Show("One user have been added", "User added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getAllData();
                }
            }
        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (usersDgv.Rows.Count == 0)
                MessageBox.Show("Non of the users have been selected from the grid, Please select one and try again", "Empty Grid", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (MessageBox.Show("Are you sure toy want to delete this user", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataTable table = new DataTable();
                    string query = "DELETE FROM Accounts WHERE id=@id";
                    SqlCommand command = new SqlCommand(query);
                    command.Parameters.AddWithValue("@id", usersDgv.SelectedRows[0].Cells["id"].Value);

                    if (DataAccess.setData(command))
                    {
                        MessageBox.Show("One user have been deleted", "User deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearInputs();
                        getAllData();
                    }
                }


            }

        }
        private void updtaeBtn_Click(object sender, EventArgs e)
        {
            if (usersDgv.Rows.Count == 0)
                MessageBox.Show("None of the users is selected from the grid, Please select one and try again", "Empty Grid", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (!isDataValid())
                {
                    MessageBox.Show("Empty fields or invlid input", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable table = new DataTable();
                string query = "UPDATE Accounts SET userType = @userType,firstName = @firstName,lastName = @lastName," +
                               "email = @email,password = @password WHERE id=@id";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddRange(new SqlParameter[] {
                    new SqlParameter("@userType",userTypeCmbBx.Text),
                    new SqlParameter("@firstName",firstNameTxtBx.Text),
                    new SqlParameter("@lastName",lastNameTxtBx.Text),
                    new SqlParameter("@email",emailTxtBx.Text),
                    new SqlParameter("@password",passwordTxtBx.Text),
                });
                command.Parameters.AddWithValue("@id", usersDgv.SelectedRows[0].Cells["id"].Value);

                if (DataAccess.setData(command))
                {
                    MessageBox.Show("One user have been updated", "User updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearInputs();
                    getAllData();
                }

            }
        }
        //Clear btn click event
        private void clearBtn_Click(object sender, EventArgs e)
        {
            clearInputs();
        }
        #endregion

        //Cell click event
        private void usersDgv_CellClick(object sender, DataGridViewCellEventArgs cell)
        {
            if (cell.RowIndex != -1)
            {
                firstNameTxtBx.Text = usersDgv["firstName", cell.RowIndex].Value.ToString();
                lastNameTxtBx.Text = usersDgv["lastName", cell.RowIndex].Value.ToString();
                emailTxtBx.Text = usersDgv["email", cell.RowIndex].Value.ToString();
                passwordTxtBx.Text = usersDgv["password", cell.RowIndex].Value.ToString();
                userTypeCmbBx.Text = usersDgv["userType", cell.RowIndex].Value.ToString();

            }
        }

        //Filtering rows
        private void filterByRegularBtn_Click(object sender, EventArgs e)
        {
            if (usersDgv.Rows.Count == 0)
                MessageBox.Show("Can't filter if the grid is empty", "Emtpty grid", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                (usersDgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("[userType] = 'regular'");
            }
        }
        private void filterByAdminBtn_Click(object sender, EventArgs e)
        {
            if (usersDgv.Rows.Count == 0)
                MessageBox.Show("Can't filter if the grid is empty", "Emtpty grid", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                (usersDgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("[userType] = 'admin'");
            }
        }
        private void filterByAllBtn_Click(object sender, EventArgs e)
        {
            if (usersDgv.Rows.Count == 0)
                MessageBox.Show("Can't filter if the grid is empty", "Emtpty grid", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                (usersDgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("");
            }
        }

        private void getAllDataBtn_Click(object sender, EventArgs e)
        {
            getAllData();
        }

        private void getAllData()
        {
            DataTable allUsersTable = new DataTable();
            string allUsersQuery = "SELECT * FROM Accounts";
            SqlCommand allusersCommand = new SqlCommand(allUsersQuery);
            allUsersTable = DataAccess.getData(allusersCommand);

            if (allUsersTable.Rows.Count == 0)
                MessageBox.Show("No data found", "Empty table", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                fillCounters(allUsersTable);
                clearInputs();
                usersDgv.DataSource = allUsersTable;
                usersDgv.Columns["id"].Visible = false;
                firstNameTxtBx.Text = usersDgv["firstName", 0].Value.ToString();
                lastNameTxtBx.Text = usersDgv["lastName", 0].Value.ToString();
                emailTxtBx.Text = usersDgv["email", 0].Value.ToString();
                passwordTxtBx.Text = usersDgv["password", 0].Value.ToString();
                userTypeCmbBx.Text = usersDgv["userType", 0].Value.ToString();

            }
        }

        //Filling Counters
        private void fillCounters(DataTable table)
        {
            allCounterLbl.Text = table.Rows.Count.ToString();
            adminCounterLbl.Text = table.Select("userType='admin'").Length.ToString();
            regularCounterLbl.Text = table.Select("userType='regular'").Length.ToString();
        }

        //Handling Inputs
        private void handlingInputs(KeyPressEventArgs keyPress)
        {
            if (keyPress.KeyChar == (Char)Keys.Back)
                keyPress.Handled = false;
            else if (!Char.IsLetter(keyPress.KeyChar))
                keyPress.Handled = true;
        }

        //Check email validation
        private bool isEmailValid()
        {
            try
            {
                MailAddress mailAddress = new MailAddress(emailTxtBx.Text);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //Data validation
        private bool isDataValid()
        {
            if (string.IsNullOrEmpty(firstNameTxtBx.Text) || string.IsNullOrEmpty(lastNameTxtBx.Text) || string.IsNullOrEmpty(userTypeCmbBx.Text))
                return false;
            if (!isEmailValid())
                return false;
            if (passwordTxtBx.Text.Length < 6)
                return false;
            return true;
        }

        //Clear inputs
        private void clearInputs()
        {
            searchTxtBx.Text = firstNameTxtBx.Text = lastNameTxtBx.Text = emailTxtBx.Text = passwordTxtBx.Text = string.Empty;
            userTypeCmbBx.SelectedIndex = 0;
        }

      
    }
}
