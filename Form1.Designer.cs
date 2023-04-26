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
            this.lvAI = new System.Windows.Forms.ListView();
            this.chPos = new System.Windows.Forms.ColumnHeader();
            this.chRate = new System.Windows.Forms.ColumnHeader();
            this.lblCalcTime = new System.Windows.Forms.Label();
            this.hScrollBarAITime = new System.Windows.Forms.HScrollBar();
            this.lblAITime = new System.Windows.Forms.Label();
            this.prgAI = new System.Windows.Forms.ProgressBar();
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
            this.grpHistory.Location = new System.Drawing.Point(872, 20);
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
            // lvAI
            // 
            this.lvAI.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPos,
            this.chRate});
            this.lvAI.FullRowSelect = true;
            this.lvAI.Location = new System.Drawing.Point(584, 29);
            this.lvAI.Name = "lvAI";
            this.lvAI.Size = new System.Drawing.Size(277, 542);
            this.lvAI.TabIndex = 3;
            this.lvAI.UseCompatibleStateImageBehavior = false;
            this.lvAI.View = System.Windows.Forms.View.Details;
            // 
            // chPos
            // 
            this.chPos.Text = "Position";
            this.chPos.Width = 100;
            // 
            // chRate
            // 
            this.chRate.Text = "Win%";
            this.chRate.Width = 100;
            // 
            // lblCalcTime
            // 
            this.lblCalcTime.AutoSize = true;
            this.lblCalcTime.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCalcTime.Location = new System.Drawing.Point(584, 582);
            this.lblCalcTime.Name = "lblCalcTime";
            this.lblCalcTime.Size = new System.Drawing.Size(120, 25);
            this.lblCalcTime.TabIndex = 4;
            this.lblCalcTime.Text = "AI Time (s): ";
            // 
            // hScrollBarAITime
            // 
            this.hScrollBarAITime.Location = new System.Drawing.Point(810, 580);
            this.hScrollBarAITime.Name = "hScrollBarAITime";
            this.hScrollBarAITime.Size = new System.Drawing.Size(203, 31);
            this.hScrollBarAITime.TabIndex = 5;
            this.hScrollBarAITime.Value = 10;
            this.hScrollBarAITime.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarComputeTime_Scroll);
            // 
            // lblAITime
            // 
            this.lblAITime.AutoSize = true;
            this.lblAITime.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAITime.Location = new System.Drawing.Point(700, 582);
            this.lblAITime.Name = "lblAITime";
            this.lblAITime.Size = new System.Drawing.Size(98, 25);
            this.lblAITime.TabIndex = 6;
            this.lblAITime.Text = "lblAITime";
            // 
            // prgAI
            // 
            this.prgAI.Location = new System.Drawing.Point(1034, 580);
            this.prgAI.Name = "prgAI";
            this.prgAI.Size = new System.Drawing.Size(131, 31);
            this.prgAI.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 625);
            this.Controls.Add(this.prgAI);
            this.Controls.Add(this.lblAITime);
            this.Controls.Add(this.hScrollBarAITime);
            this.Controls.Add(this.lblCalcTime);
            this.Controls.Add(this.lvAI);
            this.Controls.Add(this.lblWinLose);
            this.Controls.Add(this.grpHistory);
            this.Controls.Add(this.grpBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private ListView lvAI;
        private ColumnHeader chPos;
        private ColumnHeader chRate;
        private Label lblCalcTime;
        private HScrollBar hScrollBarAITime;
        private Label lblAITime;
        private ProgressBar prgAI;
    }
}