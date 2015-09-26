using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Text;
using System.Windows.Forms;

namespace OnLineTestUsing_ADO.Net
{
    public partial class ReviewForm : Form
    {
        public ReviewForm()
        {
            InitializeComponent();
        }

        private void ReviewForm_Load(object sender, EventArgs e)
        {
            MySqlConnection con=new MySqlConnection(Properties.Settings.Default.conurl);
            MySqlCommand cmd;
            int noquest = 0;

            try
            {
                //to retrieve the number of questions
                con.Open();
                cmd = new MySqlCommand("select tot_quest from exam where eid='" + SelectExam.exam_code + "'", con);

                noquest = (int)cmd.ExecuteScalar();

                Label[] label = new Label[TestForm.status.Length];
                Label[] questlb = new Label[TestForm.status.Length];
                int x = 20;//default width
                int count = 0;
                int y = 30;//default height
                int bkcnt = 0;//bookmark count
                for (int i = 0; i < noquest; i++)
                {

                    label[i] = new Label();
                    questlb[i] = new Label();
                    label[i].Height = 25;
                    label[i].Width = 25;
                    questlb[i].Height = 25;
                    questlb[i].Width = 25;

                    label[i].ForeColor = Color.White;
                    questlb[i].Location = new Point(x, y);
                    label[i].Location = new Point(x, y + 30);
                    if (i == 10)
                    {
                        y = 90;
                        x = 20;
                        questlb[i].Location = new Point(x, y);
                        label[i].Location = new Point(x, y + 30);

                    }
                    questlb[i].Text = (i + 1).ToString();
                    label[i].Text = TestForm.ans[i].ToString();//(i + 1).ToString();
                    // label[i].Click += new EventHandler(onLblClick);
                    this.Controls.Add(questlb[i]);
                    this.Controls.Add(label[i]);
                    questlb[i].Show();
                    label[i].Show();

                    /* if (TestForm.status[i] == true && TestForm.ticked[i] == false)
                     {
                         label[i].BackColor = Color.Purple;
                     }
                     */
                    if (TestForm.status[i] == true)
                    {
                        if (TestForm.ticked[i] == true)
                        {
                            label[i].BackColor = Color.Maroon;
                            bkcnt++;
                            count++;
                        }
                        else
                        {
                            label[i].BackColor = Color.Red;
                            bkcnt++;
                        }
                    }
                    else if (TestForm.ticked[i] == true)
                    {
                        label[i].BackColor = Color.Green;
                        count++;
                    }
                    else
                    {
                        label[i].BackColor = Color.Blue;
                    }

                    x += 30;

                }
                label4.Text = "Bookmarked Questions : " + bkcnt + "\n\nAnswered : " + count + "\n\nNot Answered : " + (noquest - count);
            }
            catch (Exception err)
            {
                MessageBox.Show("An Error occured while displaying the details. Please try again later");
            }
            finally { con.Close(); }
          }

        private void ReviewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button21_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            new ScoreReport().Show();
           
        }

    }
}
