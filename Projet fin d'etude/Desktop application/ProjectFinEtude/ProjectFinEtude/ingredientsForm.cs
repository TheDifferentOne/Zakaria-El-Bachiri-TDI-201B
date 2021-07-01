using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectFinEtude
{
    public partial class ingredientsForm : Form
    {
        private readonly string foodName;
        public ingredientsForm(string name)
        {
            InitializeComponent();
            foodName = name;
        }

        //Close btn click event
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Minimize btn click event
        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //On load
        private void ingredientsForm_Load(object sender, EventArgs e)
        {
            foodNameLbl.Text = foodName;

            ingredientNameTxtBx.KeyPress += OnlyLetters_KeyPress;
            ingredientQuantityTxtBx.KeyPress += OnlyDigits_KeyPress;

            getIngredientsData();
            getDirectionsData();
        }

        //Only digits key press
        private void OnlyDigits_KeyPress(object sender, KeyPressEventArgs keyPress)
        {
            if (Char.IsDigit(keyPress.KeyChar))
                keyPress.Handled = false;
            else if (keyPress.KeyChar == Char.Parse(".") || keyPress.KeyChar == (Char)Keys.Back)
                keyPress.Handled = false;
            else
                keyPress.Handled = true;
        }

        //Only Letters key press
        private void OnlyLetters_KeyPress(object sender, KeyPressEventArgs keyPress)
        {
            if (Char.IsLetter(keyPress.KeyChar))
                keyPress.Handled = false;
            else if (keyPress.KeyChar == (Char)Keys.Space || keyPress.KeyChar == (Char)Keys.Back)
                keyPress.Handled = false ;
            else
                keyPress.Handled = true;
        }


        //Cell click event for ingrediant grid
        private void ingredientsDgv_CellClick(object sender, DataGridViewCellEventArgs cell)
        {
            if (cell.RowIndex != -1)
            {
                ingredientNameTxtBx.Text = ingredientsDgv.SelectedRows[0].Cells["name"].Value.ToString();
                ingredientQuantityTxtBx.Text = ingredientsDgv.SelectedRows[0].Cells["quantity"].Value.ToString();
            }
        }

        //Cell click event for directions grid
        private void directionsDgv_CellClick(object sender, DataGridViewCellEventArgs cell)
        {
            if (cell.RowIndex != -1)
                directionTxtBx.Text = directionsDgv.SelectedRows[0].Cells["Directions"].Value.ToString();
        }

        private void clearIngredientsBtn_Click(object sender, EventArgs e)
        {
            ingredientQuantityTxtBx.Text = ingredientNameTxtBx.Text = string.Empty;
        }

        private void clearDirectionBtn_Click(object sender, EventArgs e)
        {
            directionTxtBx.Text = string.Empty;
        }

        #region Manupilation Data buttons click events for Ingredients
        private void addIngredientsBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ingredientNameTxtBx.Text)|| string.IsNullOrEmpty(ingredientQuantityTxtBx.Text))
            {
                MessageBox.Show("All fields are required","Empty fields",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                return;
            }

            string query = "INSERT INTO Recipes VALUES(@foodName,@quantity,@ingrediantName)";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@foodName", foodName);
            command.Parameters.AddWithValue("@quantity", ingredientQuantityTxtBx.Text);
            command.Parameters.AddWithValue("@ingrediantName", ingredientNameTxtBx.Text);
            if (DataAccess.setData(command))
            {
                MessageBox.Show("Ingrediants have been added", "Info");
                getIngredientsData();
                getDirectionsData();
                ingredientNameTxtBx.Text = ingredientQuantityTxtBx.Text = string.Empty;
            }
        }

        private void updtaeIngredientsBtn_Click(object sender, EventArgs e)
        {
            if (ingredientsDgv.Rows.Count == 0)
            {
                MessageBox.Show("No Ingrediants to delete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string query = "UPDATE Recipes SET foodName = @foodName,quantity = @quantity, name = @ingrediantName WHERE IngrediantId = @id";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@foodName", foodName);
            command.Parameters.AddWithValue("@quantity", ingredientQuantityTxtBx.Text);
            command.Parameters.AddWithValue("@ingrediantName", ingredientNameTxtBx.Text);
            command.Parameters.AddWithValue("@id", ingredientsDgv.SelectedRows[0].Cells["IngrediantId"].Value);
            if (DataAccess.setData(command))
            {
                MessageBox.Show("Ingrediants have been updated", "Info");
                getIngredientsData();
                getDirectionsData();
                ingredientNameTxtBx.Text = ingredientQuantityTxtBx.Text = string.Empty;

            }
        }

        private void deleteIngredientsBtn_Click(object sender, EventArgs e)
        {
            if (ingredientsDgv.Rows.Count == 0)
            {
                MessageBox.Show("No Ingrediants to delete","Info",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("Are you sure?","Info",MessageBoxButtons.YesNo) == DialogResult.Yes);
            {
                string query = "DELETE FROM Recipes WHERE IngrediantId = @id";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@id", ingredientsDgv.SelectedRows[0].Cells["IngrediantId"].Value);
                if (DataAccess.setData(command))
                {
                    MessageBox.Show("Ingrediants have been deleted", "Info");
                    getIngredientsData();
                    getDirectionsData();
                    ingredientNameTxtBx.Text = ingredientQuantityTxtBx.Text = string.Empty;

                }
            }
        }
        #endregion

        #region Manupilation Data buttons click events for Directions
        private void addDirectionBtn_Click(object sender, EventArgs e)
        {
            if (ingredientsDgv.Rows.Count == 0)
            {
                MessageBox.Show("Must fill the ingredients first","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(directionTxtBx.Text))
            {
                MessageBox.Show("Must Enter a direction", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = "INSERT INTO Directions VALUES(@foodName,@directions)";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@foodName", foodName);
            command.Parameters.AddWithValue("@directions", directionTxtBx.Text);
            if (DataAccess.setData(command))
            {
                MessageBox.Show("Directions have been added", "Info");
                directionTxtBx.Text = string.Empty;
                getDirectionsData();
            }
        }

        private void deleteDirectionBtn_Click(object sender, EventArgs e)
        {
            if (directionsDgv.Rows.Count == 0)
            {
                MessageBox.Show("No directions to delete", "Info",  MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes);
            {
                string query = "DELETE FROM Directions WHERE FoodName = @foodName AND CONVERT(VARCHAR(MAX), Directions) = @directions";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@foodName", foodName);
                command.Parameters.AddWithValue("@directions", directionsDgv.SelectedRows[0].Cells["Directions"].Value);
                if (DataAccess.setData(command))
                {
                    MessageBox.Show("Directions have been Deleted", "Info");
                    getDirectionsData();
                }
            }
        }

        private void updateDirectionBtn_Click(object sender, EventArgs e)
        {
            if (directionsDgv.Rows.Count == 0)
            {
                MessageBox.Show("No directions to update", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = "UPDATE Directions SET Directions = @directions WHERE FoodName = @foodName AND CONVERT(VARCHAR(MAX), Directions) = @originalDirections";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@foodName", foodName);
            command.Parameters.AddWithValue("@directions", directionTxtBx.Text);
            command.Parameters.AddWithValue("@originalDirections", directionsDgv.SelectedRows[0].Cells["Directions"].Value);
            if (DataAccess.setData(command))
            {
                MessageBox.Show("Directions have been updated","Info");
                getDirectionsData();
            }
        }
        #endregion

        private void getDirectionsData()
        {
            //show directions Only if there are ingredients 
            if (ingredientsDgv.Rows.Count > 0)
            {
                string query = "SELECT Directions FROM Directions WHERE FoodName = @foodName";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@foodName", foodName);
                DataTable table = DataAccess.getData(command);
                if (table.Rows.Count > 0)
                {
                    directionsDgv.DataSource = table;
                    directionTxtBx.Text = directionsDgv.SelectedRows[0].Cells["Directions"].Value.ToString();
                }
                else
                    directionsDgv.DataSource = null;
            }
        }

        private void getIngredientsData()
        {
            string query = "SELECT IngrediantId,foodName,name,quantity FROM Recipes WHERE foodName = @foodName";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@foodName", foodName);
            DataTable table = DataAccess.getData(command);
            if (table.Rows.Count > 0)
            {
                ingredientsDgv.DataSource = table;
                ingredientsDgv.Columns["IngrediantId"].Visible = ingredientsDgv.Columns["foodName"].Visible = false;
                ingredientNameTxtBx.Text = ingredientsDgv.SelectedRows[0].Cells["name"].Value.ToString();
                ingredientQuantityTxtBx.Text = ingredientsDgv.SelectedRows[0].Cells["quantity"].Value.ToString();
            }
            else
                ingredientsDgv.DataSource = null;
        }
    }
}
