using System;
using System.Collections.Generic;

namespace IntegracaoIMendes.Dominio.Entidades.Infast
{
    public class TributacaoCabecalho
    {
        public TributacaoCabecalho()
        {
            grupos = new List<TributacaoProdutoGrupo>();
            semRetorno = new List<TributacaoProdutoSemRetorno>();
        }

        public Int64 ID { get; set; }
        public int EmpresaID { get; set; }
        public int FilialID { get; set; }
        public Int64 CenarioTributarioID { get; set; }
        public string Ambiente { get; set; }
        public string CnpjCliente { get; set; }
        public DateTime DataHoraRetorno { get; set; }
        public Int64 NumeroProdutosEnviados { get; set; }
        public Int64 NumeroProdutosRetornados { get; set; }
        public Int64 NumeroProdutosNaoRetornados { get; set; }
        public Int64 NumeroTransacaoIMendes { get; set; }
        public string MensagemServidor { get; set; }
        public List<TributacaoProdutoGrupo> grupos { get; set; }
        public List<TributacaoProdutoSemRetorno> semRetorno { get; set; }
    }
}
