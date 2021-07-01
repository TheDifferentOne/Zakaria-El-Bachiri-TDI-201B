using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectFinEtude
{
    public partial class recipeUC : UserControl
    {
        public recipeUC()
        {
            InitializeComponent();

        }

        OpenFileDialog openFileDialog = new OpenFileDialog();

        //On load
        private void recipeUC_Load(object sender, EventArgs e)
        {

            getAllData();

            searchTxtBx.KeyPress += TxtBxLettersOnly_KeyPress;
            searchTxtBx.KeyPress += SearchTxtBx_KeyPress;
            foodNameTxtBx.KeyPress += TxtBxLettersOnly_KeyPress;

            servingsTxtBx.KeyPress += TxtBxDigitsOnly_KeyPress;
            cookingTimeTxtBx.KeyPress += TxtBxDigitsOnly_KeyPress;

            dgv.DefaultCellStyle.Font = new Font(dgv.DefaultCellStyle.Font, FontStyle.Bold);

            openFileDialog.InitialDirectory = @"C:\Desktop";
            openFileDialog.Title = "Choose a picture";
            openFileDialog.Filter = "Images (*.JPG;*.PNG;*.JPEG) | *.JPEG;*.JPG;*.PNG";
            openFileDialog.Multiselect = false;

        }

        private void SearchTxtBx_KeyPress(object sender, KeyPressEventArgs keyPress)
        {
            if (keyPress.KeyChar == (Char)Keys.Enter)
                searchBtn_Click(searchBtn, keyPress);
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clearInputs();
        }

        #region Data Manipulation
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (!isDataValid())
            {
                MessageBox.Show("All fileds are required", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Add food 
            string query = "INSERT INTO Food VALUES (@foodName,@cookingTime,@servings,@country)";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@foodName",foodNameTxtBx.Text),
                new SqlParameter("@cookingTime",cookingTimeTxtBx.Text),
                new SqlParameter("@servings",servingsTxtBx.Text),
                new SqlParameter("@country",countryCmbBx.Text)
            });

            if (DataAccess.setData(command))
                MessageBox.Show("One food have been added", "Added food", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                return;

            //Refresh UC and get All data
            getAllData();

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (!isDataValid())
            {
                MessageBox.Show("All fileds are required", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Update food 
            string query = "UPDATE Food SET name = @foodName, cookingTime = @cookingTime,servings = @servings,country = @country " +
                           "WHERE name = @originalFoodName";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@foodName",foodNameTxtBx.Text),
                new SqlParameter("@cookingTime",cookingTimeTxtBx.Text),
                new SqlParameter("@servings",servingsTxtBx.Text),
                new SqlParameter("@country",countryCmbBx.Text),
                new SqlParameter("@originalFoodName",dgv.SelectedRows[0].Cells["name"].Value)
            });

            if (DataAccess.setData(command))
                MessageBox.Show("One food have been updated", "Updated food", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                return;

            //Refresh UC
            getAllData();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(foodNameTxtBx.Text))
            {
                string query = "DELETE FROM Food WHERE name = @foodName";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@foodName", foodNameTxtBx.Text);

                if (DataAccess.setData(command))
                    MessageBox.Show("This food and all its pictures have been deleted", "Deleted food", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else return;

                getAllData();
            }
            else MessageBox.Show("Food name required", "Required field", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region keyPress events
        //Letters Only
        private void TxtBxLettersOnly_KeyPress(object sender, KeyPressEventArgs keyPress)
        {
            if (keyPress.KeyChar == (Char)Keys.Back || keyPress.KeyChar == (Char)Keys.Space)
                keyPress.Handled = false;
            else if (!Char.IsLetter(keyPress.KeyChar))
                keyPress.Handled = true;
        }

        //Digits only 
        private void TxtBxDigitsOnly_KeyPress(object sender, KeyPressEventArgs keyPress)
        {
            if (keyPress.KeyChar == (Char)Keys.Back)
                keyPress.Handled = false;
            else if (!Char.IsDigit(keyPress.KeyChar))
                keyPress.Handled = true;
        }

        #endregion
        //Clear inputs
        private void clearInputs()
        {
            searchTxtBx.Text = foodNameTxtBx.Text = servingsTxtBx.Text = cookingTimeTxtBx.Text = string.Empty;
            countryCmbBx.SelectedIndex = 0;
            pictureBox1.Image = pictureBox2.Image = pictureBox3.Image = pictureBox3.Image = pictureBox4.Image = null;

        }

        //Get all data function
        private void getAllData()
        {
            string query = "SELECT * FROM Food";
            SqlCommand command = new SqlCommand(query);
            DataTable table = DataAccess.getData(command);
            countryCmbBx.DataSource = table;
            countryCmbBx.DisplayMember = "name";

            if (table.Rows.Count == 0)
                MessageBox.Show("No data found", "Empty table", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                query = "SELECT * FROM Countries";
                command = new SqlCommand(query);
                countryCmbBx.DataSource = DataAccess.getData(command);

                clearInputs();
                dgv.DataSource = table;
                foodNameTxtBx.Text = dgv["name", 0].Value.ToString();
                servingsTxtBx.Text = dgv["servings", 0].Value.ToString();
                cookingTimeTxtBx.Text = dgv["cookingTime", 0].Value.ToString();
                countryCmbBx.Text = dgv["country", 0].Value.ToString();

            }

            getPicturesFromDB();
        }

        // Get all btn click event
        private void getAllDataBtn_Click(object sender, EventArgs e)
        {
            getAllData();
        }


        //Cell click event
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs cell)
        {
            if (cell.RowIndex != -1)
            {
                foodNameTxtBx.Text = dgv["name", cell.RowIndex].Value.ToString();
                cookingTimeTxtBx.Text = dgv["cookingTime", cell.RowIndex].Value.ToString();
                servingsTxtBx.Text = dgv["servings", cell.RowIndex].Value.ToString();
                countryCmbBx.Text = dgv["country", cell.RowIndex].Value.ToString();

                getPicturesFromDB();
            }
        }

        //Search click event
        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchTxtBx.Text))
            {
                MessageBox.Show("Please enter name of food you want to search for", "Empty filed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "SELECT * FROM Food WHERE name = @name";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@name", searchTxtBx.Text);
            DataTable table = DataAccess.getData(command);

            if (table.Rows.Count == 0)
                MessageBox.Show("None of the food has this name", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                dgv.DataSource = table;
                foodNameTxtBx.Text = dgv["name", 0].Value.ToString();
                cookingTimeTxtBx.Text = dgv["cookingTime", 0].Value.ToString();
                servingsTxtBx.Text = dgv["servings", 0].Value.ToString();
                countryCmbBx.Text = dgv["country", 0].Value.ToString();
            }
        }

        //Data validation
        private bool isDataValid()
        {
            if (string.IsNullOrEmpty(foodNameTxtBx.Text) 
                || string.IsNullOrEmpty(servingsTxtBx.Text) || string.IsNullOrEmpty(cookingTimeTxtBx.Text))
                return false;
            return true;
        }

        //Show ingredients click event
        private void showBtn_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("The grid is empty");
                return;
            }

            this.Parent.Parent.Hide();
            new ingredientsForm(dgv.SelectedRows[0].Cells["name"].Value.ToString()).ShowDialog();
            getAllData();
            this.Parent.Parent.Show();
        }

        //Cell formatting 
        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.DefaultCellStyle.ForeColor = Color.White;
                string query = "SELECT * FROM Recipes WHERE  foodName =@foodName";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@foodName", row.Cells["name"].Value);

                DataTable recipeTable = DataAccess.getData(command);
                if (recipeTable.Rows.Count == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.SelectionBackColor = Color.Maroon;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LimeGreen;
                    row.DefaultCellStyle.SelectionBackColor = Color.Green;
                }
            }
        }

        //Pics btn click event
        private void picsBtn_Click(object sender, EventArgs e)
        {
            List<byte[]> pics = getPicturesFromUI();
            if (pics.Count > 0)
            {
                string query, manipulationType;

                if (picsBtn.Text == "Add pictures")
                {
                    query = "INSERT INTO FoodPics VALUES(@foodName,@pic1,@pic2,@pic3,@pic4)";
                    manipulationType = "Added";
                }
                else
                {
                    query = "UPDATE FoodPics SET foodName = @foodName,pic1 = @pic1,pic2 = @pic2,pic3 = @pic3,pic4 = @pic4 WHERE foodName=@foodName";
                    manipulationType = "Updated";
                }

                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@foodName",foodNameTxtBx.Text),
                    new SqlParameter("@pic1",pics[0]),
                    new SqlParameter("@pic2",pics[1]),
                    new SqlParameter("@pic3",pics[2]),
                    new SqlParameter("@pic4",pics[3])
                });

                if (DataAccess.setData(command))
                {
                    MessageBox.Show($"Pictures have been {manipulationType} successfuly", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getAllData();
                }
                else
                    return;
            }
            else
            {
                MessageBox.Show("Must choose at least one picture");
                return;
            }


        }

        #region Pictures btn click events
        private void pic1Btn_Click(object sender, EventArgs e)
        {
            chooseImage(pictureBox1);
        }

        private void pic4Btn_Click(object sender, EventArgs e)
        {
            chooseImage(pictureBox4);

        }

        private void pic2Btn_Click(object sender, EventArgs e)
        {
            chooseImage(pictureBox2);
        }

        private void pic3Btn_Click(object sender, EventArgs e)
        {
            chooseImage(pictureBox3);
        }
        #endregion

        //Choose image function
        private void chooseImage(PictureBox pictureBox)
        {

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox.Image = new Bitmap(openFileDialog.FileName);
                }
                catch (Exception error)
                {
                    MessageBox.Show("The following error occured: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Handling Picture boxes 
        private bool arePictureBoxesEmpty()
        {
            if (pictureBox1 == null && pictureBox2 == null && pictureBox2 == null && pictureBox4 == null)
                return true;
            return false;
        }

        //Get pictures from UI function
        private List<byte[]> getPicturesFromUI()
        {
            List<byte[]> pics = new List<byte[]>();
            if (pictureBox1.Image != null) pics.Add((byte[])new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[])));
            if (pictureBox2.Image != null) pics.Add((byte[])new ImageConverter().ConvertTo(pictureBox2.Image, typeof(byte[])));
            if (pictureBox3.Image != null) pics.Add((byte[])new ImageConverter().ConvertTo(pictureBox3.Image, typeof(byte[])));
            if (pictureBox4.Image != null) pics.Add((byte[])new ImageConverter().ConvertTo(pictureBox4.Image, typeof(byte[])));
            return pics;
        }

        //Get pictures from DB 
        private void getPicturesFromDB()
        {
            string query = "SELECT [pic1],[pic2],[pic3],[pic4] FROM foodPics WHERE foodName = @foodName";
            SqlCommand command = new SqlCommand(query);
            if (dgv.Rows.Count > 0)
            {
                command.Parameters.AddWithValue("@foodName", dgv.SelectedRows[0].Cells["name"].Value);
                DataTable table = DataAccess.getData(command);
                if (table.Rows.Count == 0)
                {
                    picsBtn.Text = "Add pictures";
                    pictureBox1.Image = pictureBox2.Image = pictureBox3.Image = pictureBox3.Image = pictureBox4.Image = null;
                }
                else
                {
                    pictureBox1.Image = string.IsNullOrEmpty(table.Rows[0]["pic1"].ToString())?null:(Image)new ImageConverter().ConvertFrom(table.Rows[0]["pic1"]);
                    pictureBox2.Image = string.IsNullOrEmpty(table.Rows[0]["pic1"].ToString())? null: (Image)new ImageConverter().ConvertFrom(table.Rows[0]["pic2"]);
                    pictureBox3.Image = string.IsNullOrEmpty(table.Rows[0]["pic1"].ToString())?null: (Image)new ImageConverter().ConvertFrom(table.Rows[0]["pic3"]);
                    pictureBox4.Image = string.IsNullOrEmpty(table.Rows[0]["pic1"].ToString())?null: (Image)new ImageConverter().ConvertFrom(table.Rows[0]["pic4"]);
                    if (pictureBox1.Image == null && pictureBox2.Image == null && pictureBox3.Image == null || pictureBox4.Image == null)
                        picsBtn.Text = "Add pictures";
                    else picsBtn.Text = "Change pictures";
                }
            }
        }

        //Delete all images btn ckick event
        private void deleteAllImagesBtn_Click(object sender, EventArgs e)
        {
            List<byte[]> pics = getPicturesFromUI();
            if (pics.Count > 0)
            {
                string query = "DELETE FROM FoodPics WHERE foodName = @foodName";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@foodName", foodNameTxtBx.Text);
                if (MessageBox.Show("Are you sure ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (DataAccess.setData(command))
                    {
                        MessageBox.Show("All images are deleted", "");
                        getAllData();
                    }
                    else return;
                }
            }
            else
            {
                MessageBox.Show("No food is selected or it has no images","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }
    }
}
