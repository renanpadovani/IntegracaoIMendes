using IntegracaoIMendes.Apresentacao.Entities;
using IntegracaoIMendes.Domain.Entities.Infast;
using IntegracaoIMendes.Domain.Enums;
using IntegracaoIMendes.Domain.Handlers.Infast;
using IntegracaoIMendes.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IntegracaoIMendes.Apresentacao.UI
{
    public partial class configuracoesForm : Form
    {
        Domain.DataContext.InfastDataContext _context;
        ConfiguracoesHandler _configHandler;

        public configuracoesForm()
        {
            InitializeComponent();

            _context = new Domain.DataContext.InfastDataContext(Properties.Settings.Default.Server.ToString(), Properties.Settings.Default.Database.ToString(), Properties.Settings.Default.User.ToString(), Properties.Settings.Default.Password.ToString());

            ConfiguracoesRepositorio repositorio = new ConfiguracoesRepositorio(_context);
            _configHandler = new Domain.Handlers.Infast.ConfiguracoesHandler(repositorio);
        }

        private void configuracoesForm_Load(object sender, EventArgs e)
        {
            CarregarComboAmbiente();

            CarregarConfiguracoes();
        }

        private void CarregarComboAmbiente()
        {
            List<ChaveValor> listaAmbientes = new List<ChaveValor>();

            listaAmbientes.Add(new ChaveValor { ID = "1", Descricao = "1 - Homologação" });
            listaAmbientes.Add(new ChaveValor { ID = "2", Descricao = "2 - Produção" });
            
            ambientecomboBox.DataSource = listaAmbientes;
            ambientecomboBox.DisplayMember = "Descricao";
            ambientecomboBox.ValueMember = "ID";
        }

        private void CarregarConfiguracoes()
        {
            Configuracoes config = _configHandler.CarregarConfiguracao();

            if (config != null && config.ID != 0)
            {
                loginIMendestextBox.Text = config.Login;
                senhaIMendestextBox.Text = config.Senha;
                ambientecomboBox.SelectedValue = ((int)config.Ambiente).ToString();
                cnpjClientetextBox.Text = config.CnpjCliente;
                qtdDiariaRequisicoesIMendesnumericUpDown.Value = config.QtdRequisicoesDiarias;
                qtdProdutosPorRequisicaonumericUpDown.Value = config.QtdProdutosPorRequisicao;
                qtdUfsPorRequisicaonumericUpDown.Value = config.QtdUFsporRequisicao;
                qtdCaracteristicasTributariasPorRequisicaonumericUpDown.Value = config.QtdCaracteristicasTributariasPorRequisicao;
            }
        }

        private void salvarbutton_Click(object sender, EventArgs e)
        {
            try
            {
                string loginIMendes = "";
                string senhaIMendes = "";
                EAmbiente ambiente = EAmbiente.Homologacao;
                string cnpjCliente = "";
                int qtdRequisicoesDiariasIMendes = 0;
                int qtdProdutosPorRequisicao = 0;
                int qtdUFsPorRequisicao = 0;
                int qtdCaracteristicasTributariasPorRequisicao = 0;

                if (loginIMendestextBox.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Atenção: Login IMendes não informado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                    loginIMendes = loginIMendestextBox.Text;

                if (senhaIMendestextBox.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Atenção: Senha IMendes não informado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                    senhaIMendes = senhaIMendestextBox.Text;

                if (ambientecomboBox.SelectedValue == null)
                {
                    MessageBox.Show("Atenção: Ambiente não informado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                    ambiente = (EAmbiente)int.Parse(ambientecomboBox.SelectedValue.ToString());

                if (cnpjClientetextBox.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Atenção: CNPJ do cliente não informado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                    cnpjCliente = cnpjClientetextBox.Text;

                if (qtdDiariaRequisicoesIMendesnumericUpDown.Value == 0)
                {
                    MessageBox.Show("Atenção: Quantidade de requisições diárias ao servidor IMendes não pode ser zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                    qtdRequisicoesDiariasIMendes = int.Parse(qtdDiariaRequisicoesIMendesnumericUpDown.Text);

                if (qtdProdutosPorRequisicaonumericUpDown.Value == 0)
                {
                    MessageBox.Show("Atenção: Quantidade de produtos por requisição não pode ser zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                    qtdProdutosPorRequisicao = int.Parse(qtdProdutosPorRequisicaonumericUpDown.Text);


                if (qtdUfsPorRequisicaonumericUpDown.Value == 0)
                {
                    MessageBox.Show("Atenção: Quantidade de UF's por requisição não pode ser zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                    qtdUFsPorRequisicao = int.Parse(qtdUfsPorRequisicaonumericUpDown.Text);

                if (qtdCaracteristicasTributariasPorRequisicaonumericUpDown.Value == 0)
                {
                    MessageBox.Show("Atenção: Quantidade de características tributárias por requisição não pode ser zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                    qtdCaracteristicasTributariasPorRequisicao = int.Parse(qtdCaracteristicasTributariasPorRequisicaonumericUpDown.Text);

                _configHandler.IncluirConfiguracao(
                                                    loginIMendes,
                                                    senhaIMendes,
                                                    ambiente,
                                                    cnpjCliente,
                                                    qtdRequisicoesDiariasIMendes,
                                                    qtdProdutosPorRequisicao,
                                                    qtdUFsPorRequisicao,
                                                    qtdCaracteristicasTributariasPorRequisicao);

                MessageBox.Show("Atenção: Configurações atualizadas com sucesso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Atenção: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
