namespace Othello
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpBoard = new System.Windows.Forms.GroupBox();
            this.grpHistory = new System.Windows.Forms.GroupBox();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.lblWinLose = new System.Windows.Forms.Label();
            this.grpHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoard
            // 
            this.grpBoard.Location = new System.Drawing.Point(20, 20);
            this.grpBoard.Name = "grpBoard";
            this.grpBoard.Size = new System.Drawing.Size(550, 550);
            this.grpBoard.TabIndex = 0;
            this.grpBoard.TabStop = false;
            this.grpBoard.Text = "Board";
            // 
            // grpHistory
            // 
            this.grpHistory.Controls.Add(this.lstHistory);
            this.grpHistory.Location = new System.Drawing.Point(582, 20);
            this.grpHistory.Name = "grpHistory";
            this.grpHistory.Size = new System.Drawing.Size(293, 550);
            this.grpHistory.TabIndex = 1;
            this.grpHistory.TabStop = false;
            this.grpHistory.Text = "History";
            // 
            // lstHistory
            // 
            this.lstHistory.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.ItemHeight = 28;
            this.lstHistory.Location = new System.Drawing.Point(20, 32);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(255, 480);
            this.lstHistory.TabIndex = 0;
            this.lstHistory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstHistory_MouseDoubleClick);
            // 
            // lblWinLose
            // 
            this.lblWinLose.AutoSize = true;
            this.lblWinLose.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWinLose.Location = new System.Drawing.Point(20, 582);
            this.lblWinLose.Name = "lblWinLose";
            this.lblWinLose.Size = new System.Drawing.Size(112, 25);
            this.lblWinLose.TabIndex = 2;
            this.lblWinLose.Text = "lblWinLose";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 625);
            this.Controls.Add(this.lblWinLose);
            this.Controls.Add(this.grpHistory);
            this.Controls.Add(this.grpBoard);
            this.Name = "Form1";
            this.Text = "Othello";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpHistory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox grpBoard;
        private GroupBox grpHistory;
        private ListBox lstHistory;
        private Label lblWinLose;
    }
}