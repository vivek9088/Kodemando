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
    public partial class Delete : Form
    {
        int opt;
        public Delete(int ch)
        {
            InitializeComponent();
            opt = ch;
        }

        private void Delete_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet1.test' table. You can move, or remove it, as needed.
            this.testTableAdapter.Fill(this.testDataSet1.test);
            // TODO: This line of code loads data into the 'testDataSet11.faculty' table. You can move, or remove it, as needed.
            this.facultyTableAdapter1.Fill(this.testDataSet1.faculty);
            // TODO: This line of code loads data into the 'testDataSet11.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter1.Fill(this.testDataSet1.student);
            // TODO: This line of code loads data into the 'testDataSet11.exam' table. You can move, or remove it, as needed.
            this.examTableAdapter1.Fill(this.testDataSet1.exam);
            dataGridView1.Width = this.Width-50;
            dataGridView1.Height = (this.Height/2)+50;
            button1.Top = dataGridView1.Bottom + 30;
            
            DataGridViewButtonColumn button;
           
            switch(opt)
            {
                case 1:
                    this.studentTableAdapter1.Fill(this.testDataSet1.student);
                    dataGridView1.DataSource = this.studentBindingSource;
                    button = new DataGridViewButtonColumn();
            button.Text = "Delete";
            button.HeaderText = "Delete";
            button.FillWeight = 30;
            button.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(button);
            break;
                
                case 2:
            this.examTableAdapter1.Fill(this.testDataSet1.exam);
            dataGridView1.DataSource = this.examBindingSource;
                   button = new DataGridViewButtonColumn();
            button.Text = "Delete";
            button.HeaderText = "Delete";
            button.FillWeight = 30;
            button.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(button);
                    break;
               
                case 3:
                    this.facultyTableAdapter1.Fill(this.testDataSet1.faculty);
                    dataGridView1.DataSource = this.facultyBindingSource;
                     button = new DataGridViewButtonColumn();
            button.Text = "Delete";
            button.HeaderText = "Delete";
            button.FillWeight = 30;
            button.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(button);
            break;
                
                case 4:
            this.testTableAdapter.Fill(this.testDataSet1.test);
            dataGridView1.DataSource = this.ontestBindingSource;
                     button = new DataGridViewButtonColumn();
            button.Text = "Delete";
            button.HeaderText = "Delete";
            button.FillWeight = 30;
            button.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(button);
            break;
        }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.conurl);
            MySqlCommand cmd;
            
            //rowindex starts from zero
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex != -1)
            {
                switch (opt)
                { 
                    case 1:
                        con.Open();
                        
               cmd = new MySqlCommand("delete from student where id="+dataGridView1.Rows[e.RowIndex].Cells[2].Value, con);
               cmd.ExecuteNonQuery();

               cmd = new MySqlCommand("delete from login where id="+dataGridView1.Rows[e.RowIndex].Cells[2].Value, con);
               cmd.ExecuteNonQuery();
               con.Close();
               MessageBox.Show("Record Deleted","Delete Success");
                         this.studentTableAdapter1.Fill(this.testDataSet1.student);
                    dataGridView1.DataSource = this.studentBindingSource;
                    
               break;
                    
                    case 2:
               con.Open();

               cmd = new MySqlCommand("delete from exam where eid='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value+"'", con);
               cmd.ExecuteNonQuery();

               cmd = new MySqlCommand("delete from test where ecode='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con);
               cmd.ExecuteNonQuery();
               con.Close();

               MessageBox.Show("Record Deleted", "Delete Success");
            this.examTableAdapter1.Fill(this.testDataSet1.exam);
            dataGridView1.DataSource = this.examBindingSource;
               
               break;

                    case 3:
                        con.Open();

               cmd = new MySqlCommand("delete from faculty where fid='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value+"'", con);
               cmd.ExecuteNonQuery();
               con.Close();

               MessageBox.Show("Record Deleted", "Delete Success");
                        this.facultyTableAdapter1.Fill(this.testDataSet1.faculty);
                    dataGridView1.DataSource = this.facultyBindingSource;
               break;

                    case 4:
                         con.Open();
                         cmd = new MySqlCommand("delete from test where qno=" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + " and ecode='" + dataGridView1.Rows[e.RowIndex].Cells[7].Value + "'", con);
               cmd.ExecuteNonQuery();
                        
               cmd = new MySqlCommand("update exam set tot_quest=tot_quest-1 where eid='" + dataGridView1.Rows[e.RowIndex].Cells[7].Value+"'", con);
               cmd.ExecuteNonQuery();
               
               con.Close();

               MessageBox.Show("Record Deleted", "Delete Success");
                        this.testTableAdapter.Fill(this.testDataSet1.test);
            dataGridView1.DataSource = this.ontestBindingSource;
            
               break;

                }
               

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

    
    }
}
