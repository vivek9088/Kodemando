using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
namespace OnLineTestUsing_ADO.Net
{
    public partial class Faculty : Form
    {
        MySqlConnection con = new MySqlConnection(Properties.Settings.Default.conurl);
        MySqlCommand cmd;
       
        public Faculty()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
                                    + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                                    + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                                    + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                                    + @"[a-zA-Z]{2,}))$";
            Regex reStrict;
            bool flag = false;

            reStrict = new Regex(patternStrict);
            flag = reStrict.IsMatch(textBox6.Text);
            
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == ""|| textBox5.Text == ""|| textBox6.Text == "")
            {
                MessageBox.Show("Input cannot be empty","Input Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                textBox1.Focus();
            }
            else if(!flag)
            {
            MessageBox.Show("Invalid Email-Id Format","Input Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                textBox6.Text="";
                textBox6.Focus();
            }
             else
            {
                con.Open();
                
                //to insert into faculty db
                cmd = new MySqlCommand("insert into faculty(fname,course_take,username,password,number,email) values(@name,@cour,@user,@pwd,@num,@mail)", con);
                cmd.Parameters.AddWithValue("name",textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("cour", textBox4.Text.Trim());
                cmd.Parameters.AddWithValue("user", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("pwd","password('"+textBox3.Text.Trim()+"')");
                cmd.Parameters.AddWithValue("num",textBox5.Text);
                cmd.Parameters.AddWithValue("mail", textBox6.Text.Trim());
                cmd.ExecuteNonQuery();

                //to insert into login db
                cmd = new MySqlCommand("insert into login(id,uname,pwd,role) values(2,'"+textBox2.Text+"',password('" + textBox3.Text + "'),'Faculty')", con);
                cmd.ExecuteNonQuery();
                
                con.Close();
                MessageBox.Show("Faculty Added Successfully","Insert Success",MessageBoxButtons.OK,MessageBoxIcon.Information);


                DialogResult dr = MessageBox.Show("Do you want to add another?", "Insert More", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    this.Hide();
                    new Faculty().Show();
                    
                }
                else
                {
                    this.Hide();
                    new LoginForm().Show();
                }
            }
            
        }

        private void Faculty_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.ActiveControl = label1;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            int cnt = 0;
            con.Open();
            cmd = new MySqlCommand("select count(*) from faculty where fname='"+textBox1.Text+"' and course_take='"+textBox4.Text +"'", con);
            cnt =Convert.ToInt32(cmd.ExecuteScalar());

            if (cnt == 1)
            {
                MessageBox.Show("Course already assigned to the faculty","Input Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                textBox4.Text = "";
                textBox4.Focus();
            }
            con.Close();
        }
              private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
              {
                  if (Information.IsNumeric(e.KeyChar))
                  {
                      MessageBox.Show("No Numbers Allowed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                      textBox1.Focus();
                      e.Handled = true;
                  }
              }

              private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
              {
                  if (Information.IsNumeric(e.KeyChar))
                  {
                      MessageBox.Show("No Numbers Allowed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                      textBox4.Focus();
                      e.Handled = true;
                  }
              }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
              if (!Information.IsNumeric(e.KeyChar))
                  {
                      MessageBox.Show("Only Numbers Allowed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                      textBox5.Focus();
                      e.Handled = true;
                  }
                }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            con.Open();
            cmd = new MySqlCommand("select count(*) from login where uname='" + textBox2.Text + "'", con);
            int cnt =Convert.ToInt32(cmd.ExecuteScalar());
            if (cnt == 1)
            {
                MessageBox.Show("Username already in use", "Duplicate Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Text = "";
                textBox2.Focus();
               
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

       
                
    }
}
