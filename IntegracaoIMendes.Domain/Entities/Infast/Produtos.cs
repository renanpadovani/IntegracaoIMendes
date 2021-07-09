using System;

namespace IntegracaoIMendes.Domain.Entities.Infast
{
    public class Produtos
    {
        public int empresaID { get; set; }
        public int filialID { get; set; }
        public Int64 produtoID { get; set; }
        public string codigo { get; set; }
        public string codInterno { get; set; }
        public string descricao { get; set; }
        public string codImendes { get; set; }
        public string ncm { get; set; }
        public int origemMercadoria { get; set; }
    }
}
