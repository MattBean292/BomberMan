namespace BomberMan
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
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.player1pointLabel = new System.Windows.Forms.Label();
            this.player2pointLabel = new System.Windows.Forms.Label();
            this.victoryLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.arcadeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // player1pointLabel
            // 
            this.player1pointLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.player1pointLabel.Location = new System.Drawing.Point(12, 9);
            this.player1pointLabel.Name = "player1pointLabel";
            this.player1pointLabel.Size = new System.Drawing.Size(35, 13);
            this.player1pointLabel.TabIndex = 0;
            this.player1pointLabel.Text = "0";
            // 
            // player2pointLabel
            // 
            this.player2pointLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.player2pointLabel.Location = new System.Drawing.Point(503, 9);
            this.player2pointLabel.Name = "player2pointLabel";
            this.player2pointLabel.Size = new System.Drawing.Size(35, 13);
            this.player2pointLabel.TabIndex = 1;
            this.player2pointLabel.Text = "0";
            // 
            // victoryLabel
            // 
            this.victoryLabel.BackColor = System.Drawing.Color.Transparent;
            this.victoryLabel.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.victoryLabel.Location = new System.Drawing.Point(168, 220);
            this.victoryLabel.Name = "victoryLabel";
            this.victoryLabel.Size = new System.Drawing.Size(214, 23);
            this.victoryLabel.TabIndex = 2;
            this.victoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exitButton
            // 
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(232, 387);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(93, 37);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // startButton
            // 
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.startButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(99, 328);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(93, 37);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Vs Mode";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // arcadeButton
            // 
            this.arcadeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.arcadeButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arcadeButton.Location = new System.Drawing.Point(352, 328);
            this.arcadeButton.Name = "arcadeButton";
            this.arcadeButton.Size = new System.Drawing.Size(119, 37);
            this.arcadeButton.TabIndex = 5;
            this.arcadeButton.Text = "Arcade Mode";
            this.arcadeButton.UseVisualStyleBackColor = true;
            this.arcadeButton.Click += new System.EventHandler(this.arcadeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(550, 550);
            this.Controls.Add(this.arcadeButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.victoryLabel);
            this.Controls.Add(this.player2pointLabel);
            this.Controls.Add(this.player1pointLabel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label player1pointLabel;
        private System.Windows.Forms.Label player2pointLabel;
        private System.Windows.Forms.Label victoryLabel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button arcadeButton;
    }
}

