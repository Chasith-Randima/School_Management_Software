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
    public partial class AllStaff : Form
    {
        public AllStaff()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = button1.Height;
            pnlNav.Top = button1.Top;
            pnlNav.Left = button1.Left;
            button1.BackColor = Color.FromArgb(192, 248, 250);
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

        private void AllStaff_Load(object sender, EventArgs e)
        {
            lblUserName.Text = LoggedInUser.getUserName();
            try
            {
                string query = "Select * from StaffTbl";
                cmd = new SqlCommand(query, Con);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);
                dataGridAllStaff.RowTemplate.Height = 75;
                dataGridAllStaff.DataSource = dt;
                DataGridViewImageColumn pic1 = new DataGridViewImageColumn();
                pic1 = (DataGridViewImageColumn)dataGridAllStaff.Columns[5];
                pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void dataGridAllStaff_Click(object sender, EventArgs e)
        {
            string staIndex = dataGridAllStaff.CurrentRow.Cells[3].Value.ToString();

            SearchOne oneStue = new SearchOne();
            oneStue.staffIndex = staIndex;
            oneStue.Show();
            this.Hide();

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

        private void button6_Click(object sender, EventArgs e)
        {
            pnlNav.Height = button6.Height;
            pnlNav.Top = button6.Top;
            pnlNav.Left = button6.Left;
            button6.BackColor = Color.FromArgb(46, 51, 73);

            Search searchOne = new Search();
            searchOne.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (LoggedInUser.getUserRole() != "Admin")
            {
                MessageBox.Show("Only Admins can access this route...");
            }
            else if (LoggedInUser.getUserRole() == "Admin")
            {
                pnlNav.Height = button4.Height;
                pnlNav.Top = button4.Top;
                pnlNav.Left = button4.Left;
                button4.BackColor = Color.FromArgb(46, 51, 73);

                Delete delProfile = new Delete();
                delProfile.Show();
                this.Hide();
            }


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
                button3.BackColor = Color.FromArgb(46, 51, 73);

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
            }
            else if (LoggedInUser.getUserRole() == "Admin")
            {
                pnlNav.Height = button2.Height;
                pnlNav.Top = button2.Top;
                pnlNav.Left = button2.Left;
                button2.BackColor = Color.FromArgb(46, 51, 73);

                Delete delProfile = new Delete();
                delProfile.Show();
                this.Hide();
            }


        }

        private void button1_Leave(object sender, EventArgs e)
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
