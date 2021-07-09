using Dapper;
using IntegracaoIMendes.Domain.Entities.Infast;
using System;
using System.Collections.Generic;
using System.Data;


namespace IntegracaoIMendes.Domain.Repositories
{
    public class TributacoesRepositorio
    {
        DataContext.InfastDataContext _context;

        public TributacoesRepositorio(DataContext.InfastDataContext context)
        {
            _context = context;
        }

        public void SalvarTributacao(TributacaoCabecalho tribCab)
        {
            Int64 idCabecalho = 0;
            Int64 idProdutoGrupo = 0;

            idCabecalho = SalvarTributacaoCabecalho(tribCab);

            foreach (TributacaoProdutoGrupo grupo in tribCab.grupos)
            {
                grupo.CabecalhoID = idCabecalho;

                idProdutoGrupo = SalvarTributacaoProdutoGrupo(grupo);

                foreach (TributacaoProdutoGrupoLista lista in grupo.regras)
                {
                    lista.ProdutoGrupoID = idProdutoGrupo;

                    SSalvarTributacaoProdutoGrupoLista(lista);
                }
            }
        }

        private Int64 SalvarTributacaoCabecalho(TributacaoCabecalho tribCab)
        {
            string insertCabecalho = "";

            insertCabecalho = "Insert Into Tb_IMendes_TributacaoCabecalho " +
                                    "(IMC_Empresa_ID, " +
                                    "IMC_Filial_ID, " +
                                    "IMC_CenarioTributario_ID, " +
                                    "IMC_Ambiente, " +
                                    "IMC_CnpjCliente, " +
                                    "IMC_DataHoraRetorno, " +
                                    "IMC_NumeroProdutosEnviados, " +
                                    "IMC_NumeroProdutosRetornados, " +
                                    "IMC_NumeroProdutosNaoRetornados, " +
                                    "IMC_NumeroTransacaoIMendes, " +
                                    "IMC_MensagemServidor) " +
                                    "Values " +
                                    "(@EmpresaID, " +
                                    "@FilialID, " +
                                    "@CenarioTributarioID, " +
                                    "@Ambiente, " +
                                    "@CnpjCliente, " +
                                    "@DataHoraRetorno, " +
                                    "@NumeroProdutosEnviados, " +
                                    "@NumeroProdutosRetornados, " +
                                    "@NumeroProdutosNaoRetornados, " +
                                    "@NumeroTransacaoIMendes, " +
                                    "@MensagemServidor);" +
                                    "SELECT CAST(SCOPE_IDENTITY() as BIGINT);";

            return Int64.Parse(_context.Connection.ExecuteScalar(insertCabecalho, tribCab).ToString());
        }

        private Int64 SalvarTributacaoProdutoGrupo(TributacaoProdutoGrupo grupo)
        {
             string insertProdutoGrupo = "Insert Into Tb_IMendes_TributacaoProdutoGrupo " +
                                    "(IGI_Empresa_ID, " +
                                    "IGI_Filial_ID, " +
                                    "IGI_Cabecalho_ID, " +
                                    "IGI_ProdutoDerivado_ID, " +
                                    "IGI_Codigo, " +
                                    "IGI_NCM, " +
                                    "IGI_CEST, " +
                                    "IGI_Lista, " +
                                    "IGI_Tipo, " +
                                    "IGI_CodigoANP, " +
                                    "IGI_PassivelPMC, " +
                                    "IGI_ImpostoImportacao, " +
                                    "IGI_PisCofinsCST_Entrada, " +
                                    "IGI_PisCofinsCST_Saida, " +
                                    "IGI_PisCofins_AliquotaPis, " +
                                    "IGI_PisCofins_AliquotaCofins, " +
                                    "IGI_NRI, " +
                                    "IGI_AmparoLegal, " +
                                    "IGI_IpiCST_Entrada, " +
                                    "IGI_IpiCST_Saida, " +
                                    "IGI_Ipi_Aliquota, " +
                                    "IGI_IpiCodEnquadramento, " +
                                    "IGI_IpiEx) " +
                                    "Values " +
                                    "(@EmpresaID, " +
                                    "@FilialID, " +
                                    "@CabecalhoID, " +
                                    "@ProdutoDerivadoID, " +
                                    "@Codigo, " +
                                    "@NCM, " +
                                    "@CEST, " +
                                    "@Lista, " +
                                    "@Tipo, " +
                                    "@CodigoANP, " +
                                    "@PassivelPMC, " +
                                    "@ImpostoImportacao, " +
                                    "@PisCofinsCSTEntrada, " +
                                    "@PisCofinsCSTSaida, " +
                                    "@PisCofinsAliquotaPis, " +
                                    "@PisCofinsAliquotaCofins, " +
                                    "@NRI, " +
                                    "@AmparoLegal, " +
                                    "@IpiCSTEntrada, " +
                                    "@IpiCSTSaida, " +
                                    "@IpiAliquota, " +
                                    "@IpiCodEnquadramento, " +
                                    "@IpiEx);" +
                                    "SELECT CAST(SCOPE_IDENTITY() as BIGINT);";

            return Int64.Parse(_context.Connection.ExecuteScalar(insertProdutoGrupo, grupo).ToString());
        }

        private void SSalvarTributacaoProdutoGrupoLista(TributacaoProdutoGrupoLista lista)
        {
            string insertProdutoGrupoLista = "Insert Into Tb_IMendes_TributacaoProdutoGrupoLista " +
                                    "(IGL_Empresa_ID, " +
                                    "IGL_Filial_ID, " +
                                    "IGL_ProdutoGrupo_ID, " +
                                    "IGL_ProdutoDerivado_ID, " +
                                    "IGL_UF, " +
                                    "IGL_Cfop, " +
                                    "IGL_CodigoCaracteristicaTributaria, " +
                                    "IGL_Finalidade, " +
                                    "IGL_CfopInterno, " +
                                    "IGL_CfopInterestadual, " +
                                    "IGL_Cst, " +
                                    "IGL_Csosn, " +
                                    "IGL_AliquotaInterna, " +
                                    "IGL_AliquotaInterestadual, " +
                                    "IGL_AliquotaReducao, " +
                                    "IGL_AliquotaReducaoST, " +
                                    "IGL_AliquotaST, " +
                                    "IGL_AliquotaIVA, " +
                                    "IGL_AliquotaFCP, " +
                                    "IGL_CodBeneficio, " +
                                    "IGL_AliquotaDiferimento, " +
                                    "IGL_Antecipado, " +
                                    "IGL_Desonerado, " +
                                    "IGL_Isento, " +
                                    "IGL_AmparoLegal, " +
                                    "IGL_AliquotaIsencao) " +
                                    "Values " +
                                    "(@EmpresaID, " +
                                    "@FilialID, " +
                                    "@ProdutoGrupoID, " +
                                    "@ProdutoDerivadoID, " +
                                    "@UF, " +
                                    "@Cfop, " +
                                    "@CodigoCaracteristicaTributaria, " +
                                    "@Finalidade, " +
                                    "@CfopInterno, " +
                                    "@CfopInterestadual, " +
                                    "@Cst, " +
                                    "@Csosn, " +
                                    "@AliquotaInterna, " +
                                    "@AliquotaInterestadual, " +
                                    "@AliquotaReducao, " +
                                    "@AliquotaReducaoST, " +
                                    "@AliquotaST, " +
                                    "@AliquotaIVA, " +
                                    "@AliquotaFCP, " +
                                    "@CodBeneficio, " +
                                    "@AliquotaDiferimento, " +
                                    "@Antecipado, " +
                                    "@Desonerado, " +
                                    "@Isento, " +
                                    "@AmparoLegal, " +
                                    "@AliquotaIsencao);";

          
             _context.Connection.Execute(insertProdutoGrupoLista, lista);
        }

        public TributacaoCabecalho CarregarUltimoCabecalhoTributacaoProcessado(Int64 cenarioID)
        {
            return _context
                .Connection
                .QueryFirst<TributacaoCabecalho>(
                            "Select Top 1 " +
                                    "IMC_ID ID, " +
                                    "IMC_Empresa_ID EmpresaID, " +
                                    "IMC_Filial_ID FilialID, " +
                                    "IMC_Ambiente Ambiente, " +
                                    "IMC_CnpjCliente CnpjCliente, " +
                                    "IMC_DataHoraRetorno DataHoraRetorno, " +
                                    "IMC_NumeroProdutosEnviados NumeroProdutosEnviados, " +
                                    "IMC_NumeroProdutosRetornados NumeroProdutosRetornados, " +
                                    "IMC_NumeroProdutosNaoRetornados NumeroProdutosNaoRetornados, " +
                                    "IMC_NumeroTransacaoIMendes NumeroTransacaoIMendes, " +
                                    "IMC_MensagemServidor MensagemServidor, " +
                                    "IMC_CenarioTributario_ID CenarioTributarioID " +
                                    "From Tb_IMendes_TributacaoCabecalho " +
                                    "Where IMC_CenarioTributario_ID = " + cenarioID.ToString() + " " + 
                                    "Order By IMC_ID Desc",
                    commandType: CommandType.Text);
        }
    }
}
