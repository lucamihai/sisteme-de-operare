namespace Laborator4
{
    partial class MainForm
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
            this.buttonSuspend1 = new System.Windows.Forms.Button();
            this.buttonSuspend2 = new System.Windows.Forms.Button();
            this.buttonSuspend3 = new System.Windows.Forms.Button();
            this.buttonSuspend4 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.progressBar4 = new System.Windows.Forms.ProgressBar();
            this.buttonStartThreads = new System.Windows.Forms.Button();
            this.buttonKillThreads = new System.Windows.Forms.Button();
            this.buttonTimeThread2 = new System.Windows.Forms.Button();
            this.buttonTimeThread1 = new System.Windows.Forms.Button();
            this.buttonTimeThread3 = new System.Windows.Forms.Button();
            this.buttonTimeThread4 = new System.Windows.Forms.Button();
            this.textBoxTimeData = new System.Windows.Forms.TextBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSuspend1
            // 
            this.buttonSuspend1.Location = new System.Drawing.Point(336, 78);
            this.buttonSuspend1.Name = "buttonSuspend1";
            this.buttonSuspend1.Size = new System.Drawing.Size(75, 23);
            this.buttonSuspend1.TabIndex = 0;
            this.buttonSuspend1.Text = "Suspend";
            this.buttonSuspend1.UseVisualStyleBackColor = true;
            this.buttonSuspend1.Click += new System.EventHandler(this.SuspendThread1);
            // 
            // buttonSuspend2
            // 
            this.buttonSuspend2.Location = new System.Drawing.Point(336, 107);
            this.buttonSuspend2.Name = "buttonSuspend2";
            this.buttonSuspend2.Size = new System.Drawing.Size(75, 23);
            this.buttonSuspend2.TabIndex = 1;
            this.buttonSuspend2.Text = "Suspend";
            this.buttonSuspend2.UseVisualStyleBackColor = true;
            this.buttonSuspend2.Click += new System.EventHandler(this.SuspendThread2);
            // 
            // buttonSuspend3
            // 
            this.buttonSuspend3.Location = new System.Drawing.Point(336, 136);
            this.buttonSuspend3.Name = "buttonSuspend3";
            this.buttonSuspend3.Size = new System.Drawing.Size(75, 23);
            this.buttonSuspend3.TabIndex = 2;
            this.buttonSuspend3.Text = "Suspend";
            this.buttonSuspend3.UseVisualStyleBackColor = true;
            this.buttonSuspend3.Click += new System.EventHandler(this.SuspendThread3);
            // 
            // buttonSuspend4
            // 
            this.buttonSuspend4.Location = new System.Drawing.Point(336, 165);
            this.buttonSuspend4.Name = "buttonSuspend4";
            this.buttonSuspend4.Size = new System.Drawing.Size(75, 23);
            this.buttonSuspend4.TabIndex = 3;
            this.buttonSuspend4.Text = "Suspend";
            this.buttonSuspend4.UseVisualStyleBackColor = true;
            this.buttonSuspend4.Click += new System.EventHandler(this.SuspendThread4);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(84, 78);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(218, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(84, 107);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(218, 23);
            this.progressBar2.TabIndex = 5;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(84, 136);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(218, 23);
            this.progressBar3.TabIndex = 6;
            // 
            // progressBar4
            // 
            this.progressBar4.Location = new System.Drawing.Point(84, 165);
            this.progressBar4.Name = "progressBar4";
            this.progressBar4.Size = new System.Drawing.Size(218, 23);
            this.progressBar4.TabIndex = 7;
            // 
            // buttonStartThreads
            // 
            this.buttonStartThreads.Location = new System.Drawing.Point(84, 391);
            this.buttonStartThreads.Name = "buttonStartThreads";
            this.buttonStartThreads.Size = new System.Drawing.Size(75, 23);
            this.buttonStartThreads.TabIndex = 8;
            this.buttonStartThreads.Text = "Begin";
            this.buttonStartThreads.UseVisualStyleBackColor = true;
            this.buttonStartThreads.Click += new System.EventHandler(this.StartThreads);
            // 
            // buttonKillThreads
            // 
            this.buttonKillThreads.Location = new System.Drawing.Point(234, 391);
            this.buttonKillThreads.Name = "buttonKillThreads";
            this.buttonKillThreads.Size = new System.Drawing.Size(75, 23);
            this.buttonKillThreads.TabIndex = 9;
            this.buttonKillThreads.Text = "Kill the mall";
            this.buttonKillThreads.UseVisualStyleBackColor = true;
            this.buttonKillThreads.Click += new System.EventHandler(this.KillThreads);
            // 
            // buttonTimeThread2
            // 
            this.buttonTimeThread2.Location = new System.Drawing.Point(417, 107);
            this.buttonTimeThread2.Name = "buttonTimeThread2";
            this.buttonTimeThread2.Size = new System.Drawing.Size(75, 23);
            this.buttonTimeThread2.TabIndex = 10;
            this.buttonTimeThread2.Text = "Time";
            this.buttonTimeThread2.UseVisualStyleBackColor = true;
            this.buttonTimeThread2.Click += new System.EventHandler(this.TimeThread2);
            // 
            // buttonTimeThread1
            // 
            this.buttonTimeThread1.Location = new System.Drawing.Point(417, 78);
            this.buttonTimeThread1.Name = "buttonTimeThread1";
            this.buttonTimeThread1.Size = new System.Drawing.Size(75, 23);
            this.buttonTimeThread1.TabIndex = 10;
            this.buttonTimeThread1.Text = "Time";
            this.buttonTimeThread1.UseVisualStyleBackColor = true;
            this.buttonTimeThread1.Click += new System.EventHandler(this.TimeThread1);
            // 
            // buttonTimeThread3
            // 
            this.buttonTimeThread3.Location = new System.Drawing.Point(417, 136);
            this.buttonTimeThread3.Name = "buttonTimeThread3";
            this.buttonTimeThread3.Size = new System.Drawing.Size(75, 23);
            this.buttonTimeThread3.TabIndex = 11;
            this.buttonTimeThread3.Text = "Time";
            this.buttonTimeThread3.UseVisualStyleBackColor = true;
            this.buttonTimeThread3.Click += new System.EventHandler(this.TimeThread3);
            // 
            // buttonTimeThread4
            // 
            this.buttonTimeThread4.Location = new System.Drawing.Point(417, 165);
            this.buttonTimeThread4.Name = "buttonTimeThread4";
            this.buttonTimeThread4.Size = new System.Drawing.Size(75, 23);
            this.buttonTimeThread4.TabIndex = 12;
            this.buttonTimeThread4.Text = "Time";
            this.buttonTimeThread4.UseVisualStyleBackColor = true;
            this.buttonTimeThread4.Click += new System.EventHandler(this.TimeThread4);
            // 
            // textBoxTimeData
            // 
            this.textBoxTimeData.Location = new System.Drawing.Point(475, 265);
            this.textBoxTimeData.Multiline = true;
            this.textBoxTimeData.Name = "textBoxTimeData";
            this.textBoxTimeData.Size = new System.Drawing.Size(231, 149);
            this.textBoxTimeData.TabIndex = 13;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(472, 249);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(30, 13);
            this.labelTime.TabIndex = 14;
            this.labelTime.Text = "Time";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.textBoxTimeData);
            this.Controls.Add(this.buttonTimeThread4);
            this.Controls.Add(this.buttonTimeThread3);
            this.Controls.Add(this.buttonTimeThread1);
            this.Controls.Add(this.buttonTimeThread2);
            this.Controls.Add(this.buttonKillThreads);
            this.Controls.Add(this.buttonStartThreads);
            this.Controls.Add(this.progressBar4);
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonSuspend4);
            this.Controls.Add(this.buttonSuspend3);
            this.Controls.Add(this.buttonSuspend2);
            this.Controls.Add(this.buttonSuspend1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSuspend1;
        private System.Windows.Forms.Button buttonSuspend2;
        private System.Windows.Forms.Button buttonSuspend3;
        private System.Windows.Forms.Button buttonSuspend4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.ProgressBar progressBar4;
        private System.Windows.Forms.Button buttonStartThreads;
        private System.Windows.Forms.Button buttonKillThreads;
        private System.Windows.Forms.Button buttonTimeThread2;
        private System.Windows.Forms.Button buttonTimeThread1;
        private System.Windows.Forms.Button buttonTimeThread3;
        private System.Windows.Forms.Button buttonTimeThread4;
        private System.Windows.Forms.TextBox textBoxTimeData;
        private System.Windows.Forms.Label labelTime;
    }
}

