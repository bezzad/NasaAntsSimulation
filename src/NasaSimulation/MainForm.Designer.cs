﻿namespace Simulation
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
            this.button1 = new System.Windows.Forms.Button();
            this.radioButtonSH = new System.Windows.Forms.RadioButton();
            this.radioButtonSO = new System.Windows.Forms.RadioButton();
            this.radioButtonSP = new System.Windows.Forms.RadioButton();
            this.radioButtonSC = new System.Windows.Forms.RadioButton();
            this.checkBoxOurs = new System.Windows.Forms.CheckBox();
            this.lblAdapting = new System.Windows.Forms.Label();
            this.lblOptimizing = new System.Windows.Forms.Label();
            this.labelAdapting = new System.Windows.Forms.Label();
            this.lableOptimizing = new System.Windows.Forms.Label();
            this.checkBoxMultiOff = new System.Windows.Forms.CheckBox();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numNormalRadioRange = new System.Windows.Forms.NumericUpDown();
            this.numMessengersRadioRange = new System.Windows.Forms.NumericUpDown();
            this.numWorkersCount = new System.Windows.Forms.NumericUpDown();
            this.numTeamsCount = new System.Windows.Forms.NumericUpDown();
            this.numRulersCount = new System.Windows.Forms.NumericUpDown();
            this.numMessengersCount = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panelSetting.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNormalRadioRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMessengersRadioRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkersCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTeamsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRulersCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMessengersCount)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // guiOpenGLFrame
            // 
            this.guiOpenGLFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guiOpenGLFrame.AutoScroll = true;
            this.guiOpenGLFrame.BackColor = System.Drawing.Color.Black;
            this.guiOpenGLFrame.Location = new System.Drawing.Point(290, 0);
            this.guiOpenGLFrame.Name = "guiOpenGLFrame";
            this.guiOpenGLFrame.Size = new System.Drawing.Size(594, 511);
            this.guiOpenGLFrame.TabIndex = 0;
            this.guiOpenGLFrame.VSync = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.button1.Location = new System.Drawing.Point(3, 458);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.BtnStartClick);
            // 
            // radioButtonSH
            // 
            this.radioButtonSH.AutoSize = true;
            this.radioButtonSH.Location = new System.Drawing.Point(3, 3);
            this.radioButtonSH.Name = "radioButtonSH";
            this.radioButtonSH.Size = new System.Drawing.Size(124, 17);
            this.radioButtonSH.TabIndex = 51;
            this.radioButtonSH.TabStop = true;
            this.radioButtonSH.Text = "Self-Healing Scenaio";
            this.radioButtonSH.UseVisualStyleBackColor = true;
            // 
            // radioButtonSO
            // 
            this.radioButtonSO.AutoSize = true;
            this.radioButtonSO.Location = new System.Drawing.Point(3, 26);
            this.radioButtonSO.Name = "radioButtonSO";
            this.radioButtonSO.Size = new System.Drawing.Size(139, 17);
            this.radioButtonSO.TabIndex = 52;
            this.radioButtonSO.TabStop = true;
            this.radioButtonSO.Text = "Self-Optimizing Scenario";
            this.radioButtonSO.UseVisualStyleBackColor = true;
            // 
            // radioButtonSP
            // 
            this.radioButtonSP.AutoSize = true;
            this.radioButtonSP.Location = new System.Drawing.Point(3, 49);
            this.radioButtonSP.Name = "radioButtonSP";
            this.radioButtonSP.Size = new System.Drawing.Size(139, 17);
            this.radioButtonSP.TabIndex = 53;
            this.radioButtonSP.TabStop = true;
            this.radioButtonSP.Text = "Self-Protecting Scenario";
            this.radioButtonSP.UseVisualStyleBackColor = true;
            // 
            // radioButtonSC
            // 
            this.radioButtonSC.AutoSize = true;
            this.radioButtonSC.Location = new System.Drawing.Point(3, 72);
            this.radioButtonSC.Name = "radioButtonSC";
            this.radioButtonSC.Size = new System.Drawing.Size(144, 17);
            this.radioButtonSC.TabIndex = 54;
            this.radioButtonSC.TabStop = true;
            this.radioButtonSC.Text = "Self-Configuring Scenario";
            this.radioButtonSC.UseVisualStyleBackColor = true;
            // 
            // checkBoxOurs
            // 
            this.checkBoxOurs.AutoSize = true;
            this.checkBoxOurs.Location = new System.Drawing.Point(3, 339);
            this.checkBoxOurs.Name = "checkBoxOurs";
            this.checkBoxOurs.Size = new System.Drawing.Size(79, 17);
            this.checkBoxOurs.TabIndex = 56;
            this.checkBoxOurs.Text = "OurMethod";
            this.checkBoxOurs.UseVisualStyleBackColor = true;
            this.checkBoxOurs.CheckedChanged += new System.EventHandler(this.CheckBoxOursCheckedChanged);
            // 
            // lblAdapting
            // 
            this.lblAdapting.AutoSize = true;
            this.lblAdapting.BackColor = System.Drawing.Color.Transparent;
            this.lblAdapting.ForeColor = System.Drawing.Color.Black;
            this.lblAdapting.Location = new System.Drawing.Point(0, 262);
            this.lblAdapting.Margin = new System.Windows.Forms.Padding(0);
            this.lblAdapting.Name = "lblAdapting";
            this.lblAdapting.Size = new System.Drawing.Size(80, 17);
            this.lblAdapting.TabIndex = 57;
            this.lblAdapting.Text = "Adapting time: ";
            this.lblAdapting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAdapting.UseCompatibleTextRendering = true;
            // 
            // lblOptimizing
            // 
            this.lblOptimizing.AutoSize = true;
            this.lblOptimizing.BackColor = System.Drawing.Color.Transparent;
            this.lblOptimizing.ForeColor = System.Drawing.Color.Black;
            this.lblOptimizing.Location = new System.Drawing.Point(0, 279);
            this.lblOptimizing.Margin = new System.Windows.Forms.Padding(0);
            this.lblOptimizing.Name = "lblOptimizing";
            this.lblOptimizing.Size = new System.Drawing.Size(87, 17);
            this.lblOptimizing.TabIndex = 58;
            this.lblOptimizing.Text = "Message count: ";
            this.lblOptimizing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOptimizing.UseCompatibleTextRendering = true;
            // 
            // labelAdapting
            // 
            this.labelAdapting.AutoSize = true;
            this.labelAdapting.BackColor = System.Drawing.Color.Transparent;
            this.labelAdapting.ForeColor = System.Drawing.Color.Black;
            this.labelAdapting.Location = new System.Drawing.Point(155, 262);
            this.labelAdapting.Margin = new System.Windows.Forms.Padding(0);
            this.labelAdapting.Name = "labelAdapting";
            this.labelAdapting.Size = new System.Drawing.Size(29, 17);
            this.labelAdapting.TabIndex = 59;
            this.labelAdapting.Text = "0000";
            this.labelAdapting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelAdapting.UseCompatibleTextRendering = true;
            // 
            // lableOptimizing
            // 
            this.lableOptimizing.AutoSize = true;
            this.lableOptimizing.BackColor = System.Drawing.Color.Transparent;
            this.lableOptimizing.ForeColor = System.Drawing.Color.Black;
            this.lableOptimizing.Location = new System.Drawing.Point(155, 279);
            this.lableOptimizing.Margin = new System.Windows.Forms.Padding(0);
            this.lableOptimizing.Name = "lableOptimizing";
            this.lableOptimizing.Size = new System.Drawing.Size(29, 17);
            this.lableOptimizing.TabIndex = 60;
            this.lableOptimizing.Text = "0000";
            this.lableOptimizing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lableOptimizing.UseCompatibleTextRendering = true;
            // 
            // checkBoxMultiOff
            // 
            this.checkBoxMultiOff.AutoSize = true;
            this.checkBoxMultiOff.Location = new System.Drawing.Point(3, 316);
            this.checkBoxMultiOff.Name = "checkBoxMultiOff";
            this.checkBoxMultiOff.Size = new System.Drawing.Size(61, 17);
            this.checkBoxMultiOff.TabIndex = 61;
            this.checkBoxMultiOff.Text = "multiOff";
            this.checkBoxMultiOff.UseVisualStyleBackColor = true;
            this.checkBoxMultiOff.CheckedChanged += new System.EventHandler(this.CheckBoxMultiOffCheckedChanged);
            // 
            // panelSetting
            // 
            this.panelSetting.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelSetting.Controls.Add(this.tableLayoutPanel1);
            this.panelSetting.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSetting.Location = new System.Drawing.Point(0, 0);
            this.panelSetting.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(284, 511);
            this.panelSetting.TabIndex = 62;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.radioButtonSH, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonSO, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonSP, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonSC, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 23);
            this.tableLayoutPanel1.Controls.Add(this.lblAdapting, 0, 16);
            this.tableLayoutPanel1.Controls.Add(this.labelAdapting, 1, 16);
            this.tableLayoutPanel1.Controls.Add(this.lblOptimizing, 0, 17);
            this.tableLayoutPanel1.Controls.Add(this.lableOptimizing, 1, 17);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 18);
            this.tableLayoutPanel1.Controls.Add(this.lblSize, 1, 18);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxMultiOff, 0, 19);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxOurs, 0, 20);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.numNormalRadioRange, 1, 15);
            this.tableLayoutPanel1.Controls.Add(this.numMessengersRadioRange, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.numWorkersCount, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.numTeamsCount, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.numRulersCount, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.numMessengersCount, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 24;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 511);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 296);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 62;
            this.label1.Text = "Environment size:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.BackColor = System.Drawing.Color.Transparent;
            this.lblSize.ForeColor = System.Drawing.Color.Black;
            this.lblSize.Location = new System.Drawing.Point(155, 296);
            this.lblSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(29, 17);
            this.lblSize.TabIndex = 67;
            this.lblSize.Text = "0000";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSize.UseCompatibleTextRendering = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(0, 238);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 17);
            this.label7.TabIndex = 68;
            this.label7.Text = "Normal radio range:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.UseCompatibleTextRendering = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(0, 214);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 17);
            this.label6.TabIndex = 68;
            this.label6.Text = "Messengers radio range:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(0, 190);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
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
            this.label4.Location = new System.Drawing.Point(0, 166);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
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
            this.label3.Size = new System.Drawing.Size(71, 17);
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
            this.label2.Location = new System.Drawing.Point(0, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 63;
            this.label2.Text = "Messengers count:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.UseCompatibleTextRendering = true;
            // 
            // numNormalRadioRange
            // 
            this.numNormalRadioRange.Location = new System.Drawing.Point(157, 240);
            this.numNormalRadioRange.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numNormalRadioRange.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numNormalRadioRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNormalRadioRange.Name = "numNormalRadioRange";
            this.numNormalRadioRange.Size = new System.Drawing.Size(59, 20);
            this.numNormalRadioRange.TabIndex = 70;
            this.numNormalRadioRange.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // numMessengersRadioRange
            // 
            this.numMessengersRadioRange.Location = new System.Drawing.Point(157, 216);
            this.numMessengersRadioRange.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numMessengersRadioRange.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMessengersRadioRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMessengersRadioRange.Name = "numMessengersRadioRange";
            this.numMessengersRadioRange.Size = new System.Drawing.Size(59, 20);
            this.numMessengersRadioRange.TabIndex = 70;
            this.numMessengersRadioRange.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numWorkersCount
            // 
            this.numWorkersCount.Location = new System.Drawing.Point(157, 192);
            this.numWorkersCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numWorkersCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numWorkersCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWorkersCount.Name = "numWorkersCount";
            this.numWorkersCount.Size = new System.Drawing.Size(59, 20);
            this.numWorkersCount.TabIndex = 70;
            this.numWorkersCount.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numTeamsCount
            // 
            this.numTeamsCount.Location = new System.Drawing.Point(157, 168);
            this.numTeamsCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numTeamsCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTeamsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTeamsCount.Name = "numTeamsCount";
            this.numTeamsCount.Size = new System.Drawing.Size(59, 20);
            this.numTeamsCount.TabIndex = 70;
            this.numTeamsCount.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numRulersCount
            // 
            this.numRulersCount.Location = new System.Drawing.Point(157, 144);
            this.numRulersCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numRulersCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRulersCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRulersCount.Name = "numRulersCount";
            this.numRulersCount.Size = new System.Drawing.Size(59, 20);
            this.numRulersCount.TabIndex = 70;
            this.numRulersCount.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // numMessengersCount
            // 
            this.numMessengersCount.Location = new System.Drawing.Point(157, 120);
            this.numMessengersCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numMessengersCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMessengersCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMessengersCount.Name = "numMessengersCount";
            this.numMessengersCount.Size = new System.Drawing.Size(59, 20);
            this.numMessengersCount.TabIndex = 70;
            this.numMessengersCount.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.numWidth, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.numHeight, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(157, 94);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(121, 21);
            this.tableLayoutPanel2.TabIndex = 73;
            // 
            // numWidth
            // 
            this.numWidth.Location = new System.Drawing.Point(2, 2);
            this.numWidth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(44, 20);
            this.numWidth.TabIndex = 71;
            this.numWidth.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            // 
            // numHeight
            // 
            this.numHeight.Location = new System.Drawing.Point(71, 2);
            this.numHeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(44, 20);
            this.numHeight.TabIndex = 72;
            this.numHeight.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoEllipsis = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(48, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 23);
            this.label9.TabIndex = 63;
            this.label9.Text = "×";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label9.UseCompatibleTextRendering = true;
            // 
            // label8
            // 
            this.label8.AutoEllipsis = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(0, 92);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 26);
            this.label8.TabIndex = 63;
            this.label8.Text = "Environment Size: W× H";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.UseCompatibleTextRendering = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(884, 511);
            this.Controls.Add(this.panelSetting);
            this.Controls.Add(this.guiOpenGLFrame);
            this.Name = "MainForm";
            this.Text = "NASA ANTS Simulation";
            this.panelSetting.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNormalRadioRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMessengersRadioRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkersCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTeamsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRulersCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMessengersCount)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl guiOpenGLFrame;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButtonSH;
        private System.Windows.Forms.RadioButton radioButtonSO;
        private System.Windows.Forms.RadioButton radioButtonSP;
        private System.Windows.Forms.RadioButton radioButtonSC;
        private System.Windows.Forms.CheckBox checkBoxOurs;
        private System.Windows.Forms.Label lblAdapting;
        private System.Windows.Forms.Label lblOptimizing;
        public System.Windows.Forms.Label labelAdapting;
        public System.Windows.Forms.Label lableOptimizing;
        private System.Windows.Forms.CheckBox checkBoxMultiOff;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numMessengersCount;
        private System.Windows.Forms.NumericUpDown numRulersCount;
        private System.Windows.Forms.NumericUpDown numTeamsCount;
        private System.Windows.Forms.NumericUpDown numWorkersCount;
        private System.Windows.Forms.NumericUpDown numMessengersRadioRange;
        private System.Windows.Forms.NumericUpDown numNormalRadioRange;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.Label label9;
    }
}