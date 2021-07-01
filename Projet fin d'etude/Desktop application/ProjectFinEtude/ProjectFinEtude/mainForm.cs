using ProjectFinEtude.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectFinEtude
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            usersUC1.Show();
            recipeUC1.Hide();

        }


        //Close Btn click event
        private void logOutBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        //On load
        private void mainForm_Load(object sender, EventArgs e)
        {
            usersBtn.ForeColor = Color.FromArgb(0, 151, 254);
            usersBtn.Image = Resources.coloredUser;
        }

        #region Click Events

        //User btn click event
        private void usersBtn_Click(object sender, EventArgs e)
        {
            usersBtn.ForeColor = Color.FromArgb(0, 151, 254);
            usersBtn.Image = Resources.coloredUser;
            changeColors(recipeBtn);

            usersUC1.Show();
            recipeUC1.Hide();
        }


        //Recipe btn click event
        private void recipeBtn_Click(object sender, EventArgs e)
        {
            recipeBtn.ForeColor = Color.FromArgb(0, 151, 254);
            recipeBtn.Image = Resources.coloredRecipe;
            changeColors(usersBtn);

            recipeUC1.Show();
            usersUC1.Hide();
        }
        #endregion


        private void changeColors( Button second)
        {

            switch (second.Text)
            {
                case "Users":
                    second.Image = Resources.whiteUser; 
                    break;
                case "Recipe":
                    second.Image = Resources.whiteRecipe;
                    break;
            }
            second.ForeColor = Color.White;
        }

        private void hideUserControls( UserControl second)
        {
            second.Hide();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
