using Dapper;
using IntegracaoIMendes.Dominio.Entidades.Infast;
using IntegracaoIMendes.Dominio.Repositorios.Interfaces;
using System;
using System.Data;
using System.Linq;

namespace IntegracaoIMendes.Dominio.Repositorios
{
    public class ConfiguracoesRepositorio : IConfiguracoesRepositorio
    {
        private readonly ContextoDados.InfastContextoDados _contexto;
        public ConfiguracoesRepositorio(ContextoDados.InfastContextoDados contexto)
        {
            _contexto = contexto;
        }

        public Configuracoes CarregarConfiguracao()
        {
            return _contexto
                    .Connection
                    .Query<Configuracoes>(
                        "Select IMN_ID ID, " +
                        "IMN_Login Login, " +
                        "IMN_Senha Senha, " +
                        "IMN_Ambiente Ambiente, " +
                        "IMN_CnpjCliente CnpjCliente, " +
                        "IMN_QtdProdutosPorRequisicao QtdProdutosPorRequisicao, " +
                        "IMN_QtdUFsporRequisicao QtdUFsPorRequisicao, " +
                        "IMN_QtdCaracteristicasTributariasPorRequisicao QtdCaracteristicasTributariasPorRequisicao, " +
                        "IMN_QtdRequisicoesDiarias QtdRequisicoesDiarias " +
                        "From Tb_IMendes_Configuracoes",
                        commandType: CommandType.Text)
                    .FirstOrDefault();
        }

        public Int64 IncluirConfiguracao(Configuracoes config)
        {
            string insertConfig = "";

            insertConfig = "Delete From Tb_IMendes_Configuracoes; " +
                                    "Insert Into Tb_IMendes_Configuracoes " +
                                    "(IMN_Login, " +
                                    "IMN_Senha, " +
                                    "IMN_Ambiente, " +
                                    "IMN_CnpjCliente, " +
                                    "IMN_QtdProdutosPorRequisicao, " +
                                    "IMN_QtdUFsporRequisicao, " +
                                    "IMN_QtdCaracteristicasTributariasPorRequisicao, " +
                                    "IMN_QtdRequisicoesDiarias) " +
                                    "Values " +
                                    "(@Login, " +
                                    "@Senha, " +
                                    "@Ambiente, " +
                                    "@CnpjCliente, " +
                                    "@QtdProdutosPorRequisicao, " +
                                    "@QtdUFsporRequisicao, " +
                                    "@QtdCaracteristicasTributariasPorRequisicao, " +
                                    "@QtdRequisicoesDiarias); " +
                                    "SELECT CAST(SCOPE_IDENTITY() as BIGINT);";

            return Int64.Parse(_contexto.Connection.ExecuteScalar(insertConfig, config).ToString());
        }
    }
}
