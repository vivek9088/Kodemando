using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OnLineTestUsing_ADO.Net
{
    public partial class Stud_Register : Form
    {
        MySqlConnection con = new MySqlConnection(Properties.Settings.Default.conurl);
        MySqlCommand cmd;
             

        public Stud_Register()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
                                    + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                                    + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                                    + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                                    + @"[a-zA-Z]{2,}))$";
            string numberStrict = "^[0-9]{10}$";
            Regex reStrict;
            bool flag = false, check = false;

            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("All Fields are mandatory", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
           
            //Regex reStrict = new Regex("");
                reStrict = new Regex(numberStrict);
                check = reStrict.IsMatch(textBox4.Text);

                reStrict = new Regex(patternStrict);
                flag = reStrict.IsMatch(textBox5.Text);
           
                if (!check)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(textBox4, "Only 10-Digit Number allowed");
                    //textBox4.Text = "";
                    textBox4.Focus();

                }
                else if (!flag)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(textBox5, "Email-Id is in wrong format");
                    //textBox5.Text = "";
                    textBox5.Focus();
                }
                else
                {
                    errorProvider1.Clear();

                    con.Open();

                    //to insert into student table
                    cmd = new MySqlCommand("insert into student(name,course_name,id,mobnum,email) values(@name,@course,@stid,@num,@mail)", con);
                    cmd.Parameters.Add(new MySqlParameter("@name", textBox1.Text));
                    cmd.Parameters.Add(new MySqlParameter("@course", comboBox1.SelectedItem));
                    cmd.Parameters.Add(new MySqlParameter("@stid", textBox3.Text));
                    cmd.Parameters.Add(new MySqlParameter("@num", textBox4.Text));
                    cmd.Parameters.Add(new MySqlParameter("@mail", textBox5.Text));
                    cmd.ExecuteNonQuery();

                    //to insert into login table
                    cmd = new MySqlCommand("insert into login(id,uname,pwd,role) values(@sid,@uname,password(@pass),@rol)", con);
                    cmd.Parameters.Add(new MySqlParameter("@sid", textBox3.Text));
                    cmd.Parameters.Add(new MySqlParameter("@uname", textBox2.Text));
                    cmd.Parameters.Add(new MySqlParameter("@pass", textBox6.Text));
                    cmd.Parameters.Add(new MySqlParameter("@rol", "Student"));
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Student Registered Successfully..", "Register Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Close();

                    DialogResult dr = MessageBox.Show("Do you want to add another?", "Insert More", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        this.Hide();
                        new Stud_Register().Show();
                    }
                    else
                    {
                        this.Hide();
                        new LoginForm().Show();
                    }
                }
            }
        }

              private void Stud_Register_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            textBox3.Text = System.DateTime.Now.Day.ToString() + rnd.Next(1, 1000).ToString();

            MySqlCommand get = new MySqlCommand("select ename from exam", con);
            con.Open();
            MySqlDataReader dr = get.ExecuteReader();
            comboBox1.Items.Add("Select Course");
            while (dr.Read())
            {
                comboBox1.Items.Add(dr.GetString("ename"));
            }
            dr.Close();
            con.Close();
            this.ActiveControl = label1;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
            Regex reg = new Regex("^[a-zA-Z\\s]+$");

            bool temp = false;
            temp=reg.IsMatch(textBox1.Text);
            
            if (!temp)
            {
                errorProvider1.SetError(textBox1, "No Numbers Allowed");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

               
    }
}
