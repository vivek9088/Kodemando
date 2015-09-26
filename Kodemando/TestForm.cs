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
    public partial class TestForm : Form
    {
       public static bool[] status; // to store bookmark status for each question
       public static bool[] ticked;  // to keep track of answered questions
       public static char[] ans; // to display answers on the review form
       internal static RadioButton[] ans_status; // to store answers for each question
       List<int> indxlist=new List<int>();
       Label display = new Label();
       public  static int res;
        internal int mark,flag = 0, hh, mm, ss,check,answer,index=0,noq;
        internal static int correct;
        MySqlConnection con=new MySqlConnection(Properties.Settings.Default.conurl);
        MySqlCommand cmd;
        MySqlDataReader dr1;
     
        public TestForm()
        {
            
            InitializeComponent();
 }
        
        public void getrecords(int cnt)
        {
            con.Open();
            cmd = new MySqlCommand("select * from test where qno="+cnt+" and ecode='"+SelectExam.exam_code+"'", con);
            
            MySqlDataReader dr = cmd.ExecuteReader();
            try
            {
                if (!dr.Read())
                {
                    MessageBox.Show("Questions Not Available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    qno.Text = "Q.No. " + dr["qno"];
                    textBox1.Text = dr.GetString("quest");

                    opt1.Text = dr.GetString("opt1");
                    opt2.Text = dr.GetString("opt2");
                    opt3.Text = dr.GetString("opt3");
                    opt4.Text = dr.GetString("opt4");
                    answer = dr.GetInt16("ans");
                    mark = dr.GetInt16("mark");
                }
                dr.Close();
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("An Error Occured while fetching questions from database. Please try again!!");
            }
        }

        private void setState(int indx)
        {
             checkBox1.Checked = status[indx];
          
            try
            {
                ans_status[indx].Checked = true;
            }
            catch (Exception ex)
            {
                opt1.Checked = false;
                opt2.Checked = false;
                opt3.Checked = false;
                opt4.Checked = false;
            }
         
        }
        
        private void opt1_Click(object sender, EventArgs e)
        {
           // option = 0;
            check = 1;
            if (answer == check)
            {
                correct++;
                if (!indxlist.Contains(index+1))
                { indxlist.Add(index+1); }
            }
            else
            {
                correct--; 
                if (indxlist.Contains(index + 1))
                { indxlist.Remove(index + 1); }
            }

            ticked[index] = opt1.Checked;
            ans[index] = 'A';
                      
        }

        private void opt2_Click(object sender, EventArgs e)
        {
            //option = 1;
            check = 2; 
            if (answer == check)
            {
                correct++;
                if (!indxlist.Contains(index+1))
                { indxlist.Add(index + 1); }
            }
            else
            {
                correct--;
                if (indxlist.Contains(index + 1))
                { indxlist.Remove(index + 1); }
            }

            ticked[index] = opt2.Checked;
            ans[index] = 'B';
            
        }
       
        private void opt3_Click(object sender, EventArgs e)
        {
           // option = 2;
            check = 3; 
            if (answer == check)
            {
                correct++;
                if (!indxlist.Contains(index + 1))
                { indxlist.Add(index + 1); }
            }
            else
            {
                correct--; 
                if (indxlist.Contains(index + 1))
                { indxlist.Remove(index + 1); }
            }
            ticked[index] = opt3.Checked; 
            ans[index] = 'C';
           
        }

        private void opt4_Click(object sender, EventArgs e)
        {
           // option = 3;
           
            check = 4;
            if (answer == check)
            {
                correct++;
                if (!indxlist.Contains(index + 1))
                { indxlist.Add(index + 1); }
            }
            else
            {
                correct--; 
                if (indxlist.Contains(index + 1))
                { indxlist.Remove(index + 1); }
            }
            ticked[index] = opt4.Checked;
            ans[index] = 'D';
          
        }

       
        private void form1_Load(object sender, EventArgs e)
        {
            res = 0;
            
            this.ControlBox = false;
            hh = RulesForm.temp / 60;
            mm = RulesForm.temp % 60;
            ss = 0;
            timer1.Enabled = true;
            timer1.Interval = 1000;
            label1.Text = "Time :" +hh + ":" + mm + ":" + ss;
           try
            {
                con.Open();
                //to get the number of questions for the subject
                cmd=new MySqlCommand("select tot_quest from exam where eid='"+SelectExam.exam_code+"'",con);
                dr1 = cmd.ExecuteReader();
                dr1.Read();
                noq = dr1.GetInt32("tot_quest");
                ticked = new bool[noq];
                status = new bool[noq];
                ans = new  char[noq];
                ans_status = new RadioButton[noq];
                drawcontrols(sender,e,noq);
                dr1.Close();
                label2.Text = "1 Out Of " + noq;

               //Initialize form with 1st question with respect to the subject selected
                cmd = new MySqlCommand("select * from test where qno=1 and ecode='"+SelectExam.exam_code+"'", con);
               dr1 = cmd.ExecuteReader();
                dr1.Read();
                qno.Text = "Q.No. " + dr1["qno"];
               textBox1.Text = dr1["quest"].ToString();

                opt1.Text = dr1["opt1"].ToString();
                opt2.Text = dr1["opt2"].ToString();
                opt3.Text = dr1["opt3"].ToString();
                opt4.Text = dr1["opt4"].ToString();
                answer = dr1.GetInt16("ans");
                mark = dr1.GetInt16("mark");
                dr1.Close();
                con.Close();
           }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Exam Code...!","Exam Code Error");
                label1.Visible = false;
                this.Hide();
                new SelectExam().Show();
            }
          
           }
        private void drawcontrols(object sender,EventArgs e,int num)
        {
            Button[] clickme=new Button[num];
            int t = 0,j;
            for (int i = 0; i < num; i++)
            {
                j=0;
                    clickme[t] = new Button();
                    clickme[t].Name = "Button" + (t + 1).ToString();
                    clickme[t].Text = (t + 1).ToString();
                    clickme[t].Width = 30;
                    clickme[t].Height = 30;
                    clickme[t].Location = new Point(35 * i, 35 * j);
                    clickme[t].Click += new EventHandler(quest_Click);
                   flowLayoutPanel2.Controls.Add(clickme[t]);
                    t++;
                j++;
                
            }
        }

        private void quest_Click(object sender,EventArgs e)
        {
           Button b = (Button)sender;
            getrecords(Convert.ToInt32(b.Text));
            index = Convert.ToInt32(b.Text)-1;
            label2.Text = (index+1) + " Out Of " +noq ;
            setState(index);

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // when time retrieved from DB it is in Minutes so convert to hours.
             
            if (ss < 1)
	                {
	                    ss = 59;
	                    if (mm == 0)
	                    {
	                        mm = 59;
	                        if (hh != 0)
	                            hh -= 1;
	                    }
	                    else
	                    {
	                        mm -= 1;
	       
             }
	                }
	                else
	                    ss -= 1;

                    label1.Text = hh.ToString() + ":" + mm.ToString() + ":" + ss.ToString();
        }

      

       private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            status[index] = checkBox1.Checked;
        }

        private void TestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
 
        }

        // REVIEW button
        private void button22_Click(object sender, EventArgs e)
        {
            string ss = "";
          
            //for storing the correct answer's question number and get total mark of all correct question's
           foreach (int i in indxlist)
           {
             if(ss!=""){ss=ss+",";}
               ss += i.ToString();
           }
          try
           {
               if (ss != "")
               {
                   con.Open();
                   cmd = new MySqlCommand("select sum(mark) from test where ecode = '" + SelectExam.exam_code + "' and qno in (" + ss + ")", con);
                   res = Convert.ToInt32(cmd.ExecuteScalar());
                   con.Close();
                   //to ask user before ending the exam
                   DialogResult d = MessageBox.Show("Are You Sure To End Exam?", "End Exam", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                   if (d == DialogResult.Yes)
                   {
                       this.Hide();
                       ReviewForm rf = new ReviewForm();
                       rf.Show();
                   }
               }
               
           }
           catch (Exception ex)
           { MessageBox.Show(ex.Message); }
        }

        private void opt1_CheckedChanged(object sender, EventArgs e)
        {
            //ans_status[index] = opt1.Checked;
            ans_status[index] = opt1;
        }

        private void opt2_CheckedChanged(object sender, EventArgs e)
        {
            //ans_status[index] = opt2.Checked;
            ans_status[index] = opt2;
        }

        private void opt3_CheckedChanged(object sender, EventArgs e)
        {
            //ans_status[index] = opt3.Checked;
            ans_status[index] = opt3;
        }

        private void opt4_CheckedChanged(object sender, EventArgs e)
        {
            //ans_status[index] = opt4.Checked;
            ans_status[index] = opt4;
        }

        //End Exam Button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ScoreReport().Show();
        }

        }
}