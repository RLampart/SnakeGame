namespace SnakeGame
{
    partial class MainGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.CheckedListBox PlayMode;



        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.StartButton = new System.Windows.Forms.Button();
            this.PlayMode = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 80;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(336, 194);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "PLAY";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // PlayMode
            // 
            this.PlayMode.FormattingEnabled = true;
            this.PlayMode.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.PlayMode.Location = new System.Drawing.Point(316, 138);
            this.PlayMode.Name = "PlayMode";
            this.PlayMode.Size = new System.Drawing.Size(120, 79);
            this.PlayMode.TabIndex = 1;
            this.PlayMode.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.PlayMode_ItemCheck);
            // 
            // MainGame
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.PlayMode);
            this.Name = "MainGame";
            this.Text = "Snake Game";
            this.ResumeLayout(false);

        }
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

       
    }
}

