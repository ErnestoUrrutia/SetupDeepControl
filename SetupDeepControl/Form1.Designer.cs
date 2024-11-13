namespace SetupDeepControl
{
    partial class SetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            txtIPserver = new TextBox();
            txtPuerto = new TextBox();
            txtOrganizacion = new TextBox();
            txtNombrePC = new TextBox();
            txtGrupo = new TextBox();
            txtInventario = new TextBox();
            panel1 = new Panel();
            progressBar1 = new ProgressBar();
            pictureBox1 = new PictureBox();
            infoOrganizacion = new Label();
            infoServer = new Label();
            infoPuerto = new Label();
            infoPC = new Label();
            infoGrupo = new Label();
            infoInventario = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            groupBox5 = new GroupBox();
            groupBox6 = new GroupBox();
            btnDesinstalar = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.MenuHighlight;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(388, 332);
            button1.Name = "button1";
            button1.Size = new Size(220, 36);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.ButtonFace;
            richTextBox1.Font = new Font("Arial Narrow", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.Location = new Point(8, 305);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.Size = new Size(302, 46);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // txtIPserver
            // 
            txtIPserver.Location = new Point(7, 21);
            txtIPserver.Name = "txtIPserver";
            txtIPserver.Size = new Size(143, 26);
            txtIPserver.TabIndex = 4;
            // 
            // txtPuerto
            // 
            txtPuerto.Location = new Point(7, 20);
            txtPuerto.Name = "txtPuerto";
            txtPuerto.Size = new Size(42, 26);
            txtPuerto.TabIndex = 5;
            txtPuerto.Text = "47373";
            txtPuerto.TextAlign = HorizontalAlignment.Right;
            // 
            // txtOrganizacion
            // 
            txtOrganizacion.Location = new Point(6, 21);
            txtOrganizacion.Name = "txtOrganizacion";
            txtOrganizacion.Size = new Size(233, 26);
            txtOrganizacion.TabIndex = 6;
            // 
            // txtNombrePC
            // 
            txtNombrePC.Location = new Point(7, 22);
            txtNombrePC.Name = "txtNombrePC";
            txtNombrePC.Size = new Size(88, 26);
            txtNombrePC.TabIndex = 7;
            // 
            // txtGrupo
            // 
            txtGrupo.Location = new Point(7, 22);
            txtGrupo.Name = "txtGrupo";
            txtGrupo.Size = new Size(100, 26);
            txtGrupo.TabIndex = 8;
            // 
            // txtInventario
            // 
            txtInventario.Location = new Point(8, 22);
            txtInventario.Name = "txtInventario";
            txtInventario.Size = new Size(100, 26);
            txtInventario.TabIndex = 14;
            txtInventario.Text = "N/A";
            // 
            // panel1
            // 
            panel1.Controls.Add(progressBar1);
            panel1.Controls.Add(richTextBox1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(323, 373);
            panel1.TabIndex = 17;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(8, 358);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(302, 10);
            progressBar1.TabIndex = 20;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(323, 373);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // infoOrganizacion
            // 
            infoOrganizacion.AutoSize = true;
            infoOrganizacion.BackColor = SystemColors.Control;
            infoOrganizacion.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            infoOrganizacion.Location = new Point(243, 21);
            infoOrganizacion.Name = "infoOrganizacion";
            infoOrganizacion.Size = new Size(20, 23);
            infoOrganizacion.TabIndex = 25;
            infoOrganizacion.Text = "?";
            // 
            // infoServer
            // 
            infoServer.AutoSize = true;
            infoServer.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            infoServer.Location = new Point(153, 22);
            infoServer.Name = "infoServer";
            infoServer.Size = new Size(20, 23);
            infoServer.TabIndex = 26;
            infoServer.Text = "?";
            // 
            // infoPuerto
            // 
            infoPuerto.AutoSize = true;
            infoPuerto.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            infoPuerto.Location = new Point(53, 21);
            infoPuerto.Name = "infoPuerto";
            infoPuerto.Size = new Size(20, 23);
            infoPuerto.TabIndex = 27;
            infoPuerto.Text = "?";
            // 
            // infoPC
            // 
            infoPC.AutoSize = true;
            infoPC.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            infoPC.Location = new Point(99, 22);
            infoPC.Name = "infoPC";
            infoPC.Size = new Size(20, 23);
            infoPC.TabIndex = 28;
            infoPC.Text = "?";
            // 
            // infoGrupo
            // 
            infoGrupo.AutoSize = true;
            infoGrupo.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            infoGrupo.Location = new Point(108, 22);
            infoGrupo.Name = "infoGrupo";
            infoGrupo.Size = new Size(20, 23);
            infoGrupo.TabIndex = 29;
            infoGrupo.Text = "?";
            // 
            // infoInventario
            // 
            infoInventario.AutoSize = true;
            infoInventario.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            infoInventario.Location = new Point(109, 21);
            infoInventario.Name = "infoInventario";
            infoInventario.Size = new Size(20, 23);
            infoInventario.TabIndex = 30;
            infoInventario.Text = "?";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtOrganizacion);
            groupBox1.Controls.Add(infoOrganizacion);
            groupBox1.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(340, 74);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(266, 55);
            groupBox1.TabIndex = 31;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nombre de la organización";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtIPserver);
            groupBox2.Controls.Add(infoServer);
            groupBox2.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(339, 139);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(179, 55);
            groupBox2.TabIndex = 32;
            groupBox2.TabStop = false;
            groupBox2.Text = "IP del servidor";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtPuerto);
            groupBox3.Controls.Add(infoPuerto);
            groupBox3.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(524, 139);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(82, 55);
            groupBox3.TabIndex = 33;
            groupBox3.TabStop = false;
            groupBox3.Text = "Puerto";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtNombrePC);
            groupBox4.Controls.Add(infoPC);
            groupBox4.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox4.Location = new Point(339, 204);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(129, 55);
            groupBox4.TabIndex = 34;
            groupBox4.TabStop = false;
            groupBox4.Text = "Nombre PC";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(txtGrupo);
            groupBox5.Controls.Add(infoGrupo);
            groupBox5.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox5.Location = new Point(474, 204);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(133, 55);
            groupBox5.TabIndex = 34;
            groupBox5.TabStop = false;
            groupBox5.Text = "Grupo de trabajo";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(txtInventario);
            groupBox6.Controls.Add(infoInventario);
            groupBox6.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox6.Location = new Point(339, 268);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(268, 55);
            groupBox6.TabIndex = 34;
            groupBox6.TabStop = false;
            groupBox6.Text = "Inventario";
            // 
            // btnDesinstalar
            // 
            btnDesinstalar.BackgroundImage = (Image)resources.GetObject("btnDesinstalar.BackgroundImage");
            btnDesinstalar.BackgroundImageLayout = ImageLayout.Stretch;
            btnDesinstalar.Location = new Point(339, 332);
            btnDesinstalar.Name = "btnDesinstalar";
            btnDesinstalar.Size = new Size(36, 36);
            btnDesinstalar.TabIndex = 35;
            btnDesinstalar.UseVisualStyleBackColor = true;
            btnDesinstalar.Click += btnDesinstalar_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Arial Narrow", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(339, 5);
            label1.Name = "label1";
            label1.Size = new Size(269, 66);
            label1.TabIndex = 36;
            label1.Text = "Instalador de semilla DeepControl";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SetupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(618, 373);
            Controls.Add(label1);
            Controls.Add(btnDesinstalar);
            Controls.Add(groupBox4);
            Controls.Add(groupBox5);
            Controls.Add(groupBox6);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SetupForm";
            Text = "Instalador Semilla DeepControl";

            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private RichTextBox richTextBox1;
        private TextBox txtIPserver;
        private TextBox txtPuerto;
        private TextBox txtOrganizacion;
        private TextBox txtNombrePC;
        private TextBox txtGrupo;
        private TextBox txtInventario;
        private Panel panel1;
        private Label label9;
        private ProgressBar progressBar1;
        private Label infoOrganizacion;
        private Label infoServer;
        private Label infoPuerto;
        private Label infoPC;
        private Label infoGrupo;
        private Label infoInventario;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private Button btnDesinstalar;
        private PictureBox pictureBox1;
        private Label label1;
    }
}
