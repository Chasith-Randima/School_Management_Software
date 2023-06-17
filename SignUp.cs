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
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        //SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Family\Desktop\2nd\c#\FinalProject\WindowsFormsApp1\SchoolAdmin.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\SchoolAdminDatabase\SchoolAdmin.mdf;Integrated Security=True;Connect Timeout=30");

        SqlCommand cmd;

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


        private int checkInputs()
        {
            if (txtUsername.Text == "" || txtEmail.Text == "" || txtSignupPassword.Text == "" || txtSignupPasswordConfirm.Text == "")
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {

            if (checkInputs() == 1)
            {
                MessageBox.Show("You have some missing info...Please fill all the input fields...");

            }
            else
            {
                if(txtSignupPassword.Text == txtSignupPasswordConfirm.Text)
                {
                    try
                    {
                        string query = "Insert into UserTbl Values('" + txtUsername.Text + "','" + txtEmail.Text + "','" + txtSignupPassword.Text + "','User')";
                        Con.Open();
                        cmd = new SqlCommand(query, Con);
                        int result = cmd.ExecuteNonQuery();
                        if (result == 0)
                        {
                            MessageBox.Show("There was an error..");
                        }
                        else
                        {
                            MessageBox.Show("User created successfully..");
                            Form1 loginPage = new Form1();
                            loginPage.Show();
                            this.Hide();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Passwords dosent match...");
                }
           
           
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form1 loginPage = new Form1();
            loginPage.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtSignupPassword_Enter(object sender, EventArgs e)
        {
            txtSignupPassword.Text = "";

            txtSignupPassword.ForeColor = Color.Black;

            txtSignupPassword.UseSystemPasswordChar = true;

           

        }

        private void txtSignupPassword_Leave(object sender, EventArgs e)
        {
            if (txtSignupPassword.Text.Length ==0)
            {

                txtSignupPassword.ForeColor = Color.Gray;
                txtSignupPassword.Text = "Enter Password";

                txtSignupPassword.UseSystemPasswordChar = false;

                SelectNextControl(txtSignupPassword, true, true, false, true);

            }

        }

        private void txtSignupPasswordConfirm_Enter(object sender, EventArgs e)
        {
            txtSignupPasswordConfirm.Text = "";

            txtSignupPasswordConfirm.ForeColor = Color.Black;

            txtSignupPasswordConfirm.UseSystemPasswordChar = true;
           
        }

        private void txtSignupPasswordConfirm_Leave(object sender, EventArgs e)
        {
            if(txtSignupPasswordConfirm.Text.Length == 0)
            {
                txtSignupPasswordConfirm.ForeColor = Color.Gray;
                txtSignupPasswordConfirm.Text = "Enter Password";
                txtSignupPasswordConfirm.UseSystemPasswordChar = false;
                SelectNextControl(txtSignupPasswordConfirm, true, true, false, true);

            }

        }
    }
}
