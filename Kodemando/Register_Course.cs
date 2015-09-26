using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace OnLineTestUsing_ADO.Net
{
    public partial class Register_Course : Form
    {
        MySqlConnection con = new MySqlConnection(Properties.Settings.Default.conurl);
        MySqlCommand cmd;
        MySqlDataReader dr;
       
        public Register_Course()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int exid = 0;
            string eid;
            if(textBox2.Text=="" || textBox3.Text=="" ||textBox4.Text=="")
            {
            MessageBox.Show("Input cannot be empty","Input Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if(Convert.ToInt32(textBox4.Text)>50)
            {
                MessageBox.Show("Maximum Questions allowed is 50.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Text = "";
                textBox4.Focus();
            }
            else
            {
            try
            {
            
            con.Open();
            cmd = new MySqlCommand("select eid from exam order by eid desc limit 1", con);
            dr = cmd.ExecuteReader();
            dr.Read();
            exid =int.Parse( dr.GetString("eid").Substring(1))+1;
            dr.Close();
            if (exid.ToString().Length == 1 || exid.ToString().Length == 2)
            {
                eid = "E0" + exid.ToString();
            }
            else
            {
                eid = "E" + exid.ToString();
            }
               
            cmd = new MySqlCommand("insert into exam(eid,ename,duration,tot_quest) values(@id,@name,@dur,@qst)",con);
       
                cmd.Parameters.AddWithValue("id",eid);
            cmd.Parameters.AddWithValue("name",textBox2.Text);
            cmd.Parameters.AddWithValue("dur",textBox3.Text);
            cmd.Parameters.AddWithValue("qst",textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
                MessageBox.Show("Course added successfully", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult dr1 = MessageBox.Show("Do you want to add another?", "Insert More", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr1 == DialogResult.Yes)
                {
                    this.Hide();
                    new Register_Course().Show();
                }
                else
                {
                    this.Hide();
                    new LoginForm().Show();
                }
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            }
                
        }

        private void Register_Course_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
                        
        }

       
        private void textBox2_Leave(object sender, EventArgs e)
        {
            Regex reg = new Regex("^[a-zA-Z\\s]+$");

            bool temp = false;
            temp = reg.IsMatch(textBox2.Text);
            if (!temp)
            {
                MessageBox.Show("No Numbers Allowed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Text = "";
                textBox2.Focus();
            }
           
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            Regex reg = new Regex("^[0-9]+$");

            bool temp = false;
            temp = reg.IsMatch(textBox3.Text);
            if (!temp)
            {
                MessageBox.Show("Only 2-Digit Number Allowed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Text = "";
                textBox3.Focus();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            Regex reg = new Regex("^[0-9]+$");

            bool temp = false;
            temp = reg.IsMatch(textBox4.Text);
            if (!temp)
            {
                MessageBox.Show("Only 2-Digit Number Allowed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Text = "";
                textBox4.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            new LoginForm().Show();
        }

          }
}
