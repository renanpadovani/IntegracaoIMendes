using IntegracaoIMendes.Dominio.Manipuladores.Infast;
using IntegracaoIMendes.Apresentacao.Servicos;
using System;
using System.Windows.Forms;
using IntegracaoIMendes.Dominio.Entidades.Infast;
using System.Collections.Generic;
using System.Linq;
using IntegracaoIMendes.Dominio.Repositorios;
using IntegracaoIMendes.Dominio.Manipuladores;

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

        private void credenciaisBancoDeDadosINFASTERPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracoesBDForm oFormConfiguracaoBD = new ConfiguracoesBDForm();
            oFormConfiguracaoBD.ShowDialog();
        }

        private void configuraçõesIMendesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configuracoesForm oFormConfiguracao = new configuracoesForm(_contexto);
            oFormConfiguracao.ShowDialog();
        }

        private void cenáriosTributáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cenariosTributariosForm oFormCenario = new cenariosTributariosForm(_contexto);
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

                IEnumerable<Cenarios> listaCenarios = CarregarCenarios().OrderBy(x => x.DataHoraUltimoProcessamento);

                if (listaCenarios.Count<Cenarios>() == 0)
                {
                    listaMensagens.Add("Nenhum cenário localizado para integração.");
                    return;
                }

                List<Produtos> listaProdutos = CarregarProdutosParaIntegracao();

                if (listaProdutos.Count == 0)
                {
                    listaMensagens.Add("Nenhum produto localizado para integração.");
                    return;
                }

                ProcessamentoCenariosRepositorio repositorioProcessamentoCenarios = new ProcessamentoCenariosRepositorio(_contexto);
                CenariosRepositorio repositorioCenarios = new CenariosRepositorio(_contexto);
                TributacoesRepositorio repositorioTributacoes = new TributacoesRepositorio(_contexto);
                ProdutosRepositorio repositorioProdutos = new ProdutosRepositorio(_contexto);

                _processamentoCenariosManipulador = new ProcessamentoCenariosManipulador(repositorioProcessamentoCenarios,
                                                                                         repositorioCenarios,
                                                                                         repositorioTributacoes,
                                                                                         repositorioProdutos,
                                                                                         CarregarConfiguracaoIMendes());

                _processamentoCenariosManipulador.ProcessarCenarios(listaCenarios, listaProdutos);

                listaMensagens.Add("Integração concluída, aguardando próximo ciclo.");
            }
            else
                listaMensagens.Add("É necessário configurar a integração antes de iniciá-la.");
        }

        private Configuracoes CarregarConfiguracaoIMendes()
        {
            ConfiguracoesRepositorio repositorioConfiguracoes = new ConfiguracoesRepositorio(_contexto);
            ConfiguracoesManipulador configuracoesManipulador = new ConfiguracoesManipulador(repositorioConfiguracoes);

            return configuracoesManipulador.CarregarConfiguracao();
        }

        private IEnumerable<Cenarios> CarregarCenarios()
        {
            try
            {
                CenariosRepositorio repositorioCenarios = new CenariosRepositorio(_contexto);
                ProdutosRepositorio repositorioProdutos = new ProdutosRepositorio(_contexto);
                CenariosManipulador cenariosManipulador = new CenariosManipulador(repositorioCenarios,
                                                                                  repositorioProdutos,
                                                                                  CarregarConfiguracaoIMendes());

                return cenariosManipulador.CarregarListaCenarios();
            }
            catch (Exception)
            {
                IEnumerable<Cenarios> empty = Enumerable.Empty<Cenarios>();
                return empty;
            }
        }

    private List<Produtos> CarregarProdutosParaIntegracao(Int64 produtoId = 0, string tipoClassificacaoProdutos = "")
    {
        try
        {
            ProdutosRepositorio repositorioProdutos = new ProdutosRepositorio(_contexto);
            ProdutosManipulador produtosInfastManipulador = new ProdutosManipulador(repositorioProdutos);

            return produtosInfastManipulador.PesquisarProdutos(produtoId, tipoClassificacaoProdutos).ToList();
        }
        catch (Exception)
        {
            List<Produtos> empty = new List<Produtos>();
            return empty;
        }
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
