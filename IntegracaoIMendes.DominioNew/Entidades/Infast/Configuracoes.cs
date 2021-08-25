using IntegracaoIMendes.Dominio.Enums;
using System;

namespace IntegracaoIMendes.Dominio.Entidades.Infast
{
    public class Configuracoes
    {
        public Int64 ID { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public EAmbiente Ambiente { get; set; }
        public string CnpjCliente { get; set; }
        public int QtdProdutosPorRequisicao { get; set; }
        public int QtdUFsporRequisicao { get; set; }
        public int QtdCaracteristicasTributariasPorRequisicao { get; set; }
        public int QtdRequisicoesDiarias { get; set; }
    }
}
