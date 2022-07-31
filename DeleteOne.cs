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
    public partial class DeleteOne : Form
    {
        public DeleteOne()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            pnlNav.Height = button2.Height;
            pnlNav.Top = button2.Top;
            pnlNav.Left = button2.Left;
            button2.BackColor = Color.FromArgb(192, 248, 250);


        }

        // SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Family\Desktop\2nd\c#\FinalProject\WindowsFormsApp1\SchoolAdmin.mdf;Integrated Security=True;Connect Timeout=30");
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


        public string staffIndex;
        public string studentIndex;

        private void DeleteOne_Load(object sender, EventArgs e)
        {
            lblUserName.Text = LoggedInUser.getUserName();


            if (studentIndex != null)
            {
                lblProfile.Text = "Delete Student Profile";
                try
                {
                    string query = "Select * from StudentTbl where StudentIndexNumber = '" + studentIndex + "'";
                    cmd = new SqlCommand(query, Con);
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        lblName.Text = reader["StudentName"].ToString();
                        //lblAge.Text = reader["StudentAge"].ToString();
                        //lblIndexNumber.Text = reader["StudentIndexNumber"].ToString();
                        //lblGrade.Text = reader["StudentGrade"].ToString();
                        MemoryStream ms = new MemoryStream((byte[])reader["StudentImage"]);
                        //MemoryStream ms = new MemoryStream(data);
                        pictureBoxProfile.Image = Image.FromStream(ms);
                        //studentPictureBox.Image = reader["UserImage"].ToString();
                    }

                    if(lblName.Text == "")
                    {
                        MessageBox.Show("There is no one with that index number");


                        Delete delProfile = new Delete();
                        delProfile.Show();
                        this.Hide();
                    }


                    Con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (staffIndex != null)

                lblProfile.Text = "Delete Staff Member Profile";
            {
                try
                {
                    string query = "Select * from StaffTbl where StaffNumber = '" + staffIndex + "'";
                    cmd = new SqlCommand(query, Con);
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        lblName.Text = reader["StaffName"].ToString();
                       // lblAge.Text = reader["StaffAge"].ToString();
                        //lblIndexNumber.Text = reader["StaffNumber"].ToString();
                        //lblGrade.Text = reader["StaffAssignedClass"].ToString();
                        MemoryStream ms = new MemoryStream((byte[])reader["StaffPicture"]);
                        //MemoryStream ms = new MemoryStream(data);
                        pictureBoxProfile.Image = Image.FromStream(ms);
                        //studentPictureBox.Image = reader["UserImage"].ToString();
                    }

                    if (lblName.Text == "")
                    {
                        MessageBox.Show("There is no one with that index number");


                        Delete delProfile = new Delete();
                        delProfile.Show();
                        this.Hide();
                    }



                    Con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlNav.Height = button1.Height;
            pnlNav.Top = button1.Top;
            pnlNav.Left = button1.Left;
            button1.BackColor = Color.FromArgb(46, 51, 73);



            Home homePage = new Home();
            homePage.Show();
            this.Hide();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if(studentIndex != null)
            {
                try
                {
                    string query = "Delete from StudentTbl where StudentIndexNumber = '" + studentIndex + "'";
                    cmd = new SqlCommand(query, Con);
                    Con.Open();

                    int result = cmd.ExecuteNonQuery();

                    if (result == 0)
                    {
                        MessageBox.Show("There was an error deleting....");
                    }
                    else if (result == 1)
                    {
                        MessageBox.Show("Profile deleted successfully...");
                        Home homePage = new Home();
                        homePage.Show();
                        this.Hide();
                    }


                    Con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }else if(staffIndex != null)
            {
                try
                {
                    string query = "Delete from StaffTbl where StaffNumber = '" + staffIndex + "'";
                    cmd = new SqlCommand(query, Con);
                    Con.Open();

                    int result = cmd.ExecuteNonQuery();

                    if (result == 0)
                    {
                        MessageBox.Show("There was an error deleting....");
                    }
                    else if (result == 1)
                    {
                        MessageBox.Show("Profile deleted successfully...");
                        Home homePage = new Home();
                        homePage.Show();
                        this.Hide();

                    }


                    Con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            
        }


        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            pnlNav.Height = button1.Height;
            pnlNav.Top = button1.Top;
            pnlNav.Left = button1.Left;
            button1.BackColor = Color.FromArgb(192, 248, 250);
            // button1.BackColor = Color.FromArgb(46, 51, 73);

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
