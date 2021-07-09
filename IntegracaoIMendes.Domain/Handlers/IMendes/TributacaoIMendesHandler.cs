using IntegracaoIMendes.Domain.Entities.IMendes;
using IntegracaoIMendes.Domain.Entities.Infast;
using IntegracaoIMendes.Domain.Enums;
using IntegracaoIMendes.Domain.Services;
using System.Collections.Generic;

namespace IntegracaoIMendes.Domain.Handlers
{
    public class TributacaoIMendesHandler
    {
        private IMendesService _imendesService;
        private EAmbiente _ambiente;
        private string _cnpj;
        private string _uf;
        private ECodRegimeTributario _codRegimeTributario;
        private string _regimeTributario;

        public TributacaoIMendesHandler(
            string loginIMendes,
            string senhaIMendes,
            EAmbiente ambiente,
            string cnpj,
            string uf,
            ECodRegimeTributario codigoRegimeTributario,
            string regimeTributario)
        {
            _ambiente = ambiente;
            _cnpj = cnpj;
            _uf = uf;
            _codRegimeTributario = codigoRegimeTributario;
            _regimeTributario = regimeTributario;

            _imendesService = new IMendesService(loginIMendes, senhaIMendes);
        }

        public TributosRetorno PesquisarTributos(EFinalidade finalidade, List<ECaracteristicaTributaria> listaCaracteristicasTributarias, string cfop, List<string> ufs, int origemMercadoria, IEnumerable<Produtos> listaProdutos)
        {
            Entities.IMendes.TributosRequisicao tributosRequisicao = new Entities.IMendes.TributosRequisicao();

            //Dados do emitente
            tributosRequisicao.emit.amb = (int)_ambiente;
            tributosRequisicao.emit.cnpj = _cnpj;
            tributosRequisicao.emit.crt = (int)_codRegimeTributario;
            tributosRequisicao.emit.regimeTrib = _regimeTributario.ToString();
            tributosRequisicao.emit.uf = _uf;

            //Dados do destinatário
            List<int> caracteristicasTributarias = new List<int>();

            foreach (int caracteristica in listaCaracteristicasTributarias)
                caracteristicasTributarias.Add(caracteristica);

            tributosRequisicao.perfil.uf = ufs;
            tributosRequisicao.perfil.cfop = cfop;
            tributosRequisicao.perfil.caracTrib = caracteristicasTributarias;
            tributosRequisicao.perfil.origem = origemMercadoria.ToString();
            tributosRequisicao.perfil.finalidade = (int)finalidade;
       
            //Dados dos produtos
            foreach (Produtos prod in listaProdutos)
            {
                Produto produto = new Produto();

                produto.codigo = prod.codigo;
                produto.codInterno = prod.codInterno;
                produto.codImendes = prod.codImendes;
                produto.descricao = prod.descricao ;
                produto.ncm = prod.ncm;

                tributosRequisicao.produtos.Add(produto);
            }

            //Realiza a consulta no IMendes
            return _imendesService.PesquisarTributos(tributosRequisicao);
        }
    }
}
