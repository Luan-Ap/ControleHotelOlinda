
namespace ControleHotel.Forms
{
    partial class TelaControleReservas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaControleReservas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.mtxtTotal = new System.Windows.Forms.MaskedTextBox();
            this.mtxtCpf = new System.Windows.Forms.MaskedTextBox();
            this.txtAcomp = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtCheckOut = new System.Windows.Forms.TextBox();
            this.txtSobrenome = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCheckIn = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbTodas = new System.Windows.Forms.RadioButton();
            this.rbConcluidas = new System.Windows.Forms.RadioButton();
            this.rbCanceladas = new System.Windows.Forms.RadioButton();
            this.rbAtivas = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodQuarto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumAcompanhantes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumQuarto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDiaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataSaida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sobrenome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stLbAviso = new System.Windows.Forms.ToolStripStatusLabel();
            this.stLbAvisoTxt = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Controls.Add(this.mtxtTotal);
            this.groupBox1.Controls.Add(this.mtxtCpf);
            this.groupBox1.Controls.Add(this.txtAcomp);
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtTipo);
            this.groupBox1.Controls.Add(this.txtCheckOut);
            this.groupBox1.Controls.Add(this.txtSobrenome);
            this.groupBox1.Controls.Add(this.txtNum);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtCheckIn);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbTodas);
            this.groupBox1.Controls.Add(this.rbConcluidas);
            this.groupBox1.Controls.Add(this.rbCanceladas);
            this.groupBox1.Controls.Add(this.rbAtivas);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dgvReservas);
            this.groupBox1.Controls.Add(this.statusStrip1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnCancelar
            // 
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 2;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
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
            // mtxtTotal
            // 
            resources.ApplyResources(this.mtxtTotal, "mtxtTotal");
            this.mtxtTotal.Name = "mtxtTotal";
            this.mtxtTotal.ReadOnly = true;
            // 
            // mtxtCpf
            // 
            resources.ApplyResources(this.mtxtCpf, "mtxtCpf");
            this.mtxtCpf.Name = "mtxtCpf";
            this.mtxtCpf.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtAcomp
            // 
            resources.ApplyResources(this.txtAcomp, "txtAcomp");
            this.txtAcomp.Name = "txtAcomp";
            this.txtAcomp.ReadOnly = true;
            // 
            // txtStatus
            // 
            resources.ApplyResources(this.txtStatus, "txtStatus");
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            // 
            // txtEmail
            // 
            resources.ApplyResources(this.txtEmail, "txtEmail");
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            // 
            // txtTipo
            // 
            resources.ApplyResources(this.txtTipo, "txtTipo");
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            // 
            // txtCheckOut
            // 
            resources.ApplyResources(this.txtCheckOut, "txtCheckOut");
            this.txtCheckOut.Name = "txtCheckOut";
            this.txtCheckOut.ReadOnly = true;
            // 
            // txtSobrenome
            // 
            resources.ApplyResources(this.txtSobrenome, "txtSobrenome");
            this.txtSobrenome.Name = "txtSobrenome";
            this.txtSobrenome.ReadOnly = true;
            // 
            // txtNum
            // 
            resources.ApplyResources(this.txtNum, "txtNum");
            this.txtNum.Name = "txtNum";
            this.txtNum.ReadOnly = true;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // txtCheckIn
            // 
            resources.ApplyResources(this.txtCheckIn, "txtCheckIn");
            this.txtCheckIn.Name = "txtCheckIn";
            this.txtCheckIn.ReadOnly = true;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // txtNome
            // 
            resources.ApplyResources(this.txtNome, "txtNome");
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // rbTodas
            // 
            resources.ApplyResources(this.rbTodas, "rbTodas");
            this.rbTodas.Checked = true;
            this.rbTodas.Name = "rbTodas";
            this.rbTodas.TabStop = true;
            this.rbTodas.UseVisualStyleBackColor = true;
            this.rbTodas.CheckedChanged += new System.EventHandler(this.RbTodas_CheckedChanged);
            // 
            // rbConcluidas
            // 
            resources.ApplyResources(this.rbConcluidas, "rbConcluidas");
            this.rbConcluidas.Name = "rbConcluidas";
            this.rbConcluidas.UseVisualStyleBackColor = true;
            this.rbConcluidas.CheckedChanged += new System.EventHandler(this.RbConcluidas_CheckedChanged);
            // 
            // rbCanceladas
            // 
            resources.ApplyResources(this.rbCanceladas, "rbCanceladas");
            this.rbCanceladas.Name = "rbCanceladas";
            this.rbCanceladas.UseVisualStyleBackColor = true;
            this.rbCanceladas.CheckedChanged += new System.EventHandler(this.RbCanceladas_CheckedChanged);
            // 
            // rbAtivas
            // 
            resources.ApplyResources(this.rbAtivas, "rbAtivas");
            this.rbAtivas.Name = "rbAtivas";
            this.rbAtivas.UseVisualStyleBackColor = true;
            this.rbAtivas.CheckedChanged += new System.EventHandler(this.RbAtivas_CheckedChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // dgvReservas
            // 
            resources.ApplyResources(this.dgvReservas, "dgvReservas");
            this.dgvReservas.AllowUserToAddRows = false;
            this.dgvReservas.AllowUserToDeleteRows = false;
            this.dgvReservas.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReservas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.CodCliente,
            this.CodQuarto,
            this.Tipo,
            this.NumAcompanhantes,
            this.Nome,
            this.NumQuarto,
            this.TotalDiaria,
            this.DataEntrada,
            this.DataSaida,
            this.Status,
            this.Sobrenome,
            this.Cpf,
            this.Email});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReservas.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvReservas.MultiSelect = false;
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReservas.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvReservas.RowHeadersVisible = false;
            this.dgvReservas.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvReservas.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvReservas.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            this.dgvReservas.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvReservas.RowTemplate.Height = 25;
            this.dgvReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservas.TabStop = false;
            this.dgvReservas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvReservas_CellDoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            resources.ApplyResources(this.Codigo, "Codigo");
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // CodCliente
            // 
            this.CodCliente.DataPropertyName = "CodCliente";
            resources.ApplyResources(this.CodCliente, "CodCliente");
            this.CodCliente.Name = "CodCliente";
            this.CodCliente.ReadOnly = true;
            // 
            // CodQuarto
            // 
            this.CodQuarto.DataPropertyName = "CodQuarto";
            resources.ApplyResources(this.CodQuarto, "CodQuarto");
            this.CodQuarto.Name = "CodQuarto";
            this.CodQuarto.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            resources.ApplyResources(this.Tipo, "Tipo");
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // NumAcompanhantes
            // 
            this.NumAcompanhantes.DataPropertyName = "NumAcompanhantes";
            resources.ApplyResources(this.NumAcompanhantes, "NumAcompanhantes");
            this.NumAcompanhantes.Name = "NumAcompanhantes";
            this.NumAcompanhantes.ReadOnly = true;
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "Nome";
            resources.ApplyResources(this.Nome, "Nome");
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // NumQuarto
            // 
            this.NumQuarto.DataPropertyName = "NumQuarto";
            resources.ApplyResources(this.NumQuarto, "NumQuarto");
            this.NumQuarto.Name = "NumQuarto";
            this.NumQuarto.ReadOnly = true;
            // 
            // TotalDiaria
            // 
            this.TotalDiaria.DataPropertyName = "TotalDiaria";
            resources.ApplyResources(this.TotalDiaria, "TotalDiaria");
            this.TotalDiaria.Name = "TotalDiaria";
            this.TotalDiaria.ReadOnly = true;
            // 
            // DataEntrada
            // 
            this.DataEntrada.DataPropertyName = "DataEntrada";
            resources.ApplyResources(this.DataEntrada, "DataEntrada");
            this.DataEntrada.Name = "DataEntrada";
            this.DataEntrada.ReadOnly = true;
            // 
            // DataSaida
            // 
            this.DataSaida.DataPropertyName = "DataSaida";
            resources.ApplyResources(this.DataSaida, "DataSaida");
            this.DataSaida.Name = "DataSaida";
            this.DataSaida.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            resources.ApplyResources(this.Status, "Status");
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Sobrenome
            // 
            this.Sobrenome.DataPropertyName = "Sobrenome";
            resources.ApplyResources(this.Sobrenome, "Sobrenome");
            this.Sobrenome.Name = "Sobrenome";
            this.Sobrenome.ReadOnly = true;
            // 
            // Cpf
            // 
            this.Cpf.DataPropertyName = "Cpf";
            resources.ApplyResources(this.Cpf, "Cpf");
            this.Cpf.Name = "Cpf";
            this.Cpf.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            resources.ApplyResources(this.Email, "Email");
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
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
            // TelaControleReservas
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(143)))), ((int)(((byte)(235)))));
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "TelaControleReservas";
            this.Load += new System.EventHandler(this.TelaControleReservas_Load);
            this.Enter += new System.EventHandler(this.TelaControleReservas_Enter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stLbAviso;
        private System.Windows.Forms.ToolStripStatusLabel stLbAvisoTxt;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.RadioButton rbTodas;
        private System.Windows.Forms.RadioButton rbConcluidas;
        private System.Windows.Forms.RadioButton rbCanceladas;
        private System.Windows.Forms.RadioButton rbAtivas;
        private System.Windows.Forms.MaskedTextBox mtxtTotal;
        private System.Windows.Forms.MaskedTextBox mtxtCpf;
        private System.Windows.Forms.TextBox txtAcomp;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.TextBox txtCheckOut;
        private System.Windows.Forms.TextBox txtSobrenome;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCheckIn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodQuarto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumAcompanhantes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumQuarto;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDiaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataSaida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sobrenome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cpf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
    }
}