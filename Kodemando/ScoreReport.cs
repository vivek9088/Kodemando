using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace OnLineTestUsing_ADO.Net
{
    public partial class ScoreReport : Form
    {
        MySqlConnection conn = new MySqlConnection(Properties.Settings.Default.conurl);
        MySqlCommand cmd;
        int result;
        string name1,cours;
        public ScoreReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open();
                cmd = new MySqlCommand("insert into stud_score(stud_id,stud_name,course_reg,stud_score) values(@id,@courname,@regcourse,@score)", conn);
                cmd.Parameters.AddWithValue("id", LoginForm.studid);
                cmd.Parameters.AddWithValue("courname", name1);
                cmd.Parameters.AddWithValue("regcourse", cours);
                cmd.Parameters.AddWithValue("score", TestForm.res);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Button1 Error");
            }
            finally {
                conn.Close();
                this.Hide();
                new MasterEntry().Show();
            }

        }

        private void ScoreReport_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new MySqlCommand("select name,course_name from student where id=(select id from login where uname='" + LoginForm.studid + "')", conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                name1 = dr[0].ToString();
                cours = dr[1].ToString();
                name.Text += " " + name1;
                dr.Close();

                result = TestForm.res;
                progressBar1.Maximum = RulesForm.cnt;
                progressBar1.Value = RulesForm.cnt / 2;
                progressBar2.Value = result;
                pscore.Text += " " + (RulesForm.cnt / 2) + "/" + RulesForm.cnt;
                urscore.Text += " " + result.ToString();
                code.Text += " " + SelectExam.exam_code;
                date.Text += " " + DateTime.Now.Date.ToShortDateString();
                if (result >= (RulesForm.cnt / 2))
                    grade.Text += " " + "Pass";
                else
                    grade.Text += " " + "Fail";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Page Load Error");
            }
            finally { conn.Close(); }
        }

        private void ScoreReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
       
    }
}
