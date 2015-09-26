using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace OnLineTestUsing_ADO.Net
{
    public partial class LoginForm : Form
    {
        MySqlConnection con = new MySqlConnection(); 
        MySqlCommand cmd;
        MySqlDataReader dr;       
      public static string studid;
     
        public LoginForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string pass; // storing password
            int cnt;
            con.ConnectionString = Properties.Settings.Default.conurl;
            con.Open();
           

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Username / Password must not be empty","Input Error",MessageBoxButtons.OK);
            }
            else
            {
                studid = textBox1.Text;
                pass = textBox2.Text;
                cmd = new MySqlCommand("select id from login where uname='" + studid + "' and pwd=password('" + pass + "')", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cnt = dr.GetInt32("id");

                    if (cnt != 1 && cnt != 2)
                    {
                        MessageBox.Show("Login Success", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        new SelectExam().Show();

                    }
                    else
                    {
                        MessageBox.Show("Login Failed... Invalid Username/Password", "FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        textBox1.Text = textBox2.Text = "";
                        textBox1.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Login Failed... Invalid Username/Password", "FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    textBox1.Text = textBox2.Text = "";
                    textBox1.Focus();
                
                }
            }
                con.Close();
            
 
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
             this.ControlBox = false;
            toolTip1.InitialDelay = 1;
            if (Properties.Settings.Default.uid == 1)
            {
                sTUDENTToolStripMenuItem.Enabled = true;
                cOURSEToolStripMenuItem.Enabled = true;
                facultyToolStripMenuItem.Enabled = true;
                questionToolStripMenuItem.Enabled = true;
            }
            else if (Properties.Settings.Default.uid == 2)
            {
                sTUDENTToolStripMenuItem.Enabled = true;
                cOURSEToolStripMenuItem.Enabled = true;
                facultyToolStripMenuItem.Enabled = false;
                questionToolStripMenuItem.Enabled = true;
            }
            else
            {
                sTUDENTToolStripMenuItem.Enabled = false;
                cOURSEToolStripMenuItem.Enabled = false;
                facultyToolStripMenuItem.Enabled = false;
                questionToolStripMenuItem.Enabled = false;
            }
        }

         private void sTUDENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stud_Register sf = new Stud_Register();
            sf.Show();

        }

        private void cOURSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register_Course rc = new Register_Course();
            rc.Show();
        }

        private void facultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Faculty().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            new MasterEntry().Show();
            
        }
                 private void questionToolStripMenuItem_Click(object sender, EventArgs e)
          {
              this.Hide();
              new AddQuestion().Show();
          }
 
                 private void StuddelMenuItem1_Click(object sender, EventArgs e)
                 {
                     this.Hide();
                     new Delete(1).Show();
                 }

                 private void courdelMenuItem1_Click(object sender, EventArgs e)
                 {
                     this.Hide();
                     new Delete(2).Show();
                 }

                 private void facdelMenuItem1_Click(object sender, EventArgs e)
                 {
                     this.Hide();
                     new Delete(3).Show();

                 }

                 private void questdelMenuItem1_Click(object sender, EventArgs e)
                 {
                     this.Hide();
                     new Delete(4).Show();
                 }

      
    }
    public class sample
    {
        public static void main()
        {
            LoginForm lf = new LoginForm();
        }
    }
}