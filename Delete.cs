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

namespace WindowsFormsApp1
{
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));


            pnlNav.Height = button2.Height;
            pnlNav.Top = button2.Top;
            pnlNav.Left = button2.Left;
            button2.BackColor = Color.FromArgb(192, 248, 250);
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



    private void btnStudentSearch_Click(object sender, EventArgs e)
        {
            DeleteOne delStu = new DeleteOne();
            delStu.studentIndex = studentIndex.Text;
            delStu.Show();
            this.Hide();
        }

        private void btnStaffSearch_Click(object sender, EventArgs e)
        {
            DeleteOne delStu = new DeleteOne();
            delStu.staffIndex = staffIndex.Text;
            delStu.Show();
            this.Hide();
        }



        private void Delete_Load(object sender, EventArgs e)
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
