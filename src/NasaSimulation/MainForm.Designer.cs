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
            this.guiOpenGLFrame = new Tao.Platform.Windows.SimpleOpenGlControl();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numMessengersCount = new System.Windows.Forms.NumericUpDown();
            this.numRulersCount = new System.Windows.Forms.NumericUpDown();
            this.numTeamsCount = new System.Windows.Forms.NumericUpDown();
            this.numWorkersCount = new System.Windows.Forms.NumericUpDown();
            this.numMessengersRadioRange = new System.Windows.Forms.NumericUpDown();
            this.numNormalRadioRange = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMessengersCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRulersCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTeamsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkersCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMessengersRadioRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNormalRadioRange)).BeginInit();
            this.SuspendLayout();
            // 
            // guiOpenGLFrame
            // 
            this.guiOpenGLFrame.AccumBits = ((byte)(0));
            this.guiOpenGLFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guiOpenGLFrame.AutoCheckErrors = false;
            this.guiOpenGLFrame.AutoFinish = false;
            this.guiOpenGLFrame.AutoMakeCurrent = true;
            this.guiOpenGLFrame.AutoSwapBuffers = true;
            this.guiOpenGLFrame.BackColor = System.Drawing.Color.Black;
            this.guiOpenGLFrame.ColorBits = ((byte)(32));
            this.guiOpenGLFrame.DepthBits = ((byte)(16));
            this.guiOpenGLFrame.Location = new System.Drawing.Point(332, 0);
            this.guiOpenGLFrame.Margin = new System.Windows.Forms.Padding(4);
            this.guiOpenGLFrame.Name = "guiOpenGLFrame";
            this.guiOpenGLFrame.Size = new System.Drawing.Size(773, 639);
            this.guiOpenGLFrame.StencilBits = ((byte)(0));
            this.guiOpenGLFrame.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.button1.Location = new System.Drawing.Point(4, 572);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 63);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.BtnStartClick);
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
            this.checkBoxOurs.Location = new System.Drawing.Point(4, 377);
            this.checkBoxOurs.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxOurs.Name = "checkBoxOurs";
            this.checkBoxOurs.Size = new System.Drawing.Size(101, 21);
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
            this.lblAdapting.Location = new System.Drawing.Point(0, 284);
            this.lblAdapting.Margin = new System.Windows.Forms.Padding(0);
            this.lblAdapting.Name = "lblAdapting";
            this.lblAdapting.Size = new System.Drawing.Size(94, 20);
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
            this.lblOptimizing.Location = new System.Drawing.Point(0, 304);
            this.lblOptimizing.Margin = new System.Windows.Forms.Padding(0);
            this.lblOptimizing.Name = "lblOptimizing";
            this.lblOptimizing.Size = new System.Drawing.Size(103, 20);
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
            this.labelAdapting.Location = new System.Drawing.Point(198, 284);
            this.labelAdapting.Margin = new System.Windows.Forms.Padding(0);
            this.labelAdapting.Name = "labelAdapting";
            this.labelAdapting.Size = new System.Drawing.Size(35, 20);
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
            this.lableOptimizing.Location = new System.Drawing.Point(198, 304);
            this.lableOptimizing.Margin = new System.Windows.Forms.Padding(0);
            this.lableOptimizing.Name = "lableOptimizing";
            this.lableOptimizing.Size = new System.Drawing.Size(35, 20);
            this.lableOptimizing.TabIndex = 60;
            this.lableOptimizing.Text = "0000";
            this.lableOptimizing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lableOptimizing.UseCompatibleTextRendering = true;
            // 
            // checkBoxMultiOff
            // 
            this.checkBoxMultiOff.AutoSize = true;
            this.checkBoxMultiOff.Location = new System.Drawing.Point(4, 348);
            this.checkBoxMultiOff.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxMultiOff.Name = "checkBoxMultiOff";
            this.checkBoxMultiOff.Size = new System.Drawing.Size(78, 21);
            this.checkBoxMultiOff.TabIndex = 61;
            this.checkBoxMultiOff.Text = "multiOff";
            this.checkBoxMultiOff.UseVisualStyleBackColor = true;
            this.checkBoxMultiOff.CheckedChanged += new System.EventHandler(this.CheckBoxMultiOffCheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 639);
            this.panel1.TabIndex = 62;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.radioButtonSH, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonSO, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonSP, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonSC, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 22);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.numWorkersCount, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.numMessengersRadioRange, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.numNormalRadioRange, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.lblAdapting, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelAdapting, 1, 15);
            this.tableLayoutPanel1.Controls.Add(this.numMessengersCount, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblOptimizing, 0, 16);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lableOptimizing, 1, 16);
            this.tableLayoutPanel1.Controls.Add(this.numRulersCount, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 17);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblSize, 1, 17);
            this.tableLayoutPanel1.Controls.Add(this.numTeamsCount, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxMultiOff, 0, 18);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxOurs, 0, 19);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 23;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(325, 639);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 324);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 62;
            this.label1.Text = "Environment size:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(0, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 64;
            this.label3.Text = "Rulers count:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(0, 172);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 65;
            this.label4.Text = "Teams count:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(0, 200);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 66;
            this.label5.Text = "Workers count:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.UseCompatibleTextRendering = true;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.BackColor = System.Drawing.Color.Transparent;
            this.lblSize.ForeColor = System.Drawing.Color.Black;
            this.lblSize.Location = new System.Drawing.Point(198, 324);
            this.lblSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(35, 20);
            this.lblSize.TabIndex = 67;
            this.lblSize.Text = "0000";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSize.UseCompatibleTextRendering = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(0, 228);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 20);
            this.label6.TabIndex = 68;
            this.label6.Text = "Messengers radio range:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.UseCompatibleTextRendering = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(0, 256);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 20);
            this.label7.TabIndex = 68;
            this.label7.Text = "Normal radio range:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.UseCompatibleTextRendering = true;
            // 
            // numMessengersCount
            // 
            this.numMessengersCount.Location = new System.Drawing.Point(201, 119);
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
            this.numMessengersCount.Size = new System.Drawing.Size(120, 22);
            this.numMessengersCount.TabIndex = 70;
            this.numMessengersCount.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            // 
            // numRulersCount
            // 
            this.numRulersCount.Location = new System.Drawing.Point(201, 147);
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
            this.numRulersCount.Size = new System.Drawing.Size(120, 22);
            this.numRulersCount.TabIndex = 70;
            this.numRulersCount.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // numTeamsCount
            // 
            this.numTeamsCount.Location = new System.Drawing.Point(201, 175);
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
            this.numTeamsCount.Size = new System.Drawing.Size(120, 22);
            this.numTeamsCount.TabIndex = 70;
            this.numTeamsCount.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numWorkersCount
            // 
            this.numWorkersCount.Location = new System.Drawing.Point(201, 203);
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
            this.numWorkersCount.Size = new System.Drawing.Size(120, 22);
            this.numWorkersCount.TabIndex = 70;
            this.numWorkersCount.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numMessengersRadioRange
            // 
            this.numMessengersRadioRange.Location = new System.Drawing.Point(201, 231);
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
            this.numMessengersRadioRange.Size = new System.Drawing.Size(120, 22);
            this.numMessengersRadioRange.TabIndex = 70;
            this.numMessengersRadioRange.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numNormalRadioRange
            // 
            this.numNormalRadioRange.Location = new System.Drawing.Point(201, 259);
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
            this.numNormalRadioRange.Size = new System.Drawing.Size(120, 22);
            this.numNormalRadioRange.TabIndex = 70;
            this.numNormalRadioRange.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 639);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guiOpenGLFrame);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "NASA ANTS Simulation";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMessengersCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRulersCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTeamsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkersCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMessengersRadioRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNormalRadioRange)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl guiOpenGLFrame;
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
        private System.Windows.Forms.Panel panel1;
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
    }
}