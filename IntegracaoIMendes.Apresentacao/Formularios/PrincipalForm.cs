using IntegracaoIMendes.Dominio.Manipuladores.Infast;
using IntegracaoIMendes.Apresentacao.Servicos;
using System;
using System.Windows.Forms;
using IntegracaoIMendes.Dominio.Entidades.Infast;
using System.Collections.Generic;

namespace IntegracaoIMendes.Apresentacao.Formularios
{
    public partial class PrincipalForm : Form
    {
        Dominio.ContextoDados.InfastContextoDados _contexto;
        ProcessamentoCenariosManipulador _processamentoCenariosManipulador;
        private List<string> listaMensagens = new List<string>();

        public PrincipalForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarCredenciaisBancoDeDados();

                _contexto = new Dominio.ContextoDados.InfastContextoDados(Properties.Settings.Default.Server.ToString(), Properties.Settings.Default.Database.ToString(), Properties.Settings.Default.User.ToString(), Properties.Settings.Default.Password.ToString());

                Configuracoes config = CarregarConfiguracaoIMendes();

                if (config == null) 
                    listaMensagens.Add("É necessário configurar a integração antes de iniciá-la.");
                else
                    listaMensagens.Add("Aguardando integração.");

                logIntegracaotimer.Enabled = true;
                integracaotimer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao iniciar a conexão com o banco de dados:\n\n" + ex.Message + "\n\nEntre em contato com o suporte técnico.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void CarregarCredenciaisBancoDeDados()
        {
            ConexaoBDServico.CarregarCredenciais();

            if (Properties.Settings.Default.Server == null || Properties.Settings.Default.Server.ToString().Length == 0)
            {
                MessageBox.Show("Atenção: É necessário configurar as credenciais de banco de dados antes de iniciar integrador.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ConfiguracoesBDForm oFormConfigBD = new ConfiguracoesBDForm();
                oFormConfigBD.ShowDialog();

                CarregarCredenciaisBancoDeDados();
            }
        }

        private void processarTributosbutton_Click(object sender, EventArgs e)
        {
            integracaobackgroundWorker.RunWorkerAsync();
        }

        private Configuracoes CarregarConfiguracaoIMendes()
        {
            ConfiguracoesManipulador configuracoesManipulador = new ConfiguracoesManipulador(_contexto);

            return configuracoesManipulador.CarregarConfiguracao();
        }

        private void credenciaisBancoDeDadosINFASTERPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracoesBDForm oFormConfiguracaoBD = new ConfiguracoesBDForm();
            oFormConfiguracaoBD.ShowDialog();
        }

        private void configuraçõesIMendesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configuracoesForm oFormConfiguracao = new configuracoesForm();
            oFormConfiguracao.ShowDialog();
        }

        private void cenáriosTributáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cenariosTributariosForm oFormCenario = new cenariosTributariosForm();
            oFormCenario.ShowDialog();
        }

        private void integracaotimer_Tick(object sender, EventArgs e)
        {
            if (System.DateTime.Now.ToString("mm") == "00")
                integracaobackgroundWorker.RunWorkerAsync();
        }

        private void integracaobackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IniciarIntegracao();
        }

        private void IniciarIntegracao()
        {
            Configuracoes config = CarregarConfiguracaoIMendes();

            if (config != null)
            {
                listaMensagens.Add("Integração iniciada.");

                _processamentoCenariosManipulador = new ProcessamentoCenariosManipulador(_contexto, config);

                _processamentoCenariosManipulador.ProcessarCenarios();

                listaMensagens.Add("Integração concluída, aguardando próximo ciclo.");
            }
            else
                listaMensagens.Add("É necessário configurar a integração antes de iniciá-la.");
        }

        private void integracaobackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }

        private void logIntegracaotimer_Tick(object sender, EventArgs e)
        {
            while (listaMensagens.Count > 0)
            {
                statusIntegracaotoolStripStatusLabel.Text = System.DateTime.Now.ToString("dd/MM/yy HH:mm:ss: ") + listaMensagens[0];
                listaMensagens.RemoveAt(0);
            }            
        }
    }
}
