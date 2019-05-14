namespace Laborator8
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
            this.progressBarMusca = new System.Windows.Forms.ProgressBar();
            this.progressBarMaria = new System.Windows.Forms.ProgressBar();
            this.progressBarCorina = new System.Windows.Forms.ProgressBar();
            this.progressBarRadu = new System.Windows.Forms.ProgressBar();
            this.buttonStartReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxT1 = new System.Windows.Forms.TextBox();
            this.textBoxT2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // progressBarMusca
            // 
            this.progressBarMusca.Location = new System.Drawing.Point(248, 136);
            this.progressBarMusca.Name = "progressBarMusca";
            this.progressBarMusca.Size = new System.Drawing.Size(230, 23);
            this.progressBarMusca.TabIndex = 11;
            // 
            // progressBarMaria
            // 
            this.progressBarMaria.Location = new System.Drawing.Point(139, 107);
            this.progressBarMaria.Name = "progressBarMaria";
            this.progressBarMaria.Size = new System.Drawing.Size(339, 23);
            this.progressBarMaria.TabIndex = 10;
            // 
            // progressBarCorina
            // 
            this.progressBarCorina.Location = new System.Drawing.Point(139, 78);
            this.progressBarCorina.Name = "progressBarCorina";
            this.progressBarCorina.Size = new System.Drawing.Size(339, 23);
            this.progressBarCorina.TabIndex = 9;
            // 
            // progressBarRadu
            // 
            this.progressBarRadu.Location = new System.Drawing.Point(38, 49);
            this.progressBarRadu.Name = "progressBarRadu";
            this.progressBarRadu.Size = new System.Drawing.Size(440, 23);
            this.progressBarRadu.TabIndex = 8;
            // 
            // buttonStartReset
            // 
            this.buttonStartReset.Location = new System.Drawing.Point(341, 177);
            this.buttonStartReset.Name = "buttonStartReset";
            this.buttonStartReset.Size = new System.Drawing.Size(75, 23);
            this.buttonStartReset.TabIndex = 12;
            this.buttonStartReset.Text = "Start";
            this.buttonStartReset.UseVisualStyleBackColor = true;
            this.buttonStartReset.Click += new System.EventHandler(this.StartReset);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(520, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Radu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(520, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Corina";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Maria";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(520, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Musca";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(640, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "T1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(640, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "T2";
            // 
            // textBoxT1
            // 
            this.textBoxT1.Location = new System.Drawing.Point(643, 81);
            this.textBoxT1.Name = "textBoxT1";
            this.textBoxT1.Size = new System.Drawing.Size(100, 20);
            this.textBoxT1.TabIndex = 19;
            // 
            // textBoxT2
            // 
            this.textBoxT2.Location = new System.Drawing.Point(643, 136);
            this.textBoxT2.Name = "textBoxT2";
            this.textBoxT2.Size = new System.Drawing.Size(100, 20);
            this.textBoxT2.TabIndex = 20;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 236);
            this.Controls.Add(this.textBoxT2);
            this.Controls.Add(this.textBoxT1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStartReset);
            this.Controls.Add(this.progressBarMusca);
            this.Controls.Add(this.progressBarMaria);
            this.Controls.Add(this.progressBarCorina);
            this.Controls.Add(this.progressBarRadu);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarMusca;
        private System.Windows.Forms.ProgressBar progressBarMaria;
        private System.Windows.Forms.ProgressBar progressBarCorina;
        private System.Windows.Forms.ProgressBar progressBarRadu;
        private System.Windows.Forms.Button buttonStartReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxT1;
        private System.Windows.Forms.TextBox textBoxT2;
    }
}

