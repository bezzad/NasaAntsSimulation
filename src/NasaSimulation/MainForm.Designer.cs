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
            this.radioButtonSH = new System.Windows.Forms.RadioButton();
            this.radioButtonSO = new System.Windows.Forms.RadioButton();
            this.radioButtonSP = new System.Windows.Forms.RadioButton();
            this.radioButtonSC = new System.Windows.Forms.RadioButton();
            this.checkBoxOurs = new System.Windows.Forms.CheckBox();
            this.lblAdaptingText = new System.Windows.Forms.Label();
            this.lblOptimizingText = new System.Windows.Forms.Label();
            this.lblAdapting = new System.Windows.Forms.Label();
            this.lblOptimizing = new System.Windows.Forms.Label();
            this.checkBoxMultiOff = new System.Windows.Forms.CheckBox();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.settingPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numMaxRadioRange = new System.Windows.Forms.NumericUpDown();
            this.numMaxMessengersRadioRange = new System.Windows.Forms.NumericUpDown();
            this.numWorkersCount = new System.Windows.Forms.NumericUpDown();
            this.numTeamsCount = new System.Windows.Forms.NumericUpDown();
            this.numRulersCount = new System.Windows.Forms.NumericUpDown();
            this.numSpeed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numMessengersCount = new System.Windows.Forms.NumericUpDown();
            this.panelSetting.SuspendLayout();
            this.settingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRadioRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxMessengersRadioRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkersCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTeamsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRulersCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMessengersCount)).BeginInit();
            this.SuspendLayout();
            // 
            // guiOpenGLFrame
            // 
            this.guiOpenGLFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guiOpenGLFrame.AutoScroll = true;
            this.guiOpenGLFrame.BackColor = System.Drawing.Color.Black;
            this.guiOpenGLFrame.Location = new System.Drawing.Point(362, 0);
            this.guiOpenGLFrame.Margin = new System.Windows.Forms.Padding(5);
            this.guiOpenGLFrame.Name = "guiOpenGLFrame";
            this.guiOpenGLFrame.Size = new System.Drawing.Size(742, 639);
            this.guiOpenGLFrame.TabIndex = 0;
            this.guiOpenGLFrame.VSync = true;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnStop.Location = new System.Drawing.Point(202, 573);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(72, 62);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Sto&p";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.BtnStopClick);
            // 
            // radioButtonSH
            // 
            this.radioButtonSH.AutoSize = true;
            this.radioButtonSH.Location = new System.Drawing.Point(4, 4);
            this.radioButtonSH.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonSH.Name = "radioButtonSH";
            this.radioButtonSH.Size = new System.Drawing.Size(161, 21);
            this.radioButtonSH.TabIndex = 51;
            this.radioButtonSH.TabStop = true;
            this.radioButtonSH.Text = "Self-Healing Scenaio";
            this.radioButtonSH.UseVisualStyleBackColor = true;
            // 
            // radioButtonSO
            // 
            this.radioButtonSO.AutoSize = true;
            this.radioButtonSO.Location = new System.Drawing.Point(4, 33);
            this.radioButtonSO.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonSO.Name = "radioButtonSO";
            this.radioButtonSO.Size = new System.Drawing.Size(184, 21);
            this.radioButtonSO.TabIndex = 52;
            this.radioButtonSO.TabStop = true;
            this.radioButtonSO.Text = "Self-Optimizing Scenario";
            this.radioButtonSO.UseVisualStyleBackColor = true;
            // 
            // radioButtonSP
            // 
            this.radioButtonSP.AutoSize = true;
            this.radioButtonSP.Location = new System.Drawing.Point(4, 62);
            this.radioButtonSP.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonSP.Name = "radioButtonSP";
            this.radioButtonSP.Size = new System.Drawing.Size(182, 21);
            this.radioButtonSP.TabIndex = 53;
            this.radioButtonSP.TabStop = true;
            this.radioButtonSP.Text = "Self-Protecting Scenario";
            this.radioButtonSP.UseVisualStyleBackColor = true;
            // 
            // radioButtonSC
            // 
            this.radioButtonSC.AutoSize = true;
            this.radioButtonSC.Location = new System.Drawing.Point(4, 91);
            this.radioButtonSC.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonSC.Name = "radioButtonSC";
            this.radioButtonSC.Size = new System.Drawing.Size(190, 21);
            this.radioButtonSC.TabIndex = 54;
            this.radioButtonSC.TabStop = true;
            this.radioButtonSC.Text = "Self-Configuring Scenario";
            this.radioButtonSC.UseVisualStyleBackColor = true;
            // 
            // checkBoxOurs
            // 
            this.checkBoxOurs.AutoSize = true;
            this.checkBoxOurs.Location = new System.Drawing.Point(202, 302);
            this.checkBoxOurs.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxOurs.Name = "checkBoxOurs";
            this.checkBoxOurs.Size = new System.Drawing.Size(101, 21);
            this.checkBoxOurs.TabIndex = 56;
            this.checkBoxOurs.Text = "OurMethod";
            this.checkBoxOurs.UseVisualStyleBackColor = true;
            // 
            // lblAdaptingText
            // 
            this.lblAdaptingText.AutoSize = true;
            this.lblAdaptingText.BackColor = System.Drawing.Color.Transparent;
            this.lblAdaptingText.ForeColor = System.Drawing.Color.Black;
            this.lblAdaptingText.Location = new System.Drawing.Point(0, 347);
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
            this.lblOptimizingText.Location = new System.Drawing.Point(0, 327);
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
            this.lblAdapting.Location = new System.Drawing.Point(198, 347);
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
            this.lblOptimizing.Location = new System.Drawing.Point(198, 327);
            this.lblOptimizing.Margin = new System.Windows.Forms.Padding(0);
            this.lblOptimizing.Name = "lblOptimizing";
            this.lblOptimizing.Size = new System.Drawing.Size(35, 20);
            this.lblOptimizing.TabIndex = 60;
            this.lblOptimizing.Text = "0000";
            this.lblOptimizing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOptimizing.UseCompatibleTextRendering = true;
            // 
            // checkBoxMultiOff
            // 
            this.checkBoxMultiOff.AutoSize = true;
            this.checkBoxMultiOff.Location = new System.Drawing.Point(4, 302);
            this.checkBoxMultiOff.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxMultiOff.Name = "checkBoxMultiOff";
            this.checkBoxMultiOff.Size = new System.Drawing.Size(78, 21);
            this.checkBoxMultiOff.TabIndex = 61;
            this.checkBoxMultiOff.Text = "multiOff";
            this.checkBoxMultiOff.UseVisualStyleBackColor = true;
            // 
            // panelSetting
            // 
            this.panelSetting.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelSetting.Controls.Add(this.settingPanel);
            this.panelSetting.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSetting.Location = new System.Drawing.Point(0, 0);
            this.panelSetting.Margin = new System.Windows.Forms.Padding(2);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(355, 639);
            this.panelSetting.TabIndex = 62;
            // 
            // settingPanel
            // 
            this.settingPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.settingPanel.ColumnCount = 2;
            this.settingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.settingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.settingPanel.Controls.Add(this.btnStart, 0, 24);
            this.settingPanel.Controls.Add(this.radioButtonSH, 0, 0);
            this.settingPanel.Controls.Add(this.radioButtonSO, 0, 1);
            this.settingPanel.Controls.Add(this.radioButtonSP, 0, 2);
            this.settingPanel.Controls.Add(this.radioButtonSC, 0, 3);
            this.settingPanel.Controls.Add(this.btnStop, 0, 24);
            this.settingPanel.Controls.Add(this.label7, 0, 15);
            this.settingPanel.Controls.Add(this.label6, 0, 14);
            this.settingPanel.Controls.Add(this.label5, 0, 13);
            this.settingPanel.Controls.Add(this.label4, 0, 12);
            this.settingPanel.Controls.Add(this.label3, 0, 6);
            this.settingPanel.Controls.Add(this.label2, 0, 5);
            this.settingPanel.Controls.Add(this.numMaxRadioRange, 1, 15);
            this.settingPanel.Controls.Add(this.numMaxMessengersRadioRange, 1, 14);
            this.settingPanel.Controls.Add(this.numWorkersCount, 1, 13);
            this.settingPanel.Controls.Add(this.numTeamsCount, 1, 12);
            this.settingPanel.Controls.Add(this.numRulersCount, 1, 6);
            this.settingPanel.Controls.Add(this.numSpeed, 1, 16);
            this.settingPanel.Controls.Add(this.label1, 0, 16);
            this.settingPanel.Controls.Add(this.lblOptimizing, 1, 18);
            this.settingPanel.Controls.Add(this.lblAdaptingText, 0, 20);
            this.settingPanel.Controls.Add(this.lblOptimizingText, 0, 18);
            this.settingPanel.Controls.Add(this.checkBoxMultiOff, 0, 17);
            this.settingPanel.Controls.Add(this.lblAdapting, 1, 20);
            this.settingPanel.Controls.Add(this.checkBoxOurs, 1, 17);
            this.settingPanel.Controls.Add(this.numMessengersCount, 1, 5);
            this.settingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingPanel.Location = new System.Drawing.Point(0, 0);
            this.settingPanel.Margin = new System.Windows.Forms.Padding(2);
            this.settingPanel.Name = "settingPanel";
            this.settingPanel.RowCount = 25;
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
            this.settingPanel.Size = new System.Drawing.Size(355, 639);
            this.settingPanel.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnStart.Location = new System.Drawing.Point(4, 573);
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
            this.label7.Location = new System.Drawing.Point(0, 246);
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
            this.label6.Location = new System.Drawing.Point(0, 220);
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
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(0, 194);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 66;
            this.label5.Text = "Workers count:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(0, 168);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 65;
            this.label4.Text = "Teams count:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(0, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 64;
            this.label3.Text = "Rulers count:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 63;
            this.label2.Text = "Messengers count:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.UseCompatibleTextRendering = true;
            // 
            // numMaxRadioRange
            // 
            this.numMaxRadioRange.Location = new System.Drawing.Point(200, 248);
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
            this.numMaxRadioRange.Value = new decimal(new int[] {
            85,
            0,
            0,
            0});
            // 
            // numMaxMessengersRadioRange
            // 
            this.numMaxMessengersRadioRange.Location = new System.Drawing.Point(200, 222);
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
            this.numMaxMessengersRadioRange.Value = new decimal(new int[] {
            170,
            0,
            0,
            0});
            // 
            // numWorkersCount
            // 
            this.numWorkersCount.Location = new System.Drawing.Point(200, 196);
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
            this.numWorkersCount.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numTeamsCount
            // 
            this.numTeamsCount.Location = new System.Drawing.Point(200, 170);
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
            this.numTeamsCount.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numRulersCount
            // 
            this.numRulersCount.Location = new System.Drawing.Point(200, 144);
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
            this.numRulersCount.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // numSpeed
            // 
            this.numSpeed.Location = new System.Drawing.Point(200, 274);
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
            this.label1.Location = new System.Drawing.Point(0, 272);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 68;
            this.label1.Text = "Speed:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // numMessengersCount
            // 
            this.numMessengersCount.Location = new System.Drawing.Point(200, 118);
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
            this.numMessengersCount.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1105, 639);
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
            ((System.ComponentModel.ISupportInitialize)(this.numWorkersCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTeamsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRulersCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMessengersCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl guiOpenGLFrame;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.RadioButton radioButtonSH;
        private System.Windows.Forms.RadioButton radioButtonSO;
        private System.Windows.Forms.RadioButton radioButtonSP;
        private System.Windows.Forms.RadioButton radioButtonSC;
        private System.Windows.Forms.CheckBox checkBoxOurs;
        private System.Windows.Forms.Label lblAdaptingText;
        private System.Windows.Forms.Label lblOptimizingText;
        public System.Windows.Forms.Label lblAdapting;
        public System.Windows.Forms.Label lblOptimizing;
        private System.Windows.Forms.CheckBox checkBoxMultiOff;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.TableLayoutPanel settingPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numMessengersCount;
        private System.Windows.Forms.NumericUpDown numRulersCount;
        private System.Windows.Forms.NumericUpDown numTeamsCount;
        private System.Windows.Forms.NumericUpDown numWorkersCount;
        private System.Windows.Forms.NumericUpDown numMaxMessengersRadioRange;
        private System.Windows.Forms.NumericUpDown numMaxRadioRange;
        private System.Windows.Forms.NumericUpDown numSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
    }
}