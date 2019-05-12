namespace City_Traffic_Simulation_Application
{
    partial class Traffic_simulaator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Traffic_simulaator));
            this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbcrossing1 = new System.Windows.Forms.PictureBox();
            this.pbcrossing2 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbcrossing1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcrossing2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(141, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 250);
            this.panel1.TabIndex = 0;
            this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
            this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel1_DragEnter);
            this.panel1.DragOver += new System.Windows.Forms.DragEventHandler(this.panel1_DragOver);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbcrossing1);
            this.groupBox1.Controls.Add(this.pbcrossing2);
            this.groupBox1.Location = new System.Drawing.Point(240, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crossings tools";
            // 
            // pbcrossing1
            // 
            this.pbcrossing1.Image = ((System.Drawing.Image)(resources.GetObject("pbcrossing1.Image")));
            this.pbcrossing1.Location = new System.Drawing.Point(11, 21);
            this.pbcrossing1.Name = "pbcrossing1";
            this.pbcrossing1.Size = new System.Drawing.Size(100, 121);
            this.pbcrossing1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbcrossing1.TabIndex = 0;
            this.pbcrossing1.TabStop = false;
            this.pbcrossing1.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragDrop);
            this.pbcrossing1.DoubleClick += new System.EventHandler(this.pbcrossing1_DoubleClick);
            this.pbcrossing1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbcrossing1_MouseClick);
            this.pbcrossing1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbcrossing1_MouseDown);
            // 
            // pbcrossing2
            // 
            this.pbcrossing2.Image = ((System.Drawing.Image)(resources.GetObject("pbcrossing2.Image")));
            this.pbcrossing2.Location = new System.Drawing.Point(140, 21);
            this.pbcrossing2.Name = "pbcrossing2";
            this.pbcrossing2.Size = new System.Drawing.Size(100, 121);
            this.pbcrossing2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbcrossing2.TabIndex = 1;
            this.pbcrossing2.TabStop = false;
            this.pbcrossing2.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox2_DragDrop);
            this.pbcrossing2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbcrossing2_MouseDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(12, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 582);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 450);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 93);
            this.button4.TabIndex = 3;
            this.button4.Text = "Print";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 148);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 97);
            this.button3.TabIndex = 2;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 285);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 109);
            this.button2.TabIndex = 1;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 97);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(461, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 250);
            this.panel2.TabIndex = 1;
            this.panel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel2_DragDrop);
            this.panel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel2_DragEnter);
            this.panel2.DragOver += new System.Windows.Forms.DragEventHandler(this.panel2_DragOver);
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // Traffic_simulaator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1518, 701);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Traffic_simulaator";
            this.Text = "Traffic_simulaator";
            this.Load += new System.EventHandler(this.Traffic_simulaator_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbcrossing1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcrossing2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbcrossing2;
        private System.Windows.Forms.PictureBox pbcrossing1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
    }
}