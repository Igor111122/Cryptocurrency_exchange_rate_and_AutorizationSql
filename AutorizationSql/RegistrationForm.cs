using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SqlClient;
using System.Configuration;

namespace AutorizationSql
{
    public partial class RegistrationForm : MaterialForm
    {
        private SqlConnection connection = null;
        public RegistrationForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            string theme_of_reg_form = PasswordText.Text;

            if (theme_of_reg_form=="1")
            {
                materialSkinManager.ColorScheme = new ColorScheme(MaterialSkin.Primary.Blue800, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Blue800, MaterialSkin.Accent.Cyan700, MaterialSkin.TextShade.WHITE);
            }
            if (theme_of_reg_form == "2")
            {
                materialSkinManager.ColorScheme = new ColorScheme(MaterialSkin.Primary.Green800, MaterialSkin.Primary.Green900, MaterialSkin.Primary.Green900, MaterialSkin.Accent.LightGreen700, MaterialSkin.TextShade.WHITE);
            }
            if (theme_of_reg_form == "3")
            {
                materialSkinManager.ColorScheme = new ColorScheme(MaterialSkin.Primary.Orange800, MaterialSkin.Primary.Orange900, MaterialSkin.Primary.Orange800, MaterialSkin.Accent.Yellow700, MaterialSkin.TextShade.WHITE);
            }
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersDB"].ConnectionString);
            connection.Open();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            PasswordText.Text = "";
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile("Roboto-Regular.ttf"); 
            FontFamily family = fontCollection.Families[0];
            Font font = new Font(family, 14);
            DateBirth.Font = font;  
            DateBirth.CalendarForeColor = Color.Green;  
        }

        private void RedistrationButt_Click(object sender, EventArgs e)
        {
            if (LoginText.Text != "" && PasswordText.Text != "" && SityText.Text != "" && (ChangeSexFemale.Checked || ChangeSexMale.Checked || ChangeSexOther.Checked))
            {

                string login, password;
                bool iteretion = false;
                SqlDataReader sqlDataReader = null;
                SqlCommand sqlCommand_find_iteretion = new SqlCommand("SELECT Login FROM Users", connection);

                sqlDataReader = sqlCommand_find_iteretion.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    login = Convert.ToString(sqlDataReader["Login"]);
                    if (login == LoginText.Text)
                    {
                        iteretion = true;
                    }
                }

                if (iteretion == false) { 
                
                    string Sex = "";
                    string Date, day;

                    if (ChangeSexFemale.Checked) { Sex = "Female"; }
                    if (ChangeSexMale.Checked) { Sex = "Male"; }
                    if (ChangeSexOther.Checked) { Sex = "Other"; }

                    Date = String.Format("{0}", DateBirth.Value.ToString());
                    Date = Date.Substring(0, Date.IndexOf(' ') + 1);
                    Date = Date.Substring(Date.IndexOf('.'), Date.Length - 2);
                    Date = Date.Substring(1, Date.Length - 2);
                    day = String.Format("{0}", DateBirth.Value.ToString());
                    day = day.Substring(0, day.IndexOf(' ') + 1);
                    day = day.Substring(0, day.IndexOf('.'));
                    Date = day+"."+Date;
                    //Date = Date.Replace(Date.Substring(0, 2), Date.Substring(0, 3));


                    
                    SqlCommand command = new SqlCommand($"INSERT INTO [Users] (Login, Pasword, DateBirth, Sex, Sity) VALUES (N'{LoginText.Text}',N'{PasswordText.Text}',N'{Date}',N'{Sex}',N'{SityText.Text}')", connection);
                    sqlDataReader.Close();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Регестриция прошла успешно");
                    Close();
                }
                else{
                    MessageBox.Show("Пользователь с таким логином уже существует");
                }
            }
            else {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}
