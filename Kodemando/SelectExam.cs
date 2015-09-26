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
    public partial class SelectExam : Form
    {
        MySqlConnection mycon = new MySqlConnection();
        MySqlCommand mycom;
        MySqlDataReader mydr;
       public static string exam_code = "";
       
        public SelectExam()
        {
            InitializeComponent();
        }

        private void SelectExam_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            mycon.ConnectionString = Properties.Settings.Default.conurl;
            mycon.Open();
        string query="select s.mobnum from student s,login l where l.uname='" + LoginForm.studid + "'";
        mycom = new MySqlCommand("select e.eid,s.course_name from student s,exam e where s.course_name=e.ename and s.mobnum=(" + query + ")", mycon);
            mydr = mycom.ExecuteReader();
            comboBox1.Items.Clear();
            while (mydr.Read())
            {
        comboBox1.Items.Add(mydr[0].ToString() + " - " + mydr[1].ToString());
            }
            mydr.Close();
            mycon.Close();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            exam_code = comboBox1.SelectedItem.ToString().Substring(0,4);
            if (exam_code == "")
            {
              MessageBox.Show("Select Any Exam..", "Select Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                    DialogResult d1 = MessageBox.Show("Want To Continue Or Not?", "Proceed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d1 == DialogResult.No)
                    {
                        this.Hide();
                        new LoginForm().Show();
                    }
                    else
                    {
                        
                       this.Hide();
                        new RulesForm().Show();
                    }
            }
        }

        
        private void SelectExam_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            new LoginForm().Show();
        }
    }
}
