using Dapper;
using IntegracaoIMendes.Domain.Entities.Infast;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace IntegracaoIMendes.Domain.Repositories
{
    public class ConfiguracoesRepositorio
    {
        private readonly DataContext.InfastDataContext _context;
        public ConfiguracoesRepositorio(DataContext.InfastDataContext context)
        {
            _context = context;
        }

        public Configuracoes CarregarConfiguracao()
        {
            return _context
                    .Connection
                    .Query<Configuracoes>(
                        "Select IMN_ID ID, " +
                        "IMN_Login Login, " +
                        "IMN_Senha Senha, " +
                        "IMN_Ambiente Ambiente, " +
                        "IMN_CnpjCliente CnpjCliente, " +
                        "IMN_QtdProdutosPorRequisicao QtdProdutosPorRequisicao, " +
                        "IMN_QtdUFsporRequisicao QtdUFsPorRequisicao, " +
                        "IMN_QtdCaracteristicasTributariasPorRequisicao QtdCaracteristicasTributariasPorRequisicao " +
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
                                    "IMN_QtdCaracteristicasTributariasPorRequisicao) " +
                                    "Values " +
                                    "(@Login, " +
                                    "@Senha, " +
                                    "@Ambiente, " +
                                    "@CnpjCliente, " +
                                    "@QtdProdutosPorRequisicao, " +
                                    "@QtdUFsporRequisicao, " +
                                    "@QtdCaracteristicasTributariasPorRequisicao); " +
                                    "SELECT CAST(SCOPE_IDENTITY() as BIGINT);";

            return Int64.Parse(_context.Connection.ExecuteScalar(insertConfig, config).ToString());
        }
    }
}
