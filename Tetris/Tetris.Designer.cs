namespace Tetris
{
    partial class Tetris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tetris));
            this.textBoxScore = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.tickTimer = new System.Windows.Forms.Timer(this.components);
            this.gameGrid = new System.Windows.Forms.Panel();
            this.textBoxRowsCompleted = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxMute = new System.Windows.Forms.CheckBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.labelGameOver = new System.Windows.Forms.Label();
            this.textBoxLevel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxHighScore = new System.Windows.Forms.TextBox();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonResume = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHowToPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAboutDev = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxScore
            // 
            this.textBoxScore.CausesValidation = false;
            this.textBoxScore.Enabled = false;
            this.textBoxScore.Location = new System.Drawing.Point(371, 319);
            this.textBoxScore.Name = "textBoxScore";
            this.textBoxScore.ReadOnly = true;
            this.textBoxScore.Size = new System.Drawing.Size(100, 20);
            this.textBoxScore.TabIndex = 1;
            this.textBoxScore.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(344, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "SCORE:";
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonStart.CausesValidation = false;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(361, 28);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.TabStop = false;
            this.buttonStart.Text = "&START";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(454, 68);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.TabStop = false;
            this.buttonSave.Text = "S&AVE";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Location = new System.Drawing.Point(361, 558);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(75, 23);
            this.buttonQuit.TabIndex = 5;
            this.buttonQuit.Text = "QUIT";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonLoad.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoad.Location = new System.Drawing.Point(454, 28);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 6;
            this.buttonLoad.TabStop = false;
            this.buttonLoad.Text = "&LOAD";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // tickTimer
            // 
            this.tickTimer.Interval = 500;
            this.tickTimer.Tick += new System.EventHandler(this.tickTimer_Tick);
            // 
            // gameGrid
            // 
            this.gameGrid.Location = new System.Drawing.Point(28, 28);
            this.gameGrid.Name = "gameGrid";
            this.gameGrid.Size = new System.Drawing.Size(310, 558);
            this.gameGrid.TabIndex = 7;
            // 
            // textBoxRowsCompleted
            // 
            this.textBoxRowsCompleted.Enabled = false;
            this.textBoxRowsCompleted.Location = new System.Drawing.Point(371, 377);
            this.textBoxRowsCompleted.Name = "textBoxRowsCompleted";
            this.textBoxRowsCompleted.ReadOnly = true;
            this.textBoxRowsCompleted.Size = new System.Drawing.Size(100, 20);
            this.textBoxRowsCompleted.TabIndex = 9;
            this.textBoxRowsCompleted.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(346, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "ROWS COMPLETED:";
            // 
            // checkBoxMute
            // 
            this.checkBoxMute.AutoSize = true;
            this.checkBoxMute.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMute.Location = new System.Drawing.Point(366, 485);
            this.checkBoxMute.Name = "checkBoxMute";
            this.checkBoxMute.Size = new System.Drawing.Size(100, 19);
            this.checkBoxMute.TabIndex = 12;
            this.checkBoxMute.TabStop = false;
            this.checkBoxMute.Text = "Mute sound";
            this.checkBoxMute.UseVisualStyleBackColor = true;
            this.checkBoxMute.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(511, 558);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(39, 46);
            this.axWindowsMediaPlayer1.TabIndex = 11;
            this.axWindowsMediaPlayer1.TabStop = false;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // labelGameOver
            // 
            this.labelGameOver.AutoSize = true;
            this.labelGameOver.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameOver.Location = new System.Drawing.Point(361, 188);
            this.labelGameOver.Name = "labelGameOver";
            this.labelGameOver.Size = new System.Drawing.Size(0, 26);
            this.labelGameOver.TabIndex = 13;
            // 
            // textBoxLevel
            // 
            this.textBoxLevel.Enabled = false;
            this.textBoxLevel.Location = new System.Drawing.Point(371, 264);
            this.textBoxLevel.Name = "textBoxLevel";
            this.textBoxLevel.ReadOnly = true;
            this.textBoxLevel.ShortcutsEnabled = false;
            this.textBoxLevel.Size = new System.Drawing.Size(100, 20);
            this.textBoxLevel.TabIndex = 14;
            this.textBoxLevel.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(344, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "LEVEL:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(346, 415);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "HIGH SCORE:";
            // 
            // textBoxHighScore
            // 
            this.textBoxHighScore.Enabled = false;
            this.textBoxHighScore.Location = new System.Drawing.Point(371, 435);
            this.textBoxHighScore.Name = "textBoxHighScore";
            this.textBoxHighScore.ReadOnly = true;
            this.textBoxHighScore.Size = new System.Drawing.Size(100, 20);
            this.textBoxHighScore.TabIndex = 17;
            this.textBoxHighScore.TabStop = false;
            // 
            // buttonPause
            // 
            this.buttonPause.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonPause.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPause.Location = new System.Drawing.Point(361, 68);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(75, 23);
            this.buttonPause.TabIndex = 18;
            this.buttonPause.Text = "&PAUSE";
            this.buttonPause.UseVisualStyleBackColor = false;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonResume
            // 
            this.buttonResume.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonResume.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResume.Location = new System.Drawing.Point(361, 109);
            this.buttonResume.Name = "buttonResume";
            this.buttonResume.Size = new System.Drawing.Size(75, 23);
            this.buttonResume.TabIndex = 19;
            this.buttonResume.Text = "&RESUME";
            this.buttonResume.UseVisualStyleBackColor = false;
            this.buttonResume.Click += new System.EventHandler(this.buttonResume_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem6});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(564, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.toolStripMenuItem1.Text = "&Game";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem2.Text = "&Start new game";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem3.Text = "S&ave game";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem4.Text = "&Load game";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem5.Text = "&Exit";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemHowToPlay,
            this.toolStripMenuItemAboutDev});
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(52, 20);
            this.toolStripMenuItem6.Text = "A&bout";
            // 
            // toolStripMenuItemHowToPlay
            // 
            this.toolStripMenuItemHowToPlay.Name = "toolStripMenuItemHowToPlay";
            this.toolStripMenuItemHowToPlay.Size = new System.Drawing.Size(183, 22);
            this.toolStripMenuItemHowToPlay.Text = "&How to play";
            this.toolStripMenuItemHowToPlay.Click += new System.EventHandler(this.toolStripMenuItemHowToPlay_Click);
            // 
            // toolStripMenuItemAboutDev
            // 
            this.toolStripMenuItemAboutDev.Name = "toolStripMenuItemAboutDev";
            this.toolStripMenuItemAboutDev.Size = new System.Drawing.Size(183, 22);
            this.toolStripMenuItemAboutDev.Text = "About the &Developer";
            this.toolStripMenuItemAboutDev.Click += new System.EventHandler(this.toolStripMenuItemAboutDev_Click);
            // 
            // Tetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(564, 614);
            this.Controls.Add(this.buttonResume);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.textBoxHighScore);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxLevel);
            this.Controls.Add(this.labelGameOver);
            this.Controls.Add(this.checkBoxMute);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxRowsCompleted);
            this.Controls.Add(this.gameGrid);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxScore);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Tetris";
            this.Text = "Tetris";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tetris_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tetris_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Tetris_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Tetris_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Timer tickTimer;
        private System.Windows.Forms.Panel gameGrid;
        private System.Windows.Forms.TextBox textBoxRowsCompleted;
        private System.Windows.Forms.Label label2;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.CheckBox checkBoxMute;
        private System.Windows.Forms.Label labelGameOver;
        private System.Windows.Forms.TextBox textBoxLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxHighScore;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonResume;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHowToPlay;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAboutDev;
    }
}

