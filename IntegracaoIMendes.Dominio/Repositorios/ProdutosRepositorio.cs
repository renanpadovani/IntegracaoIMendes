using System.Collections.Generic;
using System.Data;
using Dapper;
using IntegracaoIMendes.Dominio.Entidades.Infast;
using System;
using IntegracaoIMendes.Dominio.Repositorios.Interfaces;

namespace IntegracaoIMendes.Dominio.Repositorios
{
    public class ProdutosRepositorio : IProdutosRepositorio
    {
        private readonly ContextoDados.InfastContextoDados _contexto;
        public ProdutosRepositorio(ContextoDados.InfastContextoDados contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Produtos> PesquisarProdutos(Int64 produtoId = 0, string tipoClassificacao = "")
        {
            return _contexto
                .Connection
                .Query<Produtos>(
                    "Select " +
                    "Prd_Empresa_ID empresaID, " +
                    "Prd_Filial_ID filialID, " +
                    "Prd_ID produtoID, " +
                    "Right('00000000000000' + CONVERT(NVARCHAR, RTRIM(LTRIM(PRD_EAN))), 14) AS codigo, " +
                    "IIF(Prd_TipoCodigo = 'INTERNO', 'S', 'N') codInterno, " +
                    "Prd_DescCompleta descricao, " +
                    "PRD_CodIMendes codImendes, " +
                    "Prd_MediaNcmNcm ncm, " +
                    "Prd_OrigemMercadoriaNFe origemMercadoria " +
                    "From Tb_ProdutoDerivado " +
                    "Where PRD_IntegraIMendes = 1 " +
                    "And Prd_Inativo = 0 " +
                    (tipoClassificacao.Length > 0 ? "And Prd_TipoProduto = '" + tipoClassificacao + "' " : "") +
                    (produtoId != 0 ? "And Prd_ID = " + produtoId.ToString() + " " : "") +
                    "Order By Prd_OrigemMercadoriaNFe, Prd_EAN Asc",
                commandType: CommandType.Text); 
        }
    }
}


