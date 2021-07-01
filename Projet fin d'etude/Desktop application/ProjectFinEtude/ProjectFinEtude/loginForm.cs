using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;

namespace ProjectFinEtude
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        //Log in btn click event
        private void logInBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(emailTxtBx.Text) || string.IsNullOrEmpty(passwordTxtBx.Text))
            {
                MessageBox.Show("All fields are required", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (emailErrorLbl.ForeColor == Color.OrangeRed || passwordErrorLbl.ForeColor == Color.OrangeRed)
            {
                MessageBox.Show("Check the data you entered", "Detected wrong inputs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = "SELECT * FROM Accounts WHERE email = @email AND password = @password";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@email", emailTxtBx.Text);
            command.Parameters.AddWithValue("@password", passwordTxtBx.Text);

            //Getting the data 
            DataTable table = DataAccess.getData(command);
            if (table.Rows.Count == 0)
                MessageBox.Show("The information entered doesn't match our data", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (table.Rows[0]["userType"].ToString() == "admin")
                {
                    mainForm mainForm = new mainForm();
                    this.Hide();
                    mainForm.ShowDialog();
                    if (mainForm.IsDisposed) return;
                    this.Show();
                }
                else
                    MessageBox.Show("Only admins are allowed", "Permission denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        //Email textbox keyPress event
        private void emailTxtBx_KeyPress(object sender, KeyPressEventArgs keyPress)
        {
            if (keyPress.KeyChar == (Char)Keys.Back) keyPress.Handled = false;
            else if (keyPress.KeyChar == (Char)Keys.Space)
            {
                keyPress.Handled = true;
                emailErrorLbl.ForeColor = Color.OrangeRed;
                emailErrorLbl.Text = "Spaces are not allowed ❌";
            }
            else if (keyPress.KeyChar == (Char)Keys.Enter || !Char.IsLetter(keyPress.KeyChar)) keyPress.Handled = true;
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
                    emailErrorLbl.ForeColor = Color.Lime;
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
                emailErrorLbl.ForeColor = Color.Lime;
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
                    passwordErrorLbl.ForeColor = Color.Lime;
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

        //Password Keypress event
        private void passwordTxtBx_KeyPress(object sender, KeyPressEventArgs keyPress)
        {
            if (keyPress.KeyChar == (Char)Keys.Enter)
            {
                keyPress.Handled = true;
                logInBtn.PerformClick();
            }

        }

        private void closeBtn_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
