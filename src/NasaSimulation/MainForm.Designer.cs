namespace Simulation
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
            this.guiOpenGLFrame = new OpenTK.GLControl();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblAdaptingText = new System.Windows.Forms.Label();
            this.lblOptimizingText = new System.Windows.Forms.Label();
            this.lblAdapting = new System.Windows.Forms.Label();
            this.lblOptimizing = new System.Windows.Forms.Label();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.settingPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numMaxRadioRange = new System.Windows.Forms.NumericUpDown();
            this.numMaxMessengersRadioRange = new System.Windows.Forms.NumericUpDown();
            this.numSpeed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.numMessengersCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.numRulersCount = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.numTeamsCount = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.numWorkersCount = new System.Windows.Forms.NumericUpDown();
            this.btnMessengerFailure = new System.Windows.Forms.Button();
            this.btnWorkerFailure = new System.Windows.Forms.Button();
            this.btnRulerFailure = new System.Windows.Forms.Button();
            this.btnLeaderFailure = new System.Windows.Forms.Button();
            this.panelSetting.SuspendLayout();
            this.settingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRadioRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxMessengersRadioRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMessengersCount)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRulersCount)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTeamsCount)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkersCount)).BeginInit();
            this.SuspendLayout();
            // 
            // guiOpenGLFrame
            // 
            this.guiOpenGLFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guiOpenGLFrame.AutoScroll = true;
            this.guiOpenGLFrame.BackColor = System.Drawing.Color.Black;
            this.guiOpenGLFrame.Location = new System.Drawing.Point(397, 0);
            this.guiOpenGLFrame.Margin = new System.Windows.Forms.Padding(5);
            this.guiOpenGLFrame.Name = "guiOpenGLFrame";
            this.guiOpenGLFrame.Size = new System.Drawing.Size(707, 730);
            this.guiOpenGLFrame.TabIndex = 0;
            this.guiOpenGLFrame.VSync = true;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnStop.Location = new System.Drawing.Point(186, 664);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(72, 62);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Sto&p";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.BtnStopClick);
            // 
            // lblAdaptingText
            // 
            this.lblAdaptingText.AutoSize = true;
            this.lblAdaptingText.BackColor = System.Drawing.Color.Transparent;
            this.lblAdaptingText.ForeColor = System.Drawing.Color.Black;
            this.lblAdaptingText.Location = new System.Drawing.Point(0, 315);
            this.lblAdaptingText.Margin = new System.Windows.Forms.Padding(0);
            this.lblAdaptingText.Name = "lblAdaptingText";
            this.lblAdaptingText.Size = new System.Drawing.Size(94, 20);
            this.lblAdaptingText.TabIndex = 57;
            this.lblAdaptingText.Text = "Adapting time: ";
            this.lblAdaptingText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAdaptingText.UseCompatibleTextRendering = true;
            // 
            // lblOptimizingText
            // 
            this.lblOptimizingText.AutoSize = true;
            this.lblOptimizingText.BackColor = System.Drawing.Color.Transparent;
            this.lblOptimizingText.ForeColor = System.Drawing.Color.Black;
            this.lblOptimizingText.Location = new System.Drawing.Point(0, 295);
            this.lblOptimizingText.Margin = new System.Windows.Forms.Padding(0);
            this.lblOptimizingText.Name = "lblOptimizingText";
            this.lblOptimizingText.Size = new System.Drawing.Size(103, 20);
            this.lblOptimizingText.TabIndex = 58;
            this.lblOptimizingText.Text = "Message count: ";
            this.lblOptimizingText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOptimizingText.UseCompatibleTextRendering = true;
            // 
            // lblAdapting
            // 
            this.lblAdapting.AutoSize = true;
            this.lblAdapting.BackColor = System.Drawing.Color.Transparent;
            this.lblAdapting.ForeColor = System.Drawing.Color.Black;
            this.lblAdapting.Location = new System.Drawing.Point(182, 315);
            this.lblAdapting.Margin = new System.Windows.Forms.Padding(0);
            this.lblAdapting.Name = "lblAdapting";
            this.lblAdapting.Size = new System.Drawing.Size(35, 20);
            this.lblAdapting.TabIndex = 59;
            this.lblAdapting.Text = "0000";
            this.lblAdapting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAdapting.UseCompatibleTextRendering = true;
            // 
            // lblOptimizing
            // 
            this.lblOptimizing.AutoSize = true;
            this.lblOptimizing.BackColor = System.Drawing.Color.Transparent;
            this.lblOptimizing.ForeColor = System.Drawing.Color.Black;
            this.lblOptimizing.Location = new System.Drawing.Point(182, 295);
            this.lblOptimizing.Margin = new System.Windows.Forms.Padding(0);
            this.lblOptimizing.Name = "lblOptimizing";
            this.lblOptimizing.Size = new System.Drawing.Size(35, 20);
            this.lblOptimizing.TabIndex = 60;
            this.lblOptimizing.Text = "0000";
            this.lblOptimizing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOptimizing.UseCompatibleTextRendering = true;
            // 
            // panelSetting
            // 
            this.panelSetting.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelSetting.Controls.Add(this.settingPanel);
            this.panelSetting.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSetting.Location = new System.Drawing.Point(0, 0);
            this.panelSetting.Margin = new System.Windows.Forms.Padding(2);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(394, 730);
            this.panelSetting.TabIndex = 62;
            // 
            // settingPanel
            // 
            this.settingPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.settingPanel.ColumnCount = 3;
            this.settingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.settingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.settingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.settingPanel.Controls.Add(this.btnStart, 0, 27);
            this.settingPanel.Controls.Add(this.btnStop, 0, 27);
            this.settingPanel.Controls.Add(this.label7, 0, 15);
            this.settingPanel.Controls.Add(this.label6, 0, 14);
            this.settingPanel.Controls.Add(this.label5, 0, 13);
            this.settingPanel.Controls.Add(this.label4, 0, 12);
            this.settingPanel.Controls.Add(this.label3, 0, 6);
            this.settingPanel.Controls.Add(this.numMaxRadioRange, 1, 15);
            this.settingPanel.Controls.Add(this.numMaxMessengersRadioRange, 1, 14);
            this.settingPanel.Controls.Add(this.numSpeed, 1, 16);
            this.settingPanel.Controls.Add(this.label1, 0, 16);
            this.settingPanel.Controls.Add(this.lblOptimizing, 1, 18);
            this.settingPanel.Controls.Add(this.lblAdaptingText, 0, 20);
            this.settingPanel.Controls.Add(this.lblOptimizingText, 0, 18);
            this.settingPanel.Controls.Add(this.lblAdapting, 1, 20);
            this.settingPanel.Controls.Add(this.pictureBox2, 2, 5);
            this.settingPanel.Controls.Add(this.pictureBox3, 2, 12);
            this.settingPanel.Controls.Add(this.pictureBox4, 2, 13);
            this.settingPanel.Controls.Add(this.tableLayoutPanel1, 2, 6);
            this.settingPanel.Controls.Add(this.tableLayoutPanel3, 1, 5);
            this.settingPanel.Controls.Add(this.label2, 0, 5);
            this.settingPanel.Controls.Add(this.tableLayoutPanel2, 1, 6);
            this.settingPanel.Controls.Add(this.tableLayoutPanel5, 1, 12);
            this.settingPanel.Controls.Add(this.tableLayoutPanel4, 1, 13);
            this.settingPanel.Controls.Add(this.btnMessengerFailure, 0, 23);
            this.settingPanel.Controls.Add(this.btnWorkerFailure, 0, 24);
            this.settingPanel.Controls.Add(this.btnRulerFailure, 1, 23);
            this.settingPanel.Controls.Add(this.btnLeaderFailure, 1, 24);
            this.settingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingPanel.Location = new System.Drawing.Point(0, 0);
            this.settingPanel.Margin = new System.Windows.Forms.Padding(2);
            this.settingPanel.Name = "settingPanel";
            this.settingPanel.RowCount = 28;
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.settingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingPanel.Size = new System.Drawing.Size(394, 730);
            this.settingPanel.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnStart.Location = new System.Drawing.Point(4, 664);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(72, 62);
            this.btnStart.TabIndex = 74;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStartClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(0, 243);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 20);
            this.label7.TabIndex = 68;
            this.label7.Text = "Max radio range:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.UseCompatibleTextRendering = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(0, 217);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 20);
            this.label6.TabIndex = 68;
            this.label6.Text = "Max messengers radio range:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            this.label5.AutoEllipsis = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(0, 159);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 58);
            this.label5.TabIndex = 66;
            this.label5.Text = "Workers count:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(0, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 67);
            this.label4.TabIndex = 65;
            this.label4.Text = "Teams count:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(0, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 44);
            this.label3.TabIndex = 64;
            this.label3.Text = "Rulers count:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.UseCompatibleTextRendering = true;
            // 
            // numMaxRadioRange
            // 
            this.numMaxRadioRange.Location = new System.Drawing.Point(184, 245);
            this.numMaxRadioRange.Margin = new System.Windows.Forms.Padding(2);
            this.numMaxRadioRange.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMaxRadioRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxRadioRange.Name = "numMaxRadioRange";
            this.numMaxRadioRange.Size = new System.Drawing.Size(74, 22);
            this.numMaxRadioRange.TabIndex = 70;
            this.numMaxRadioRange.ThousandsSeparator = true;
            this.numMaxRadioRange.Value = new decimal(new int[] {
            85,
            0,
            0,
            0});
            // 
            // numMaxMessengersRadioRange
            // 
            this.numMaxMessengersRadioRange.Location = new System.Drawing.Point(184, 219);
            this.numMaxMessengersRadioRange.Margin = new System.Windows.Forms.Padding(2);
            this.numMaxMessengersRadioRange.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMaxMessengersRadioRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxMessengersRadioRange.Name = "numMaxMessengersRadioRange";
            this.numMaxMessengersRadioRange.Size = new System.Drawing.Size(74, 22);
            this.numMaxMessengersRadioRange.TabIndex = 70;
            this.numMaxMessengersRadioRange.ThousandsSeparator = true;
            this.numMaxMessengersRadioRange.Value = new decimal(new int[] {
            170,
            0,
            0,
            0});
            // 
            // numSpeed
            // 
            this.numSpeed.Location = new System.Drawing.Point(184, 271);
            this.numSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.numSpeed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSpeed.Name = "numSpeed";
            this.numSpeed.Size = new System.Drawing.Size(74, 22);
            this.numSpeed.TabIndex = 70;
            this.numSpeed.ThousandsSeparator = true;
            this.numSpeed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 269);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 68;
            this.label1.Text = "Speed:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Simulation.Properties.Resources.messenger;
            this.pictureBox2.Location = new System.Drawing.Point(301, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(72, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 76;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Simulation.Properties.Resources.team;
            this.pictureBox3.Location = new System.Drawing.Point(301, 95);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(69, 61);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 77;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Simulation.Properties.Resources.workers;
            this.pictureBox4.Location = new System.Drawing.Point(301, 162);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(69, 52);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 78;
            this.pictureBox4.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(301, 51);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(72, 38);
            this.tableLayoutPanel1.TabIndex = 80;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Simulation.Properties.Resources.failed_ruler;
            this.pictureBox5.Location = new System.Drawing.Point(39, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(30, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox5.TabIndex = 79;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Simulation.Properties.Resources.ruler;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.numMessengersCount, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(185, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(102, 42);
            this.tableLayoutPanel3.TabIndex = 82;
            // 
            // numMessengersCount
            // 
            this.numMessengersCount.Location = new System.Drawing.Point(2, 10);
            this.numMessengersCount.Margin = new System.Windows.Forms.Padding(2);
            this.numMessengersCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMessengersCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMessengersCount.Name = "numMessengersCount";
            this.numMessengersCount.Size = new System.Drawing.Size(74, 22);
            this.numMessengersCount.TabIndex = 70;
            this.numMessengersCount.ThousandsSeparator = true;
            this.numMessengersCount.Value = new decimal(new int[] {
            85,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 48);
            this.label2.TabIndex = 63;
            this.label2.Text = "Messengers count:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.UseCompatibleTextRendering = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.numRulersCount, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(185, 51);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(102, 38);
            this.tableLayoutPanel2.TabIndex = 81;
            // 
            // numRulersCount
            // 
            this.numRulersCount.Location = new System.Drawing.Point(2, 8);
            this.numRulersCount.Margin = new System.Windows.Forms.Padding(2);
            this.numRulersCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numRulersCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRulersCount.Name = "numRulersCount";
            this.numRulersCount.Size = new System.Drawing.Size(74, 22);
            this.numRulersCount.TabIndex = 70;
            this.numRulersCount.ThousandsSeparator = true;
            this.numRulersCount.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.numTeamsCount, 0, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(185, 95);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(102, 61);
            this.tableLayoutPanel5.TabIndex = 84;
            // 
            // numTeamsCount
            // 
            this.numTeamsCount.Location = new System.Drawing.Point(2, 19);
            this.numTeamsCount.Margin = new System.Windows.Forms.Padding(2);
            this.numTeamsCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTeamsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTeamsCount.Name = "numTeamsCount";
            this.numTeamsCount.Size = new System.Drawing.Size(74, 22);
            this.numTeamsCount.TabIndex = 70;
            this.numTeamsCount.ThousandsSeparator = true;
            this.numTeamsCount.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.numWorkersCount, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(185, 162);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(102, 52);
            this.tableLayoutPanel4.TabIndex = 83;
            // 
            // numWorkersCount
            // 
            this.numWorkersCount.Location = new System.Drawing.Point(2, 15);
            this.numWorkersCount.Margin = new System.Windows.Forms.Padding(2);
            this.numWorkersCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWorkersCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWorkersCount.Name = "numWorkersCount";
            this.numWorkersCount.Size = new System.Drawing.Size(74, 22);
            this.numWorkersCount.TabIndex = 70;
            this.numWorkersCount.ThousandsSeparator = true;
            this.numWorkersCount.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // btnMessengerFailure
            // 
            this.btnMessengerFailure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMessengerFailure.Location = new System.Drawing.Point(3, 338);
            this.btnMessengerFailure.Name = "btnMessengerFailure";
            this.btnMessengerFailure.Size = new System.Drawing.Size(146, 37);
            this.btnMessengerFailure.TabIndex = 85;
            this.btnMessengerFailure.Text = "Messsenger Failure";
            this.btnMessengerFailure.UseVisualStyleBackColor = true;
            this.btnMessengerFailure.Click += new System.EventHandler(this.BtnMessengerFailureClick);
            // 
            // btnWorkerFailure
            // 
            this.btnWorkerFailure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWorkerFailure.Location = new System.Drawing.Point(3, 381);
            this.btnWorkerFailure.Name = "btnWorkerFailure";
            this.btnWorkerFailure.Size = new System.Drawing.Size(146, 37);
            this.btnWorkerFailure.TabIndex = 86;
            this.btnWorkerFailure.Text = "Worker Failure";
            this.btnWorkerFailure.UseVisualStyleBackColor = true;
            this.btnWorkerFailure.Click += new System.EventHandler(this.BtnWorkerFailureClick);
            // 
            // btnRulerFailure
            // 
            this.btnRulerFailure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRulerFailure.Location = new System.Drawing.Point(185, 338);
            this.btnRulerFailure.Name = "btnRulerFailure";
            this.btnRulerFailure.Size = new System.Drawing.Size(110, 37);
            this.btnRulerFailure.TabIndex = 86;
            this.btnRulerFailure.Text = "Ruler Failure";
            this.btnRulerFailure.UseVisualStyleBackColor = true;
            this.btnRulerFailure.Click += new System.EventHandler(this.BtnRulerFailureClick);
            // 
            // btnLeaderFailure
            // 
            this.btnLeaderFailure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeaderFailure.Location = new System.Drawing.Point(185, 381);
            this.btnLeaderFailure.Name = "btnLeaderFailure";
            this.btnLeaderFailure.Size = new System.Drawing.Size(110, 37);
            this.btnLeaderFailure.TabIndex = 87;
            this.btnLeaderFailure.Text = "Leader Failure";
            this.btnLeaderFailure.UseVisualStyleBackColor = true;
            this.btnLeaderFailure.Click += new System.EventHandler(this.BtnLeaderFailureClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1105, 730);
            this.Controls.Add(this.panelSetting);
            this.Controls.Add(this.guiOpenGLFrame);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "NASA ANTS Simulation";
            this.panelSetting.ResumeLayout(false);
            this.settingPanel.ResumeLayout(false);
            this.settingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRadioRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxMessengersRadioRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numMessengersCount)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numRulersCount)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numTeamsCount)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numWorkersCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl guiOpenGLFrame;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblAdaptingText;
        private System.Windows.Forms.Label lblOptimizingText;
        public System.Windows.Forms.Label lblAdapting;
        public System.Windows.Forms.Label lblOptimizing;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.TableLayoutPanel settingPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numWorkersCount;
        private System.Windows.Forms.NumericUpDown numMaxMessengersRadioRange;
        private System.Windows.Forms.NumericUpDown numMaxRadioRange;
        private System.Windows.Forms.NumericUpDown numSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.NumericUpDown numMessengersCount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown numRulersCount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.NumericUpDown numTeamsCount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnMessengerFailure;
        private System.Windows.Forms.Button btnWorkerFailure;
        private System.Windows.Forms.Button btnRulerFailure;
        private System.Windows.Forms.Button btnLeaderFailure;
    }
}