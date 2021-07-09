
namespace IntegracaoIMendes.Apresentacao.UI
{
    partial class PrincipalForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalForm));
            this.processarTributosbutton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.credenciaisBancoDeDadosINFASTERPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesIMendesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cenáriosTributáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.logIntegracaolistBox = new System.Windows.Forms.ListBox();
            this.logIntegracaotimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // processarTributosbutton
            // 
            this.processarTributosbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.processarTributosbutton.Image = global::IntegracaoIMendes.Apresentacao.Properties.Resources.start64;
            this.processarTributosbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.processarTributosbutton.Location = new System.Drawing.Point(12, 271);
            this.processarTributosbutton.Name = "processarTributosbutton";
            this.processarTributosbutton.Size = new System.Drawing.Size(166, 41);
            this.processarTributosbutton.TabIndex = 0;
            this.processarTributosbutton.Text = "            Iniciar Integração";
            this.processarTributosbutton.UseVisualStyleBackColor = true;
            this.processarTributosbutton.Click += new System.EventHandler(this.processarTributosbutton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(744, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.credenciaisBancoDeDadosINFASTERPToolStripMenuItem,
            this.configuraçõesIMendesToolStripMenuItem,
            this.cenáriosTributáriosToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // credenciaisBancoDeDadosINFASTERPToolStripMenuItem
            // 
            this.credenciaisBancoDeDadosINFASTERPToolStripMenuItem.Name = "credenciaisBancoDeDadosINFASTERPToolStripMenuItem";
            this.credenciaisBancoDeDadosINFASTERPToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.credenciaisBancoDeDadosINFASTERPToolStripMenuItem.Text = "Credenciais Banco de Dados INFAST ERP";
            this.credenciaisBancoDeDadosINFASTERPToolStripMenuItem.Click += new System.EventHandler(this.credenciaisBancoDeDadosINFASTERPToolStripMenuItem_Click);
            // 
            // configuraçõesIMendesToolStripMenuItem
            // 
            this.configuraçõesIMendesToolStripMenuItem.Name = "configuraçõesIMendesToolStripMenuItem";
            this.configuraçõesIMendesToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.configuraçõesIMendesToolStripMenuItem.Text = "Configurações IMendes";
            this.configuraçõesIMendesToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesIMendesToolStripMenuItem_Click);
            // 
            // cenáriosTributáriosToolStripMenuItem
            // 
            this.cenáriosTributáriosToolStripMenuItem.Name = "cenáriosTributáriosToolStripMenuItem";
            this.cenáriosTributáriosToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.cenáriosTributáriosToolStripMenuItem.Text = "Cenários Tributários";
            this.cenáriosTributáriosToolStripMenuItem.Click += new System.EventHandler(this.cenáriosTributáriosToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Log Integração:";
            // 
            // logIntegracaolistBox
            // 
            this.logIntegracaolistBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logIntegracaolistBox.FormattingEnabled = true;
            this.logIntegracaolistBox.ItemHeight = 15;
            this.logIntegracaolistBox.Location = new System.Drawing.Point(12, 57);
            this.logIntegracaolistBox.Name = "logIntegracaolistBox";
            this.logIntegracaolistBox.Size = new System.Drawing.Size(720, 199);
            this.logIntegracaolistBox.TabIndex = 7;
            // 
            // logIntegracaotimer
            // 
            this.logIntegracaotimer.Interval = 1000;
            this.logIntegracaotimer.Tick += new System.EventHandler(this.logIntegracaotimer_Tick);
            // 
            // PrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(744, 326);
            this.Controls.Add(this.logIntegracaolistBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.processarTributosbutton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PrincipalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Integração IMendes";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button processarTributosbutton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem credenciaisBancoDeDadosINFASTERPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesIMendesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cenáriosTributáriosToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox logIntegracaolistBox;
        private System.Windows.Forms.Timer logIntegracaotimer;
    }
}

