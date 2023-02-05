using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace AutorizationSql
{
    public partial class MainForm : MaterialForm
    {
        bool settings = true; 
        private SqlConnection connection = null;

        public MainForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(MaterialSkin.Primary.Blue800, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Blue800, MaterialSkin.Accent.Cyan700, MaterialSkin.TextShade.WHITE);
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersDB"].ConnectionString);
            connection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PictureChengecolor.BackColor = System.Drawing.Color.FromArgb(10, 100, 200);
            PanelChangecolor.BackColor = System.Drawing.Color.FromArgb(10, 100, 200);
        }

        private void PictureChengecolor_Click(object sender, EventArgs e)
        {
            if (settings)
            {
                settings = false;
                PanelChangecolor.Visible = true;
                ChangeBlue.Visible = true;
                ChangeGreen.Visible = true;
                ChangeOrange.Visible = true;
            }
            else 
            {
                settings = true;
                PanelChangecolor.Visible = false;
                ChangeBlue.Visible = false;
                ChangeGreen.Visible = false;
                ChangeOrange.Visible = false;
            }
        }

        private void ChangeOrange_CheckedChanged(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.ColorScheme = new ColorScheme(MaterialSkin.Primary.Orange800, MaterialSkin.Primary.Orange900, MaterialSkin.Primary.Orange800, MaterialSkin.Accent.Yellow700, MaterialSkin.TextShade.WHITE);
            PictureChengecolor.BackColor = System.Drawing.Color.FromArgb(239, 107, 10);
            PanelChangecolor.BackColor = System.Drawing.Color.FromArgb(239, 107, 10);
        }

        private void ChangeBlue_CheckedChanged(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.ColorScheme = new ColorScheme(MaterialSkin.Primary.Blue800, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Blue800, MaterialSkin.Accent.Cyan700, MaterialSkin.TextShade.WHITE);
            PictureChengecolor.BackColor = System.Drawing.Color.FromArgb(10, 100, 200);
            PanelChangecolor.BackColor = System.Drawing.Color.FromArgb(10, 100, 200);
        }

        private void ChangeGreen_CheckedChanged(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.ColorScheme = new ColorScheme(MaterialSkin.Primary.Green800, MaterialSkin.Primary.Green900, MaterialSkin.Primary.Green900, MaterialSkin.Accent.LightGreen700, MaterialSkin.TextShade.WHITE);
            PictureChengecolor.BackColor = System.Drawing.Color.FromArgb(46, 125, 50);
            PanelChangecolor.BackColor = System.Drawing.Color.FromArgb(46, 125, 50);
        }

        private void RegBut_Click(object sender, EventArgs e)
        {
            RegistrationForm form = new RegistrationForm();
            form.PasswordText.Text = Theme_of_reg_form();
            form.ShowDialog();
        }

        private void EnterBut_Click(object sender, EventArgs e)
        {
            if (LoginText.Text != "" && PasswordText.Text != "")
            {
                string login, password;
                bool isopen = false;
                SqlDataReader sqlDataReader = null;
                SqlCommand sqlCommand = new SqlCommand("SELECT Login, Pasword FROM Users", connection);

                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {

                    login = Convert.ToString(sqlDataReader["Login"]);
                    password = Convert.ToString(sqlDataReader["Pasword"]);

                    if (login == LoginText.Text && password == PasswordText.Text)
                    {
                        isopen = true;
                        sqlDataReader.Close();
                        Hide();
                        FormAfterEnter form = new FormAfterEnter();
                        form.TextColor.Text = Theme_of_reg_form();
                        form.ShowDialog();
                        break;
                    }
                }
                if (isopen == false)
                {
                    MessageBox.Show("Вы ввели некорректные данные");
                }
            }
            else {
                MessageBox.Show("Введите логин и пароль");
            }
        }

        public string Theme_of_reg_form () {
            string theme_of_reg_form = "1";
            
            if (ChangeBlue.Checked) {
                theme_of_reg_form = "1";
            }
            if (ChangeGreen.Checked)
            {
                theme_of_reg_form = "2";
            }
            if (ChangeOrange.Checked)
            {
                theme_of_reg_form = "3";
            }
            
            return theme_of_reg_form;   
        }
    }
}
