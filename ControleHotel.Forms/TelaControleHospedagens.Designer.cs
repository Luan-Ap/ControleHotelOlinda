
namespace ControleHotel.Forms
{
    partial class TelaControleHospedagens
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaControleHospedagens));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.rbTodas = new System.Windows.Forms.RadioButton();
            this.rbAtivas = new System.Windows.Forms.RadioButton();
            this.rbConcluidas = new System.Windows.Forms.RadioButton();
            this.btnConsumos = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stLbAviso = new System.Windows.Forms.ToolStripStatusLabel();
            this.stLbAvisoTxt = new System.Windows.Forms.ToolStripStatusLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvHospedagens = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodQuarto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumQuarto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConsumoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataSaida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sobrenome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtxtTotal = new System.Windows.Forms.MaskedTextBox();
            this.mtxtCpf = new System.Windows.Forms.MaskedTextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtCheckOut = new System.Windows.Forms.TextBox();
            this.txtSobrenome = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.txtCheckIn = new System.Windows.Forms.TextBox();
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
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospedagens)).BeginInit();
            this.SuspendLayout();
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
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.rbTodas);
            this.groupBox1.Controls.Add(this.rbAtivas);
            this.groupBox1.Controls.Add(this.rbConcluidas);
            this.groupBox1.Controls.Add(this.btnConsumos);
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Controls.Add(this.statusStrip1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dgvHospedagens);
            this.groupBox1.Controls.Add(this.mtxtTotal);
            this.groupBox1.Controls.Add(this.mtxtCpf);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtTipo);
            this.groupBox1.Controls.Add(this.txtCheckOut);
            this.groupBox1.Controls.Add(this.txtSobrenome);
            this.groupBox1.Controls.Add(this.txtNum);
            this.groupBox1.Controls.Add(this.txtCheckIn);
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
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // txtStatus
            // 
            resources.ApplyResources(this.txtStatus, "txtStatus");
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
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
            // rbAtivas
            // 
            resources.ApplyResources(this.rbAtivas, "rbAtivas");
            this.rbAtivas.Name = "rbAtivas";
            this.rbAtivas.UseVisualStyleBackColor = true;
            this.rbAtivas.CheckedChanged += new System.EventHandler(this.RbAtivas_CheckedChanged);
            // 
            // rbConcluidas
            // 
            resources.ApplyResources(this.rbConcluidas, "rbConcluidas");
            this.rbConcluidas.Name = "rbConcluidas";
            this.rbConcluidas.UseVisualStyleBackColor = true;
            this.rbConcluidas.CheckedChanged += new System.EventHandler(this.RbConcluidas_CheckedChanged);
            // 
            // btnConsumos
            // 
            resources.ApplyResources(this.btnConsumos, "btnConsumos");
            this.btnConsumos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsumos.FlatAppearance.BorderSize = 2;
            this.btnConsumos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnConsumos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnConsumos.Name = "btnConsumos";
            this.btnConsumos.UseVisualStyleBackColor = true;
            this.btnConsumos.Click += new System.EventHandler(this.BtnConsumos_Click);
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
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // dgvHospedagens
            // 
            resources.ApplyResources(this.dgvHospedagens, "dgvHospedagens");
            this.dgvHospedagens.AllowUserToAddRows = false;
            this.dgvHospedagens.AllowUserToDeleteRows = false;
            this.dgvHospedagens.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHospedagens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHospedagens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHospedagens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.CodCliente,
            this.CodQuarto,
            this.Tipo,
            this.Nome,
            this.NumQuarto,
            this.ConsumoTotal,
            this.DataEntrada,
            this.DataSaida,
            this.Sobrenome,
            this.Cpf,
            this.Email,
            this.Ativo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHospedagens.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHospedagens.MultiSelect = false;
            this.dgvHospedagens.Name = "dgvHospedagens";
            this.dgvHospedagens.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHospedagens.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHospedagens.RowHeadersVisible = false;
            this.dgvHospedagens.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvHospedagens.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvHospedagens.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            this.dgvHospedagens.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHospedagens.RowTemplate.Height = 25;
            this.dgvHospedagens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHospedagens.TabStop = false;
            this.dgvHospedagens.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvReservas_CellDoubleClick);
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
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
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
            // ConsumoTotal
            // 
            this.ConsumoTotal.DataPropertyName = "ConsumoTotal";
            resources.ApplyResources(this.ConsumoTotal, "ConsumoTotal");
            this.ConsumoTotal.Name = "ConsumoTotal";
            this.ConsumoTotal.ReadOnly = true;
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
            // Ativo
            // 
            this.Ativo.DataPropertyName = "Ativo";
            resources.ApplyResources(this.Ativo, "Ativo");
            this.Ativo.Name = "Ativo";
            this.Ativo.ReadOnly = true;
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
            // txtCheckIn
            // 
            resources.ApplyResources(this.txtCheckIn, "txtCheckIn");
            this.txtCheckIn.Name = "txtCheckIn";
            this.txtCheckIn.ReadOnly = true;
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
            // TelaControleHospedagens
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(143)))), ((int)(((byte)(235)))));
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnVoltar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "TelaControleHospedagens";
            this.Enter += new System.EventHandler(this.TelaControleHospedagens_Enter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospedagens)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox mtxtTotal;
        private System.Windows.Forms.MaskedTextBox mtxtCpf;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.TextBox txtCheckOut;
        private System.Windows.Forms.TextBox txtSobrenome;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.TextBox txtCheckIn;
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvHospedagens;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stLbAviso;
        private System.Windows.Forms.ToolStripStatusLabel stLbAvisoTxt;
        private System.Windows.Forms.Button btnConsumos;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.RadioButton rbTodas;
        private System.Windows.Forms.RadioButton rbAtivas;
        private System.Windows.Forms.RadioButton rbConcluidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodQuarto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumQuarto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConsumoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataSaida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sobrenome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cpf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ativo;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label12;
    }
}