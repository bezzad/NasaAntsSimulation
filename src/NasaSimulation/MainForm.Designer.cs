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
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.button1.Size = new System.Drawing.Size(165, 63);
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
            this.checkBoxOurs.Location = new System.Drawing.Point(4, 189);
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
            this.lblAdapting.Location = new System.Drawing.Point(0, 116);
            this.lblAdapting.Margin = new System.Windows.Forms.Padding(0);
            this.lblAdapting.Name = "lblAdapting";
            this.lblAdapting.Size = new System.Drawing.Size(92, 20);
            this.lblAdapting.TabIndex = 57;
            this.lblAdapting.Text = "adapting time: ";
            this.lblAdapting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAdapting.UseCompatibleTextRendering = true;
            // 
            // lblOptimizing
            // 
            this.lblOptimizing.AutoSize = true;
            this.lblOptimizing.BackColor = System.Drawing.Color.Transparent;
            this.lblOptimizing.ForeColor = System.Drawing.Color.Black;
            this.lblOptimizing.Location = new System.Drawing.Point(0, 136);
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
            this.labelAdapting.Location = new System.Drawing.Point(245, 116);
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
            this.lableOptimizing.Location = new System.Drawing.Point(245, 136);
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
            this.checkBoxMultiOff.Location = new System.Drawing.Point(4, 160);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.69231F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.30769F));
            this.tableLayoutPanel1.Controls.Add(this.radioButtonSH, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxOurs, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxMultiOff, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonSO, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lableOptimizing, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonSP, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblOptimizing, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelAdapting, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonSC, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblAdapting, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
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
    }
}