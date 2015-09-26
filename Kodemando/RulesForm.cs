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
    public partial class RulesForm : Form
    {
        public static int noquest,temp,cnt;
        MySqlConnection con = new MySqlConnection(Properties.Settings.Default.conurl);
        MySqlCommand cmd;
        MySqlDataReader dr;
                
        public RulesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new TestForm().Show();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            button1.Enabled = checkBox1.Checked;
            button2.Enabled = checkBox1.Checked;
        }

        private void RulesForm_Load(object sender, EventArgs e)
        {
            string time="";
            this.ControlBox = false;
           
            con.Open();
            cmd = new MySqlCommand("select sum(mark) from test where ecode='" + SelectExam.exam_code + "'", con);
            dr = cmd.ExecuteReader();
            dr.Read();
            cnt = dr.GetInt32(0);
            dr.Close();

           cmd = new MySqlCommand("select duration,tot_quest from exam where eid='" + SelectExam.exam_code + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                noquest = dr.GetInt32("tot_quest");
                temp = dr.GetInt32("duration");
                time = (temp.ToString().Length > 1) ? "mins" : "hrs";
                label3.Text = "Duraton of Exam is : " + temp.ToString() + " " + time + "\n\nTotal Number Of Questions : " + noquest+"\n\nMax. Marks : "+cnt;
            }
            else
            {
                MessageBox.Show("Exam Code not selected", "Code Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Hide();
                new SelectExam().Show();
            }
            dr.Close();
            con.Close();
        }

        private void RulesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Do you want to stop the test?", "Stop Test", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                this.Hide();
                new SelectExam().Show();
            }
            
        }

    }
}