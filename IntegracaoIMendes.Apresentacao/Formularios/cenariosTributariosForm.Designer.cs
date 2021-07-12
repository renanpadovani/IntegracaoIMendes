
namespace IntegracaoIMendes.Apresentacao.Formularios
{
    partial class cenariosTributariosForm
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
            this.ufEmitentecomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.intervaloDeBuscaEmDiasnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tipoDeProdutoscomboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.incluirCenariobutton = new System.Windows.Forms.Button();
            this.removerCenariobutton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.caracteristicasTributariasDestinocheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.cfopDestinocomboBox = new System.Windows.Forms.ComboBox();
            this.finalidadeDestinacaocheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ufDestinocheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.regimeTributariocomboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tipoRegimecomboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cenariosdataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervaloDeBuscaEmDiasnumericUpDown)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cenariosdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ufEmitentecomboBox
            // 
            this.ufEmitentecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ufEmitentecomboBox.FormattingEnabled = true;
            this.ufEmitentecomboBox.Items.AddRange(new object[] {
            "AC",
            "AL",
            "AM",
            "AP",
            "BA",
            "CE",
            "DF",
            "ES",
            "GO",
            "MA",
            "MG",
            "MS",
            "MT",
            "PA",
            "PB",
            "PE",
            "PI",
            "PR",
            "RJ",
            "RN",
            "RO",
            "RR",
            "RS",
            "SC",
            "SE",
            "SP",
            "TO"});
            this.ufEmitentecomboBox.Location = new System.Drawing.Point(6, 36);
            this.ufEmitentecomboBox.Name = "ufEmitentecomboBox";
            this.ufEmitentecomboBox.Size = new System.Drawing.Size(74, 23);
            this.ufEmitentecomboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "UF:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.incluirCenariobutton);
            this.groupBox1.Controls.Add(this.removerCenariobutton);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 288);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Incluir Novo Cenário";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.intervaloDeBuscaEmDiasnumericUpDown);
            this.groupBox5.Controls.Add(this.tipoDeProdutoscomboBox);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Location = new System.Drawing.Point(414, 22);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(330, 65);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Parâmetros de Busca";
            // 
            // intervaloDeBuscaEmDiasnumericUpDown
            // 
            this.intervaloDeBuscaEmDiasnumericUpDown.Location = new System.Drawing.Point(160, 36);
            this.intervaloDeBuscaEmDiasnumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.intervaloDeBuscaEmDiasnumericUpDown.Name = "intervaloDeBuscaEmDiasnumericUpDown";
            this.intervaloDeBuscaEmDiasnumericUpDown.Size = new System.Drawing.Size(148, 23);
            this.intervaloDeBuscaEmDiasnumericUpDown.TabIndex = 18;
            this.intervaloDeBuscaEmDiasnumericUpDown.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // tipoDeProdutoscomboBox
            // 
            this.tipoDeProdutoscomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoDeProdutoscomboBox.FormattingEnabled = true;
            this.tipoDeProdutoscomboBox.Items.AddRange(new object[] {
            "",
            "Produto Acabado",
            "Semi-Acabado",
            "Matéria Prima",
            "Material Terceiros",
            "Consumo",
            "Ativo Fixo",
            "Serviço Interno",
            "Serviço Externo",
            "Outros"});
            this.tipoDeProdutoscomboBox.Location = new System.Drawing.Point(6, 36);
            this.tipoDeProdutoscomboBox.Name = "tipoDeProdutoscomboBox";
            this.tipoDeProdutoscomboBox.Size = new System.Drawing.Size(145, 23);
            this.tipoDeProdutoscomboBox.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 15);
            this.label9.TabIndex = 1;
            this.label9.Text = "Tipo de Produtos:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(157, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(151, 15);
            this.label10.TabIndex = 3;
            this.label10.Text = "Intervalo de Busca em Dias:";
            // 
            // incluirCenariobutton
            // 
            this.incluirCenariobutton.Location = new System.Drawing.Point(637, 174);
            this.incluirCenariobutton.Name = "incluirCenariobutton";
            this.incluirCenariobutton.Size = new System.Drawing.Size(107, 23);
            this.incluirCenariobutton.TabIndex = 15;
            this.incluirCenariobutton.Text = "Incluir Cenário";
            this.incluirCenariobutton.UseVisualStyleBackColor = true;
            this.incluirCenariobutton.Click += new System.EventHandler(this.incluirCenariobutton_Click);
            // 
            // removerCenariobutton
            // 
            this.removerCenariobutton.Location = new System.Drawing.Point(637, 203);
            this.removerCenariobutton.Name = "removerCenariobutton";
            this.removerCenariobutton.Size = new System.Drawing.Size(107, 23);
            this.removerCenariobutton.TabIndex = 16;
            this.removerCenariobutton.Text = "Remover Cenário";
            this.removerCenariobutton.UseVisualStyleBackColor = true;
            this.removerCenariobutton.Click += new System.EventHandler(this.removerCenariobutton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.caracteristicasTributariasDestinocheckedListBox);
            this.groupBox4.Controls.Add(this.cfopDestinocomboBox);
            this.groupBox4.Controls.Add(this.finalidadeDestinacaocheckedListBox);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.ufDestinocheckedListBox);
            this.groupBox4.Location = new System.Drawing.Point(6, 90);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(625, 188);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dados do Destinatário";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(135, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(478, 23);
            this.label8.TabIndex = 15;
            this.label8.Text = "Nossa sugestão é de 5 UF’s, um CFOP e uma característica tributária por cenário";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Características Tributárias:";
            // 
            // caracteristicasTributariasDestinocheckedListBox
            // 
            this.caracteristicasTributariasDestinocheckedListBox.FormattingEnabled = true;
            this.caracteristicasTributariasDestinocheckedListBox.Location = new System.Drawing.Point(6, 84);
            this.caracteristicasTributariasDestinocheckedListBox.Name = "caracteristicasTributariasDestinocheckedListBox";
            this.caracteristicasTributariasDestinocheckedListBox.Size = new System.Drawing.Size(300, 94);
            this.caracteristicasTributariasDestinocheckedListBox.TabIndex = 6;
            // 
            // cfopDestinocomboBox
            // 
            this.cfopDestinocomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cfopDestinocomboBox.FormattingEnabled = true;
            this.cfopDestinocomboBox.Items.AddRange(new object[] {
            "5101",
            "5102",
            "5405",
            "6101",
            "6102",
            "6403",
            "6404"});
            this.cfopDestinocomboBox.Location = new System.Drawing.Point(6, 37);
            this.cfopDestinocomboBox.Name = "cfopDestinocomboBox";
            this.cfopDestinocomboBox.Size = new System.Drawing.Size(91, 23);
            this.cfopDestinocomboBox.TabIndex = 14;
            // 
            // finalidadeDestinacaocheckedListBox
            // 
            this.finalidadeDestinacaocheckedListBox.FormattingEnabled = true;
            this.finalidadeDestinacaocheckedListBox.Location = new System.Drawing.Point(312, 84);
            this.finalidadeDestinacaocheckedListBox.Name = "finalidadeDestinacaocheckedListBox";
            this.finalidadeDestinacaocheckedListBox.Size = new System.Drawing.Size(172, 94);
            this.finalidadeDestinacaocheckedListBox.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "CFOP (Destino):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(312, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Finalidade (Destinação):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(490, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "UF\'s Destino:";
            // 
            // ufDestinocheckedListBox
            // 
            this.ufDestinocheckedListBox.FormattingEnabled = true;
            this.ufDestinocheckedListBox.Location = new System.Drawing.Point(490, 84);
            this.ufDestinocheckedListBox.Name = "ufDestinocheckedListBox";
            this.ufDestinocheckedListBox.Size = new System.Drawing.Size(123, 94);
            this.ufDestinocheckedListBox.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ufEmitentecomboBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.regimeTributariocomboBox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.tipoRegimecomboBox);
            this.groupBox3.Location = new System.Drawing.Point(6, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(402, 65);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dados do Emitente";
            // 
            // regimeTributariocomboBox
            // 
            this.regimeTributariocomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regimeTributariocomboBox.FormattingEnabled = true;
            this.regimeTributariocomboBox.Location = new System.Drawing.Point(86, 36);
            this.regimeTributariocomboBox.Name = "regimeTributariocomboBox";
            this.regimeTributariocomboBox.Size = new System.Drawing.Size(147, 23);
            this.regimeTributariocomboBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Regime Tributário:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo Regime Normal:";
            // 
            // tipoRegimecomboBox
            // 
            this.tipoRegimecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoRegimecomboBox.FormattingEnabled = true;
            this.tipoRegimecomboBox.Location = new System.Drawing.Point(239, 36);
            this.tipoRegimecomboBox.Name = "tipoRegimecomboBox";
            this.tipoRegimecomboBox.Size = new System.Drawing.Size(147, 23);
            this.tipoRegimecomboBox.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cenariosdataGridView);
            this.groupBox2.Location = new System.Drawing.Point(12, 306);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 243);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cenários Configurados";
            // 
            // cenariosdataGridView
            // 
            this.cenariosdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cenariosdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cenariosdataGridView.Location = new System.Drawing.Point(6, 22);
            this.cenariosdataGridView.MultiSelect = false;
            this.cenariosdataGridView.Name = "cenariosdataGridView";
            this.cenariosdataGridView.ReadOnly = true;
            this.cenariosdataGridView.RowTemplate.Height = 25;
            this.cenariosdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cenariosdataGridView.Size = new System.Drawing.Size(748, 215);
            this.cenariosdataGridView.TabIndex = 0;
            // 
            // cenariosTributariosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MinimizeBox = false;
            this.Name = "cenariosTributariosForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cenários Tributários";
            this.Load += new System.EventHandler(this.configuracaoCenariosForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervaloDeBuscaEmDiasnumericUpDown)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cenariosdataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ufEmitentecomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button removerCenariobutton;
        private System.Windows.Forms.Button incluirCenariobutton;
        private System.Windows.Forms.ComboBox cfopDestinocomboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox ufDestinocheckedListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox finalidadeDestinacaocheckedListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox caracteristicasTributariasDestinocheckedListBox;
        private System.Windows.Forms.ComboBox tipoRegimecomboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox regimeTributariocomboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView cenariosdataGridView;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox tipoDeProdutoscomboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown intervaloDeBuscaEmDiasnumericUpDown;
    }
}