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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = button1.Height;
            pnlNav.Top = button1.Top;
            pnlNav.Left = button1.Left;
            button1.BackColor = Color.FromArgb(192, 248, 250);
        }
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

        //SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Family\Desktop\2nd\c#\FinalProject\WindowsFormsApp1\SchoolAdmin.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\SchoolAdminDatabase\SchoolAdmin.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (LoggedInUser.getUserRole() != "Admin")
            {
                MessageBox.Show("Only admins can access this route..");
            }else if(LoggedInUser.getUserRole() == "Admin")
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

        private void btnAllStudents_Click(object sender, EventArgs e)
        {
            AllStudents allStudentsGrid = new AllStudents();
            allStudentsGrid.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {

            lblUserName.Text = LoggedInUser.getUserName();

            lblTotalClasses.Text = "13";

            try
            {
               string query = "Select count(Id) as numberCount from StudentTbl;";
            cmd = new SqlCommand(query, Con);
            Con.Open();
            cmd.ExecuteNonQuery();


            
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                lblTotalStudents.Text = reader["numberCount"].ToString();
            }

                Con.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string query = "Select count(Id) as numberCount from StaffTbl;";
                cmd = new SqlCommand(query, Con);
                Con.Open();
                cmd.ExecuteNonQuery();

                //lblStudents.Text = number.ToString();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblTotalStaff.Text = reader["numberCount"].ToString();
                }

                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAllStaff_Click(object sender, EventArgs e)
        {
            AllStaff allStaffGrid = new AllStaff();

            allStaffGrid.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (LoggedInUser.getUserRole() != "Admin")
            {
                MessageBox.Show("Only Admins can access this route...");
            }else if(LoggedInUser.getUserRole() == "Admin")
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

        private void btnAllClasses_Click(object sender, EventArgs e)
        {
            AllClasses alClasses = new AllClasses();
            alClasses.Show();
            this.Hide();
        }



        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
