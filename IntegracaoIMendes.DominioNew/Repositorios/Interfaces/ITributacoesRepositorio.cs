using IntegracaoIMendes.Dominio.Entidades.Infast;
using System;

namespace IntegracaoIMendes.Dominio.Repositorios.Interfaces
{
    public interface ITributacoesRepositorio
    {
        void IncluirTributacao(TributacaoCabecalho tribCab);

        Int64 IncluirTributacaoCabecalho(TributacaoCabecalho tribCab);

        Int64 IncluirTributacaoProdutoGrupo(TributacaoProdutoGrupo grupo);

        void IncluirTributacaoProdutoGrupoLista(TributacaoProdutoGrupoLista lista);

        TributacaoCabecalho CarregarUltimoCabecalhoTributacaoProcessado(Int64 cenarioID);
    }
}
