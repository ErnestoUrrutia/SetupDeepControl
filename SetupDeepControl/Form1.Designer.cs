namespace SetupDeepControl
{
    partial class Form1
    {
      
        private System.ComponentModel.IContainer components = null;

       
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            txtIPserver = new TextBox();
            txtPuerto = new TextBox();
            txtOrganizacion = new TextBox();
            txtNombrePC = new TextBox();
            txtGrupo = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtInventario = new TextBox();
            label6 = new Label();
            panel1 = new Panel();
            label8 = new Label();
            label9 = new Label();
            progressBar1 = new ProgressBar();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.MenuHighlight;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(9, 440);
            button1.Name = "button1";
            button1.Size = new Size(220, 36);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.ButtonFace;
            richTextBox1.Location = new Point(531, 51);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.Size = new Size(301, 408);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // txtIPserver
            // 
            txtIPserver.Location = new Point(14, 191);
            txtIPserver.Name = "txtIPserver";
            txtIPserver.Size = new Size(141, 23);
            txtIPserver.TabIndex = 4;
            // 
            // txtPuerto
            // 
            txtPuerto.Location = new Point(14, 307);
            txtPuerto.Name = "txtPuerto";
            txtPuerto.Size = new Size(59, 23);
            txtPuerto.TabIndex = 5;
            txtPuerto.Text = "47373";
            txtPuerto.TextAlign = HorizontalAlignment.Right;
            // 
            // txtOrganizacion
            // 
            txtOrganizacion.Location = new Point(12, 75);
            txtOrganizacion.Name = "txtOrganizacion";
            txtOrganizacion.Size = new Size(217, 23);
            txtOrganizacion.TabIndex = 6;
            // 
            // txtNombrePC
            // 
            txtNombrePC.Location = new Point(293, 72);
            txtNombrePC.Name = "txtNombrePC";
            txtNombrePC.Size = new Size(100, 23);
            txtNombrePC.TabIndex = 7;
            // 
            // txtGrupo
            // 
            txtGrupo.Location = new Point(293, 186);
            txtGrupo.Name = "txtGrupo";
            txtGrupo.Size = new Size(100, 23);
            txtGrupo.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(11, 51);
            label1.Name = "label1";
            label1.Size = new Size(218, 21);
            label1.TabIndex = 9;
            label1.Text = "Nombre de la organización";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(14, 169);
            label2.Name = "label2";
            label2.Size = new Size(122, 21);
            label2.TabIndex = 10;
            label2.Text = "IP del Servidor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(14, 284);
            label3.Name = "label3";
            label3.Size = new Size(61, 21);
            label3.TabIndex = 11;
            label3.Text = "Puerto";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(293, 54);
            label4.Name = "label4";
            label4.Size = new Size(97, 21);
            label4.TabIndex = 12;
            label4.Text = "Nombre PC";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(293, 164);
            label5.Name = "label5";
            label5.Size = new Size(139, 21);
            label5.TabIndex = 13;
            label5.Text = "Grupo de trabajo";
            // 
            // txtInventario
            // 
            txtInventario.Location = new Point(293, 318);
            txtInventario.Name = "txtInventario";
            txtInventario.Size = new Size(100, 23);
            txtInventario.TabIndex = 14;
            txtInventario.Text = "N/A";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(293, 294);
            label6.Name = "label6";
            label6.Size = new Size(89, 21);
            label6.TabIndex = 15;
            label6.Text = "Inventario";
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(851, 48);
            panel1.TabIndex = 17;
            // 
            // label8
            // 
            label8.Location = new Point(11, 99);
            label8.Name = "label8";
            label8.Size = new Size(219, 71);
            label8.TabIndex = 18;
            label8.Text = "En este campo se coloca el nombre de la organización que controla las salas de computo o estaciones\nEjemplo: \"Departamento de Sistemas\"";
            // 
            // label9
            // 
            label9.Location = new Point(12, 215);
            label9.Name = "label9";
            label9.Size = new Size(219, 68);
            label9.TabIndex = 19;
            label9.Text = "En este campo se coloca la direccion IP donde se encuentra corriendo el servidor DeepControl\nEjemplo: 192.168.1.200";
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.Location = new Point(0, 482);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(851, 12);
            progressBar1.TabIndex = 20;
            // 
            // label10
            // 
            label10.Location = new Point(14, 333);
            label10.Name = "label10";
            label10.Size = new Size(257, 55);
            label10.TabIndex = 21;
            label10.Text = "En este campo se coloca el puerto de trabajo entre servidor y semilla\nSe recomienda usar el default: 47373";
            // 
            // label11
            // 
            label11.Location = new Point(291, 96);
            label11.Name = "label11";
            label11.Size = new Size(219, 71);
            label11.TabIndex = 22;
            label11.Text = "En este campo se coloca el nombre de la maquina o estación en la cual se esta instalando, de esta forma será visualizada en el servidor\nEjemplo: \"PC10\"";
            // 
            // label12
            // 
            label12.Location = new Point(292, 210);
            label12.Name = "label12";
            label12.Size = new Size(219, 81);
            label12.TabIndex = 23;
            label12.Text = "En este campo se coloca el nombre de la sala o grupo de trabajo, de esta forma será agrupado con las estaciones de su misma area \nEjemplo: \"SALA01\"";
            // 
            // label7
            // 
            label7.Location = new Point(293, 344);
            label7.Name = "label7";
            label7.Size = new Size(219, 115);
            label7.TabIndex = 24;
            label7.Text = resources.GetString("label7.Text");
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(851, 494);
            Controls.Add(label7);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(progressBar1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(txtInventario);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtGrupo);
            Controls.Add(txtNombrePC);
            Controls.Add(txtOrganizacion);
            Controls.Add(txtPuerto);
            Controls.Add(txtIPserver);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Instalador Semilla DeepControl";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private RichTextBox richTextBox1;
        private TextBox txtIPserver;
        private TextBox txtPuerto;
        private TextBox txtOrganizacion;
        private TextBox txtNombrePC;
        private TextBox txtGrupo;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtInventario;
        private Label label6;
        private Panel panel1;
        private Label label8;
        private Label label9;
        private ProgressBar progressBar1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label7;
    }
}
