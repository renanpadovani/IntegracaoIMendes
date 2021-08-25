using IntegracaoIMendes.Apresentacao.Entitidades;
using IntegracaoIMendes.Dominio.Enums;
using IntegracaoIMendes.Dominio.Servicos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IntegracaoIMendes.Apresentacao.Formularios
{
    public partial class cenariosTributariosForm : Form
    {
        CenariosServico _cenarioServico;

        public cenariosTributariosForm()
        {
            InitializeComponent();

            _cenarioServico = Fabrica.container.GetRequiredService<CenariosServico>(); 
        }

        private void configuracaoCenariosForm_Load(object sender, EventArgs e)
        {
            CarregarComboRegimeTributario();

            CarregarComboTipoRegimeNormal();

            CarregarComboCfop();

            CarregarListBoxCaracteristicasTributarias();

            CarregarListBoxFinalidades();

            CarregarListBoxUFsDestino();

            CarregarGridCenarios();
        }

        private void CarregarComboRegimeTributario()
        {
            List<ChaveValor> listaRegimesTributarios = new List<ChaveValor>();
            
            listaRegimesTributarios.Add(new ChaveValor { ID = "1", Descricao = "1 - Simples Nacional" });
            listaRegimesTributarios.Add(new ChaveValor { ID = "2", Descricao = "2 - SN com excesso sublimite de receita bruta" });
            listaRegimesTributarios.Add(new ChaveValor { ID = "3", Descricao = "3 - Regime Normal" });

            regimeTributariocomboBox.DataSource = listaRegimesTributarios;
            regimeTributariocomboBox.DisplayMember = "Descricao";
            regimeTributariocomboBox.ValueMember = "ID";
        }

        private void CarregarComboTipoRegimeNormal()
        {
            List<ChaveValor> listaRegimesTributarios = new List<ChaveValor>();

            listaRegimesTributarios.Add(new ChaveValor { ID = "LR", Descricao = "LR - Lucro Real" });
            listaRegimesTributarios.Add(new ChaveValor { ID = "LP", Descricao = "LP - Lucro Presumido" });

            tipoRegimecomboBox.DataSource = listaRegimesTributarios;
            tipoRegimecomboBox.DisplayMember = "Descricao";
            tipoRegimecomboBox.ValueMember = "ID";
        }

        private void CarregarComboCfop()
        {
            List<ChaveValor> listaCfops = new List<ChaveValor>();

            listaCfops.Add(new ChaveValor { ID = "1101", Descricao = "1101 - Compra para industrialização" });
            listaCfops.Add(new ChaveValor { ID = "1102", Descricao = "1102 - Compra para comercialização" });
            listaCfops.Add(new ChaveValor { ID = "1202", Descricao = "1202 - Devolução de venda de mercadoria adquirida ou recebida de terceiros" });
            listaCfops.Add(new ChaveValor { ID = "5101", Descricao = "5101 - Venda de mercadorias industrializadas" });
            listaCfops.Add(new ChaveValor { ID = "5102", Descricao = "5102 - Revenda de mercadorias" });
            listaCfops.Add(new ChaveValor { ID = "5124", Descricao = "5124 - Industrialização efetuada para outra empresa" });
            listaCfops.Add(new ChaveValor { ID = "5202", Descricao = "5202 - Devolução de compra para comercialização" });
            listaCfops.Add(new ChaveValor { ID = "5902", Descricao = "5902 - Retorno de mercadoria utilizada na industrialização por encomenda" });
            listaCfops.Add(new ChaveValor { ID = "5910", Descricao = "5910 - Remessa em bonificação, doação ou brinde" });
            listaCfops.Add(new ChaveValor { ID = "5915", Descricao = "5915 - Remessa de mercadoria ou bem para conserto ou reparo" });
            listaCfops.Add(new ChaveValor { ID = "5949", Descricao = "5949 - Simples Remessa" });
            

            cfopDestinocomboBox.DataSource = listaCfops;
            cfopDestinocomboBox.DisplayMember = "Descricao";
            cfopDestinocomboBox.ValueMember = "ID";
        }

        private void CarregarListBoxCaracteristicasTributarias()
        {
            caracteristicasTributariasDestinocheckedListBox.Items.Add(new ChaveValor { ID = "0", Descricao = "0 - Industrial" });
            caracteristicasTributariasDestinocheckedListBox.Items.Add(new ChaveValor { ID = "1", Descricao = "1 - Distribuidor" });
            caracteristicasTributariasDestinocheckedListBox.Items.Add(new ChaveValor { ID = "2", Descricao = "2 - Atacadista" });
            caracteristicasTributariasDestinocheckedListBox.Items.Add(new ChaveValor { ID = "3", Descricao = "3 - Varejista" });
            caracteristicasTributariasDestinocheckedListBox.Items.Add(new ChaveValor { ID = "4", Descricao = "4 - Produtor Rural Pessoa Jurídica" });
            caracteristicasTributariasDestinocheckedListBox.Items.Add(new ChaveValor { ID = "6", Descricao = "6 - Produtor Rural Pessoa Física" });
            caracteristicasTributariasDestinocheckedListBox.Items.Add(new ChaveValor { ID = "7", Descricao = "7 - Pessoa Jurídica não Contribuinte do ICMS" });
            caracteristicasTributariasDestinocheckedListBox.Items.Add(new ChaveValor { ID = "8", Descricao = "8 - Pessoa Física não Contribuinte do ICMS" });

            caracteristicasTributariasDestinocheckedListBox.DisplayMember = "Descricao";
            caracteristicasTributariasDestinocheckedListBox.ValueMember = "ID";
        }

        private void CarregarListBoxFinalidades()
        {
            finalidadeDestinacaocheckedListBox.Items.Add(new ChaveValor { ID = "0", Descricao = "0 - Revenda" });
            finalidadeDestinacaocheckedListBox.Items.Add(new ChaveValor { ID = "1", Descricao = "1 - Insumo" });
            finalidadeDestinacaocheckedListBox.Items.Add(new ChaveValor { ID = "2", Descricao = "2 - Uso e Consumo ou Ativo Imobilizado" });

            finalidadeDestinacaocheckedListBox.DisplayMember = "Descricao";
            finalidadeDestinacaocheckedListBox.ValueMember = "ID";
        }

        private void CarregarListBoxUFsDestino()
        {
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "AC", Descricao = "AC" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "AL", Descricao = "AL" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "AM", Descricao = "AM" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "AP", Descricao = "AP" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "BA", Descricao = "BA" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "CE", Descricao = "CE" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "DF", Descricao = "DF" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "ES", Descricao = "ES" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "GO", Descricao = "GO" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "MA", Descricao = "MA" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "MG", Descricao = "MG" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "MS", Descricao = "MS" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "MT", Descricao = "MT" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "PA", Descricao = "PA" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "PB", Descricao = "PB" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "PE", Descricao = "PE" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "PI", Descricao = "PI" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "PR", Descricao = "PR" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "RJ", Descricao = "RJ" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "RN", Descricao = "RN" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "RO", Descricao = "RO" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "RR", Descricao = "RR" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "RS", Descricao = "RS" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "SC", Descricao = "SC" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "SE", Descricao = "SE" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "SP", Descricao = "SP" });
            ufDestinocheckedListBox.Items.Add(new ChaveValor { ID = "TO", Descricao = "TO" });

            ufDestinocheckedListBox.DisplayMember = "Descricao";
            ufDestinocheckedListBox.ValueMember = "ID";
        }

        private void incluirCenariobutton_Click(object sender, EventArgs e)
        {
            try
            {
                string ufEmitente = "";
                string cfopDestino = "";
                ECodRegimeTributario regimeTributario = ECodRegimeTributario.RegimeNormal;
                string tipoRegimeNormal = "";
                List<EFinalidade> finalidades = new List<EFinalidade>();
                List<ECaracteristicaTributaria> caracteristicasTributarias = new List<ECaracteristicaTributaria>();
                List<string> ufsDestino = new List<string>();
                string tipoProduto = "";
                Int16 intervaloDeBuscaEmDias = 0;

                if (ufEmitentecomboBox.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Atenção: UF do emitente não informada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                    ufEmitente = ufEmitentecomboBox.Text;

                if (regimeTributariocomboBox.SelectedValue == null)
                {
                    MessageBox.Show("Atenção: Regime tributário do emitente não informado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                    regimeTributario = (ECodRegimeTributario)int.Parse(regimeTributariocomboBox.SelectedValue.ToString());


                if (regimeTributariocomboBox.SelectedValue.ToString() == "3" && tipoRegimecomboBox.SelectedValue == null)
                {
                    MessageBox.Show("Atenção: Tipo do regime normal do emitente não informado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (regimeTributariocomboBox.SelectedValue.ToString() == "3")
                    tipoRegimeNormal = tipoRegimecomboBox.SelectedValue.ToString();


                if (cfopDestinocomboBox.SelectedValue == null)
                {
                    MessageBox.Show("Atenção: CFOP de destino não informado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                    cfopDestino = cfopDestinocomboBox.SelectedValue.ToString();

                if (caracteristicasTributariasDestinocheckedListBox.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Atenção: Nenhuma característica tributária de destino foi informada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    foreach(ChaveValor item in caracteristicasTributariasDestinocheckedListBox.CheckedItems)
                        caracteristicasTributarias.Add((ECaracteristicaTributaria)int.Parse(item.ID));
                }

                if (finalidadeDestinacaocheckedListBox.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Atenção: Nenhuma finalidade (destinação) foi informada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    foreach (ChaveValor item in finalidadeDestinacaocheckedListBox.CheckedItems)
                        finalidades.Add((EFinalidade)int.Parse(item.ID));
                }

                if (ufDestinocheckedListBox.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Atenção: Nenhum UF de destino foi informado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    foreach (ChaveValor item in ufDestinocheckedListBox.CheckedItems)
                        ufsDestino.Add(item.ID);
                }

                tipoProduto = tipoDeProdutoscomboBox.Text;

                if (intervaloDeBuscaEmDiasnumericUpDown.Value == 0)
                {
                    MessageBox.Show("Atenção: Intervalo de busca em dias não pode ser zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                    intervaloDeBuscaEmDias = (Int16)intervaloDeBuscaEmDiasnumericUpDown.Value;

                _cenarioServico.IncluirCenario(ufEmitente,
                                               cfopDestino,
                                               regimeTributario,
                                               tipoRegimeNormal,
                                               finalidades,
                                               caracteristicasTributarias,
                                               ufsDestino,
                                               tipoProduto,
                                               intervaloDeBuscaEmDias);

                MessageBox.Show("Atenção: Cenário Tributário criado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarGridCenarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Atenção: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CarregarGridCenarios()
        {
            cenariosdataGridView.DataSource = _cenarioServico.CarregarListaCenarios();
        }

        private void removerCenariobutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (cenariosdataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("Atenção: É necessário selecionar um cenário tributário antes de prosseguir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Atenção: Deseja realmente remover o cenário tributário selecionado?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Int64 id = Int64.Parse(cenariosdataGridView.CurrentRow.Cells[0].Value.ToString());

                    _cenarioServico.InativarCenario(id);

                    CarregarGridCenarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Atenção: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
