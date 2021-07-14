using IntegracaoIMendes.Dominio.Entidades.Infast;
using IntegracaoIMendes.Dominio.Enums;
using System;
using System.Collections.Generic;

namespace IntegracaoIMendes.Dominio.Servicos
{
    public class CalculoRequisicoesIMendesServico
    {
        public Int64 RetornarNumeroRequisicoesIMendesEstimadasParaProcessamentoCenario(int qtdProdutosPorRequisicao, 
                                                                                       List<Entidades.Infast.Produtos> listaProdutos, 
                                                                                       List<EFinalidade> listaFinalidades)
        {
            int qtdRequisicoes = 0;

            if (listaProdutos == null) return 0;

            if (listaFinalidades == null) return 0;

            if (listaProdutos.Count > 0)
            {
                foreach (EFinalidade finalidade in listaFinalidades)
                {
                    int contador = 0;
                    int origemMercadoria = listaProdutos[0].origemMercadoria;

                    foreach (Produtos produto in listaProdutos)
                    {
                        contador++;

                        if (origemMercadoria != produto.origemMercadoria || contador >= qtdProdutosPorRequisicao)
                        {
                            qtdRequisicoes++;
                            contador = 0;
                        }

                        origemMercadoria = produto.origemMercadoria;
                    }

                    if (contador > 0) qtdRequisicoes++;
                }
            }

            return qtdRequisicoes;
        }
    }
}
