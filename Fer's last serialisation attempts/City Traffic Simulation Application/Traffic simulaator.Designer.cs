﻿namespace City_Traffic_Simulation_Application
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Traffic_simulaator));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbcrossing2 = new System.Windows.Forms.PictureBox();
            this.pbcrossing1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pb3 = new System.Windows.Forms.PictureBox();
            this.pb4 = new System.Windows.Forms.PictureBox();
            this.pb2 = new System.Windows.Forms.PictureBox();
            this.p1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbcrossing2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcrossing1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbcrossing2);
            this.groupBox1.Controls.Add(this.pbcrossing1);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(129, 286);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crossings tools";
            // 
            // pbcrossing2
            // 
            this.pbcrossing2.Image = ((System.Drawing.Image)(resources.GetObject("pbcrossing2.Image")));
            this.pbcrossing2.Location = new System.Drawing.Point(11, 149);
            this.pbcrossing2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbcrossing2.Name = "pbcrossing2";
            this.pbcrossing2.Size = new System.Drawing.Size(100, 118);
            this.pbcrossing2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbcrossing2.TabIndex = 1;
            this.pbcrossing2.TabStop = false;
            this.pbcrossing2.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox2_DragDrop);
            this.pbcrossing2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbcrossing2_MouseDown);
            // 
            // pbcrossing1
            // 
            this.pbcrossing1.Image = ((System.Drawing.Image)(resources.GetObject("pbcrossing1.Image")));
            this.pbcrossing1.Location = new System.Drawing.Point(11, 21);
            this.pbcrossing1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbcrossing1.Name = "pbcrossing1";
            this.pbcrossing1.Size = new System.Drawing.Size(100, 122);
            this.pbcrossing1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbcrossing1.TabIndex = 0;
            this.pbcrossing1.TabStop = false;
            this.pbcrossing1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbcrossing1_MouseClick);
            this.pbcrossing1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbcrossing1_MouseDown);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(12, 302);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(123, 470);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "OPERATIONS";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 393);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(99, 22);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(11, 161);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(105, 66);
            this.button5.TabIndex = 4;
            this.button5.Text = "ReStart ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(7, 299);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 71);
            this.button4.TabIndex = 3;
            this.button4.Text = "Print";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(11, 234);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 60);
            this.button3.TabIndex = 2;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 94);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 62);
            this.button2.TabIndex = 1;
            this.button2.Text = "Pause";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 21);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pb1
            // 
            this.pb1.Location = new System.Drawing.Point(0, 0);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(533, 264);
            this.pb1.TabIndex = 0;
            this.pb1.TabStop = false;
            this.pb1.Click += new System.EventHandler(this.pb1_Click);
            this.pb1.DragDrop += new System.Windows.Forms.DragEventHandler(this.pb1_DragDrop);
            this.pb1.DragEnter += new System.Windows.Forms.DragEventHandler(this.pb1_DragEnter);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pb3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pb4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pb2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.p1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(141, 9);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1333, 740);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pb3
            // 
            this.pb3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb3.Location = new System.Drawing.Point(3, 372);
            this.pb3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pb3.Name = "pb3";
            this.pb3.Size = new System.Drawing.Size(660, 366);
            this.pb3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb3.TabIndex = 2;
            this.pb3.TabStop = false;
            this.pb3.DragDrop += new System.Windows.Forms.DragEventHandler(this.pb1_DragDrop);
            this.pb3.DragEnter += new System.Windows.Forms.DragEventHandler(this.p1_DragEnter);
            // 
            // pb4
            // 
            this.pb4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb4.Location = new System.Drawing.Point(669, 372);
            this.pb4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pb4.Name = "pb4";
            this.pb4.Size = new System.Drawing.Size(661, 366);
            this.pb4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb4.TabIndex = 4;
            this.pb4.TabStop = false;
            this.pb4.DragDrop += new System.Windows.Forms.DragEventHandler(this.pb1_DragDrop);
            this.pb4.DragEnter += new System.Windows.Forms.DragEventHandler(this.p1_DragEnter);
            // 
            // pb2
            // 
            this.pb2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb2.Location = new System.Drawing.Point(669, 2);
            this.pb2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pb2.Name = "pb2";
            this.pb2.Size = new System.Drawing.Size(661, 366);
            this.pb2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb2.TabIndex = 8;
            this.pb2.TabStop = false;
            this.pb2.DragDrop += new System.Windows.Forms.DragEventHandler(this.pb1_DragDrop);
            this.pb2.DragEnter += new System.Windows.Forms.DragEventHandler(this.p1_DragEnter);
            // 
            // p1
            // 
            this.p1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p1.Location = new System.Drawing.Point(3, 2);
            this.p1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(660, 366);
            this.p1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1.TabIndex = 9;
            this.p1.TabStop = false;
            this.p1.DragDrop += new System.Windows.Forms.DragEventHandler(this.pb1_DragDrop);
            this.p1.DragEnter += new System.Windows.Forms.DragEventHandler(this.p1_DragEnter);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Traffic_simulaator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1485, 751);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Traffic_simulaator";
            this.Text = "Traffic_simulator";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbcrossing2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcrossing1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbcrossing2;
        private System.Windows.Forms.PictureBox pbcrossing1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pb3;
        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.PictureBox pb4;
        private System.Windows.Forms.PictureBox pb2;
        private System.Windows.Forms.PictureBox p1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}