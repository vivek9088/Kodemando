namespace OnLineTestUsing_ADO.Net
{
    partial class ScoreReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.pscore = new System.Windows.Forms.Label();
            this.urscore = new System.Windows.Forms.Label();
            this.grade = new System.Windows.Forms.Label();
            this.rscore = new System.Windows.Forms.Label();
            this.yscore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(172, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Examination Score Report";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(61, 76);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(132, 17);
            this.name.TabIndex = 1;
            this.name.Text = "Candidate Name:";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Location = new System.Drawing.Point(61, 117);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(47, 17);
            this.date.TabIndex = 2;
            this.date.Text = "Date:";
            // 
            // code
            // 
            this.code.AutoSize = true;
            this.code.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.code.Location = new System.Drawing.Point(61, 158);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(93, 17);
            this.code.TabIndex = 3;
            this.code.Text = "Exam Code:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(280, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(199, 215);
            this.progressBar1.Maximum = 200;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(195, 27);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 5;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(199, 268);
            this.progressBar2.Maximum = 200;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(194, 27);
            this.progressBar2.Step = 1;
            this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar2.TabIndex = 6;
            // 
            // pscore
            // 
            this.pscore.AutoSize = true;
            this.pscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pscore.Location = new System.Drawing.Point(107, 341);
            this.pscore.Name = "pscore";
            this.pscore.Size = new System.Drawing.Size(117, 17);
            this.pscore.TabIndex = 7;
            this.pscore.Text = "Passing Score:";
            // 
            // urscore
            // 
            this.urscore.AutoSize = true;
            this.urscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urscore.Location = new System.Drawing.Point(316, 340);
            this.urscore.Name = "urscore";
            this.urscore.Size = new System.Drawing.Size(94, 17);
            this.urscore.TabIndex = 8;
            this.urscore.Text = "Your Score:";
            // 
            // grade
            // 
            this.grade.AutoSize = true;
            this.grade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grade.Location = new System.Drawing.Point(496, 340);
            this.grade.Name = "grade";
            this.grade.Size = new System.Drawing.Size(58, 17);
            this.grade.TabIndex = 9;
            this.grade.Text = "Grade:";
            // 
            // rscore
            // 
            this.rscore.AutoSize = true;
            this.rscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rscore.Location = new System.Drawing.Point(72, 215);
            this.rscore.Name = "rscore";
            this.rscore.Size = new System.Drawing.Size(121, 17);
            this.rscore.TabIndex = 10;
            this.rscore.Text = "Required Score";
            // 
            // yscore
            // 
            this.yscore.AutoSize = true;
            this.yscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yscore.Location = new System.Drawing.Point(89, 268);
            this.yscore.Name = "yscore";
            this.yscore.Size = new System.Drawing.Size(89, 17);
            this.yscore.TabIndex = 11;
            this.yscore.Text = "Your Score";
            // 
            // ScoreReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 513);
            this.Controls.Add(this.yscore);
            this.Controls.Add(this.rscore);
            this.Controls.Add(this.grade);
            this.Controls.Add(this.urscore);
            this.Controls.Add(this.pscore);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.code);
            this.Controls.Add(this.date);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Name = "ScoreReport";
            this.Text = "ScoreReport";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ScoreReport_FormClosed);
            this.Load += new System.EventHandler(this.ScoreReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label code;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label pscore;
        private System.Windows.Forms.Label urscore;
        private System.Windows.Forms.Label grade;
        private System.Windows.Forms.Label rscore;
        private System.Windows.Forms.Label yscore;
    }
}