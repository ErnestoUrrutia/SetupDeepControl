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
            btnInstalar = new Button();
            btnDesinstalar = new Button();
            richTextBox1 = new RichTextBox();
            txtIPserver = new TextBox();
            txtPuerto = new TextBox();
            txtOrganizacion = new TextBox();
            txtNombrePC = new TextBox();
            txtGrupo = new TextBox();
            txtInventario = new TextBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            progressBar1 = new ProgressBar();
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
            label1 = new Label();
            txtTerminos = new RichTextBox();
            label2 = new Label();
            chkActivar = new CheckBox();
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
            // btnInstalar
            // 
            btnInstalar.BackColor = Color.Transparent;
            btnInstalar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInstalar.Location = new Point(572, 373);
            btnInstalar.Name = "btnInstalar";
            btnInstalar.Size = new Size(200, 36);
            btnInstalar.TabIndex = 8;
            btnInstalar.Text = "Instalar";
            btnInstalar.UseVisualStyleBackColor = false;
            btnInstalar.Click += button1_Click;
            // 
            // btnDesinstalar
            // 
            btnDesinstalar.BackgroundImageLayout = ImageLayout.Stretch;
            btnDesinstalar.Font = new Font("Microsoft Sans Serif", 14.25F);
            btnDesinstalar.Location = new Point(329, 373);
            btnDesinstalar.Name = "btnDesinstalar";
            btnDesinstalar.Size = new Size(129, 36);
            btnDesinstalar.TabIndex = 9;
            btnDesinstalar.Text = "Desinstalar";
            btnDesinstalar.UseVisualStyleBackColor = true;
            btnDesinstalar.Click += btnDesinstalar_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.ButtonFace;
            richTextBox1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.Location = new Point(12, 337);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.Size = new Size(298, 72);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // txtIPserver
            // 
            txtIPserver.Location = new Point(7, 21);
            txtIPserver.Name = "txtIPserver";
            txtIPserver.Size = new Size(107, 27);
            txtIPserver.TabIndex = 1;
            // 
            // txtPuerto
            // 
            txtPuerto.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPuerto.Location = new Point(7, 20);
            txtPuerto.Name = "txtPuerto";
            txtPuerto.Size = new Size(42, 26);
            txtPuerto.TabIndex = 2;
            txtPuerto.Text = "47474";
            txtPuerto.TextAlign = HorizontalAlignment.Right;
            // 
            // txtOrganizacion
            // 
            txtOrganizacion.Location = new Point(6, 21);
            txtOrganizacion.Name = "txtOrganizacion";
            txtOrganizacion.Size = new Size(143, 27);
            txtOrganizacion.TabIndex = 0;
            // 
            // txtNombrePC
            // 
            txtNombrePC.Location = new Point(7, 22);
            txtNombrePC.Name = "txtNombrePC";
            txtNombrePC.Size = new Size(110, 27);
            txtNombrePC.TabIndex = 4;
            // 
            // txtGrupo
            // 
            txtGrupo.Location = new Point(7, 22);
            txtGrupo.Name = "txtGrupo";
            txtGrupo.Size = new Size(108, 27);
            txtGrupo.TabIndex = 5;
            // 
            // txtInventario
            // 
            txtInventario.Location = new Point(8, 22);
            txtInventario.Name = "txtInventario";
            txtInventario.Size = new Size(100, 27);
            txtInventario.TabIndex = 6;
            txtInventario.Text = "N/A";
            // 
            // panel1
            // 
            panel1.Controls.Add(richTextBox1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(323, 416);
            panel1.TabIndex = 17;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(323, 416);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            progressBar1.ForeColor = SystemColors.Control;
            progressBar1.Location = new Point(0, 0);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(780, 10);
            progressBar1.TabIndex = 20;
            // 
            // infoOrganizacion
            // 
            infoOrganizacion.AutoSize = true;
            infoOrganizacion.BackColor = SystemColors.Control;
            infoOrganizacion.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            infoOrganizacion.Location = new Point(155, 22);
            infoOrganizacion.Name = "infoOrganizacion";
            infoOrganizacion.Size = new Size(20, 23);
            infoOrganizacion.TabIndex = 25;
            infoOrganizacion.Text = "?";
            // 
            // infoServer
            // 
            infoServer.AutoSize = true;
            infoServer.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            infoServer.Location = new Point(120, 22);
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
            infoPC.Location = new Point(123, 21);
            infoPC.Name = "infoPC";
            infoPC.Size = new Size(20, 23);
            infoPC.TabIndex = 28;
            infoPC.Text = "?";
            // 
            // infoGrupo
            // 
            infoGrupo.AutoSize = true;
            infoGrupo.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            infoGrupo.Location = new Point(121, 22);
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
            groupBox1.Font = new Font("Calibri", 12F, FontStyle.Bold);
            groupBox1.Location = new Point(330, 58);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(196, 55);
            groupBox1.TabIndex = 31;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nombre de la organización";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtIPserver);
            groupBox2.Controls.Add(infoServer);
            groupBox2.Font = new Font("Calibri", 12F, FontStyle.Bold);
            groupBox2.Location = new Point(535, 58);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(142, 55);
            groupBox2.TabIndex = 32;
            groupBox2.TabStop = false;
            groupBox2.Text = "IP del servidor";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtPuerto);
            groupBox3.Controls.Add(infoPuerto);
            groupBox3.Font = new Font("Calibri", 12F, FontStyle.Bold);
            groupBox3.Location = new Point(685, 58);
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
            groupBox4.Font = new Font("Calibri", 12F, FontStyle.Bold);
            groupBox4.Location = new Point(330, 119);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(149, 55);
            groupBox4.TabIndex = 34;
            groupBox4.TabStop = false;
            groupBox4.Text = "Nombre PC";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(txtGrupo);
            groupBox5.Controls.Add(infoGrupo);
            groupBox5.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox5.Location = new Point(485, 119);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(147, 55);
            groupBox5.TabIndex = 34;
            groupBox5.TabStop = false;
            groupBox5.Text = "Grupo de trabajo";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(txtInventario);
            groupBox6.Controls.Add(infoInventario);
            groupBox6.Font = new Font("Calibri", 12F, FontStyle.Bold);
            groupBox6.Location = new Point(638, 119);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(129, 55);
            groupBox6.TabIndex = 34;
            groupBox6.TabStop = false;
            groupBox6.Text = "Inventario";
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(337, 9);
            label1.Name = "label1";
            label1.Size = new Size(435, 44);
            label1.TabIndex = 36;
            label1.Text = "Instalador de semilla DeepControl EU";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtTerminos
            // 
            txtTerminos.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTerminos.Location = new Point(330, 207);
            txtTerminos.Name = "txtTerminos";
            txtTerminos.ReadOnly = true;
            txtTerminos.Size = new Size(437, 129);
            txtTerminos.TabIndex = 80;
            txtTerminos.Text = resources.GetString("txtTerminos.Text");
            txtTerminos.TextChanged += richTextBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.CausesValidation = false;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.HotTrack;
            label2.Location = new Point(331, 189);
            label2.Name = "label2";
            label2.Size = new Size(139, 15);
            label2.TabIndex = 38;
            label2.Text = "Términos y Condiciones ";
            // 
            // chkActivar
            // 
            chkActivar.AutoSize = true;
            chkActivar.Location = new Point(331, 337);
            chkActivar.Name = "chkActivar";
            chkActivar.Size = new Size(211, 19);
            chkActivar.TabIndex = 7;
            chkActivar.Text = "Aceptar los términos y condiciones";
            chkActivar.UseVisualStyleBackColor = true;
            chkActivar.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // SetupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(778, 416);
            Controls.Add(progressBar1);
            Controls.Add(label2);
            Controls.Add(txtTerminos);
            Controls.Add(label1);
            Controls.Add(btnDesinstalar);
            Controls.Add(groupBox4);
            Controls.Add(groupBox5);
            Controls.Add(groupBox6);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Controls.Add(chkActivar);
            Controls.Add(btnInstalar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SetupForm";
            Text = "Instalador Semilla DeepControl";
            Load += SetupForm_Load;
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
            PerformLayout();
        }

        #endregion

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
        
        private PictureBox pictureBox1;
        private Label label1;
        private RichTextBox txtTerminos;
        private Label label2;
        private CheckBox chkActivar;
        private Button btnInstalar;
        private Button btnDesinstalar;
    }
}
