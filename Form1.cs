using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
(
    int nLeftRect, // x-coordinate of upper-left corner
    int nTopRect, // y-coordinate of upper-left corner
    int nRightRect, // x-coordinate of lower-right corner
    int nBottomRect, // y-coordinate of lower-right corner
    int nWidthEllipse, // height of ellipse
    int nHeightEllipse // width of ellipse 
 );

        public static class LoginInfo
        {
            public static string userName;
        }

        //SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Family\Desktop\2nd\c#\FinalProject\WindowsFormsApp1\SchoolAdmin.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\SchoolAdminDatabase\SchoolAdmin.mdf;Integrated Security=True;Connect Timeout=30");

        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }


        public int checkInputs()
        {
            if (txtEmail.Text == "" || txtPassword.Text == "")
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
        string password;
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (checkInputs() == 1)
            {
                MessageBox.Show("You have some missing info...Please fill all the input fields...");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Select * from UserTbl where Email = '" +txtEmail.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    SqlDataReader reader = null;

                    cmd.ExecuteNonQuery();
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        password = reader["Password"].ToString();
                       // LoggedInUser.setUserName(reader["UserName"].ToString());
                        LoggedInUser.setUserName(reader["UserName"].ToString());
                        // LoggedInUser.userName = reader["UserName"].ToString();
                        LoggedInUser.setUserRole(reader["Role"].ToString());
                        //LoggedInUser.userRole = reader["Role"].ToString();

                    }
               
                    if (password == txtPassword.Text)
                    {
                        MessageBox.Show("You are logged in successfully...");
                        Con.Close();
                        Home hm = new Home();
                        hm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Youre password is wrong...");
                    Con.Close();
                    }


                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUpPage = new SignUp();

            signUpPage.Show();
            this.Hide();
        }

 

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
           
            txtPassword.Text = "";

            txtPassword.ForeColor = Color.Black;

            txtPassword.UseSystemPasswordChar = true;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length == 0)
            {
                txtPassword.ForeColor = Color.Gray;

                txtPassword.Text = "Enter password";

                txtPassword.UseSystemPasswordChar = false;

                SelectNextControl(txtPassword, true, true, false, true);
            }
        }
    }
}
