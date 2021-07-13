using IntegracaoIMendes.Dominio.Entidades.Infast;
using System;

namespace IntegracaoIMendes.Dominio.Repositorios.Interfaces
{
    public interface ITributacoesRepositorio
    {
        public void IncluirTributacao(TributacaoCabecalho tribCab);

        public Int64 IncluirTributacaoCabecalho(TributacaoCabecalho tribCab);

        public Int64 IncluirTributacaoProdutoGrupo(TributacaoProdutoGrupo grupo);

        public void IncluirTributacaoProdutoGrupoLista(TributacaoProdutoGrupoLista lista);

        public TributacaoCabecalho CarregarUltimoCabecalhoTributacaoProcessado(Int64 cenarioID);
    }
}
