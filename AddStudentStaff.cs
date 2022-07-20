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
    public partial class AddStudentStaff : Form
    {
        public AddStudentStaff()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = button4.Height;
            pnlNav.Top = button4.Top;
            pnlNav.Left = button4.Left;
            button4.BackColor = Color.FromArgb(192, 248, 250);
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

                    string query = "Insert into StudentTbl values('" + txtStudentName.Text + "','" + txtAge.Text + "','" + txtIndexNumber.Text + "','" + cmboGrade.SelectedItem.ToString() + "',@UserImage)";
                    cmd = new SqlCommand(query, Con);
                    MemoryStream memstr = new MemoryStream();
                    pictureUser.Image.Save(memstr, pictureUser.Image.RawFormat);
                    cmd.Parameters.AddWithValue("UserImage", memstr.ToArray());
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Student Created Successfully..");
                    txtStudentName.Text = "";
                    txtAge.Text = "";
                    txtIndexNumber.Text = "";
                    cmboGrade.SelectedItem = null;
                    pictureUser.Image = null;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "Select image(*.jpg;*png;*.Gif*.jpeg)|*.jpg;*png;*.Gif*.jpeg";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                pictureBoxStaff.Image = Image.FromFile(openFileDialog2.FileName);
            }
        }

        public int checkStaffInputs()
        {
            if(txtStaffName.Text == "" || txtStaffAge.Text == "" || txtStaffNumber.Text =="" || cmbAssignedClass.Text == "")
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private void btnCreateStaff_Click(object sender, EventArgs e)
        {
            if (checkStaffInputs() == 1)
            {
                try
                {

                    string query = "Insert into StaffTbl values('" + txtStaffName.Text + "','" + txtStaffAge.Text + "','" + txtStaffNumber.Text + "','" + cmbAssignedClass.SelectedItem.ToString() + "',@UserImage)";
                    cmd = new SqlCommand(query, Con);
                    MemoryStream memstr = new MemoryStream();
                    pictureBoxStaff.Image.Save(memstr,pictureBoxStaff.Image.RawFormat);
                    cmd.Parameters.AddWithValue("UserImage", memstr.ToArray());
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Staff Created Successfully...");
                    txtStaffName.Text = "";
                    txtStaffAge.Text = "";
                    txtStaffNumber.Text = "";
                    cmbAssignedClass.SelectedItem = null;
                    pictureBoxStaff.Image = null;

                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("You have some missing fields..");
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {

            pnlNav.Height = button1.Height;
            pnlNav.Top = button1.Top;
            pnlNav.Left = button1.Left;
            button1.BackColor = Color.FromArgb(46, 51, 73);

            Search searchOne = new Search();
            searchOne.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnlNav.Height = button4.Height;
            pnlNav.Top = button4.Top;
            pnlNav.Left = button4.Left;
            button4.BackColor = Color.FromArgb(46, 51, 73);


            AddStudentStaff addStuSta = new AddStudentStaff();

            addStuSta.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlNav.Height = button3.Height;
            pnlNav.Top = button3.Top;
            pnlNav.Left = button3.Left;
            button3.BackColor = Color.FromArgb(46, 51, 73);



            Update upStuStaff = new Update();
            upStuStaff.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlNav.Height = button2.Height;
            pnlNav.Top = button2.Top;
            pnlNav.Left = button2.Left;
            button2.BackColor = Color.FromArgb(46, 51, 73);

            Delete delProfile = new Delete();
            delProfile.Show();
            this.Hide();
        }

        private void AddStudentStaff_Load(object sender, EventArgs e)
        {


            lblUserName.Text = LoggedInUser.getUserName();

            if (LoggedInUser.getUserRole() != "Admin")
            {
                MessageBox.Show("Only admins can access this route..");
                Home homePage = new Home();
                homePage.Show();
                this.Hide();
            }
        }

        private void pnlNav_Leave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(89, 131, 145);
        }

        private void button6_Leave(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(89, 131, 145);
        }

        private void button4_Leave(object sender, EventArgs e)
        {

            button4.BackColor = Color.FromArgb(89, 131, 145);
        }

        private void button3_Leave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(89, 131, 145);
        }

        private void button2_Leave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(89, 131, 145);
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

        private void label11_Click(object sender, EventArgs e)
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
