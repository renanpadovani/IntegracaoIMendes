using IntegracaoIMendes.Dominio.Entidades.IMendes;
using IntegracaoIMendes.Dominio.Enums;
using System;
using System.Collections.Generic;

namespace IntegracaoIMendes.Testes.Servicos.Mocks
{
    public class TributosRequisicaoMocks
    {
        public TributosRequisicao RetornarInstanciaTributosRetornoValida()
        {
            TributosRequisicao tributosRequisicao = new TributosRequisicao();

            //Dados do emitente
            tributosRequisicao.emit.amb = (int)EAmbiente.Homologacao;
            tributosRequisicao.emit.cnpj = "08956337000189";
            tributosRequisicao.emit.crt = (int)ECodRegimeTributario.RegimeNormal;
            tributosRequisicao.emit.regimeTrib = "LR";
            tributosRequisicao.emit.uf = "SP";

            //Dados do destinatário
            List<int> caracteristicasTributarias = new List<int>();

            caracteristicasTributarias.Add(0);
            caracteristicasTributarias.Add(1);
            caracteristicasTributarias.Add(2);

            List<String> listaUFs = new List<string>();
            listaUFs.Add("SP");

            tributosRequisicao.perfil.uf = listaUFs;
            tributosRequisicao.perfil.cfop = "5102";
            tributosRequisicao.perfil.caracTrib = caracteristicasTributarias;
            tributosRequisicao.perfil.origem = "0";
            tributosRequisicao.perfil.finalidade = (int)EFinalidade.Revenda;

            tributosRequisicao.produtos.Add(new Produto { codigo = "1", codImendes = "", codInterno = "", descricao = "Produto Teste 1", ncm = "12345678" });
            tributosRequisicao.produtos.Add(new Produto { codigo = "2", codImendes = "", codInterno = "", descricao = "Produto Teste 2", ncm = "12345678" });

            return tributosRequisicao;
        }

        public TributosRequisicao RetornarInstanciaTributosRetornoInvalida()
        {
            TributosRequisicao tributosRequisicao = new TributosRequisicao();

            return tributosRequisicao;
        }
    }
}
