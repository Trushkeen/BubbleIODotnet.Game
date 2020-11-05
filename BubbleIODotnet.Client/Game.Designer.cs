namespace BubbleIODotnet.Client
{
    partial class Game
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblKeyPressed = new System.Windows.Forms.Label();
            this.lblPlayerPosition = new System.Windows.Forms.Label();
            this.field = new System.Windows.Forms.Panel();
            this.lblPlayerSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblKeyPressed
            // 
            this.lblKeyPressed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyPressed.Location = new System.Drawing.Point(12, 659);
            this.lblKeyPressed.Name = "lblKeyPressed";
            this.lblKeyPressed.Size = new System.Drawing.Size(530, 13);
            this.lblKeyPressed.TabIndex = 0;
            this.lblKeyPressed.Text = "Key";
            // 
            // lblPlayerPosition
            // 
            this.lblPlayerPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlayerPosition.Location = new System.Drawing.Point(84, 659);
            this.lblPlayerPosition.Name = "lblPlayerPosition";
            this.lblPlayerPosition.Size = new System.Drawing.Size(117, 13);
            this.lblPlayerPosition.TabIndex = 1;
            this.lblPlayerPosition.Text = "Player Pos";
            // 
            // field
            // 
            this.field.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.field.Location = new System.Drawing.Point(12, 12);
            this.field.Name = "field";
            this.field.Size = new System.Drawing.Size(1240, 644);
            this.field.TabIndex = 2;
            // 
            // lblPlayerSize
            // 
            this.lblPlayerSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlayerSize.Location = new System.Drawing.Point(207, 659);
            this.lblPlayerSize.Name = "lblPlayerSize";
            this.lblPlayerSize.Size = new System.Drawing.Size(117, 13);
            this.lblPlayerSize.TabIndex = 1;
            this.lblPlayerSize.Text = "Size";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.field);
            this.Controls.Add(this.lblPlayerSize);
            this.Controls.Add(this.lblPlayerPosition);
            this.Controls.Add(this.lblKeyPressed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblKeyPressed;
        private System.Windows.Forms.Label lblPlayerPosition;
        private System.Windows.Forms.Panel field;
        private System.Windows.Forms.Label lblPlayerSize;
    }
}

