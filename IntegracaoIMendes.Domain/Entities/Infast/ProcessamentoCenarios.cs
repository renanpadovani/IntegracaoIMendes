using IntegracaoIMendes.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoIMendes.Domain.Entities.Infast
{
    public class ProcessamentoCenarios
    {
        public Int64 ID { get; set; }
        public int EmpresaID { get; set; }
        public int FilialID{ get; set; }
        public DateTime Data { get; set; }
        public Int64 CenarioID { get; set; }
        public List<EFinalidade> Finalidades { get; set; }
        public List<ECaracteristicaTributaria> CaracteristicasTributarias { get; set; }
        public List<string> UFs { get; set; }
        public int QtdProdutos { get; set; }
        public int QtdOrigensProdutos { get; set; }
        public int QtdRequisicoesRealizadas { get; set; }
        public string Mensagem { get; set; }
    }
}
