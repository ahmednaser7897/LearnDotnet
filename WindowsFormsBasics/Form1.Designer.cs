namespace WindowsFormsBasics
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
            play = new Button();
            domainUpDown1 = new DomainUpDown();
            SuspendLayout();
            // 
            // play
            // 
            play.Location = new Point(458, 159);
            play.Name = "play";
            play.RightToLeft = RightToLeft.Yes;
            play.Size = new Size(94, 29);
            play.TabIndex = 0;
            play.Text = "play";
            play.UseVisualStyleBackColor = true;
            play.Click += button1_Click;
            // 
            // domainUpDown1
            // 
            domainUpDown1.Location = new Point(254, 237);
            domainUpDown1.Name = "domainUpDown1";
            domainUpDown1.Size = new Size(150, 27);
            domainUpDown1.TabIndex = 1;
            domainUpDown1.Text = "domainUpDown1";
            domainUpDown1.SelectedItemChanged += domainUpDown1_SelectedItemChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(domainUpDown1);
            Controls.Add(play);
            Cursor = Cursors.PanSW;
            Name = "Form1";
            Text = "Hellow Windows First";
            ResumeLayout(false);
        }

        #endregion

        private Button play;
        private DomainUpDown domainUpDown1;
    }
}
