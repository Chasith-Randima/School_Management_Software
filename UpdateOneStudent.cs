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
using System.IO;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class UpdateOneStudent : Form
    {
        public UpdateOneStudent()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));


            pnlNav.Height = button3.Height;
            pnlNav.Top = button3.Top;
            pnlNav.Left = button3.Left;
            button3.BackColor = Color.FromArgb(192, 248, 250);
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

        public string studentIndex;

        private void UpdateOneStudent_Load(object sender, EventArgs e)
        {

            lblUserName.Text = LoggedInUser.getUserName();
            try
                {
                    string query = "Select * from StudentTbl where StudentIndexNumber = '" +studentIndex + "'";
                    cmd = new SqlCommand(query, Con);
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtStudentName.Text = reader["StudentName"].ToString();
                        txtAge.Text = reader["StudentAge"].ToString();
                        txtIndexNumber.Text = reader["StudentIndexNumber"].ToString();
                        cmboGrade.Text = reader["StudentGrade"].ToString();
                        MemoryStream ms = new MemoryStream((byte[])reader["StudentImage"]);
                        pictureUser.Image = Image.FromStream(ms);
                    }

                if (txtStudentName.Text == "")
                {
                    MessageBox.Show("There is no one with that index number");
                    Update upStuStaff = new Update();
                    upStuStaff.Show();
                    this.Hide();
                }




            }
            catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
            }




        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Select image(*.jpg;*png;*.Gif*.jpeg)|*.jpg;*png;*.Gif*.jpeg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureUser.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        public int checkStudentInputs()
        {
            if (txtStudentName.Text == "" || txtAge.Text == "" || txtIndexNumber.Text == "" || cmboGrade.Text == "")
            {


                return 0;
            }
            else
            {

                return 1;
            }

        }

        private void btnCreateStudent_Click(object sender, EventArgs e)
        {
            if (checkStudentInputs() == 1)
            {
                try
                {

                    string query = "Update StudentTbl set StudentName='" +txtStudentName.Text+ "',StudentAge='" +txtAge.Text+"',StudentIndexNumber ='"+txtIndexNumber.Text+"',StudentGrade ='"+cmboGrade.SelectedItem.ToString()+"',StudentImage = @UserImage where StudentIndexNumber='"+studentIndex+"'";
                    cmd = new SqlCommand(query, Con);
                    MemoryStream memstr = new MemoryStream();
                    pictureUser.Image.Save(memstr, pictureUser.Image.RawFormat);
                    cmd.Parameters.AddWithValue("UserImage", memstr.ToArray());
                    Con.Open();
                    cmd.ExecuteNonQuery();

               
                    MessageBox.Show("Student Updated Successfully...");
                    txtStudentName.Text = "";
                    txtAge.Text = "";
                    txtIndexNumber.Text = "";
                    cmboGrade.SelectedItem = null;
                    pictureUser.Image = null;

                    Home homePage = new Home();
                    homePage.Show();
                    this.Hide();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Con.Close();
                }

            }
            else
            {
                MessageBox.Show("You have some missign fields..");
            }
        }

   
  

        private void button1_Click_1(object sender, EventArgs e)
        {
            pnlNav.Height = button1.Height;
            pnlNav.Top = button1.Top;
            pnlNav.Left = button1.Left;
            button1.BackColor = Color.FromArgb(192, 248, 250);

            Home homePage = new Home();
            homePage.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            pnlNav.Height = button6.Height;
            pnlNav.Top = button6.Top;
            pnlNav.Left = button6.Left;
            button6.BackColor = Color.FromArgb(192, 248, 250);
            Search searchOne = new Search();
            searchOne.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (LoggedInUser.getUserRole() != "Admin")
            {
                MessageBox.Show("Only admins can access this route..");
            }
            else if (LoggedInUser.getUserRole() == "Admin")
            {
                pnlNav.Height = button4.Height;
                pnlNav.Top = button4.Top;
                pnlNav.Left = button4.Left;
                button4.BackColor = Color.FromArgb(192, 248, 250);

                AddStudentStaff addStuSta = new AddStudentStaff();
                addStuSta.Show();
                this.Hide();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            if (LoggedInUser.getUserRole() != "Admin")
            {
                MessageBox.Show("Only Admins can access this route...");
            }
            else if (LoggedInUser.getUserRole() == "Admin")
            {
                pnlNav.Height = button3.Height;
                pnlNav.Top = button3.Top;
                pnlNav.Left = button3.Left;
                button3.BackColor = Color.FromArgb(192, 248, 250);

                Update upStuStaff = new Update();
                upStuStaff.Show();
                this.Hide();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            if (LoggedInUser.getUserRole() != "Admin")
            {
                MessageBox.Show("Only Admins can access this route...");
            }
            else if (LoggedInUser.getUserRole() == "Admin")
            {
                pnlNav.Height = button2.Height;
                pnlNav.Top = button2.Top;
                pnlNav.Left = button2.Left;
                button2.BackColor = Color.FromArgb(192, 248, 250);

                Delete delProfile = new Delete();
                delProfile.Show();
                this.Hide();
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 logInPage = new Form1();
            logInPage.Show();
            LoggedInUser.setUserName(null);
            LoggedInUser.setUserRole(null);
            this.Hide();
        }
    }



}


