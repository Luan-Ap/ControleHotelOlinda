
namespace ControleHotel.Forms
{
    partial class TelaFazerCheckIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaFazerCheckIn));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFazerCheckIn = new System.Windows.Forms.Button();
            this.dpSaida = new System.Windows.Forms.DateTimePicker();
            this.dpEntrada = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.mtxtTotal = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtAcomp = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.mtxtCpf = new System.Windows.Forms.MaskedTextBox();
            this.txtSobrenome = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stLbAviso = new System.Windows.Forms.ToolStripStatusLabel();
            this.stLbAvisoTxt = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.btnFazerCheckIn);
            this.groupBox1.Controls.Add(this.dpSaida);
            this.groupBox1.Controls.Add(this.dpEntrada);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.mtxtTotal);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.statusStrip1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnFazerCheckIn
            // 
            resources.ApplyResources(this.btnFazerCheckIn, "btnFazerCheckIn");
            this.btnFazerCheckIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFazerCheckIn.FlatAppearance.BorderSize = 2;
            this.btnFazerCheckIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnFazerCheckIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnFazerCheckIn.Name = "btnFazerCheckIn";
            this.btnFazerCheckIn.UseVisualStyleBackColor = true;
            this.btnFazerCheckIn.Click += new System.EventHandler(this.BtnFazerCheckIn_Click);
            // 
            // dpSaida
            // 
            resources.ApplyResources(this.dpSaida, "dpSaida");
            this.dpSaida.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpSaida.Name = "dpSaida";
            // 
            // dpEntrada
            // 
            resources.ApplyResources(this.dpEntrada, "dpEntrada");
            this.dpEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpEntrada.Name = "dpEntrada";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // mtxtTotal
            // 
            resources.ApplyResources(this.mtxtTotal, "mtxtTotal");
            this.mtxtTotal.Name = "mtxtTotal";
            this.mtxtTotal.ReadOnly = true;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.txtTipo);
            this.groupBox3.Controls.Add(this.txtAcomp);
            this.groupBox3.Controls.Add(this.txtNum);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // txtTipo
            // 
            resources.ApplyResources(this.txtTipo, "txtTipo");
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            // 
            // txtAcomp
            // 
            resources.ApplyResources(this.txtAcomp, "txtAcomp");
            this.txtAcomp.Name = "txtAcomp";
            this.txtAcomp.ReadOnly = true;
            // 
            // txtNum
            // 
            resources.ApplyResources(this.txtNum, "txtNum");
            this.txtNum.Name = "txtNum";
            this.txtNum.ReadOnly = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.btnConsultar);
            this.groupBox2.Controls.Add(this.mtxtCpf);
            this.groupBox2.Controls.Add(this.txtSobrenome);
            this.groupBox2.Controls.Add(this.txtNome);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btnConsultar
            // 
            resources.ApplyResources(this.btnConsultar, "btnConsultar");
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.FlatAppearance.BorderSize = 2;
            this.btnConsultar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnConsultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // mtxtCpf
            // 
            resources.ApplyResources(this.mtxtCpf, "mtxtCpf");
            this.mtxtCpf.Name = "mtxtCpf";
            this.mtxtCpf.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtSobrenome
            // 
            resources.ApplyResources(this.txtSobrenome, "txtSobrenome");
            this.txtSobrenome.Name = "txtSobrenome";
            this.txtSobrenome.ReadOnly = true;
            // 
            // txtNome
            // 
            resources.ApplyResources(this.txtNome, "txtNome");
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stLbAviso,
            this.stLbAvisoTxt});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // stLbAviso
            // 
            resources.ApplyResources(this.stLbAviso, "stLbAviso");
            this.stLbAviso.BackColor = System.Drawing.Color.White;
            this.stLbAviso.ForeColor = System.Drawing.Color.Black;
            this.stLbAviso.Name = "stLbAviso";
            // 
            // stLbAvisoTxt
            // 
            resources.ApplyResources(this.stLbAvisoTxt, "stLbAvisoTxt");
            this.stLbAvisoTxt.BackColor = System.Drawing.Color.White;
            this.stLbAvisoTxt.ForeColor = System.Drawing.Color.Red;
            this.stLbAvisoTxt.Name = "stLbAvisoTxt";
            // 
            // btnVoltar
            // 
            resources.ApplyResources(this.btnVoltar, "btnVoltar");
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.FlatAppearance.BorderSize = 2;
            this.btnVoltar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnVoltar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnVoltar.ForeColor = System.Drawing.Color.White;
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.BtnVoltar_Click);
            // 
            // TelaFazerCheckIn
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(143)))), ((int)(((byte)(235)))));
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TelaFazerCheckIn";
            this.Load += new System.EventHandler(this.TelaFazerCheckIn_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stLbAviso;
        private System.Windows.Forms.ToolStripStatusLabel stLbAvisoTxt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.MaskedTextBox mtxtCpf;
        private System.Windows.Forms.TextBox txtSobrenome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.TextBox txtAcomp;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dpSaida;
        private System.Windows.Forms.DateTimePicker dpEntrada;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox mtxtTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnFazerCheckIn;
    }
}