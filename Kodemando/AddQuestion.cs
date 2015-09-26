using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
namespace OnLineTestUsing_ADO.Net
{
    public partial class AddQuestion : Form
    {
        MySqlConnection con = new MySqlConnection(Properties.Settings.Default.conurl);
        MySqlCommand cmd;
        MySqlDataReader dr;
        int qcnt;
        public AddQuestion()
        {
            InitializeComponent();
        }
         

          private void AddQuestion_Load(object sender, EventArgs e)
          {
              this.ControlBox = false;
              this.ActiveControl = textBox1;
              try
              {
              
              con.Open();
              cmd = new MySqlCommand("select eid,ename from exam",con);

              dr = cmd.ExecuteReader();
              comboBox1.Items.Add("Select Exam Code");
              while (dr.Read())
              {
                  comboBox1.Items.Add(dr.GetString("eid") + " - " + dr.GetString("ename"));
              }
              dr.Close();
              con.Close();
              }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message,"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
               }
          }

          private void button2_Click(object sender, EventArgs e)
          {
              this.Hide();
              new AddQuestion().Show();
          }

          private void button1_Click(object sender, EventArgs e)
          {
              int temp = qcnt + 1;
              if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "" || textBox5.Text != "" || textBox6.Text != "" || comboBox1.SelectedIndex > 0 || comboBox2.SelectedIndex > 0)
              {
                  try
                  {
                      con.Open();
                      cmd = new MySqlCommand("insert into test values(@subcode,@id,@question,@ans1,@ans2,@ans3,@ans4,@ans,@tot)", con);
                      cmd.Parameters.AddWithValue("id", temp);
                      cmd.Parameters.AddWithValue("question", textBox1.Text);
                      cmd.Parameters.AddWithValue("ans1", textBox2.Text);
                      cmd.Parameters.AddWithValue("ans2", textBox3.Text);
                      cmd.Parameters.AddWithValue("ans3", textBox4.Text);
                      cmd.Parameters.AddWithValue("ans4", textBox5.Text);
                      cmd.Parameters.AddWithValue("ans", Convert.ToInt32(comboBox2.SelectedItem));
                      cmd.Parameters.AddWithValue("subcode", comboBox1.SelectedItem.ToString().Substring(0,4));
                      cmd.Parameters.AddWithValue("tot", Convert.ToInt32(textBox6.Text));
                      cmd.ExecuteNonQuery();
                      MessageBox.Show("Question Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      con.Close();
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
              }
              else
              {
                  MessageBox.Show("Proper Values not given for an required input.","Input Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
              }
          }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {
                con.Open();
                cmd = new MySqlCommand("select tot_quest from exam where eid='" + comboBox1.SelectedItem.ToString().Substring(0, 4) + "'", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                qcnt = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                MessageBox.Show("Enter 2-Digit Number only","Input Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                e.Handled = true; // Remove the character

            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text != "" && Convert.ToInt32(textBox6.Text)>10)
            {
                MessageBox.Show("Limit is 1-10","Input Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBox6.Text = "";
                textBox6.Focus();   
            }
        }

            }
}
