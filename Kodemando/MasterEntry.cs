using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OnLineTestUsing_ADO.Net
{
    public partial class MasterEntry : Form
    {
        int logid=0,logpass = 0,checkme=0;
        string id,pass;
        MySqlConnection con = new MySqlConnection(Properties.Settings.Default.conurl);
        MySqlCommand cmd;
        MySqlDataReader dr;
        public static bool flag;
        
        public MasterEntry()
        {
            InitializeComponent();
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
         /*   if (label3.Left + label3.Width > this.ClientRectangle.Width)
            {
                flag = flag * (-1);
            }
            else if (label3.Left < this.ClientRectangle.Left )
            {
                flag = flag * (-1);
            }
                label3.Left += (10*flag );
            */
            Random r = new Random();
            label3.ForeColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
        }

        private void MasterEntry_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            flag = false;
            timer1.Enabled = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            this.ControlBox = false;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.unpwd))
            { 
              string[] spl=Properties.Settings.Default.unpwd.Split('/');
              
            textBox1.Text=spl[0];
            textBox2.Text=spl[1];
            }
       }
        private void button1_Click(object sender, EventArgs e)
        {
            flag = false;
            Properties.Settings.Default.unpwd = textBox1.Text + "/" + textBox2.Text;
            Properties.Settings.Default.uid = checkme;
            Properties.Settings.Default.Save();
            if (logid == 1 && logpass == 1)
            {
                this.Hide();
                new LoginForm().Show();
            }
            
            }
                
        private void textBox1_Leave(object sender, EventArgs e)
        {
           id= textBox1.Text.Trim();
           
            con.Open();

            if (flag)
            {
                if (id.Length < 1)
                {
                    pictureBox1.Visible = false;
                    pictureBox1.ImageLocation = "";
                    errorProvider1.SetError(textBox1, "Id Should Not Be Empty");
                    textBox1.Text = textBox2.Text = "";
                }
                else
                {
                    pictureBox1.Visible = true;
                    cmd = new MySqlCommand("select id from login where uname='" + id + "'", con);
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        checkme = dr.GetInt32("id");

                        if (checkme == 1 || checkme == 2)
                        {
                            pictureBox1.ImageLocation = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 9) + "\\images\\correct1.jpg";
                            logid = 1;
                        }
                        else
                        {
                            pictureBox1.ImageLocation = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 9) + "\\images\\wrong.jpg";

                        }
                    }
                    else
                    {
                        pictureBox1.ImageLocation = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 9) + "\\images\\wrong.jpg";

                    }

                    dr.Close();
                    con.Close();
                }
            }
              }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            
            int cnt=0;
            pass = textBox2.Text.Trim();
            cmd = new MySqlCommand("select id from login where pwd=password('" + pass + "')", con);
            if (flag)
            {
                con.Open();
                cnt = Convert.ToInt32(cmd.ExecuteScalar());

                pictureBox2.Visible = true;
                if (pass.Length < 1)
                {
                    pictureBox2.Visible = false;
                    pictureBox2.ImageLocation = "";
                    errorProvider1.SetError(textBox2, "Password Should Not Be Empty");
                }
                else if (cnt == 1 || cnt == 2)
                {
                    pictureBox2.ImageLocation = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 9) + "\\images\\correct1.jpg";
                    logpass = 1;
                }
                else
                {
                    pictureBox2.ImageLocation = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 9) + "\\images\\wrong.jpg";

                }
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.unpwd = null;
            Properties.Settings.Default.uid = 0;
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            flag = true;
        }

        private void MasterEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.unpwd = null;
            Properties.Settings.Default.uid = 0;
            Properties.Settings.Default.Save();
        }
                    }
}
