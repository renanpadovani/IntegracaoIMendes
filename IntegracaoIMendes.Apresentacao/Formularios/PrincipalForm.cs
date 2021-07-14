using IntegracaoIMendes.Dominio.Manipuladores.Infast;
using IntegracaoIMendes.Apresentacao.Servicos;
using System;
using System.Windows.Forms;
using IntegracaoIMendes.Dominio.Entidades.Infast;
using System.Collections.Generic;
using IntegracaoIMendes.Dominio.Repositorios;
using IntegracaoIMendes.Dominio.Servicos;
using IntegracaoIMendes.Dominio.ContextoDados;

namespace IntegracaoIMendes.Apresentacao.Formularios
{
    public partial class PrincipalForm : Form
    {
        private List<string> listaMensagens = new List<string>();
        private Configuracoes _configuracao;
       
        public PrincipalForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarCredenciaisBancoDeDados();

                _configuracao = CarregarConfiguracaoIMendes();

                if (_configuracao == null) 
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

        private InfastContextoDados CriarContextoDados()
        {
            return new InfastContextoDados(Properties.Settings.Default.Server.ToString(), Properties.Settings.Default.Database.ToString(), Properties.Settings.Default.User.ToString(), Properties.Settings.Default.Password.ToString());
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

        private void credenciaisBancoDeDadosINFASTERPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracoesBDForm oFormConfiguracaoBD = new ConfiguracoesBDForm();
            oFormConfiguracaoBD.ShowDialog();
        }

        private void configuraçõesIMendesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfastContextoDados contexto = CriarContextoDados();

            configuracoesForm oFormConfiguracao = new configuracoesForm(contexto);
            oFormConfiguracao.ShowDialog();

            contexto.Dispose();
        }

        private void cenáriosTributáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfastContextoDados contexto = CriarContextoDados();

            cenariosTributariosForm oFormCenario = new cenariosTributariosForm(contexto);
            oFormCenario.ShowDialog();

            contexto.Dispose();
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
            if (_configuracao != null)
            {
                InfastContextoDados contexto = CriarContextoDados();

                listaMensagens.Add("Integração iniciada.");

                ProcessamentoCenariosRepositorio repositorioProcessamentoCenarios = new ProcessamentoCenariosRepositorio(contexto);
                CenariosRepositorio repositorioCenarios = new CenariosRepositorio(contexto);
                TributacoesRepositorio repositorioTributacoes = new TributacoesRepositorio(contexto);
                ProdutosRepositorio repositorioProdutos = new ProdutosRepositorio(contexto);
                ConfiguracoesRepositorio repositorioConfiguracoes = new ConfiguracoesRepositorio(contexto);

                ProcessamentoCenariosServico _processamentoServico = new ProcessamentoCenariosServico(repositorioProcessamentoCenarios,
                                                                                                      repositorioCenarios,
                                                                                                      repositorioTributacoes,
                                                                                                      repositorioProdutos,
                                                                                                      repositorioConfiguracoes);

                _processamentoServico.ProcessarCenarios();

                contexto.Dispose();

                listaMensagens.Add("Integração concluída, aguardando próximo ciclo.");
            }
            else
                listaMensagens.Add("É necessário configurar a integração antes de iniciá-la.");
        }

        private Configuracoes CarregarConfiguracaoIMendes()
        {
            ConfiguracoesRepositorio repositorioConfiguracoes = new ConfiguracoesRepositorio(CriarContextoDados());
            ConfiguracoesManipulador configuracoesManipulador = new ConfiguracoesManipulador(repositorioConfiguracoes);

            return configuracoesManipulador.CarregarConfiguracao();
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
