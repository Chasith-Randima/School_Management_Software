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
    public partial class UpdateOneStaff : Form
    {
        public UpdateOneStaff()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            pnlNav.Height = button3.Height;
            pnlNav.Top = button3.Top;
            pnlNav.Left = button3.Left;
            button3.BackColor = Color.FromArgb(192, 248, 250);
        }

        //  SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Family\Desktop\2nd\c#\FinalProject\WindowsFormsApp1\SchoolAdmin.mdf;Integrated Security=True;Connect Timeout=30");
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


        public string staffNumber;

        private void UpdateOneStaff_Load(object sender, EventArgs e)
        {
            lblUserName.Text = LoggedInUser.getUserName();

            try
            {
                string query = "Select * from StaffTbl where StaffNumber = '" + staffNumber + "'";
                cmd = new SqlCommand(query, Con);
                Con.Open();
                
                cmd.ExecuteNonQuery();
             
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    
                    txtStaffName.Text = reader["StaffName"].ToString();
                    txtStaffAge.Text = reader["StaffAge"].ToString();
                    txtStaffNumber.Text = reader["StaffNumber"].ToString();
                    cmbAssignedClass.Text = reader["StaffAssignedClass"].ToString();
                    MemoryStream ms = new MemoryStream((byte[])reader["StaffPicture"]);
                    pictureBoxStaff.Image = Image.FromStream(ms);
                    
                }
                if (txtStaffName.Text == "")
                {
                    MessageBox.Show("There is no one with that index number");
                    Update upStuStaff = new Update();
                    upStuStaff.Show();
                    this.Hide();
                }

                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        public int checkStaffInputs()
        {
            if (txtStaffName.Text == "" || txtStaffAge.Text == "" || txtStaffNumber.Text == "" || cmbAssignedClass.Text == "")
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

                    string query = "Update StaffTbl set StaffName='" + txtStaffName.Text + "',StaffAge='" +txtStaffAge.Text + "',StaffNumber ='" + txtStaffNumber.Text + "',StaffAssignedClass ='" + cmbAssignedClass.SelectedItem.ToString() + "',StaffPicture = @UserImage where StaffNumber='" + staffNumber + "'";
                    cmd = new SqlCommand(query, Con);
                    MemoryStream memstr = new MemoryStream();
                    pictureBoxStaff.Image.Save(memstr, pictureBoxStaff.Image.RawFormat);
                    cmd.Parameters.AddWithValue("UserImage", memstr.ToArray());
                    Con.Open();
                    cmd.ExecuteNonQuery();
        

                    MessageBox.Show("Student Updated Successfully...");
                    txtStaffName.Text = "";
                    txtStaffAge.Text = "";
                    txtStaffNumber.Text = "";
                    cmbAssignedClass.SelectedItem = "";
                    pictureBoxStaff.Image = null;

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

        private void btnBrowseStaff_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Select image(*.jpg;*png;*.Gif*.jpeg)|*.jpg;*png;*.Gif*.jpeg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBoxStaff.Image = Image.FromFile(openFileDialog1.FileName);
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
