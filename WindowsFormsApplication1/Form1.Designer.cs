namespace WindowsFormsApplication1
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
            this.stateLabel = new System.Windows.Forms.Label();
            this.dbgButt = new System.Windows.Forms.Button();
            this.dbgProcNameBox = new System.Windows.Forms.TextBox();
            this.startPauseButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Font = new System.Drawing.Font("MisterEarl BT", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stateLabel.Location = new System.Drawing.Point(277, 9);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(41, 30);
            this.stateLabel.TabIndex = 0;
            this.stateLabel.Text = "Test";
            // 
            // dbgButt
            // 
            this.dbgButt.Location = new System.Drawing.Point(205, 115);
            this.dbgButt.Name = "dbgButt";
            this.dbgButt.Size = new System.Drawing.Size(75, 23);
            this.dbgButt.TabIndex = 1;
            this.dbgButt.Text = "Debug";
            this.dbgButt.UseVisualStyleBackColor = true;
            this.dbgButt.Visible = false;
            this.dbgButt.Click += new System.EventHandler(this.button1_Click);
            // 
            // dbgProcNameBox
            // 
            this.dbgProcNameBox.Location = new System.Drawing.Point(286, 115);
            this.dbgProcNameBox.Name = "dbgProcNameBox";
            this.dbgProcNameBox.Size = new System.Drawing.Size(138, 22);
            this.dbgProcNameBox.TabIndex = 2;
            this.dbgProcNameBox.Visible = false;
            // 
            // startPauseButton
            // 
            this.startPauseButton.Location = new System.Drawing.Point(212, 43);
            this.startPauseButton.Name = "startPauseButton";
            this.startPauseButton.Size = new System.Drawing.Size(171, 38);
            this.startPauseButton.TabIndex = 3;
            this.startPauseButton.UseVisualStyleBackColor = true;
            this.startPauseButton.Click += new System.EventHandler(this.startPauseButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 91);
            this.Controls.Add(this.startPauseButton);
            this.Controls.Add(this.dbgProcNameBox);
            this.Controls.Add(this.dbgButt);
            this.Controls.Add(this.stateLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Pauser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Button dbgButt;
        private System.Windows.Forms.TextBox dbgProcNameBox;
        private System.Windows.Forms.Button startPauseButton;
        private System.Windows.Forms.Timer timer1;
    }
}

