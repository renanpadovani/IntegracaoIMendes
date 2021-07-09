using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoIMendes.Domain.Enums
{
    public enum ECaracteristicaTributaria
    {
        Industrial = 0,
        Distribuidor = 1,
        Atacadista = 2,
        Varejista = 3,
        ProdutorPessoaJuridica = 4,
        ProdutorPessoaFisica = 6,
        PessoaJuridicaNAOContribuinte = 7,
        PessoaFisicaNAOContribuinte = 8
    }
}
