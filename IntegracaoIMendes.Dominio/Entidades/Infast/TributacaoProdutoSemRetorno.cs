using System;

namespace IntegracaoIMendes.Dominio.Entidades.Infast
{
    public class TributacaoProdutoSemRetorno
    {
        public Int64 ID { get; set; }
        public int EmpresaID { get; set; }
        public int FilialID { get; set; }
        public Int64 CenarioTributarioID { get; set; }
        public Int64 ProdutoDerivadoID { get; set; }
        public string CodigoProdutoUtilizado { get; set; }
    }
}
