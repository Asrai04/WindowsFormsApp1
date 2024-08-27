namespace WindowsFormsApp1
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
            this.Boton_Start = new System.Windows.Forms.Button();
            this.Fondo_Juego = new System.Windows.Forms.PictureBox();
            this.Timer_del_juego = new System.Windows.Forms.Timer(this.components);
            this.txtScore = new System.Windows.Forms.Label();
            this.PORCOM = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Fondo_Juego)).BeginInit();
            this.SuspendLayout();
            // 
            // Boton_Start
            // 
            this.Boton_Start.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Boton_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Boton_Start.Location = new System.Drawing.Point(1032, 12);
            this.Boton_Start.Name = "Boton_Start";
            this.Boton_Start.Size = new System.Drawing.Size(138, 55);
            this.Boton_Start.TabIndex = 0;
            this.Boton_Start.Text = "START";
            this.Boton_Start.UseVisualStyleBackColor = false;
            this.Boton_Start.Click += new System.EventHandler(this.Start_Game);
            // 
            // Fondo_Juego
            // 
            this.Fondo_Juego.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Fondo_Juego.Location = new System.Drawing.Point(21, 12);
            this.Fondo_Juego.Name = "Fondo_Juego";
            this.Fondo_Juego.Size = new System.Drawing.Size(1000, 675);
            this.Fondo_Juego.TabIndex = 1;
            this.Fondo_Juego.TabStop = false;
            this.Fondo_Juego.Paint += new System.Windows.Forms.PaintEventHandler(this.Update_Fondo);
            // 
            // Timer_del_juego
            // 
            this.Timer_del_juego.Interval = 40;
            this.Timer_del_juego.Tick += new System.EventHandler(this.Timer_Juego);
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.Location = new System.Drawing.Point(1038, 85);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(80, 20);
            this.txtScore.TabIndex = 2;
            this.txtScore.Text = "Score: 0";
            // 
            // PORCOM
            // 
            this.PORCOM.AutoSize = true;
            this.PORCOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PORCOM.Location = new System.Drawing.Point(1038, 121);
            this.PORCOM.Name = "PORCOM";
            this.PORCOM.Size = new System.Drawing.Size(114, 20);
            this.PORCOM.TabIndex = 3;
            this.PORCOM.Text = "FUEL: 100%";
            this.PORCOM.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 703);
            this.Controls.Add(this.PORCOM);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.Fondo_Juego);
            this.Controls.Add(this.Boton_Start);
            this.Name = "Form1";
            this.Text = "Tron";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDOWN);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUP);
            ((System.ComponentModel.ISupportInitialize)(this.Fondo_Juego)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Boton_Start;
        private System.Windows.Forms.PictureBox Fondo_Juego;
        private System.Windows.Forms.Timer Timer_del_juego;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label PORCOM;
    }
}

