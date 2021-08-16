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

namespace TimeTable_Management_System
{
    public partial class MainDashboard : Form
    {
        public MainDashboard()
        {
            InitializeComponent();
            schoolcatcombofill();
        }

        SqlConnection con = new SqlConnection("Data Source=(localDB)\\MSSQLLocalDB;Initial Catalog=Timetable;Integrated Security=True; MultipleActiveResultSets=True");

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            mainPanel.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageTeachers.BringToFront();
        }

        private void btntimetable_Click(object sender, EventArgs e)
        {
            TimeTable.BringToFront();
        }

        private void btnAppSetUp_Click(object sender, EventArgs e)
        {
            SetUp_Parameters.BringToFront();
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            mainPanel.BringToFront();

        }

        private void TopHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SideNav_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainbody_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SetUp_Parameters_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TimeTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ManageTeachers_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button22_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox12cat.Text!="")
                {
                    SqlCommand validate = new SqlCommand("Select * From School_Category Where ([CategoryName]='"+ guna2TextBox12cat.Text + "')",con);
                    con.Open();
                    SqlDataReader sdr = validate.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        MessageBox.Show("School Category already exist !!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("Insert into School_Category values('" + guna2TextBox12cat.Text + "')", con);
                        
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("School Category Saved Successfully.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        guna2TextBox12cat.Text = "";
                    }
                    
                }
                else
                {
                    MessageBox.Show("Provide All Details.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void guna2Button21_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * FROM School_Category ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView3Category.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TextBox12cat.Text = "";
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2ComboBox3cat.SelectedItem != null && guna2TextBox11class.Text!="")
                {
                    SqlCommand validate = new SqlCommand("Select * From Classes Where ([SchoolCategory]='" + guna2ComboBox3cat.SelectedItem + "'AND [ClassName]='"+ guna2TextBox11class.Text + "')", con);
                    con.Open();
                    SqlDataReader sdr = validate.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        MessageBox.Show("Class  "+ guna2TextBox11class.Text + "  already exist !!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("Insert into Classes values('" + guna2TextBox11class.Text + "','"+ guna2ComboBox3cat.SelectedItem + "')", con);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Class Saved Successfully.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        guna2TextBox11class.Text = "";
                    }

                }
                else
                {
                    MessageBox.Show("Provide All Details.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        public void schoolcatcombofill()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * From School_Category",con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    string sname = sdr["CategoryName"].ToString();
                    guna2ComboBox3cat.Items.Add(sname);
                    guna2ComboBox3category.Items.Add(sname);
                }
                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2TextBox11class.Text = "";
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * FROM Classes ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2Class.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox10stream.Text != "")
                {
                    SqlCommand validate = new SqlCommand("Select * From Stream Where ([stream]='" + guna2TextBox10stream.Text+ "')", con);
                    con.Open();
                    SqlDataReader sdr = validate.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        MessageBox.Show("Stream  " + guna2TextBox10stream.Text + "  already exist !!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("Insert into Stream values('" + guna2TextBox10stream.Text + "')", con);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Stream Saved Successfully.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        guna2TextBox10stream.Text = "";
                    }

                }
                else
                {
                    MessageBox.Show("Provide All Details.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2TextBox10stream.Text = "";
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * FROM Stream ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1Stream.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {

            try
            {
                if (guna2TextBox9subject.Text != "" && guna2TextBox10subjectcode.Text!="" && guna2ComboBox3category.SelectedItem!=null)
                {
                    SqlCommand validate = new SqlCommand("Select * From Subject Where ([Subject_Name]='" + guna2TextBox9subject.Text + "' AND [SchoolCategory]='"+ guna2ComboBox3category.SelectedItem+ "')", con);
                    con.Open();
                    SqlDataReader sdr = validate.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        MessageBox.Show("Subject  " + guna2TextBox9subject.Text + "  already exist !!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("Insert into Subject values('" + guna2TextBox10subjectcode.Text + "','"+ guna2TextBox9subject.Text+ "','"+ guna2ComboBox3category.SelectedItem + "')", con);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Subject Saved Successfully.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        guna2TextBox9subject.Text = "";
                        guna2TextBox10subjectcode.Text = "";
                    }

                }
                else
                {
                    MessageBox.Show("Provide All Details.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }

        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * FROM Subject ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView4Subject.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2TextBox9subject.Text = "";
            guna2TextBox10subjectcode.Text = "";
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

            try
            {
                if (guna2TextBox8day.Text != "" )
                {
                    SqlCommand validate = new SqlCommand("Select * From Days Where ([Day]='" + guna2TextBox8day.Text + "')", con);
                    con.Open();
                    SqlDataReader sdr = validate.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        MessageBox.Show("Day  " + guna2TextBox8day.Text + "  already exist !!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("Insert into Days values('" + guna2TextBox8day.Text + "')", con);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Day Saved Successfully.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        guna2TextBox8day.Text = "";
                    }

                }
                else
                {
                    MessageBox.Show("Provide All Details.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }

        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            guna2TextBox8day.Text = "";
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * FROM Days ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView5Days.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox7time.Text != "")
                {
                    SqlCommand validate = new SqlCommand("Select * From Time Where ([Time]='" + guna2TextBox7time.Text + "')", con);
                    con.Open();
                    SqlDataReader sdr = validate.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        MessageBox.Show("Time  " + guna2TextBox7time.Text + "  already exist !!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("Insert into Time values('" + guna2TextBox7time.Text + "')", con);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Time Saved Successfully.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        guna2TextBox7time.Text = "";
                    }

                }
                else
                {
                    MessageBox.Show("Provide All Details.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }

        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            guna2TextBox7time.Text = "";
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * FROM Time ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView6Time.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void guna2Button7save_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox6term.Text != "")
                {
                    SqlCommand validate = new SqlCommand("Select * From Term Where ([Term]='" + guna2TextBox6term.Text + "')", con);
                    con.Open();
                    SqlDataReader sdr = validate.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        MessageBox.Show("Term  " + guna2TextBox6term.Text + "  already exist !!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("Insert into Term values('" + guna2TextBox6term.Text + "')", con);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Term Saved Successfully.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        guna2TextBox6term.Text = "";
                    }

                }
                else
                {
                    MessageBox.Show("Provide All Details.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            guna2TextBox6term.Text = "";
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * FROM Term ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView7term.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void guna2Button8save_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox4year.Text != "")
                {
                    SqlCommand validate = new SqlCommand("Select * From Year Where ([Year]='" + guna2TextBox4year.Text + "')", con);
                    con.Open();
                    SqlDataReader sdr = validate.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        MessageBox.Show("Year  " + guna2TextBox4year.Text + "  already exist !!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("Insert into Year values('" + guna2TextBox4year.Text + "')", con);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Year Saved Successfully.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        guna2TextBox4year.Text = "";
                    }

                }
                else
                {
                    MessageBox.Show("Provide All Details.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * FROM Year ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView8year.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            guna2TextBox4year.Text = "";
        }
    }
}
