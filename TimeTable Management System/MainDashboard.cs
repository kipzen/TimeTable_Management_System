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
            Specialisationcombofill();
            Levelcombofill();
            Teacherscombofill();
            combofillyear();
            combofillTerm();
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

        public void combofillyear()
        {
            try
            {
                // combo fill Year
                guna2ComboBox3Year.Items.Clear();
                guna2ComboBox2year.Items.Clear();
                guna2ComboBox23year.Items.Clear();
                SqlCommand cmdYear = new SqlCommand("Select * From Year ", con);
                con.Open();
                SqlDataReader sdrYear = cmdYear.ExecuteReader();
                while (sdrYear.Read())
                {
                    string sname = sdrYear["Year"].ToString();
                    guna2ComboBox3Year.Items.Add(sname);
                    guna2ComboBox2year.Items.Add(sname);
                    guna2ComboBox23year.Items.Add(sname);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        public void combofillTerm()
        {
            try
            {
                guna2ComboBox2term.Items.Clear();
                guna2ComboBox3term.Items.Clear();
                guna2ComboBox1term.Items.Clear();
                SqlCommand cmdTerm = new SqlCommand("Select * From Term ", con);
                con.Open();
                SqlDataReader sdrTerm = cmdTerm.ExecuteReader();
                while (sdrTerm.Read())
                {
                    string sname = sdrTerm["Term"].ToString();
                    guna2ComboBox2term.Items.Add(sname);
                    guna2ComboBox3term.Items.Add(sname);
                    guna2ComboBox1term.Items.Add(sname);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }
        public void Specialisationcombofill()
        {
            try
            {
                guna2ComboBox2specialisation.Items.Clear();
                SqlCommand cmd = new SqlCommand("Select * From Specialisation", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    string sname = sdr["Specialisation"].ToString();
                    guna2ComboBox2specialisation.Items.Add(sname);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        public void Streamcombofill()
        {
          
        }

        public void Teacherscombofill()
        {
            try
            {
                guna2ComboBox2TNo.Items.Clear();
                SqlCommand cmd = new SqlCommand("Select * From Teachers Where Status='Teaching'", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    string sname = sdr["TeacherNo"].ToString();
                    guna2ComboBox2TNo.Items.Add(sname);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        public void Levelcombofill()
        {
            try
            {
                guna2ComboBox1Level.Items.Clear();
                SqlCommand cmd = new SqlCommand("Select * From Level", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    string sname = sdr["Level"].ToString();
                    guna2ComboBox1Level.Items.Add(sname);
                }
                con.Close();

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
                guna2ComboBox3cat.Items.Clear();
                guna2ComboBox3category.Items.Clear();
                guna2ComboBox1SchCat.Items.Clear();
                guna2ComboBox1SchCategory.Items.Clear();
                SqlCommand cmd = new SqlCommand("Select * From School_Category", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    string sname = sdr["CategoryName"].ToString();
                    guna2ComboBox3cat.Items.Add(sname);
                    guna2ComboBox3category.Items.Add(sname);
                    guna2ComboBox1SchCat.Items.Add(sname);
                    guna2ComboBox1SchCategory.Items.Add(sname);
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

        private void tabPage1MENU_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1SAVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox1TNO.Text!="" && guna2TextBox2Tname.Text!="" && guna2TextBox3phoneNo.Text!="" && guna2TextBox5Email.Text!="" && guna2ComboBox1Level.SelectedItem!=null && guna2ComboBox2specialisation.SelectedItem!=null)
                {
                    string TeacherNumber = "TN"+guna2TextBox1TNO.Text;
                    SqlCommand validate = new SqlCommand("Select * From Teachers where TeacherNo='"+ TeacherNumber + "' ",con);
                    con.Open();
                    SqlDataReader SDR = validate.ExecuteReader();
                    if (SDR.HasRows)
                    {
                        MessageBox.Show("Teacher already Exist..!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }
                    else
                    {
                        string status = "Teaching";
                        SqlCommand cmd1 = new SqlCommand("insert into Teachers values('" + TeacherNumber + "','" + guna2TextBox2Tname.Text + "','" + guna2TextBox3phoneNo.Text + "','" + guna2DateTimePicker1recruited.Value + "','" + guna2TextBox5Email.Text + "','" + guna2ComboBox1Level.SelectedItem + "','" + guna2ComboBox2specialisation.SelectedItem + "','" + status + "')", con);

                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Teacher successfully saved.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        guna2TextBox1TNO.Text = "";
                        guna2TextBox2Tname.Text = "";
                        guna2TextBox3phoneNo.Text = "";
                        guna2DateTimePicker1recruited.Value = DateTime.Now;
                        guna2TextBox5Email.Text = "";
                        guna2ComboBox2specialisation.SelectedItem = null;
                        guna2ComboBox1Level.SelectedItem = null;
                        
                    }

                }
                else
                {
                    MessageBox.Show("Provide all details.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();

            }
        }

        private void guna2TextBox5Email_TextChanged(object sender, EventArgs e)
        {
            
           
        }

        private void guna2TextBox5Email_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (guna2TextBox5Email.Text.Length>0 && !rEMail.IsMatch(guna2TextBox5Email.Text))
            {
                MessageBox.Show("Invalid E-Mail.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                guna2TextBox5Email.SelectAll();

                e.Cancel = true;
            }
        }

        private void guna2Button20_Click_1(object sender, EventArgs e)
        {
           
        }

        private void topTeacherpnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Levelcombofill();
            schoolcatcombofill();
            Specialisationcombofill();
        }

        private void guna2GroupBox9otherdetails_Click(object sender, EventArgs e)
        {

        }

        private void TimetableDetails_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1SchCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                //combo fill classes
                guna2ComboBox3Class.Items.Clear();
                guna2ComboBox1Class.Items.Clear();
                SqlCommand cmdClass = new SqlCommand("Select * From Classes where SchoolCategory='"+ guna2ComboBox1SchCat.SelectedItem+ "' ", con);
                con.Open();
                SqlDataReader sdrClass = cmdClass.ExecuteReader();
                while (sdrClass.Read())
                {
                    string sname = sdrClass["ClassName"].ToString();
                    guna2ComboBox3Class.Items.Add(sname);
                    guna2ComboBox1Class.Items.Add(sname);
                }

                // Fill combo Subjects.
                guna2ComboBox1Tsubject.Items.Clear();
                SqlCommand cmdSubject = new SqlCommand("Select * From Subject where SchoolCategory='" + guna2ComboBox1SchCat.SelectedItem + "' ", con);
                SqlDataReader sdrSubject = cmdSubject.ExecuteReader();
                while (sdrSubject.Read())
                {
                    string sname = sdrSubject["Subject_Code"].ToString();
                    guna2ComboBox1Tsubject.Items.Add(sname);
                }

                // combo fill Year
                guna2ComboBox3Year.Items.Clear();
                guna2ComboBox2year.Items.Clear();
                SqlCommand cmdYear = new SqlCommand("Select * From Year ", con);
                SqlDataReader sdrYear = cmdYear.ExecuteReader();
                while (sdrYear.Read())
                {
                    string sname = sdrYear["Year"].ToString();
                    guna2ComboBox3Year.Items.Add(sname);
                    guna2ComboBox2year.Items.Add(sname);
                }

                // Combo fill Term 
                guna2ComboBox2term.Items.Clear();
                SqlCommand cmdTerm = new SqlCommand("Select * From Term ", con);
                SqlDataReader sdrTerm = cmdTerm.ExecuteReader();
                while (sdrTerm.Read())
                {
                    string sname = sdrTerm["Term"].ToString();
                    guna2ComboBox2term.Items.Add(sname);
                }

                // Combo fill Time
                guna2ComboBox3time.Items.Clear();
                SqlCommand cmdTime = new SqlCommand("Select * From Time ", con);
                SqlDataReader sdrTime = cmdTime.ExecuteReader();
                while (sdrTime.Read())
                {
                    string sname = sdrTime["Time"].ToString();
                    guna2ComboBox3time.Items.Add(sname);
                }

                //Combo fill Day
                guna2ComboBox4Day.Items.Clear();
                SqlCommand cmdDay = new SqlCommand("Select * From Days ", con);
                SqlDataReader sdrDay = cmdDay.ExecuteReader();
                while (sdrDay.Read())
                {
                    string sname = sdrDay["Day"].ToString();
                    guna2ComboBox4Day.Items.Add(sname);
                }


                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();

            }
        }

        private void guna2ComboBox3Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                guna2ComboBox2Stream.Items.Clear();
                SqlCommand cmd = new SqlCommand("Select * From Stream", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    string sname = sdr["Stream"].ToString();
                    guna2ComboBox2Stream.Items.Add(sname);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        public string TeachingSubjectCode { get; set; }
        public string statusTimetable { get; set; }

        private void guna2Button23save_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox2TNo.SelectedItem != null && guna2ComboBox4Day.SelectedItem != null && guna2ComboBox3time.SelectedItem != null && guna2ComboBox3Year.SelectedItem != null && guna2ComboBox2term.SelectedItem != null && guna2ComboBox1SchCat.SelectedItem != null && guna2ComboBox3Class.SelectedItem != null && guna2ComboBox2Stream.SelectedItem != null && guna2ComboBox1Tsubject.SelectedItem != null)
            {
                try
                {
                    TeachingSubjectCode = guna2ComboBox2TNo.Text + "-" + guna2ComboBox1Tsubject.Text;
                    statusTimetable = "Active";

                    SqlCommand validate = new SqlCommand("Select * From Timetable where TeacherNo='" + guna2ComboBox2TNo.SelectedItem + "' AND Time='" + guna2ComboBox3time.SelectedItem + "' AND Day='" + guna2ComboBox4Day.SelectedItem + "' AND Status='"+ statusTimetable + "'", con);
                    con.Open();
                    SqlDataReader sdrv = validate.ExecuteReader();
                    if (sdrv.HasRows)
                    {
                        MessageBox.Show("Teacher already Assigned to this Time" + guna2ComboBox3time.SelectedItem, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }
                    else
                    {
                        SqlCommand validcmd = new SqlCommand("Select * From Timetable where Class='" + guna2ComboBox3Class.SelectedItem + "' AND Stream='" + guna2ComboBox2Stream.SelectedItem + "' AND Time='" + guna2ComboBox3time.SelectedItem + "' AND Day='" + guna2ComboBox4Day.SelectedItem + "' AND Status='"+ statusTimetable + "'", con);
                        SqlDataReader sdrcmdVal = validcmd.ExecuteReader();
                        if (sdrcmdVal.HasRows)
                        {
                            MessageBox.Show("Class already Assigned to Time: " + guna2ComboBox3time.SelectedItem, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            con.Close();
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("Insert into Timetable values('" + guna2ComboBox2TNo.SelectedItem + "','" + guna2ComboBox4Day.SelectedItem + "','" + guna2ComboBox3time.SelectedItem + "','" + guna2ComboBox3Year.SelectedItem + "','" + guna2ComboBox2term.SelectedItem + "','" + guna2ComboBox1SchCat.SelectedItem + "','" + guna2ComboBox3Class.SelectedItem + "','" + guna2ComboBox2Stream.SelectedItem + "','" + guna2ComboBox1Tsubject.SelectedItem + "','" + TeachingSubjectCode + "','" + statusTimetable + "')", con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Saved Successfully", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            con.Close();
                            guna2ComboBox2TNo.SelectedItem = null;
                            guna2ComboBox4Day.SelectedItem = null;
                            guna2ComboBox3time.SelectedItem = null;
                            guna2ComboBox3Year.SelectedItem = null;
                            guna2ComboBox2term.SelectedItem = null;
                            guna2ComboBox2Stream.SelectedItem = null;
                            guna2ComboBox1Tsubject.SelectedItem = null;
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }

            }
            else
            {
                MessageBox.Show("Please Provide all Details." + guna2ComboBox3time.SelectedItem, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void guna2ComboBox3time_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  textBox1.Text = guna2ComboBox2TNo.Text +"-"+guna2ComboBox1Tsubject.Text;
        }

        private void guna2Button20new_Click(object sender, EventArgs e)
        {
            guna2ComboBox2TNo.SelectedItem = null;
            guna2ComboBox4Day.SelectedItem = null;
            guna2ComboBox3time.SelectedItem = null;
            guna2ComboBox3Year.SelectedItem = null;
            guna2ComboBox2term.SelectedItem = null;
            guna2ComboBox2Stream.SelectedItem = null;
            guna2ComboBox1Tsubject.SelectedItem = null;
        }

        private void guna2TabControl1Timetable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox3Year_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1SchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //combo fill classes
                guna2ComboBox1Class.Items.Clear();
                SqlCommand cmdClass = new SqlCommand("Select * From Classes where SchoolCategory='" + guna2ComboBox1SchCategory.SelectedItem + "' ", con);
                con.Open();
                SqlDataReader sdrClass = cmdClass.ExecuteReader();
                while (sdrClass.Read())
                {
                    string sname = sdrClass["ClassName"].ToString();
                    guna2ComboBox1Class.Items.Add(sname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void guna2Button20_Click_2(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("", con);
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                sda.Fill(dt);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
           

        }
    }
}
