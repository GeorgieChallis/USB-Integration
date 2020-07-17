namespace HID_PnP_Demo
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ANxVoltage_lbl = new System.Windows.Forms.Label();
            this.StatusBox_lbl = new System.Windows.Forms.Label();
            this.StatusBox_txtbx = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ReadWriteThread = new System.ComponentModel.BackgroundWorker();
            this.FormUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.ANxVoltageToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ToggleLEDToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.PushbuttonStateTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.button_C = new System.Windows.Forms.Button();
            this.button_D = new System.Windows.Forms.Button();
            this.button_E = new System.Windows.Forms.Button();
            this.button_F = new System.Windows.Forms.Button();
            this.button_G = new System.Windows.Forms.Button();
            this.button_A = new System.Windows.Forms.Button();
            this.button_B = new System.Windows.Forms.Button();
            this.button_Cs = new System.Windows.Forms.Button();
            this.button_Eb = new System.Windows.Forms.Button();
            this.button_Fs = new System.Windows.Forms.Button();
            this.button_Gs = new System.Windows.Forms.Button();
            this.button_Bb = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ANxVoltage_lbl
            // 
            this.ANxVoltage_lbl.AutoSize = true;
            this.ANxVoltage_lbl.Enabled = false;
            this.ANxVoltage_lbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ANxVoltage_lbl.Location = new System.Drawing.Point(247, 498);
            this.ANxVoltage_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ANxVoltage_lbl.Name = "ANxVoltage_lbl";
            this.ANxVoltage_lbl.Size = new System.Drawing.Size(80, 25);
            this.ANxVoltage_lbl.TabIndex = 23;
            this.ANxVoltage_lbl.Text = "Notes: ";
            // 
            // StatusBox_lbl
            // 
            this.StatusBox_lbl.AutoSize = true;
            this.StatusBox_lbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.StatusBox_lbl.Location = new System.Drawing.Point(632, 29);
            this.StatusBox_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.StatusBox_lbl.Name = "StatusBox_lbl";
            this.StatusBox_lbl.Size = new System.Drawing.Size(0, 25);
            this.StatusBox_lbl.TabIndex = 22;
            // 
            // StatusBox_txtbx
            // 
            this.StatusBox_txtbx.BackColor = System.Drawing.SystemColors.Window;
            this.StatusBox_txtbx.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.StatusBox_txtbx.Location = new System.Drawing.Point(24, 23);
            this.StatusBox_txtbx.Margin = new System.Windows.Forms.Padding(6);
            this.StatusBox_txtbx.Name = "StatusBox_txtbx";
            this.StatusBox_txtbx.ReadOnly = true;
            this.StatusBox_txtbx.Size = new System.Drawing.Size(592, 31);
            this.StatusBox_txtbx.TabIndex = 21;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.progressBar1.ForeColor = System.Drawing.Color.Coral;
            this.progressBar1.Location = new System.Drawing.Point(130, 559);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(6);
            this.progressBar1.Maximum = 1024;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(406, 44);
            this.progressBar1.Step = 205;
            this.progressBar1.TabIndex = 20;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // ReadWriteThread
            // 
            this.ReadWriteThread.WorkerReportsProgress = true;
            this.ReadWriteThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ReadWriteThread_DoWork);
            // 
            // FormUpdateTimer
            // 
            this.FormUpdateTimer.Enabled = true;
            this.FormUpdateTimer.Interval = 6;
            this.FormUpdateTimer.Tick += new System.EventHandler(this.FormUpdateTimer_Tick);
            // 
            // ANxVoltageToolTip
            // 
            this.ANxVoltageToolTip.AutomaticDelay = 20;
            this.ANxVoltageToolTip.AutoPopDelay = 20000;
            this.ANxVoltageToolTip.InitialDelay = 15;
            this.ANxVoltageToolTip.ReshowDelay = 15;
            this.ANxVoltageToolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.ANxVoltageToolTip_Popup);
            // 
            // ToggleLEDToolTip
            // 
            this.ToggleLEDToolTip.AutomaticDelay = 2000;
            this.ToggleLEDToolTip.AutoPopDelay = 20000;
            this.ToggleLEDToolTip.InitialDelay = 15;
            this.ToggleLEDToolTip.ReshowDelay = 15;
            // 
            // PushbuttonStateTooltip
            // 
            this.PushbuttonStateTooltip.AutomaticDelay = 20;
            this.PushbuttonStateTooltip.AutoPopDelay = 20000;
            this.PushbuttonStateTooltip.InitialDelay = 15;
            this.PushbuttonStateTooltip.ReshowDelay = 15;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 2000;
            this.toolTip1.AutoPopDelay = 20000;
            this.toolTip1.InitialDelay = 15;
            this.toolTip1.ReshowDelay = 15;
            // 
            // toolTip2
            // 
            this.toolTip2.AutomaticDelay = 20;
            this.toolTip2.AutoPopDelay = 20000;
            this.toolTip2.InitialDelay = 15;
            this.toolTip2.ReshowDelay = 15;
            // 
            // button_C
            // 
            this.button_C.BackColor = System.Drawing.Color.White;
            this.button_C.Location = new System.Drawing.Point(53, 105);
            this.button_C.Name = "button_C";
            this.button_C.Size = new System.Drawing.Size(78, 338);
            this.button_C.TabIndex = 30;
            this.button_C.UseVisualStyleBackColor = false;
            // 
            // button_D
            // 
            this.button_D.BackColor = System.Drawing.Color.White;
            this.button_D.Location = new System.Drawing.Point(130, 105);
            this.button_D.Name = "button_D";
            this.button_D.Size = new System.Drawing.Size(78, 338);
            this.button_D.TabIndex = 31;
            this.button_D.UseVisualStyleBackColor = false;
            // 
            // button_E
            // 
            this.button_E.BackColor = System.Drawing.Color.White;
            this.button_E.Location = new System.Drawing.Point(206, 105);
            this.button_E.Name = "button_E";
            this.button_E.Size = new System.Drawing.Size(78, 338);
            this.button_E.TabIndex = 32;
            this.button_E.UseVisualStyleBackColor = false;
            // 
            // button_F
            // 
            this.button_F.BackColor = System.Drawing.Color.White;
            this.button_F.Location = new System.Drawing.Point(283, 105);
            this.button_F.Name = "button_F";
            this.button_F.Size = new System.Drawing.Size(78, 338);
            this.button_F.TabIndex = 33;
            this.button_F.UseVisualStyleBackColor = false;
            // 
            // button_G
            // 
            this.button_G.BackColor = System.Drawing.Color.White;
            this.button_G.Location = new System.Drawing.Point(360, 105);
            this.button_G.Name = "button_G";
            this.button_G.Size = new System.Drawing.Size(78, 338);
            this.button_G.TabIndex = 34;
            this.button_G.UseVisualStyleBackColor = false;
            // 
            // button_A
            // 
            this.button_A.BackColor = System.Drawing.Color.White;
            this.button_A.Location = new System.Drawing.Point(437, 105);
            this.button_A.Name = "button_A";
            this.button_A.Size = new System.Drawing.Size(78, 338);
            this.button_A.TabIndex = 35;
            this.button_A.UseVisualStyleBackColor = false;
            // 
            // button_B
            // 
            this.button_B.BackColor = System.Drawing.Color.White;
            this.button_B.Location = new System.Drawing.Point(514, 105);
            this.button_B.Name = "button_B";
            this.button_B.Size = new System.Drawing.Size(78, 338);
            this.button_B.TabIndex = 36;
            this.button_B.UseVisualStyleBackColor = false;
            // 
            // button_Cs
            // 
            this.button_Cs.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Cs.Location = new System.Drawing.Point(104, 106);
            this.button_Cs.Name = "button_Cs";
            this.button_Cs.Size = new System.Drawing.Size(53, 203);
            this.button_Cs.TabIndex = 37;
            this.button_Cs.UseVisualStyleBackColor = false;
            // 
            // button_Eb
            // 
            this.button_Eb.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Eb.Location = new System.Drawing.Point(182, 106);
            this.button_Eb.Name = "button_Eb";
            this.button_Eb.Size = new System.Drawing.Size(53, 203);
            this.button_Eb.TabIndex = 38;
            this.button_Eb.UseVisualStyleBackColor = false;
            // 
            // button_Fs
            // 
            this.button_Fs.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Fs.Location = new System.Drawing.Point(332, 105);
            this.button_Fs.Name = "button_Fs";
            this.button_Fs.Size = new System.Drawing.Size(53, 203);
            this.button_Fs.TabIndex = 39;
            this.button_Fs.UseVisualStyleBackColor = false;
            // 
            // button_Gs
            // 
            this.button_Gs.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Gs.Location = new System.Drawing.Point(412, 106);
            this.button_Gs.Name = "button_Gs";
            this.button_Gs.Size = new System.Drawing.Size(53, 203);
            this.button_Gs.TabIndex = 40;
            this.button_Gs.UseVisualStyleBackColor = false;
            // 
            // button_Bb
            // 
            this.button_Bb.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Bb.Location = new System.Drawing.Point(492, 106);
            this.button_Bb.Name = "button_Bb";
            this.button_Bb.Size = new System.Drawing.Size(53, 203);
            this.button_Bb.TabIndex = 41;
            this.button_Bb.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(34, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(570, 388);
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(645, 537);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_Bb);
            this.Controls.Add(this.button_Gs);
            this.Controls.Add(this.button_Fs);
            this.Controls.Add(this.button_Eb);
            this.Controls.Add(this.button_Cs);
            this.Controls.Add(this.button_B);
            this.Controls.Add(this.button_A);
            this.Controls.Add(this.button_G);
            this.Controls.Add(this.button_F);
            this.Controls.Add(this.button_E);
            this.Controls.Add(this.button_D);
            this.Controls.Add(this.button_C);
            this.Controls.Add(this.ANxVoltage_lbl);
            this.Controls.Add(this.StatusBox_lbl);
            this.Controls.Add(this.StatusBox_txtbx);
            this.Controls.Add(this.progressBar1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "HID PnP Demo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ANxVoltage_lbl;
        private System.Windows.Forms.Label StatusBox_lbl;
        private System.Windows.Forms.TextBox StatusBox_txtbx;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker ReadWriteThread;
        private System.Windows.Forms.Timer FormUpdateTimer;
        private System.Windows.Forms.ToolTip ANxVoltageToolTip;
        private System.Windows.Forms.ToolTip ToggleLEDToolTip;
        private System.Windows.Forms.ToolTip PushbuttonStateTooltip;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Button button_C;
        private System.Windows.Forms.Button button_D;
        private System.Windows.Forms.Button button_E;
        private System.Windows.Forms.Button button_F;
        private System.Windows.Forms.Button button_G;
        private System.Windows.Forms.Button button_A;
        private System.Windows.Forms.Button button_B;
        private System.Windows.Forms.Button button_Cs;
        private System.Windows.Forms.Button button_Eb;
        private System.Windows.Forms.Button button_Fs;
        private System.Windows.Forms.Button button_Gs;
        private System.Windows.Forms.Button button_Bb;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

