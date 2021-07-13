
namespace IntegracaoIMendes.Apresentacao.Formularios
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
            this.integracaotimer = new System.Windows.Forms.Timer(this.components);
            this.integracaobackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusIntegracaotoolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.logIntegracaotimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // processarTributosbutton
            // 
            this.processarTributosbutton.Image = global::IntegracaoIMendes.Apresentacao.Properties.Resources.start64;
            this.processarTributosbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.processarTributosbutton.Location = new System.Drawing.Point(153, 75);
            this.processarTributosbutton.Name = "processarTributosbutton";
            this.processarTributosbutton.Size = new System.Drawing.Size(179, 48);
            this.processarTributosbutton.TabIndex = 0;
            this.processarTributosbutton.Text = "            Forçar Integração";
            this.processarTributosbutton.UseVisualStyleBackColor = true;
            this.processarTributosbutton.Click += new System.EventHandler(this.processarTributosbutton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(478, 24);
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
            // integracaotimer
            // 
            this.integracaotimer.Interval = 30000;
            this.integracaotimer.Tick += new System.EventHandler(this.integracaotimer_Tick);
            // 
            // integracaobackgroundWorker
            // 
            this.integracaobackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.integracaobackgroundWorker_DoWork);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusIntegracaotoolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 164);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(478, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusIntegracaotoolStripStatusLabel
            // 
            this.statusIntegracaotoolStripStatusLabel.Name = "statusIntegracaotoolStripStatusLabel";
            this.statusIntegracaotoolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
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
            this.ClientSize = new System.Drawing.Size(478, 186);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.processarTributosbutton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "PrincipalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Integração IMendes";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.Timer integracaotimer;
        private System.ComponentModel.BackgroundWorker integracaobackgroundWorker;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusIntegracaotoolStripStatusLabel;
        private System.Windows.Forms.Timer logIntegracaotimer;
    }
}

