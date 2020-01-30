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
            this.button1 = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
            this.guiOpenGLFrame.Location = new System.Drawing.Point(362, 0);
            this.guiOpenGLFrame.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.guiOpenGLFrame.Name = "guiOpenGLFrame";
            this.guiOpenGLFrame.Size = new System.Drawing.Size(742, 639);
            this.guiOpenGLFrame.TabIndex = 0;
            this.guiOpenGLFrame.VSync = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.button1.Location = new System.Drawing.Point(4, 573);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 62);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.BtnStartClick);
            // 
            // radioButtonSH
            // 
            this.radioButtonSH.AutoSize = true;
            this.radioButtonSH.Location = new System.Drawing.Point(4, 4);
            this.radioButtonSH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.radioButtonSO.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.radioButtonSP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.radioButtonSC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.checkBoxOurs.Location = new System.Drawing.Point(4, 377);
            this.checkBoxOurs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxOurs.Name = "checkBoxOurs";
            this.checkBoxOurs.Size = new System.Drawing.Size(101, 21);
            this.checkBoxOurs.TabIndex = 56;
            this.checkBoxOurs.Text = "OurMethod";
            this.checkBoxOurs.UseVisualStyleBackColor = true;
            this.checkBoxOurs.CheckedChanged += new System.EventHandler(this.CheckBoxOursCheckedChanged);
            // 
            // lblAdaptingText
            // 
            this.lblAdaptingText.AutoSize = true;
            this.lblAdaptingText.BackColor = System.Drawing.Color.Transparent;
            this.lblAdaptingText.ForeColor = System.Drawing.Color.Black;
            this.lblAdaptingText.Location = new System.Drawing.Point(0, 304);
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
            this.lblOptimizingText.Location = new System.Drawing.Point(0, 324);
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
            this.lblAdapting.Location = new System.Drawing.Point(198, 304);
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
            this.lblOptimizing.Location = new System.Drawing.Point(198, 324);
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
            this.checkBoxMultiOff.Location = new System.Drawing.Point(4, 348);
            this.checkBoxMultiOff.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxMultiOff.Name = "checkBoxMultiOff";
            this.checkBoxMultiOff.Size = new System.Drawing.Size(78, 21);
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
            this.panelSetting.Margin = new System.Windows.Forms.Padding(2);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(355, 639);
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
            this.tableLayoutPanel1.Controls.Add(this.lblAdaptingText, 0, 16);
            this.tableLayoutPanel1.Controls.Add(this.lblAdapting, 1, 16);
            this.tableLayoutPanel1.Controls.Add(this.lblOptimizingText, 0, 17);
            this.tableLayoutPanel1.Controls.Add(this.lblOptimizing, 1, 17);
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
            this.tableLayoutPanel1.Controls.Add(this.checkBoxMultiOff, 0, 18);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(355, 639);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(0, 278);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 20);
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
            this.label6.Location = new System.Drawing.Point(0, 252);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 20);
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
            this.label5.Location = new System.Drawing.Point(0, 226);
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
            this.label4.Location = new System.Drawing.Point(0, 200);
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
            this.label3.Location = new System.Drawing.Point(0, 174);
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
            this.label2.Location = new System.Drawing.Point(0, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 63;
            this.label2.Text = "Messengers count:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.UseCompatibleTextRendering = true;
            // 
            // numNormalRadioRange
            // 
            this.numNormalRadioRange.Location = new System.Drawing.Point(200, 280);
            this.numNormalRadioRange.Margin = new System.Windows.Forms.Padding(2);
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
            this.numNormalRadioRange.Size = new System.Drawing.Size(74, 22);
            this.numNormalRadioRange.TabIndex = 70;
            this.numNormalRadioRange.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // numMessengersRadioRange
            // 
            this.numMessengersRadioRange.Location = new System.Drawing.Point(200, 254);
            this.numMessengersRadioRange.Margin = new System.Windows.Forms.Padding(2);
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
            this.numMessengersRadioRange.Size = new System.Drawing.Size(74, 22);
            this.numMessengersRadioRange.TabIndex = 70;
            this.numMessengersRadioRange.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numWorkersCount
            // 
            this.numWorkersCount.Location = new System.Drawing.Point(200, 228);
            this.numWorkersCount.Margin = new System.Windows.Forms.Padding(2);
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
            this.numTeamsCount.Location = new System.Drawing.Point(200, 202);
            this.numTeamsCount.Margin = new System.Windows.Forms.Padding(2);
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
            this.numRulersCount.Location = new System.Drawing.Point(200, 176);
            this.numRulersCount.Margin = new System.Windows.Forms.Padding(2);
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
            this.numRulersCount.Size = new System.Drawing.Size(74, 22);
            this.numRulersCount.TabIndex = 70;
            this.numRulersCount.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // numMessengersCount
            // 
            this.numMessengersCount.Location = new System.Drawing.Point(200, 150);
            this.numMessengersCount.Margin = new System.Windows.Forms.Padding(2);
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
            this.numMessengersCount.Size = new System.Drawing.Size(74, 22);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(200, 118);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(151, 26);
            this.tableLayoutPanel2.TabIndex = 73;
            // 
            // numWidth
            // 
            this.numWidth.Location = new System.Drawing.Point(2, 2);
            this.numWidth.Margin = new System.Windows.Forms.Padding(2);
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
            this.numWidth.Size = new System.Drawing.Size(55, 22);
            this.numWidth.TabIndex = 71;
            this.numWidth.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            // 
            // numHeight
            // 
            this.numHeight.Location = new System.Drawing.Point(87, 2);
            this.numHeight.Margin = new System.Windows.Forms.Padding(2);
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
            this.numHeight.Size = new System.Drawing.Size(55, 22);
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
            this.label9.Location = new System.Drawing.Point(59, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 29);
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
            this.label8.Location = new System.Drawing.Point(0, 116);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(194, 32);
            this.label8.TabIndex = 63;
            this.label8.Text = "Environment Size: W× H";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.UseCompatibleTextRendering = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1105, 639);
            this.Controls.Add(this.panelSetting);
            this.Controls.Add(this.guiOpenGLFrame);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Label lblAdaptingText;
        private System.Windows.Forms.Label lblOptimizingText;
        public System.Windows.Forms.Label lblAdapting;
        public System.Windows.Forms.Label lblOptimizing;
        private System.Windows.Forms.CheckBox checkBoxMultiOff;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
        private System.Windows.Forms.NumericUpDown numMessengersRadioRange;
        private System.Windows.Forms.NumericUpDown numNormalRadioRange;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.Label label9;
    }
}