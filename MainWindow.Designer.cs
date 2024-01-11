namespace SaperV2
{
    partial class MainWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easy10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normal40ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hard99ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetButton = new System.Windows.Forms.Button();
            this.GamePanel = new System.Windows.Forms.Panel();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.MenuStrip.Size = new System.Drawing.Size(785, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easy10ToolStripMenuItem,
            this.normal40ToolStripMenuItem,
            this.hard99ToolStripMenuItem});
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(43, 22);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // easy10ToolStripMenuItem
            // 
            this.easy10ToolStripMenuItem.Name = "easy10ToolStripMenuItem";
            this.easy10ToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.easy10ToolStripMenuItem.Text = "Easy (10)";
            this.easy10ToolStripMenuItem.Click += new System.EventHandler(this.EasyDifficulty);
            // 
            // normal40ToolStripMenuItem
            // 
            this.normal40ToolStripMenuItem.Name = "normal40ToolStripMenuItem";
            this.normal40ToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.normal40ToolStripMenuItem.Text = "Normal (40)";
            this.normal40ToolStripMenuItem.Click += new System.EventHandler(this.NormalDifficulty);
            // 
            // hard99ToolStripMenuItem
            // 
            this.hard99ToolStripMenuItem.Name = "hard99ToolStripMenuItem";
            this.hard99ToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.hard99ToolStripMenuItem.Text = "Hard (99)";
            this.hard99ToolStripMenuItem.Click += new System.EventHandler(this.HardDifficulty);
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ResetButton.Location = new System.Drawing.Point(349, 2);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(2);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(73, 20);
            this.ResetButton.TabIndex = 1;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.Reset);
            // 
            // GamePanel
            // 
            this.GamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GamePanel.Location = new System.Drawing.Point(0, 24);
            this.GamePanel.Margin = new System.Windows.Forms.Padding(2);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(785, 348);
            this.GamePanel.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 372);
            this.Controls.Add(this.GamePanel);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainWindow";
            this.Text = "Saper";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResizeEnd += new System.EventHandler(this.WindowSizeChanged);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easy10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normal40ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hard99ToolStripMenuItem;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Panel GamePanel;
    }
}

